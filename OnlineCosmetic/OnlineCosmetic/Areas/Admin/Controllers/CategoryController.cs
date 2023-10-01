using OnlineCosmetic.Models;
using OnlineCosmetic.Models.EF;
using System;
using System.Linq;
using System.Web.Mvc;

namespace OnlineCosmetic.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Admin/Category
        public ActionResult Index()
        {
            var items = _context.Categories;
            return View(items);
        }

        public ActionResult Add()
        {
            ViewBag.TotalItems = _context.Categories.Count();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            if (ModelState.IsValid)
            {
                model.Alias = Models.Common.Filter.ConvertToURLSlug(model.Title);
                model.CreatedDate = DateTime.UtcNow;
                model.CreatedBy = "Admin";
                model.ModifiedDate = DateTime.UtcNow;

                _context.Categories.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            Category item = _context.Categories.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                var item = _context.Categories.FirstOrDefault(c => c.Id == model.Id);

                item.Title = model.Title;
                item.Alias = Models.Common.Filter.ConvertToURLSlug(model.Title);
                item.Description = model.Description;
                item.Position = model.Position;
                item.SEOTitle = model.SEOTitle;
                item.SEODescription = model.SEODescription;
                item.SEOKeywords = model.SEOKeywords;
                item.ModifiedDate = DateTime.Now;
                item.ModifiedBy = "Admin";

                //_context.Categories.Attach(model);

                //model.Alias = Models.Common.Filter.ConvertToURLSlug(model.Title); ;
                //model.ModifiedDate = DateTime.Now;
                //model.ModifiedBy = "Admin";

                //_context.Entry(model).Property(x => x.Title).IsModified = true;
                //_context.Entry(model).Property(x => x.Alias).IsModified = true;
                //_context.Entry(model).Property(x => x.Description).IsModified = true;
                //_context.Entry(model).Property(x => x.Position).IsModified = true;
                //_context.Entry(model).Property(x => x.SEOTitle).IsModified = true;
                //_context.Entry(model).Property(x => x.SEODescription).IsModified = true;
                //_context.Entry(model).Property(x => x.SEOKeywords).IsModified = true;
                //_context.Entry(model).Property(x => x.ModifiedDate).IsModified = true;
                //_context.Entry(model).Property(x => x.ModifiedBy).IsModified = true;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Category item = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                //var deleteItem = _context.Categories.Attach(item);
                _context.Categories.Remove(item);
                _context.SaveChanges();

                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}