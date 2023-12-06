using OnlineCosmetic.Models;
using OnlineCosmetic.Models.EF;
using System;
using System.Linq;
using System.Web.Mvc;

namespace OnlineCosmetic.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Admin/ProductProductCategory
        public ActionResult Index()
        {
            var items = _context.ProductCategories.OrderByDescending(p => p.Id);
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                model.Alias = Models.Common.Filter.ConvertToURLSlug(model.Title);
                model.CreatedDate = DateTime.Now;
                model.CreatedBy = "Admin";
                model.ModifiedDate = DateTime.Now;

                _context.ProductCategories.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            ProductCategory item = _context.ProductCategories.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                var item = _context.ProductCategories.FirstOrDefault(c => c.Id == model.Id);

                item.Title = model.Title;
                item.Description = model.Description;
                item.Icon = model.Icon;
                item.Alias = Models.Common.Filter.ConvertToURLSlug(model.Title);
                item.SEOTitle = model.SEOTitle;
                item.SEODescription = model.SEODescription;
                item.SEOKeywords = model.SEOKeywords;
                item.ModifiedDate = DateTime.Now;
                item.ModifiedBy = "Admin";

                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            ProductCategory item = _context.ProductCategories.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                _context.ProductCategories.Remove(item);
                _context.SaveChanges();

                return Json(new { success = true });
            }
            return Json(new { success = false });;
        }
    }
}