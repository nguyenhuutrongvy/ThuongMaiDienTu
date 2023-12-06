using OnlineCosmetic.Models;
using OnlineCosmetic.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineCosmetic.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Admin/Post
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
            IEnumerable<Post> items = _context.Posts.OrderByDescending(x => x.Id);
            if (!string.IsNullOrEmpty(searchText))
            {
                var result = _context.Posts.Where(x =>
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
        public ActionResult Add(Post model)
        {
            if (ModelState.IsValid)
            {
                model.CategoryId = 4;
                model.Alias = Models.Common.Filter.ConvertToURLSlug(model.Title);
                model.CreatedDate = DateTime.Now;
                model.CreatedBy = "Admin";
                model.ModifiedDate = DateTime.Now;

                _context.Posts.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            Post post = _context.Posts.FirstOrDefault(x => x.Id == id);
            if (post != null)
            {
                return View(post);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post model)
        {
            if (ModelState.IsValid)
            {
                Post post = _context.Posts.FirstOrDefault(x => x.Id == model.Id);
                if (post != null)
                {
                    post.Title = model.Title;
                    post.Description = model.Description;
                    post.Detail = model.Detail;
                    post.Image = model.Image;
                    post.SEOTitle = model.SEOTitle;
                    post.SEODescription = model.SEODescription;
                    post.SEOKeywords = model.SEOKeywords;
                    post.ModifiedDate = DateTime.Now;
                    post.ModifiedBy = "Admin";
                    post.Alias = Models.Common.Filter.ConvertToURLSlug(model.Title);
                    post.IsActive = model.IsActive;

                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Post item = _context.Posts.FirstOrDefault(n => n.Id == id);
            if (item != null)
            {
                _context.Posts.Remove(item);
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
                List<Post> items = new List<Post>();
                string[] strings = ids.Split(',');
                foreach (string s in strings)
                {
                    Post temp = _context.Posts.Find(int.Parse(s));
                    if (temp != null)
                    {
                        items.Add(temp);
                    }
                }
                if (items != null)
                {
                    _context.Posts.RemoveRange(items);
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
            Post item = _context.Posts.FirstOrDefault(n => n.Id == id);
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