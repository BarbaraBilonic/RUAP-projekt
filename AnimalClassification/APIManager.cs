using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Classification
{
    class APIManager
    {
        private static APIManager instance;
        private HttpClient client;
        private string Uri = "https://ussouthcentral.services.azureml.net/workspaces/08e5ab1e56a94658a67241a8d4ec9e93/services/ec3cd8887c514cd69ff1ea66d1e15253/execute?api-version=2.0&details=true";
        private string Apikey = "QXhMCc4bV5HrbcbIxNO5mIKRB1mvsmIYWPJTyVL6iKomMxthxnRPpvbVjmg0YHcdZGpBDaugc+frxEykAFIDXw==";
        private string[] columnNames = new string[] { "animal name", "hair", "feathers", "eggs", "milk", "airborne", "aquatic", "predator", "toothed", "backbone", "breathes", "venomous", "fins", "legs", "tail", "domestic", "catsize" };


        APIManager()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Apikey);
            client.BaseAddress = new Uri(Uri);
            


        }

        public static APIManager getInstance()
        {

            if (instance == null)
            {
                instance = new APIManager();

            }
            return instance;

        }

        public async Task<string> InvokeRequestResponseService(List<List<string>> values)
        {

            var scoreRequest = new
            {

                Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames =columnNames ,
                                Values=values,
                            }
                        },
                    },
                GlobalParameters = new Dictionary<string, string>()
                {
                }
            };

            using (HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest).ConfigureAwait(false))
            {



                if (response.IsSuccessStatusCode)
                {
                    string type = await response.Content.ReadAsStringAsync();
                    return type;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
