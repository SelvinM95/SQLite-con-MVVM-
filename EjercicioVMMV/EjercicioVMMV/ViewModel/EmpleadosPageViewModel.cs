using EjercicioVMMV.Model;
using EjercicioVMMV.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EjercicioVMMV.ViewModel
{
    public class EmpleadosPageViewModel : BaseViewModel
    {
        private EmpleadoViewModel _selectedEmpleados;
        private IEmpleadoStore _empleadoStore;
        private IPageService _pageService;

        private bool _isDataLoaded;

        public ObservableCollection<EmpleadoViewModel> Empleados { get; private set; }
            = new ObservableCollection<EmpleadoViewModel>();

        public EmpleadoViewModel SelectedEmpleados
        {
            get { return _selectedEmpleados; }
            set { SetValue(ref _selectedEmpleados, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddEmpleadosCommand { get; private set; }
        public ICommand SelectEmpleadosCommand { get; private set; }
        public ICommand DeleteEmpleadosCommand { get; private set; } 

        public EmpleadosPageViewModel(IEmpleadoStore empleadoStore, IPageService pageService)
        {
            _empleadoStore = empleadoStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddEmpleadosCommand = new Command(async () => await AddEmpleados());
            SelectEmpleadosCommand = new Command<EmpleadoViewModel>(async c => await SelectEmpleados(c));
            DeleteEmpleadosCommand = new Command<EmpleadoViewModel>(async c => await DeleteEmpleados(c));

            MessagingCenter.Subscribe<EmpleadosDetailViewModel, Empleados>
               (this, Events.EmpleadosAdded, OnEmpleadosAdded);

            MessagingCenter.Subscribe<EmpleadosDetailViewModel, Empleados>
            (this, Events.EmpleadosUpdated, OnEmpleadosUpdated);
        }

        private void OnEmpleadosAdded(EmpleadosDetailViewModel source, Empleados empleados)
        {
            Empleados.Add(new EmpleadoViewModel(empleados));
        }

        private void OnEmpleadosUpdated(EmpleadosDetailViewModel source, Empleados empleados)
        {
            var empleadosInList = Empleados.Single(c => c.Id == empleados.Id);

            empleadosInList.Id = empleados.Id;
            empleadosInList.Nombre = empleados.Nombre;
            empleadosInList.Apellido = empleados.Apellido;
            empleadosInList.Edad = empleados.Edad;
            empleadosInList.Direccion = empleados.Direccion;
            empleadosInList.Puesto = empleados.Puesto;
        }


        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;
            var emplead = await _empleadoStore.GetEmpleadosAsync();
            foreach (var empleados in emplead)
                Empleados.Add(new EmpleadoViewModel(empleados));
        }

        private async Task AddEmpleados()
        {
            await _pageService.PushAsync(new EmpleadosDetailsPage(new EmpleadoViewModel()));
        }

        private async Task SelectEmpleados(EmpleadoViewModel employee)
        {
            if (employee == null)
                return;

            SelectedEmpleados = null;
            await _pageService.PushAsync(new EmpleadosDetailsPage(employee));
        }

        private async Task DeleteEmpleados(EmpleadoViewModel empleadoViewModel)
        {
            if (await _pageService.DisplayAlert("Warning", $"Quieres Eliminar el Empleado: {empleadoViewModel.FullName}?", "Yes", "No"))
            {
                Empleados.Remove(empleadoViewModel);

                var employee = await _empleadoStore.GetEmpleados(empleadoViewModel.Id);
                await _empleadoStore.DeleteEmpleados(employee);
            }
        }
    }
}
