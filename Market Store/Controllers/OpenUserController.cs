
using Market_Store.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market_Store.Controllers
{
    public class OpenUserController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public OpenUserController(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            var item1 = _context.Homes.ToList();
            var item2 = _context.Stores.ToList();
            var item3 = _context.Categories.ToList();
            var item4 = _context.Testimonials.ToList();
            var item5 = _context.Aboutus.ToList();
            var item6 = Tuple.Create<IEnumerable<Home>, IEnumerable<Store>, IEnumerable<Category>, IEnumerable<Testimonial>, IEnumerable<Aboutu>>(item1, item2, item3, item4, item5);

            return View(item6);
        }
        public IActionResult StoreByCategory(int Id)
        {
            var result = _context.Categories.Where(x => x.StoreId == Id).ToList();

            return View(result);
        }
        public IActionResult CategoryByProduct(int Id)
        {
            const string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);

            ViewBag.cat = _context.Categories.ToList();
            ViewBag.home = _context.Homes.ToList();
            var result = _context.Products.Where(x => x.CategoryId == Id).ToList();

            return View(result);
        }
        public IActionResult Testimonial()
        {
            var item = _context.Testimonials.ToList();
            return View(item);

        }
        public IActionResult About()
        {
            var item = _context.Aboutus.ToList();
            return View(item);

        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(string name, string email, decimal phone, DateTime date, string description)
        {
            Contact contact = new Contact();
            contact.Fullname = name;
            contact.ContEmail = email;
            contact.ContPhone = phone;
            contact.ContDate = date;
            contact.ConDescription = description;
            contact.ContId = contact.ContId;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return View();
        }
          [HttpPost]

        public IActionResult search(string search)
        {
            var searchLower = search.ToLower();
            var Store = _context.Stores.Where(x => x.StoreName.ToLower().Contains(searchLower)).ToList();
            return View(Store);
        }
        public IActionResult search()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");


            return View();
        }
        public IActionResult SuccessfuView()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }
        public IActionResult SendTestamonial(string mass)
        {
            Testimonial testimonial = new Testimonial();
            testimonial.Masseges = mass;
            _context.Add(testimonial);
            _context.SaveChanges();
                return View("SuccessfuView");
        }
    }
}
