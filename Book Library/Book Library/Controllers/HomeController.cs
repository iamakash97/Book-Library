using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using DAL;
using BLL;
namespace Book_Library.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult addbook()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult addbook(string title,string author,string isbn,string publisher,string year)
        {
            string msg = "Failed Registereation";
            Book b = new Book();
            b.title = title;
            b.author = author;
            b.ISBN = isbn;
            b.publisher = publisher;
            b.year = year;
            if(BookManager.addbook(b))
            {
                msg = "Book Added SuccessFully";
            }
            ViewData["msg"] = msg;

            return RedirectToAction("bookadded", "Home");
        }

        [HttpGet]
        public ActionResult bookadded()
        {
            return View();
        }

        [HttpGet]
        public ActionResult showbooklist()
        {
            List<Book> books = BookManager.GetBooks();
            return View(books);
        }
        [HttpGet]
        public ActionResult modifybookrecord()
        {
            List<Book> books = BookManager.GetBooks();
            return View(books);
        }
        [HttpPost]
        public ActionResult updatebook(int serno,string title, string author, string isbn, string publisher, string year)
        {
            Book b = new Book();
            b.serno = serno;
            b.title = title;
            b.author = author;
            b.ISBN = isbn;
            b.publisher = publisher;
            b.year = year;
            if (BookManager.updatebook(b))
            {
                return RedirectToAction("modifybookrecord", "Home");
            }
            return View();

        }
        [HttpGet]
        public ActionResult showbook(int serno)
        {
            Book b = BookManager.getbook(serno);
            ViewData["Id"] = b.serno;
            ViewData["title"] = b.title;
            ViewData["author"] = b.author;
            ViewData["ISBN"] = b.ISBN;
            ViewData["publisher"] = b.publisher;
            ViewData["year"] = b.year;

            return View();
        }
        [HttpGet]
        public ActionResult deletebook(int serno)
        {
            if(BookManager.deletebook(serno))
            {
                return RedirectToAction("modifybookrecord", "Home");
            }
            return View();
        }
        [HttpGet]
        public ActionResult searchbook()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult bookdetail(String t)
        {
            if(BookConnected.checkbook(t))
            {
                Book b = BookManager.searchbook(t);
                ViewData["Id"] = b.serno;
                ViewData["name"] = b.title;
                ViewData["author"] = b.author;
                ViewData["ISBN"] = b.ISBN;
                ViewData["publisher"] = b.publisher;
                ViewData["year"] = b.year;
                return View();
            }
            return RedirectToAction("searchbookfailed", "Home");
            
        }
        [HttpGet]
        public ActionResult searchbookfailed()
        {

            return View();
        }

    }
}