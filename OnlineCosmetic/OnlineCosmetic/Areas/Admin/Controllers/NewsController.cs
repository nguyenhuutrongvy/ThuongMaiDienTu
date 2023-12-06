using OnlineCosmetic.Models;
using OnlineCosmetic.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineCosmetic.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Admin/News
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
            IEnumerable<News> items = _context.News.OrderByDescending(x => x.Id);
            if (!string.IsNullOrEmpty(searchText))
            {
                var result = _context.News.Where(x =>
                    x.Title.ToLower().Contains(searchText) ||
                    x.Description.ToLower().Contains(searchText) ||
                    x.Alias.Contains(searchText)
                ).OrderByDescending(x => x.Id);
                return View(result.ToPagedList(pageIndex, pageSize));
            }
            return View(items.ToPagedList(pageIndex, pageSize));
        }

        public ActionResult Add() { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(News model)
        {
            if (ModelState.IsValid)
            {
                model.CategoryId = 4;
                model.Alias = Models.Common.Filter.ConvertToURLSlug(model.Title);
                model.CreatedDate = DateTime.Now;
                model.CreatedBy = "Admin";
                model.ModifiedDate = DateTime.Now;

                _context.News.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            News news = _context.News.FirstOrDefault(x => x.Id == id);
            if (news != null)
            {
                return View(news);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News model)
        {
            if (ModelState.IsValid)
            {
                News news = _context.News.FirstOrDefault(x => x.Id == model.Id);
                if (news != null)
                {
                    news.Title = model.Title;
                    news.Description = model.Description;
                    news.Detail = model.Detail;
                    news.Image = model.Image;
                    news.SEOTitle = model.SEOTitle;
                    news.SEODescription = model.SEODescription;
                    news.SEOKeywords = model.SEOKeywords;
                    news.ModifiedDate = DateTime.Now;
                    news.ModifiedBy = "Admin";
                    news.Alias = Models.Common.Filter.ConvertToURLSlug(model.Title);
                    news.IsActive = model.IsActive;

                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            News item = _context.News.FirstOrDefault(n => n.Id == id);
            if (item != null)
            {
                _context.News.Remove(item);
                _context.SaveChanges();

                return Json(new { success = true });
            }
            return Json(new { success = false });
            //return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult DeleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                List<News> items = new List<News>();
                string[] strings = ids.Split(',');
                foreach (string s in strings)
                {
                    News temp = _context.News.Find(int.Parse(s));
                    if (temp != null)
                    {
                        items.Add(temp);
                    }
                }
                if (items != null)
                {
                    _context.News.RemoveRange(items);
                    _context.SaveChanges();

                    return Json(new { success = true });
                }
            }
            return Json(new { success = false });
            //return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult Active(int id)
        {
            News item = _context.News.FirstOrDefault(n => n.Id == id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                item.ModifiedDate = DateTime.Now;
                item.ModifiedBy = "Admin";

                bool isActive = item.IsActive;

                _context.SaveChanges();

                return Json(new { success = true, status = isActive });
            }
            return Json(new { success = false });
        }
    }
}