using EjercicioVMMV.Persistence;
using EjercicioVMMV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EjercicioVMMV.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmpleadosPage : ContentPage
    {
        public EmpleadosPage()
        {
            var empleadoStore = new SQLiteEmpleadoStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new EmpleadosPageViewModel(empleadoStore, pageService);

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }

        void OnEmpleadosSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectEmpleadosCommand.Execute(e.SelectedItem);
        }
        public EmpleadosPageViewModel ViewModel
        {
            get { return BindingContext as EmpleadosPageViewModel; }
            set { BindingContext = value; }
        }
    }
}