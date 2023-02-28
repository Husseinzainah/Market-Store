using Market_Store.Infrastructure;
using Market_Store.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market_Store.Controllers
{
    public class CartController : Controller
    {
        private readonly ModelContext context;
        public CartController(ModelContext _context)
        {
            this.context = _context;
        }
        public IActionResult Index()
        {
            List<Shopping> shoppings = HttpContext.Session.GetJason<List<Shopping>>("Cart") ?? new List<Shopping>();
            ShopViewModel shopVM = new ShopViewModel
            {
                shoppings = shoppings,
                GrandTotal = shoppings.Sum(x => x.Price * x.Quantity)


            };
            return View(shopVM);
        }
        public async Task<IActionResult> Add(decimal id)
        {
            Product product = await context.Products.FindAsync(id);
            List<Shopping> shoppings = HttpContext.Session.GetJason<List<Shopping>>("Cart") ?? new List<Shopping>();
            Shopping shopping = shoppings.Where(x => x.ShopId == id).FirstOrDefault();
            if (shopping == null)
            {
                shoppings.Add(new Shopping(product));
            }
            else
            {
                shopping.Quantity += 1;
            }
            HttpContext.Session.SetJason("Cart", shoppings);
            //if (HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")


            return RedirectToAction("Index");
            //return ViewComponent("SmallCart");
        }
        //Get/cart/Add/2

        //Get/cart/Decrease/5
        public IActionResult Decrease(decimal id)
        {

            List<Shopping> shoppings = HttpContext.Session.GetJason<List<Shopping>>("Cart");
            Shopping shopping = shoppings.Where(x => x.ShopId == id).FirstOrDefault();
            if (shopping.Quantity > 1)
            {
                --shopping.Quantity;
            }
            else
            {
                shoppings.RemoveAll(x => x.ShopId == id);
            }

            if (shoppings.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJason("Cart", shoppings);

            }

            return RedirectToAction("Index");
        }
        //Get/cart/remove/5
        public IActionResult Remove(decimal id)
        {

            List<Shopping> shoppings = HttpContext.Session.GetJason<List<Shopping>>("Shop");

            shoppings.RemoveAll(x => x.ShopId == id);

            //HttpContext.Session.SetJason("Shop", shoppings);
            if (shoppings.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJason("Cart", shoppings);

            }

            return RedirectToAction("Index");
        }
        //Get/cart/Clear 
        public IActionResult Clear()
        {


            HttpContext.Session.Remove("Cart");

            //if (HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
            //return Redirect(Request.Headers["Referer"].ToString());

            return RedirectToAction("CategoryByProduct", "OpenUser");
            //return Ok();
        }
       
        
        public IActionResult Checkout()
        {



            return View();
        }
        [HttpPost]
        public IActionResult Checkout(int Qun,DateTime orderdate,string address,string city,string country,string note,string name,int price)
        {
            Orderr orderr = new Orderr();
            orderr.CustName = name;
            orderr.UserCountry = country;
            orderr.Price = price;
            orderr.Quantity = Qun;
            orderr.UserCity = city;
            orderr.UserAddress = address;
            orderr.OrdDate = orderdate;
            orderr.UserNote = note;
            orderr.OrdId = orderr.OrdId;
            context.Orderrs.Add(orderr);
            context.SaveChanges();



            return RedirectToAction("visa", "Cart");
        }
        public IActionResult visa()
        {



            return View();

        }
        [HttpPost]
        public IActionResult visa( string type,int price,DateTime exp)
        {
            Payment payment = new Payment();
            payment.PayType = type;
            payment.Price = price;
            payment.Expiry = exp;
            payment.CutId = payment.CutId;
            context.Payments.Add(payment);
            context.SaveChanges();


            return View();

        }



    }

}

