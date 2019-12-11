using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CIT255_KT_list_builder.Models;
using CIT255_KT_list_builder.BusinessLayer;
using CIT255_KT_list_builder.PresentationLayer.ViewModels;
using CIT255_KT_list_builder.PresentationLayer.Views;

namespace CIT255_KT_list_builder
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            KTBusiness ktBusiness = new KTBusiness();
            KTViewModel mainWindowViewModel = new KTViewModel(ktBusiness);

            KTBuilderWindow appWindow = new KTBuilderWindow();
            appWindow.DataContext = mainWindowViewModel;
            appWindow.Show();
        }
    }
}
