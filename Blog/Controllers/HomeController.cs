using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    
    public class HomeController : Controller
    {
        private DataContext context;
        private IEnumerable<Author> Authors => context.Authors;
        public HomeController(DataContext data)
        {
            context = data;
        }
        public IActionResult Index()
        {
            IEnumerable<Author> authors = context.Authors;
            IEnumerable<Article> articles = context.Articles.Include(art=>art.Author).ToArray();
            Author host = context.Authors.FirstOrDefault(auth=>auth.IsHost==true);
            AuthorViewModel hvm = ViewModelFactory.Home(authors, articles,host);
            return View(hvm);
        }
        public async Task<IActionResult> Detail(int id)
        {   
            Article art = await context.Articles.Include(art => art.Author).FirstOrDefaultAsync(art => art.ArticleId == id);
            art.Author.Articles = null;
            ArticleViewModel avm = ViewModelFactory.Detail(art, Authors);
            return View(avm);
        }
    }
}
