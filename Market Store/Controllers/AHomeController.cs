using Market_Store.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market_Store.Controllers
{
    public class AHomeController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AHomeController(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.AdminName = HttpContext.Session.GetString("AdminName");
            ViewBag.countofcustomer = _context.Customers.Count();
            ViewBag.countofstore = _context.Stores.Count();
            ViewBag.countofcontact = _context.Products.Count();
            ViewBag.totalofsale = _context.Products.Sum(x => x.ProductPrice);


            return View();

        }
        public IActionResult ViewContact()
        {
            var item = _context.Contacts.ToList();
            return View(item);

        }
        public IActionResult ViewTestimonial()
        {
            var item = _context.Testimonials.ToList();
            return View(item);

        }
        public IActionResult ViewCustomer()
        {
            var item = _context.Customers.ToList();
            return View(item);

        }

        //create report
        [HttpGet]
        public IActionResult Report()
        {
            var customer = _context.Customers.ToList();
            var product = _context.Products.ToList();
            var categories = _context.Categories.ToList();
            var prductcustomer = _context.Productcustomers.ToList();


            // select * from customer c join productcustomer pc on c.custid = pc.custid join product p on p.productid = pc.procid join category c on p.catid = c.catid
            var multitable = from c in customer
                             join PC in prductcustomer on c.CustId equals PC.ProductId
                             join p in product on PC.ProId equals p.ProId
                             join cat in categories on p.ProId equals cat.CategoryId
                             select new JoinTable { product = p, category = cat, customer = c, productcustomer = PC };



            var modelContext = _context.Productcustomers.Include(p => p.Cust).Include(p => p.Pro);
            ViewBag.TotalQuantity = modelContext.Sum(p => p.Quantity);
            ViewBag.Totalprice = modelContext.Sum(p => p.Pro.ProductPrice * p.Quantity);
            var data = Tuple.Create<IEnumerable<JoinTable>, IEnumerable<Productcustomer>>(multitable, modelContext);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Report(DateTime? startDate, DateTime? endDate)
        {
            var customer = _context.Customers.ToList();
            var productcustomer = _context.Productcustomers.ToList();
            var product = _context.Products.ToList();
            var categories = _context.Categories.ToList();



            //var multitable = from p in patients
            //                 join AP in Appointment on p.PatientId equals AP.AppointmentId
            //                 join A in appointment on AP.AppointmentpatientId equals A.AppointmentId
            //                 join cat in categories on A.AppointmentId equals cat.CategoryId
            //                 select new JoinTable { appointment = A, category = cat, patient = p, appointmentpatient = AP };
            var multitable = from c in customer
                             join PC in productcustomer on c.CustId equals PC.ProductId
                             join p in product on PC.ProId equals p.ProId
                             join cat in categories on p.ProId equals cat.CategoryId
                             select new JoinTable { product = p, category = cat, customer = c, productcustomer = PC };


            var modelContext = _context.Productcustomers.Include(p => p.Cust).Include(p => p.Pro);



            if (startDate == null && endDate == null)
            {
                ViewBag.TotalQuantity = modelContext.Sum(x => x.Quantity);
                ViewBag.TotalPrice = modelContext.Sum(x => x.Pro.ProductPrice * x.Quantity);
                var model3 = Tuple.Create<IEnumerable<JoinTable>, IEnumerable<Productcustomer>>(multitable, await modelContext.ToListAsync());
                return View(model3);



            }
            else if (startDate == null && endDate != null)
            {
                ViewBag.TotalQuantity = modelContext.Where(x => x.Datefrom.Value.Date == endDate).Sum(x => x.Quantity);
                ViewBag.TotalPrice = modelContext.Where(x => x.Datefrom.Value.Date == endDate).Sum(x => x.Pro.ProductPrice * x.Quantity);



                var model3 = Tuple.Create<IEnumerable<JoinTable>, IEnumerable<Productcustomer>>(multitable, await modelContext.Where(x => x.Dateto.Value.Date == endDate).ToListAsync());
                return View(model3);
            }
            else if (startDate != null && endDate == null)
            {
                ViewBag.TotalQuantity = modelContext.Where(x => x.Datefrom.Value.Date == startDate).Sum(x => x.Quantity);
                ViewBag.TotalPrice = modelContext.Where(x => x.Datefrom.Value.Date == startDate).Sum(x => x.Pro.ProductPrice * x.Quantity);



                var model3 = Tuple.Create<IEnumerable<JoinTable>, IEnumerable<Productcustomer>>(multitable, await modelContext.Where(x => x.Datefrom.Value.Date == startDate).ToListAsync());
                return View(model3);
            }
            else
            {
                ViewBag.TotalQuantity = modelContext.Where(x => x.Datefrom >= startDate && x.Datefrom <= endDate).Sum(x => x.Quantity);
                ViewBag.TotalPrice = modelContext.Where(x => x.Datefrom >= startDate && x.Datefrom <= endDate).Sum(x => x.Pro.ProductPrice * x.Quantity);
                var model3 = Tuple.Create<IEnumerable<JoinTable>, IEnumerable<Productcustomer>>(multitable, await modelContext.Where(x => x.Datefrom >= startDate && x.Datefrom <= endDate).ToListAsync());
                return View(model3);
            }





        }
        //create Search
        [HttpGet]
        public IActionResult Search()
        {
            var result = _context.Productcustomers.Include(p => p.Cust).Include(p => p.Pro).ToList();
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Search(DateTime? dateFrom, DateTime? dateTo)
        {
            var result = _context.Productcustomers.Include(p => p.Cust).Include(p => p.Pro);



            if (dateFrom == null && dateTo == null)
            {
                return View(result);
            }
            else if (dateFrom == null && dateTo != null)
            {
                var SearchResult = await result.Where(x => x.Dateto <= dateTo).ToListAsync();
                return View(SearchResult);
            }
            else if (dateFrom != null && dateTo == null)
            {
                var SearchResult = await result.Where(x => x.Datefrom >= dateFrom).ToListAsync();
                return View(SearchResult);
            }
            else
            {
                var SearchResult = await result.Where(x => x.Datefrom >= dateFrom && x.Dateto <= dateTo).ToListAsync();
                return View(SearchResult);
            }
        }
    }
}
