using Comsume_API.Services;
using Microsoft.EntityFrameworkCore;

namespace Comsume_API.Models
{
    public class DataBaseContext: DbContext
    {
        private readonly string _api = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd";
        public DataBaseContext (DbContextOptions<DataBaseContext> options): base(options) { }   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
           HttpClient httpClient= new HttpClient();
            httpClient.BaseAddress = new Uri(_api);
            var data=httpClient.GetAsync(_api).Result;
            var result=data.IsSuccessStatusCode? data.Content.ToString() : null;    
         
        }
        DbSet<Coin> Coins { get; set; }
        DbSet<CategoryModel> Categorys { get; set; } 
        DbSet<ListCoinModel> ListCoins { get; set; }
    }
}
