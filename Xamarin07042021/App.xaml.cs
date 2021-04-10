using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin07042021.Services;
using Xamarin07042021.Views;

namespace Xamarin07042021
{
    public partial class App : Application
    {

        //2- resivir como argumento la ruta de la base de datos y pasarlo como variable statica, en la linea 15 lo recibimos en el
        //contructor y en la linea 21 lo asignamos a la variable
        public static string rutaDB;

        public App(string ruta_db)
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();

            rutaDB = ruta_db;

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
