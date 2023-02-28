using Market_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market_Store.Controllers
{
    public class websiteController : Controller
    {
        private readonly ModelContext context;
        public websiteController(ModelContext _context)
        {
            this.context = _context;
        }
        public IActionResult Index()
        {
            var item1 = context.Homes.ToList();
            var item2 = context.Stores.ToList();
            var item3 = context.Categories.ToList();
            var item4 = context.Testimonials.ToList();
            var item5 = context.Aboutus.ToList();
            var item6 = Tuple.Create<IEnumerable<Home>, IEnumerable<Store>, IEnumerable<Category>, IEnumerable<Testimonial>, IEnumerable<Aboutu>>(item1,item2,item3,item4,item5);

            return View(item6);
        }
        public IActionResult StoreByCategory(int Id)
        {
            var result = context.Categories.Where(x => x.StoreId ==Id).ToList();

            return View(result);
        }
        public IActionResult CategoryByProduct(int Id)
        {
            var result = context.Products.Where(x => x.CategoryId == Id).ToList();

            return View(result);
        }
        public IActionResult Testimonial()
        {
            var item = context.Testimonials.ToList();
            return View(item);
        
        }
        public IActionResult About()
        {
            var item = context.Aboutus.ToList();
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
            context.Contacts.Add(contact);
            context.SaveChanges();
            return View();
        }
       
    }
}
