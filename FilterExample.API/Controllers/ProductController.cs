using FilterExample.API.Filters;
using FilterExample.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilterExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
      
        [HttpGet("[action]/{id}")]
        [ServiceFilter(typeof(ProductIDfilter))]
        public IActionResult Api(int id)
        {
            List<Product> products = ProductUret.ProductUrets();
            List<Product> product=products.Where(p=>p.ID==id).ToList();
            return new DTos<List<Product>>.Response().ResponseData(DTos<List<Product>>.Success(200,product));
        }
    }
}
