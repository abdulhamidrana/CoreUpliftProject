using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uplift.DataAccess.Data;
using Uplift.Models;

namespace Uplift.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryNgjsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryNgjsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult CategoryList()
        {
            var data = _db.Category.ToList();

            return Json(data, new Newtonsoft.Json.JsonSerializerSettings());

        }
        [HttpPost]
        public JsonResult AddCategory([FromBody] Category category)
        {

            _db.Category.Add(category);
            _db.SaveChanges();
            var p = _db.Category.ToList();
            return Json(p, new Newtonsoft.Json.JsonSerializerSettings());

        }
        [HttpPost]
        public JsonResult UpdateCategory([FromBody] Category category)
        {
            var upcategory = _db.Category.FirstOrDefault(x => x.Id == category.Id); 
            upcategory.Name = category.Name;
            upcategory.DisplayOrder = category.DisplayOrder;
            _db.Entry(upcategory).State = EntityState.Modified;
            _db.SaveChanges();
            var p = _db.Category.ToList(); 
            return Json(p, new Newtonsoft.Json.JsonSerializerSettings());
        }

        public string DeleteCategory(int? id)
        {
            var data = _db.Category
                   .Where(x => x.Id == id)
                   .Select(x => x)
                   .FirstOrDefault();

            if (data != null)
            {
                _db.Category.Remove(data);
            }
            _db.SaveChanges();

            return "Delete Success full";
        }

    }
}
