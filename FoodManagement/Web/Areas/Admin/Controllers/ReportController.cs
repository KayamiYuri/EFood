using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models.EF;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : Controller
    {
        private readonly FoodContext _dbContext;
        public ReportController(FoodContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult IncomeByMonth()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> getIncomeByMonth(int year)
        {
            var items = from k in (from o in _dbContext.Orders.Where(i => i.CreatedOn.Value.Year == year && i.UpdatedOn != null)
                                   join d in _dbContext.Details on o.Id equals d.OrderId
                                   select new
                                   {
                                       Month = o.CreatedOn.Value.Month,
                                       Income = d.Amount * d.Price * 1.1 + 30000
                                   })
                        group k by k.Month into g
                        select new
                        {
                            Months = g.Key,
                            Incomes = g.Sum(p => p.Income)
                        };
            return Ok(await items.OrderBy(p => p.Months).ToListAsync());
        }

    }
}
