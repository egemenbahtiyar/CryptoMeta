using CryptoMeta.Business.Abstract;
using CryptoMeta.Entities;
using CryptoMeta.Identitiy;
using CryptoMeta.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMeta.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        public IBlogService _blogService { get; }
        public ICategoryService _categoryService { get; }
        public UserManager<User> _userManager { get; }
        public BlogController(IBlogService blogService, ICategoryService categoryService, UserManager<User> userManager )
        {
            _userManager = userManager;
            _categoryService = categoryService;
            _blogService = blogService;
        }
   
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var categories = _categoryService.GetAll().ToList();
            ViewBag.CategoryId = new SelectList(categories, "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogModel model, IFormFile file)
        {
            var categories = _categoryService.GetAll();
            ViewBag.CategoryId = new SelectList(categories, "Id", "CategoryName");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bilgileri doğru girdiğinizden emin olunuz.");
                return View(model);
            }
            if (file != null)
            {
                var extention = Path.GetExtension(file.FileName);
                var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                model.BlogImageUrl = randomName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Blogimg", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            var userId = _userManager.GetUserId(HttpContext.User);
            Blog entitiy = new Blog()
            {
                BlogCreatedTime = model.BlogCreatedTime,
                BlogDescription = model.BlogDescription,
                CategoryId = model.CategoryId,
                UserId = userId,
                Title = model.Title,
            };
            _blogService.Create(entitiy);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Details(int? id)
        {

            return View();
        }

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var blog = await _context.Blogs.FindAsync(id);
        //    if (blog == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "KategoriAdi", blog.CategoryId);
        //    return View(blog);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, Blog blog)
        //{
            
        //    return View(blog);
        //}


    }
}
