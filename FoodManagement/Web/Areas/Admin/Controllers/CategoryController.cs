using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Areas.Admin.Models;
using Web.Models.EF;
using System.Linq.Dynamic.Core;
using System.Data;

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
        public IActionResult Index(Guid? parentId)
        {
            return View(parentId);
        }
        [HttpPost]
        public async Task<IActionResult> getList(JDatatable model, Guid? parentId)
        {
            if (parentId == Guid.Empty)
                parentId = null;
            var items = (from i in _dbContext.Categories where i.ParentId == parentId select i);
            int recordsTotal = 0;
            if (!string.IsNullOrEmpty(model.columns[model.order[0].column].name) && !string.IsNullOrEmpty(model.order[0].dir))
            {
                items = items.OrderBy(model.columns[model.order[0].column].name + ' ' + model.order[0].dir);
            }
            if (!string.IsNullOrEmpty(model.search.value))
            {
                items = items.Where(i => i.Name.Contains(model.search.value));
            }
            recordsTotal = items.Count();
            var data = await items.Select(i => new
            {
                i.Id,
                i.Name
            }).Skip(model.start).Take(model.length).ToListAsync();
            var jsonData = new { draw = model.draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
            return Ok(jsonData);
        }
        [HttpGet]
        public async Task<IActionResult> getItem(Guid id)
        {
            if (_dbContext.Categories == null)
                return NotFound();
            var item = await _dbContext.Categories.FindAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> Save(CategoryViewModel model)
        {
            Core.Database.Models.Category item;
            if (model.Id == null)
            {
                item = new Core.Database.Models.Category();
                item.Id = Guid.NewGuid();
                await _dbContext.Categories.AddAsync(item);
            }
            else
            {
                item = await _dbContext.Categories.FindAsync(model.Id);
            }
            item.Name = model.Name;
            if (model.ParentId == Guid.Empty)
                model.ParentId = null;
            item.ParentId = model.ParentId;
            await _dbContext.SaveChangesAsync();
            return Ok(item);
        }
        [HttpGet]
        public async Task<IActionResult> GetChild(Guid parentId)
        {
            var items = from i in _dbContext.Categories where i.ParentId == parentId select i;
            var data = await items.Select(i => new { i.Id, i.Name }).ToListAsync();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var categoryInProduct = await _dbContext.Products.Where(m => m.CategoryId == id).FirstOrDefaultAsync();
            if (categoryInProduct != null) { return Ok(false); }
            var categoryInRole = await _dbContext.Roles.Where(m => m.CategoryId == id).FirstOrDefaultAsync();
            if (categoryInRole != null) { return Ok(false); }
            var item = await _dbContext.Categories.FindAsync(id);
            _dbContext.Entry(item).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return Ok(true);
        }
    }
}
