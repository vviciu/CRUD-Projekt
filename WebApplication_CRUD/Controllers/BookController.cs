using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication_CRUD.Models;
using WebApplication_CRUD.ViewModels;

namespace WebApplication_CRUD.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        //[AllowAnonymous]
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        //[AllowAnonymous]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        //
        // POST: /Account/Login
        //[AllowAnonymous]
        [HttpPost]
        public ActionResult Add(Book model, string returnUrl)
        {

            //Add saving book.

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Books.Add(model);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Book");
        }

        //[AllowAnonymous]
        [HttpGet]
        public ActionResult Get()
        {
            return View();
        }

        //[AllowAnonymous]
        [HttpPost]
        public ActionResult Get(BookViewModel model)
        {
            using (ApplicationDbContext context = ApplicationDbContext.Create())
            {
                model.Book = context.Books.FirstOrDefault(x => x.Id == model.Id);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(BookViewModel model)
        {
            using (ApplicationDbContext context = ApplicationDbContext.Create())
            {
                model.Book = context.Books.FirstOrDefault(x => x.Id == model.Id);
                if (model.Book != null)
                {
                    context.Books.Remove(model.Book);
                    context.SaveChanges();
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(BookViewModel model)
        {
            using (ApplicationDbContext context = ApplicationDbContext.Create())
            {
                if (model.StanUpdate == StanUpdate.Pobranie)
                {
                    model.Book = context.Books.FirstOrDefault(x => x.Id == model.Id);
                    model.StanUpdate = StanUpdate.Zmiana;
                }
                else
                {
                    var book = context.Books.FirstOrDefault(x => x.Id == model.Id);
                    book.Author = model.Book.Author;
                    book.Title = model.Book.Title;
                    context.SaveChanges();
                    model.StanUpdate = StanUpdate.Wynik;
                }
            }

            return View(model);
        }
    }
}