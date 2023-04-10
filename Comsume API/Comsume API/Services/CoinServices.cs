using Comsume_API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text.Json.Nodes;

namespace Comsume_API.Services
{
    public class CoinServices
    {
        private readonly string _api = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd";
        private readonly string _apiList = "https://api.coingecko.com/api/v3/coins/list";
        private readonly string _apiCategory = " https://api.coingecko.com/api/v3/coins/categories/list ";
        public CoinServices() { }   
        public async Task<string> allCoin(string id,string category_id)
        {
            string url = _api;
            if (string.IsNullOrEmpty(category_id) == false && string.IsNullOrEmpty(id)==true)
            {
            
                url +="&category="+category_id;
            }
            else if (string.IsNullOrEmpty(category_id)==true  && string.IsNullOrEmpty(id)==false)
            {
                url += "&ids=" + id;
            }
            else if (string.IsNullOrEmpty(category_id) == false && string.IsNullOrEmpty(id) == false)
            {
                url += "&category=" + category_id + "&ids=" + id;
            }
            Debug.WriteLine("id: " + id + " category: " + category_id);
            Debug.WriteLine(url);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(url);
            HttpResponseMessage data = httpClient.GetAsync(url).Result;
           string result = data.IsSuccessStatusCode ?await  data.Content.ReadAsStringAsync() : null;
          
            return result;
        }
    
        public async Task<string> Category()
        {
            HttpClient httpClient= new HttpClient();
            httpClient.BaseAddress = new Uri(_apiCategory);
            HttpResponseMessage data= httpClient.GetAsync(_apiCategory).Result;
            string result = data.IsSuccessStatusCode ?await data.Content.ReadAsStringAsync() : null;

            return result;
        }
        public async Task<string> ListCoin()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_apiList);
            HttpResponseMessage data = httpClient.GetAsync(_apiList).Result;
            string result = data.IsSuccessStatusCode ? await data.Content.ReadAsStringAsync() : null;

            return result;
        }
    }
}
