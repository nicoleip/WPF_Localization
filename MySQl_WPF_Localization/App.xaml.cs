using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MySQL_WPF_Localization;
using EZLocalizeNS;

namespace MySQL_WPF_Localization
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static EZLocalizeNS.EZLocalize MyEZLocalize = null;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MyEZLocalize = new EZLocalize(App.Current.Resources, "en", null, "Languages\\", "InterfaceStrings");
        }
    }
}
