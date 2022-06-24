using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using TranslatorApp.Models;

namespace TranslatorApp.Services
{
    public class ApiServices
    {
        HttpClient client;
        public ApiServices()
        {            
            client = new HttpClient();
        }

        public async Task<string> getTranslation(string word)
        {
            Root root = new Root();

            if(Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                string url = $"https://api.mymemory.translated.net/get?q={word}!&langpair=en|it";
                var response = await client.GetAsync(url); 

                if(response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    root = JsonConvert.DeserializeObject<Root>(json);
                }
            }
            return root.responseData.translatedText;
        }

    }
}
