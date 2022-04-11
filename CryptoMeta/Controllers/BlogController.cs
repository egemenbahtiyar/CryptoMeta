﻿using CryptoMeta.Business.Abstract;
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
            var userId = _userManager.GetUserId(HttpContext.User);
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bilgileri doğru girdiğinizden emin olunuz.");
                return View(model);
            }
            if (file != null)
            {
    
                Blog entitiy = new Blog()
                {
                    BlogComment = "Created",
                    LikeCount = 0,
                    DislikeCount = 0,
                    BlogCreatedTime = DateTime.Now,
                    BlogDescription = model.BlogDescription,
                    CategoryId = model.CategoryId,
                    UserId = userId,
                    Title = model.Title,
                };
                
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BlogPictures", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                entitiy.BlogImageUrl = fileName;
                _blogService.Create(entitiy);
               
            }
            return RedirectToAction("Index", "Home");


        }

        [HttpGet]
        public IActionResult MyArticles(string q)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var articles = _blogService.GetMyArticles(userId);
            var Viewmodel = articles.Select(r => new BlogModel
            {
                Id = r.Id,
                BlogComment = r.BlogComment,
                BlogCreatedTime = r.BlogCreatedTime,
                BlogDescription = r.BlogDescription,
                BlogImageUrl = r.BlogImageUrl,
                CategoryName = r.Category.CategoryName,
                CategoryId =r.Category.Id,
                LikeCount = r.LikeCount,
                DislikeCount = r.DislikeCount,
                Title = r.Title,
                UserId = r.UserId
                
            }).ToList();
            if (q != null)
            {
                var searchedArticles = _blogService.SearcMyArticles(q);
                if (searchedArticles.Count!=0)
                {
                    var SearchedViewmodel = searchedArticles.Select(r => new BlogModel
                    {
                        Id = r.Id,
                        BlogComment = r.BlogComment,
                        BlogCreatedTime = r.BlogCreatedTime,
                        BlogDescription = r.BlogDescription,
                        BlogImageUrl = r.BlogImageUrl,
                        CategoryName = r.Category.CategoryName,
                        CategoryId = r.Category.Id,
                        LikeCount = r.LikeCount,
                        DislikeCount = r.DislikeCount,
                        Title = r.Title,
                        UserId = r.UserId


                    }).ToList();
                    return View(SearchedViewmodel);
                }
                return NotFound();

            }
            return View(Viewmodel);
        }

        public IActionResult Details(int? id)
        {

            return View();
        }
       







    }
}
