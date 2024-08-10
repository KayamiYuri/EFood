using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Areas.Admin.Models;
using Web.Models.EF;
using System.Linq.Dynamic.Core;
using Core.Database.Models;
using Web.Areas.Admin.Attributes;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly FoodContext _dbContext;

        public CategoryController(FoodContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        //Lay danh sach category de hien thi tren combobox trong category
        [HttpGet]
        public async Task<IActionResult> GetChild(Guid parentId)
        {
            var items = from i in _dbContext.Categories where i.ParentId == parentId select i;
            var data = await items.Select(i => new { i.Id, i.Name }).ToListAsync();
            return Ok(data);
        }
    }
}
