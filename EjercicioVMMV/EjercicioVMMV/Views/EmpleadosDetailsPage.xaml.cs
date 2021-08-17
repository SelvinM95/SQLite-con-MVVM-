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
    public partial class EmpleadosDetailsPage : ContentPage
    {
        public EmpleadosDetailsPage(EmpleadoViewModel viewModel)
        {
            InitializeComponent();
            var empleadoStore = new SQLiteEmpleadoStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            Title = (viewModel.Nombre == null) ? "New Contact" : "Edit Contact";
            BindingContext = new EmpleadosDetailViewModel(viewModel ?? new EmpleadoViewModel(), empleadoStore, pageService);
        }
    }
}