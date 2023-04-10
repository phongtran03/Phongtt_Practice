using MaiHuyHoat_Practice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaiHuyHoat_Practice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        protected readonly DbFirstContext _dbFirstContext;
        protected readonly ILogger<ProductsController> _logger;
        public ProductsController(DbFirstContext dbFirstContext)
        {
            _dbFirstContext = dbFirstContext;
        }
        [HttpGet]
        public IActionResult getList([FromQuery] Product? model)
        {
            var result = _dbFirstContext.Products.Where(p =>
               (p.Name.ToLower().Contains(model.Name.ToLower()) || model.Name == "")
               && (p.Price == model.Price || model.Price == 0)
               && (p.Amount == model.Amount || model.Amount == 0)
               && (p.Description.ToLower().Contains(model.Description.ToLower()) || model.Description == "")
           );
            return Ok(result);
        }
        [HttpGet("id:long")]
        public IActionResult getDetail(long id)
        {
            var products = _dbFirstContext.Products.Find(id);
            return products == null ? NotFound("No Product with this id") : Ok(products);
        }
        [HttpPost]
        public IActionResult create([FromQuery] Product product)
        {
            if (product == null)
            {
                return BadRequest("Error : The Product is null");
            }
            _dbFirstContext.Products.Add(product);
            _dbFirstContext.SaveChanges();
            return Ok($"Add: {product}");
        }
        [HttpPut("id:long")]
        public IActionResult update(long id, [FromBody] Product product)
        {
            if (id != product.Id) { return BadRequest("ID Insert and ID The Product are not same"); }
            _dbFirstContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            try
            {
                _dbFirstContext.SaveChanges();
                return Ok("Save" + product.Id);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error: " + ex);
            }
            return BadRequest("Error ");
        }
        [HttpDelete("id: long")]
        public IActionResult delete(long id)
        {
            var model = _dbFirstContext.Products.Find(id);
            if (model == null) return NotFound($" Not Found the product id={id}");
            _dbFirstContext.Products.Remove(model);
            return Ok($"Deleted {model.Name}");
        }
    }
}
