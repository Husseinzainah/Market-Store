using System;
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
    public class StoresController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public StoresController(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        // GET: Stores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stores.ToListAsync());
        }

        // GET: Stores/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var store = await _context.Stores
                .FirstOrDefaultAsync(m => m.StoreId == id);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // GET: Stores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreId,StoreName,StoreImage,ImageFile,StoreLogo,StoreDescription")] Store store)
        {
            if (ModelState.IsValid)
            {
                if (store.ImageFile != null)
                {
                    string wwwroot = webHostEnvironment.WebRootPath;
                    string name = Guid.NewGuid().ToString() + "_" + store.ImageFile.FileName;
                    string pathofcopyofimage = Path.Combine(wwwroot + "/Images/", name);
                    using (var filestream = new FileStream(pathofcopyofimage, FileMode.Create))
                    {
                        await store.ImageFile.CopyToAsync(filestream);
                    }
                    store.StoreImage = name;
                    _context.Add(store);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return null;
                }

            }
            return View(store);
        }

        // GET: Stores/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var store = await _context.Stores.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }
            return View(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("StoreId,StoreName,StoreImage,ImageFile,StoreLogo,StoreDescription")] Store store)
        {
            if (id != store.StoreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string wwwroot = webHostEnvironment.WebRootPath;
                string name = Guid.NewGuid().ToString() + "_" + store.ImageFile.FileName;
                string pathofcopyofimage = Path.Combine(wwwroot + "/Images/", name);
                using (var filestream = new FileStream(pathofcopyofimage, FileMode.Create))
                {
                    await store.ImageFile.CopyToAsync(filestream);
                }
                store.StoreImage = name;
                _context.Update(store);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Update(store);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(store.StoreId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return View(store);
        }
        // GET: Stores/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var store = await _context.Stores
                .FirstOrDefaultAsync(m => m.StoreId == id);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var store = await _context.Stores.FindAsync(id);
            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreExists(decimal id)
        {
            return _context.Stores.Any(e => e.StoreId == id);
        }
    }
}
