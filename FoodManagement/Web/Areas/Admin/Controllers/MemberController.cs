using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Areas.Admin.Models;
using Web.Models.EF;
using System.Linq.Dynamic.Core;
using Core.Database.Models;
using System;
using System.Security.Cryptography;
using System.Text;
using Web.Areas.Admin.Extensions;
using Microsoft.AspNetCore.Authorization;
using Web.Areas.Admin.Attributes;


namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MemberController : Controller
    {
        private readonly FoodContext _dbContext;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _environment;

        public MemberController(FoodContext dbContext, Microsoft.AspNetCore.Hosting.IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        //public MemberController(FoodContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        [Authorized(Code = "view-members")]
        [HttpPost]
        public async Task<IActionResult> getList(JDatatable model)
        {
            var items = (from i in _dbContext.Members select i);
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
                i.Name,
                groupName = i.Group.Name,
                i.LastLogin,
                i.Picture
            }).Skip(model.start).Take(model.length).ToListAsync();

            var jsonData = new { draw = model.draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
            return Ok(jsonData);
        }
        public IActionResult Index()
        {
            return View();
        }
        //Cac nut chuc nang
        //Lay danh sach group de hien thi tren combobox trong member
        [Authorized(Code = "edit-member")]
        [HttpGet]
        public async Task<IActionResult> getItem(Guid id)
        {
            if (_dbContext.Members == null)
                return NotFound();
            var item = await _dbContext.Members.FindAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        //Nut Save
        [Authorized(Code = "save-member")]
        [HttpPost]
        public async Task<IActionResult> Save(MemberViewModel model, IFormFile Picture)
        {
            Member item;
            if (model.Id == null)
            {
                item = new Core.Database.Models.Member();
                item.Id = Guid.NewGuid();
                item.CreatedOn = DateTime.Now;
                await _dbContext.Members.AddAsync(item);
            }
            else
            {
                item = await _dbContext.Members.FindAsync(model.Id);
                item.ModifiedOn = DateTime.Now;
            }
            item.Name = model.Name;
            item.LoginName = model.LoginName;
            if (!string.IsNullOrEmpty(model.Password))
            {
                item.Password = model.Password;
            }
            item.Email = model.Email;

            //Add Image
            if (Picture != null)
            {
                var path = Path.Combine(this._environment.WebRootPath, "img/users/", Picture.FileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await Picture.CopyToAsync(stream);
                    stream.Close();
                }
                item.Picture = "/img/users/" + Picture.FileName;
            }
            item.GroupId = model.GroupId;
            await _dbContext.SaveChangesAsync();
            return Ok(item);
        }
        //Nut Delete
        [Authorized(Code = "delete-member")]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var memberInArticle = await _dbContext.Articles.Where(m => m.CreatedBy == id).FirstOrDefaultAsync();
            if (memberInArticle == null)
            {
                var item = await _dbContext.Members.FindAsync(id);
                _dbContext.Entry(item).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
                return Ok(true);
            }
            return Ok(false);
        }
        
        //Trang Login
        [HttpGet] //Day la ham mac dinh khong can them cung duoc    
        public IActionResult Login()
        {
            return View();
        }
        //Login
        [HttpPost]
        public IActionResult Login(LoginViewModel item)
        {
            string md5Password = MD5Hash(item.Password);
            var member = _dbContext.Members.Where(m => m.LoginName == item.LoginName && m.Password == md5Password).FirstOrDefault();
            if (member != null)
            {
                HttpContext.Session.SetObject("Member", member);
                //Kiem tra quyen cua user
                var codes = _dbContext.Authorizeds.Where(a => a.GroupId == member.GroupId).Select(a => a.Role.Code).ToList();
                HttpContext.Session.SetObject("codes", codes);
                return RedirectToAction("Index", "Home"); 
            } 
            return RedirectToAction("Login", "Member");
        }
        //Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Member"); //Code AI
            return RedirectToAction("Index", "Home", new {area = ""});
        }

        //Ham ma hoa md5 
        public string MD5Hash(string text)
        {
            MD5 md5H = MD5.Create();
            //convert the input string to a byte array and compute its hash
            byte[] data = md5H.ComputeHash(Encoding.UTF8.GetBytes(text));
            // create a new stringbuilder to collect the bytes and create a string
            StringBuilder sB = new StringBuilder();
            //loop through each byte of hashed data and format each one as a hexadecimal string
            for (int i = 0; i < data.Length; i++)
            {
                sB.Append(data[i].ToString("x2"));
            }
            //return hexadecimal string
            return sB.ToString();
        }
    }
}