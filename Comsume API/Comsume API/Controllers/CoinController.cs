using Comsume_API.Models;
using Comsume_API.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Comsume_API.Controllers
{
    public class CoinController : Controller
    {
        public readonly CoinServices _CoinServices;

        public async Task<IActionResult> Index()
        {
            CoinServices coinServices = new CoinServices();
            string allCoin = await coinServices.allCoin(Request.Query["id"]!, Request.Query["category_id"]!);

            try {

                var model = JsonConvert.DeserializeObject<List<Coin>>(allCoin);
                // Category
                string strCategory = await coinServices.Category();
                ViewBag.Category = JsonConvert.DeserializeObject<List<CategoryModel>>(strCategory);
                // listCoin
                string strListCoin = await coinServices.ListCoin();
                ViewBag.ListCoin = JsonConvert.DeserializeObject<List<ListCoinModel>>(strListCoin);
                return View(model);

            }
            catch(Exception ex) {

                return RedirectToAction(nameof(LimitAccess));
            }     
            
        }
        public IActionResult LimitAccess()
        {
            return View();
        }
        
    }
}
