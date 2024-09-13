using System;
using KnowledgeHubPortal.Domain.Repository;
using konwledgeHubPortal.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//using KnowledgeHubPortal.Domain.Entities.Article;

namespace KnowledgeHubPortal.WebApp.Controllers
{
    public class ArticlesController1 : Controller
    {
        private readonly ICatagoryRepository cRepo;
        private readonly IArticlesRepository aRepo;
        public ArticlesController1(IArticlesRepository aRepo, ICatagoryRepository cRepo)
        {
            this.aRepo = aRepo;
            this.cRepo = cRepo;
        }
        // browse articles
        public IActionResult Index(int cid = 0) //in index.cshtml name is cid in select tag. so here in this method also parameter should be same.
        {

            // fetch all approved articles for browse
            var articlesToBrowse = aRepo.GetArticleForBrowse(cid);
            // fetch all catagories
            var catagories = from cat in cRepo.GetAll()
                             select new SelectListItem 
                             { 
                                 Text = cat.Name, 
                                 Value = cat.CatagoryId.ToString() 
                             };

            ViewBag.Catagories = catagories; // here Catagories is a key and catagories is a value
            //ViewData["Catagories"] = catagories;
            return View(articlesToBrowse);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Submit()
        {
            var catagories = from cat in cRepo.GetAll()
                             select new SelectListItem
                             {
                                 Text = cat.Name,
                                 Value = cat.CatagoryId.ToString()
                             };

            ViewBag.Catagories = catagories;
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Submit(KnowledgeHubPortal.Domain.Entities.Article article)
        {
            //validate
            if(!ModelState.IsValid)
            {
                return View();
            }

            //save
            article.DateSubmitted = DateTime.Now;
            article.IsApproved = false;
            if(User.Identity.IsAuthenticated)
            {
                article.SubmittedBy = User.Identity.Name;
            }
            else
                article.SubmittedBy = "Unknown";
            
            aRepo.Submit(article);
            TempData["Message"] = $"Article {article.Title} submitted successfully for admin review";
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "admin")]

        public IActionResult Review(int cid = 0)
        {
            // fetch all new  articles for review
            var articlesToReview = aRepo.GetArticleForReview(cid);
            // fetch all categories
            var categories = from cat in cRepo.GetAll()
                             select new SelectListItem
                             {
                                 Text = cat.Name,
                                 Value = cat.CatagoryId.ToString()
                             };

            ViewBag.Categories = categories;

            return View(articlesToReview);
        }

        //[HttpGet]
        //[Authorize(Roles = "admin")]
        //public IActionResult Accept()
        //{
        //    var articlesToReview = aRepo.GetArticleForReview();
        //    ViewBag.articles = articlesToReview;
        //    return View(articlesToReview);
        //}

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Accept(List<int> selectedArticleIds)
        {
            aRepo.Approve(selectedArticleIds);
            TempData["Message"] = $"{selectedArticleIds.Count} Article/s Approved successfully";
            return RedirectToAction("Review");
        }

        //[HttpGet]
        //[Authorize(Roles = "admin")]
        //public IActionResult Reject()
        //{
        //    var articlesToReview = aRepo.GetArticleForReview();
        //    ViewBag.articles = articlesToReview;
        //    return View(articlesToReview);
        //}

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Reject(List<int> selectedArticleIds)
        {
            aRepo.Reject(selectedArticleIds);
            TempData["Message"] = $"{selectedArticleIds.Count} Article/s Rejected successfully";
            return RedirectToAction("Review");
        }
    }
}
