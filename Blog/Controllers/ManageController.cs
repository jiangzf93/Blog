using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    public class ManageController : Controller
    {
        private DataContext context;
        private IEnumerable<Author> Authors => context.Authors;

        public ManageController(DataContext data)
        {
            context = data;
        }
        public IActionResult Index()
        {
            IEnumerable<Article> articles = context.Articles.Include(art => art.Author);
            foreach(Article art in articles)
            {
                art.Author.Articles = null;
            }
            return View(articles);
        }
        public IActionResult Create()
        {
            return View("ArticleEditor", ViewModelFactory.Create(new Article(), Authors));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ArticleViewModel avm)
        {
            context.Articles.Add(avm.Article);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Detail(int id)
        {
            Article art = await context.Articles.Include(art=>art.Author).FirstOrDefaultAsync(art => art.ArticleId == id);
            ArticleViewModel model = ViewModelFactory.Detail(art, Authors);
            return View("ArticleEditor", model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            Article art = await context.Articles.Include(art => art.Author).FirstOrDefaultAsync(art => art.ArticleId == id);
            ArticleViewModel model = ViewModelFactory.Edit(art, Authors);
            return View("ArticleEditor", model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] ArticleViewModel avm)
        {
            context.Articles.Update(avm.Article);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            context.Articles.Remove(context.Articles.FirstOrDefault(art=>art.ArticleId==id));
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       
        
        public IActionResult Author()
        {
            return View(Authors);
        }
        public IActionResult AuthorCreate()
        {
            return View("AuthorEditor", ViewModelFactory.AuthorCreate(new Author()));
        }
        [HttpPost]
        public async Task<IActionResult> AuthorCreate([FromForm] AuthorViewModel avm)
        {
            avm.Author.AuthorId = default;
            context.Authors.Add(avm.Author);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Author));

        }
        public async Task<IActionResult> AuthorDetail(int id)
        {
            Author auth = await context.Authors.FirstOrDefaultAsync(art => art.AuthorId == id);
            AuthorViewModel model = ViewModelFactory.AuthorDetail(auth);
            return View("AuthorEditor", model);
        }
        public async Task<IActionResult> AuthorEdit(int id)
        {
            Author auth = await context.Authors.FirstOrDefaultAsync(art => art.AuthorId == id);
            AuthorViewModel model = ViewModelFactory.AuthorEdit(auth);
            return View("AuthorEditor", model);
        }
        [HttpPost]
        public async Task<IActionResult> AuthorEdit([FromForm] AuthorViewModel avm)
        {
            context.Authors.Update(avm.Author);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Author));
        }
        public async Task<IActionResult> AuthorDelete(int id)
        {
            Author auth = await context.Authors.FirstOrDefaultAsync(auth => auth.AuthorId == id);
            if (!auth.IsHost)
            {
                context.Authors.Remove(context.Authors.FirstOrDefault(auth => auth.AuthorId == id));
                await context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Author));
        }

    }
}
