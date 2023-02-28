﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Market_Store.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Market_Store.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CustomersController(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            _context = context;
        }


        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustId,CustFname,CustLname,Email,Password,RoleId,Phone,Imagename,ImageFile")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.ImageFile != null)
                {
                    string wwwroot = webHostEnvironment.WebRootPath;
                    string name = Guid.NewGuid().ToString() + "_" + customer.ImageFile.FileName;
                    string pathofcopyofimage = Path.Combine(wwwroot + "/Images/", name);
                    using (var filestream = new FileStream(pathofcopyofimage, FileMode.Create))
                    {
                        await customer.ImageFile.CopyToAsync(filestream);
                    }
                    customer.Imagename = name;
                    _context.Add(customer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return null;
                }
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("CustId,CustFname,CustLname,Email,Password,RoleId,Phone,Imagename,ImageFile")] Customer customer)
        {
            if (id != customer.CustId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string wwwroot = webHostEnvironment.WebRootPath;
                string name = Guid.NewGuid().ToString() + "_" + customer.ImageFile.FileName;
                string pathofcopyofimage = Path.Combine(wwwroot + "/Images/", name);
                using (var filestream = new FileStream(pathofcopyofimage, FileMode.Create))
                {
                    await customer.ImageFile.CopyToAsync(filestream);
                }
                customer.Imagename = name;
                _context.Update(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Update(customer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(customer.CustId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(decimal id)
        {
            return _context.Customers.Any(e => e.CustId == id);
        }
    }
}
