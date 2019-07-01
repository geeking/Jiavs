using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Jiavs.MVC.Models;
using Jiavs.Application.IServices;
using Jiavs.Domain.Models;

namespace Jiavs.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly int PageSize = 20;
        public HomeController(IArticleService articleService)
        {
            this._articleService = articleService;

        }
        public async Task<IActionResult> Index(int page = 0)
        {
            var articlePagination = new ArticlePaginationParameter
            {
                PageSize = this.PageSize,
                PageIndex = page
            };
            
            var articles =  _articleService.GetArticlesSummary(articlePagination);
            return View(articles);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
