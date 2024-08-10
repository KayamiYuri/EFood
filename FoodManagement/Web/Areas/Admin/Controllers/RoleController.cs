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
    public class RoleController : Controller
    {
        private readonly FoodContext _dbContext;

        public RoleController(FoodContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllByCategory(Guid CategoryId)
        {
            var items = await (from r in _dbContext.Roles
                               join a in _dbContext.Authorizeds
                               on r.Id equals a.RoleId into g
                               from a in g.DefaultIfEmpty()
                               where r.CategoryId == CategoryId
                               select new
                               {
                                   r.Id,
                                   r.Name,
                                   a.GroupId
                               }).ToListAsync();
            return Ok(items);
        }
    }
}
