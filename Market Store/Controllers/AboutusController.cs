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
   
        public class AboutusController : Controller
        {
            private readonly ModelContext _context;
            private readonly IWebHostEnvironment webHostEnvironment;

            public AboutusController(ModelContext context, IWebHostEnvironment webHostEnvironment)
            {
                this.webHostEnvironment = webHostEnvironment;
                _context = context;
            }


            // GET: Aboutus
            public async Task<IActionResult> Index()
        {
            return View(await _context.Aboutus.ToListAsync());
        }

        // GET: Aboutus/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutu = await _context.Aboutus
                .FirstOrDefaultAsync(m => m.AboutId == id);
            if (aboutu == null)
            {
                return NotFound();
            }

            return View(aboutu);
        }

        // GET: Aboutus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aboutus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AboutId,TextA,Imagename,ImageFile,TextB,Imagename2,ImageFile2")] Aboutu aboutu)
        {
            if (ModelState.IsValid)
            {
                if (aboutu.ImageFile != null &&aboutu.ImageFile2!=null)
                {
                    string wwwroot = webHostEnvironment.WebRootPath;
                    string name = Guid.NewGuid().ToString() + "_" + aboutu.ImageFile.FileName;
                    string name1 = Guid.NewGuid().ToString() + "_" + aboutu.ImageFile2.FileName;
                    string pathofcopyofimage = Path.Combine(wwwroot + "/Images/", name);
                    string pathofcopyofimage1 = Path.Combine(wwwroot + "/Images/", name1);
                    using (var filestream = new FileStream(pathofcopyofimage, FileMode.Create))
                    {
                        await aboutu.ImageFile.CopyToAsync(filestream);


                    }
                    using (var filestream = new FileStream(pathofcopyofimage1, FileMode.Create))
                    {
                        await aboutu.ImageFile2.CopyToAsync(filestream);


                    }
                    aboutu.Imagename = name;
                    aboutu.Imagename2 = name1;
                    _context.Add(aboutu);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return null;
                }
            }
            return View(aboutu);
        }

        // GET: Aboutus/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutu = await _context.Aboutus.FindAsync(id);
            if (aboutu == null)
            {
                return NotFound();
            }
            return View(aboutu);
        }

        // POST: Aboutus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("AboutId,TextA,Imagename,ImageFile,TextB,Imagename2,ImageFile2")] Aboutu aboutu)
        {
            if (id != aboutu.AboutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string wwwroot = webHostEnvironment.WebRootPath;
                string name = Guid.NewGuid().ToString() + "_" + aboutu.ImageFile.FileName;
                string pathofcopyofimage = Path.Combine(wwwroot + "/Images/", name);
                using (var filestream = new FileStream(pathofcopyofimage, FileMode.Create))
                {
                    await aboutu.ImageFile.CopyToAsync(filestream);
                }

                aboutu.Imagename = name;
                aboutu.Imagename2 = name;
                _context.Update(aboutu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Update(aboutu);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AboutuExists(aboutu.AboutId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return View(aboutu);
        }

        // GET: Aboutus/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutu = await _context.Aboutus
                .FirstOrDefaultAsync(m => m.AboutId == id);
            if (aboutu == null)
            {
                return NotFound();
            }

            return View(aboutu);
        }

        // POST: Aboutus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var aboutu = await _context.Aboutus.FindAsync(id);
            _context.Aboutus.Remove(aboutu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutuExists(decimal id)
        {
            return _context.Aboutus.Any(e => e.AboutId == id);
        }
    }
}
