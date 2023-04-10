using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_API.Model;

namespace Product_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly DatabaseContext _databaseContext;
        public StudentController( DatabaseContext databaseContext) { 
        this._databaseContext = databaseContext;
        }
        [HttpGet("GetList")]
        public IActionResult GetList([FromQuery] Product? data) {

            if (string.IsNullOrEmpty(data.Name)==false || string.IsNullOrEmpty(data.Unit)==false || data.Price!=0 || data.Amount!=0)
            {
                var model = _databaseContext.Products.Where(m =>
                (m.Name.ToLower().Contains(data.Name.ToLower()) || data.Name=="")
                && (m.Price == data.Price || data.Price == 0)
                && (m.Amount == data.Amount || data.Amount == 0)
                && (m.Unit == data.Unit || data.Unit == "")
                ).ToList();
                return Ok(model);
            }
            return Ok(_databaseContext.Products.ToList());
        }
        [HttpGet("Detail/{id}")]
        public IActionResult GetDetail(int id) {
        var model = _databaseContext.Products.Find( id);
            return model== null ? NotFound() : Ok(model);

        }
      
        [HttpPost("Create")]
        public IActionResult Create( [FromQuery] Product model) {
        _databaseContext.Products.Add(model);
            int rowEff = _databaseContext.SaveChanges();
            return rowEff > 0 ? Ok(" Add " + model.Name+ " Success") : BadRequest("Error");

        }
        [HttpPut("Edit")]
        public IActionResult Update(Product model)
        {
            _databaseContext.Products.Update(model);
            int rowEff = _databaseContext.SaveChanges();
            return rowEff > 0 ? Ok(" Edit " + model.Name + " Success") : BadRequest("Error");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {

            var model = _databaseContext.Products.Find(id);
            _databaseContext.Remove(model);
            int rowEff= _databaseContext.SaveChanges();
            return rowEff>0 ? Ok($"Delete {model.Name} Success") : BadRequest("Error");
        }
    }
}
