using CryptoMeta.Business.Abstract;
using CryptoMeta.Entities;
using CryptoMeta.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMeta.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        
        public IBlogService _blogService { get; }
        public ICategoryService _categoryService { get; }
        public ICryptoNewService _cryptoNewService { get; }
        public IForumPostService _forumPostService { get; }
        public INftService _nftService { get; }

        public AdminController(IBlogService blogService, ICategoryService categoryService, ICryptoNewService cryptoNewService, IForumPostService forumPostService,INftService nftService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _cryptoNewService = cryptoNewService;
            _forumPostService = forumPostService;
            _nftService = nftService;
        }
        public ActionResult Index()
        {
            var AdminIndexListViewmodel = new AdminIndexListViewmodel()
            {
                Categories = _categoryService.GetAll(),
                Blogs = _blogService.GetAll(),
                CryptoNews = _cryptoNewService.GetAll(),
                ForumPosts = _forumPostService.GetAll(),
                Nfts = _nftService.GetAll()
            };

            return View(AdminIndexListViewmodel);
        }

        [HttpGet]
        public IActionResult CreateCryptoNew()
        {
            return View(new CryptoNewModel());
        }

        [HttpPost]
        public IActionResult CreateCryptoNew(CryptoNewModel CNVM)
        {
            
            if (ModelState.IsValid)
            {
                var entity = new CryptoNew()
                {
                    Id = CNVM.Id,
                    NewCreatedTime = CNVM.NewCreatedTime,
                    NewDescription = CNVM.NewDescription,
                    NewTitle = CNVM.NewTitle
                };
                _cryptoNewService.Create(entity);
          
            }
            return View(CNVM);
            

        }
        [HttpGet]
        public IActionResult EditCryptoNew(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _cryptoNewService.GetbyId((int)id);

            if (entity == null)
            {
                return NotFound();
            }

            var model = new CryptoNewModel()
            {
                Id = entity.Id,
                NewCreatedTime = entity.NewCreatedTime,
                NewDescription = entity.NewDescription,
                NewTitle = entity.NewTitle
            };

            ViewBag.News = _cryptoNewService.GetAll();

            return View(model);
        }

        [HttpPut]
        public IActionResult EditCryptoNew(CryptoNewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _cryptoNewService.GetbyId(model.Id);

                if (entity == null)
                {
                    return NotFound();
                }

                entity.NewDescription = model.NewDescription;
                entity.NewTitle = model.NewTitle;

                _cryptoNewService.Update(entity);

                return RedirectToAction("ProductList"); // SONRA EKLENCEK
            }

            ViewBag.Categories = _categoryService.GetAll();

            return View(model);

        }
        [HttpDelete]
        public IActionResult DeleteCryptoNew(int Id)
        {
            var entity = _cryptoNewService.GetbyId(Id);

            if (entity != null)
            {
                _cryptoNewService.Delete(entity);
            }

            return RedirectToAction("CategoryList"); // SONRA EKLENCEK
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View(new CategoryModel());
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryModel CM)
        {

            if (ModelState.IsValid)
            {
                var entity = new Category()
                {
                    Id = CM.Id,
                    CategoryName = CM.CategoryName
                };
                _categoryService.Create(entity);

            }
            return View(CM);


        }

        [HttpGet]
        public IActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _categoryService.GetbyId((int)id);

            if (entity == null)
            {
                return NotFound();
            }

            var model = new CategoryModel()
            {
                Id = entity.Id,
                CategoryName = entity.CategoryName
            };

            ViewBag.Categories = _categoryService.GetAll();

            return View(model);
        }

        [HttpPut]
        public IActionResult EditCategory(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _categoryService.GetbyId(model.Id);

                if (entity == null)
                {
                    return NotFound();
                }

                entity.CategoryName = model.CategoryName;

                _categoryService.Update(entity);

                return RedirectToAction("ProductList"); // SONRA EKLENCEK
            }

            ViewBag.Categories = _categoryService.GetAll();

            return View(model);

        }
        [HttpDelete]
        public IActionResult DeleteCategory(int categoryId)
        {
            var entity = _categoryService.GetbyId(categoryId);

            if (entity != null)
            {
                _categoryService.Delete(entity);
            }

            return RedirectToAction("CategoryList"); // SONRA EKLENCEK
        }

        [HttpGet]
        public IActionResult CreateNft()
        {
            return View(new NftModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateNft(NftModel NftModel, IFormFile file)
        {

            if (ModelState.IsValid)
            {
                var entity = new Nft()
                {
                    Id = NftModel.Id,
                    NftCreatedTime = NftModel.NftCreatedTime,
                    NftDescription = NftModel.NftDescription

                };
                if (file != null)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/NftPictures", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    entity.NftImageUrl = fileName;
                }
                _nftService.Create(entity);

            }
            return View(NftModel);


        }
        [HttpGet]
        public IActionResult EditNft(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _nftService.GetbyId((int)id);

            if (entity == null)
            {
                return NotFound();
            }

            var model = new NftModel()
            {
                Id = entity.Id,
                NftCreatedTime = entity.NftCreatedTime,
                NftDescription = entity.NftDescription,
                NftImageUrl = entity.NftImageUrl
            };

            ViewBag.Nfts = _nftService.GetAll();

            return View(model);
        }

        [HttpPut]
        public async Task<IActionResult> EditNft(NftModel model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var entity = _nftService.GetbyId(model.Id);

                if (entity == null)
                {
                    return NotFound();
                }

                entity.NftDescription = model.NftDescription;

                if (file != null)
                {
                    //var imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Nftimg", entity.NftImageUrl);     // Test et
                    //if (System.IO.File.Exists(imagepath))
                    //{
                    //    System.IO.File.Delete(imagepath);
                    //}
                    entity.NftImageUrl = model.NftImageUrl;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Nftimg", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                 
                }

                _nftService.Update(entity);

                return RedirectToAction("ProductList"); // SONRA EKLENCEK
            }

            ViewBag.Nfts = _nftService.GetAll();

            return View(model);

        }

        [HttpDelete]
        public IActionResult DeleteNft(int Id)
        {
            var entity = _nftService.GetbyId(Id);

            if (entity != null)
            {
                _nftService.Delete(entity);
            }

            return RedirectToAction("Index"); // SONRA EKLENCEK
        }

        [HttpDelete]
        public IActionResult DeleteBlog(int Id)
        {
            var entity = _blogService.GetbyId(Id);

            if (entity != null)
            {
                _blogService.Delete(entity);
            }

            return RedirectToAction("Index"); // SONRA EKLENCEK
        }

        [HttpDelete]
        public IActionResult DeleteForumPost(int Id)
        {
            var entity = _forumPostService.GetbyId(Id);

            if (entity != null)
            {
                _forumPostService.Delete(entity);
            }

            return RedirectToAction("Index"); // SONRA EKLENCEK
        }

    }
}
