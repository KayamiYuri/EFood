using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models.EF;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly FoodContext _dbContext;
        public ProductController(FoodContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetIsComming()
        { 
            var items = from p in _dbContext.Products
                        where p.IsComming == true
                        orderby p.CreatedBy descending
                        select p;
            return Ok(await items.Take(4).Select(i => new {i.Id, i.Picture, i.Title, i.Intro }).ToListAsync());
        }
    }
}
