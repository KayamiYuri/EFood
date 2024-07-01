using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Areas.Admin.Models;
using Web.Models.EF;
using System.Linq.Dynamic.Core;
using Core.Database.Models;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GroupController : Controller
    {
        private readonly FoodContext _dbContext;

        public GroupController(FoodContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> getList(JDatatable model)
        {
            var items = (from i in _dbContext.Groups select i);
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
        //Lay danh sach group de hien thi tren combobox trong member
        [HttpGet]
        public async Task<IActionResult> getList()
        {

            var items = (from i in _dbContext.Groups select i);
            var data = await items.Select(i => new { i.Id, i.Name }).ToListAsync();
            return Ok(data); 
        }
         [HttpGet]
        public async Task<IActionResult> getItem(Guid id)
        {
            if (_dbContext.Groups == null)
                return NotFound();
            var item = await _dbContext.Groups.FindAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> Save(GroupViewModel model)
        {
            Group item;
            if (model.Id == null)
            {
                item = new Core.Database.Models.Group();
                item.Id = Guid.NewGuid();
                await _dbContext.Groups.AddAsync(item);
            }
            else
            {
                item = await _dbContext.Groups.FindAsync(model.Id);
            }
            item.Name = model.Name;
            await _dbContext.SaveChangesAsync();
            return Ok(item);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var memberInGroup = await _dbContext.Members.Where(m => m.GroupId == id).FirstOrDefaultAsync();
            if (memberInGroup == null)
            {
                var item = await _dbContext.Groups.FindAsync(id);
                _dbContext.Entry(item).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
                return Ok(true);
            }
            return Ok(false);
        }
    }
}