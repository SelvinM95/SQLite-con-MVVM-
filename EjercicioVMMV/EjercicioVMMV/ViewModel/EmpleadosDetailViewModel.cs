using EjercicioVMMV.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EjercicioVMMV.ViewModel
{
    public class EmpleadosDetailViewModel
    {
        private readonly IEmpleadoStore _empleadoStore;
        private readonly IPageService _pageService;

        public Empleados Empleados { get; private set; }

        public ICommand SaveCommand { get; private set; }

        public EmpleadosDetailViewModel(EmpleadoViewModel viewModel, IEmpleadoStore empleadoStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _empleadoStore = empleadoStore;

            SaveCommand = new Command(async () => await Save());

            Empleados = new Empleados
            {
                Id = viewModel.Id,
                Nombre = viewModel.Nombre,
                Apellido = viewModel.Apellido,
                Edad = viewModel.Edad,
                Direccion = viewModel.Direccion,
                Puesto = viewModel.Puesto,
            };
        }

        async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Empleados.Nombre) && String.IsNullOrWhiteSpace(Empleados.Apellido))
            {
                await _pageService.DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }
            if (Empleados.Id == 0)
            {
                await _empleadoStore.AddEmpleados(Empleados);
                MessagingCenter.Send(this, Events.EmpleadosAdded, Empleados);
            }
            else
            {
                await _empleadoStore.UpdateEmpleados(Empleados);
                MessagingCenter.Send(this, Events.EmpleadosUpdated, Empleados);
            }
            await _pageService.PopAsync();
        }
    }
}
