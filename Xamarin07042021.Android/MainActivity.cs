using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using System.IO;
using Google.Android.Material.Snackbar;

namespace Xamarin07042021.Droid
{
    [Activity(Label = "Xamarin07042021", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            string NombreBD = "DBXamarin.sqlite";
            string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
            string rutaDB = Path.Combine(ruta, NombreBD);

            LoadApplication(new App(rutaDB));
        }
       
        /*public async Task TryGetLocationAsync()
        {
            if ((int)Build.VERSION.SdkInt < 23)
            {

                return;
            }

            await GetLocationPermissionAsync();
        }*/
        readonly string[] PermissionsLocation =
        {

          Android.Manifest.Permission.WriteExternalStorage,

           //Android.Manifest.Permission.Camera,
           Android.Manifest.Permission.ReadExternalStorage,
           //Android.Manifest.Permission.WriteCalendar,
           //Android.Manifest.Permission.ReadCalendar,
           //Android.Manifest.Permission.AccessCoarseLocation,
           //Android.Manifest.Permission.AccessFineLocation,
           //Android.Manifest.Permission.AccessMockLocation,
           //Android.Manifest.Permission.AccessNetworkState

        };

        const int RequestLocationId = 0;

        /*private async Task GetLocationPermissionAsync()
        {

            const string permission = Android.Manifest.Permission.AccessFineLocation;
            if (CheckSelfPermission(permission) == (int)Permission.Granted)
            {

                return;
            }

            if (ShouldShowRequestPermissionRationale(permission))
            {

                var layout = Window.DecorView.FindViewById(Android.Resource.Id.Content);
                //Explain to the user why we need to read the contacts
                Snackbar.Make(layout, "Se requiere habilitar permisos.", Snackbar.LengthIndefinite)
                        .SetAction("OK", v => RequestPermissions(PermissionsLocation, RequestLocationId))
                        .Show();
                return;
            }


            RequestPermissions(PermissionsLocation, RequestLocationId);
        }*/

        public override async void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            var layout = Window.DecorView.FindViewById(Android.Resource.Id.Content);
            switch (requestCode)
            {
                case RequestLocationId:
                    {
                        if (grantResults[0] == Permission.Granted)
                        {
                            //Permission granted
                            var snack = Snackbar.Make(layout, "Los permiso de almacenamiento y GPS están disponible.", Snackbar.LengthShort);
                            snack.Show();

                            //await GetLocationAsync();
                        }
                        else
                        {
                            //Permission Denied :(
                            //Disabling location functionality
                            var snack = Snackbar.Make(layout, "Los Permisos no se habilitarion.", Snackbar.LengthShort);
                            snack.Show();
                        }
                    }
                    break;
            }
        }
    }
}