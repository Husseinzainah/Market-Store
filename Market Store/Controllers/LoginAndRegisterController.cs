using Market_Store.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Market_Store.Controllers
{
    public class LoginAndRegisterController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public LoginAndRegisterController(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            _context = context;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Customer customer, string pass)
        {
            if (ModelState.IsValid)
            {
                string wwwroot = webHostEnvironment.WebRootPath;
                string name = Guid.NewGuid().ToString() + "_" + customer.ImageFile.FileName;
                string pathofcopyofimage = Path.Combine(wwwroot + "/Images/", name);
                
                using (var filestream = new FileStream(pathofcopyofimage, FileMode.Create))

                {
                    await customer.ImageFile.CopyToAsync(filestream);
                }
                //save image path
                customer.Imagename = name;
                customer.Password = pass;
                customer.RoleId = 1;
                ////add patient
                _context.Add(customer);
                await _context.SaveChangesAsync();
                UserLogin userLogin = new UserLogin();
                userLogin.Username = customer.CustFname + customer.CustLname;
                userLogin.Password = pass;
               
                userLogin.RoleId = 1;
                userLogin.CustomeId = customer.CustId;
                _context.Add(userLogin);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login", "LoginAndRegister");
            }
            return View();

        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLogin userLogin)
        {
            const string id = "id";
            var auth = _context.UserLogins.Where(x => x.Username == userLogin.Username && x.Password == userLogin.Password).SingleOrDefault();
            if (auth != null)
            {
                switch (auth.RoleId)
                {
                    case 1:
                        HttpContext.Session.SetString("UserName", auth.Username);
                        return RedirectToAction("Index", "OpenUser");

                    case 2:
                        HttpContext.Session.SetInt32(id, (int)auth.CustomeId);
                        HttpContext.Session.SetString("AdminName", auth.Username);
                        return RedirectToAction("Index", "AHome");
                    case null:
                        {
                            HttpContext.Session.SetInt32(id, (int)userLogin.CustomeId);
                            return RedirectToAction("Index", "AHome");
                        }
                }
            }
            return View();
        }

    }
}