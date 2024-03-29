﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uplift.DataAccess.Data.Repository.IRepository;
using Uplift.Models;

namespace Uplift.DataAccess.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {
            return _db.Category.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            }); 

        }

        public void Update(Category category)
        {
            var ObjFromDb = _db.Category.FirstOrDefault(c => c.Id == category.Id);

            ObjFromDb.Name = category.Name;
            ObjFromDb.DisplayOrder = category.DisplayOrder;

            _db.SaveChanges();
        }
    }
}
