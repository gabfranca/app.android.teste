using Android.App;
using Android.Widget;
using Android.OS;
using android.api.teste;
using System.Collections.Generic;

namespace app.android.teste
{
    [Activity(Label = "app.android.teste", MainLauncher = true)]
    public class MainActivity : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            ListView table = FindViewById<ListView>(Resource.Id.listView1);
            Button btnGet = FindViewById<Button>(Resource.Id.btnGetApi);

            btnGet.Click += async delegate
            {
                try
                {
                    List<DadosTeste> dados = await new WebApiRequest().Get("");
                    string[] itens = new string[dados.Count];
                    int i = 0;
                    foreach (var item in dados)
                    {
                        itens[i] = item.CompanyName;
                        i++;
                    }
                    var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1,
                    Android.Resource.Id.Text1, itens);
                    table.SetAdapter(adapter);

                }
                catch (System.Exception e)
                {
                    Toast.MakeText(this, e.Message, ToastLength.Long).Show();
                    throw;
                }

            };
           

        }
    }
}

