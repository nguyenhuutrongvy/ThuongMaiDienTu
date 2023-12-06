using OnlineCosmetic.Models;
using OnlineCosmetic.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineCosmetic.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Admin/Product
        public ActionResult Index(string searchText, int? page)
        {
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            IEnumerable<Product> items = _context.Products.OrderByDescending(x => x.Id);
            if (!string.IsNullOrEmpty(searchText))
            {
                var result = _context.Products.Where(x =>
                    x.Title.ToLower().Contains(searchText) ||
                    x.Description.ToLower().Contains(searchText) ||
                    x.Alias.Contains(searchText)
                ).OrderByDescending(x => x.Id);
                return View(result.ToPagedList(pageIndex, pageSize));
            }
            return View(items.ToPagedList(pageIndex, pageSize));
        }

        public ActionResult Add()
        {
            ViewBag.ProductCategory = new SelectList(_context.ProductCategories.ToList(), "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product model)
        {
            if (ModelState.IsValid)
            {
                model.ProductCategoryId = 4;
                model.Alias = Models.Common.Filter.ConvertToURLSlug(model.Title);
                model.CreatedDate = DateTime.Now;
                model.CreatedBy = "Admin";
                model.ModifiedDate = DateTime.Now;

                _context.Products.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}