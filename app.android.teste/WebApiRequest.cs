using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using android.api.teste;

namespace app.android.teste
{
    class WebApiRequest
    {
        public String Url = @"http://192.168.1.105:1010/api";
        private  HttpClient client = new HttpClient();
        public string resposta = string.Empty;


        public async Task<List<DadosTeste>>Get(string caminho)
        {
            HttpResponseMessage response = null;
            response = await client.GetAsync(new Uri(Url+"/dadosteste"));

            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            List<DadosTeste> dadosJson = JsonConvert.DeserializeObject<List<DadosTeste>>(responseBody);
            return dadosJson;
        }

      

        public async Task<DadosTeste> PostDadoTesteAsync(DadosTeste dadoteste)
        {
     
            try
            {
                var uri = new Uri(string.Format(Url + "/Login"));
                string data = JsonConvert.SerializeObject(dadoteste);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception(errorMessage);
                }
                string responseBody = await response.Content.ReadAsStringAsync();
                DadosTeste sessionJson = JsonConvert.DeserializeObject<DadosTeste>(responseBody);
                return sessionJson;   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
