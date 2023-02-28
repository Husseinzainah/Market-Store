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
    public class HomesController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomesController(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            _context = context;
        }
        // GET: Homes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Homes.ToListAsync());
        }

        // GET: Homes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Homes
                .FirstOrDefaultAsync(m => m.HId == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // GET: Homes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Homes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HId,Text1,Imagename1,ImageFile1,Imagename2,ImageFile2,Imagename3,ImageFile3,Text2,Text3,Imagename4,ImageFile4,Text4")] Home home)
        {
            if (ModelState.IsValid)
            {
                if (home.ImageFile1 != null && home.ImageFile2 != null && home.ImageFile3 != null && home.ImageFile4 != null)
                {
                    string wwwroot = webHostEnvironment.WebRootPath;
                    string name = Guid.NewGuid().ToString() + "_" + home.ImageFile1.FileName;
                    string name1 = Guid.NewGuid().ToString() + "_" + home.ImageFile2.FileName;
                    string name2 = Guid.NewGuid().ToString() + "_" + home.ImageFile3.FileName;
                    string name3 = Guid.NewGuid().ToString() + "_" + home.ImageFile4.FileName;
                    string pathofcopyofimage = Path.Combine(wwwroot + "/Images/", name);
                    string pathofcopyofimage1 = Path.Combine(wwwroot + "/Images/", name1);
                    string pathofcopyofimage2 = Path.Combine(wwwroot + "/Images/", name2);
                    string pathofcopyofimage3 = Path.Combine(wwwroot + "/Images/", name3);
                    using (var filestream = new FileStream(pathofcopyofimage, FileMode.Create))
                    {
                        await home.ImageFile1.CopyToAsync(filestream);


                    }
                    using (var filestream = new FileStream(pathofcopyofimage1, FileMode.Create))
                    {
                        await home.ImageFile2.CopyToAsync(filestream);
                    }
                    using (var filestream = new FileStream(pathofcopyofimage2, FileMode.Create))
                    {
                        await home.ImageFile3.CopyToAsync(filestream);
                    }
                    using (var filestream = new FileStream(pathofcopyofimage3, FileMode.Create))
                    {
                        await home.ImageFile4.CopyToAsync(filestream);
                    }
                    home.Imagename1 = name;
                    home.Imagename2 = name1;
                    home.Imagename3 = name2;
                    home.Imagename4 = name3;
                    _context.Add(home);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return null;
                }
            }
            return View(home);
        }

        // POST: Homes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("HId,Text1,Imagename1,ImageFile1,Imagename2,ImageFile2,Imagename3,ImageFile3,Text2,Text3,Imagename4,ImageFile4,Text4")] Home home)
        {
            if (id != home.HId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string wwwroot = webHostEnvironment.WebRootPath;
                string name = Guid.NewGuid().ToString() + "_" + home.ImageFile1.FileName;
                string name1 = Guid.NewGuid().ToString() + "_" + home.ImageFile2.FileName;
                string name2 = Guid.NewGuid().ToString() + "_" + home.ImageFile3.FileName;
                string name3 = Guid.NewGuid().ToString() + "_" + home.ImageFile4.FileName;
                string pathofcopyofimage = Path.Combine(wwwroot + "/Images/", name);
                string pathofcopyofimage1 = Path.Combine(wwwroot + "/Images/", name1);
                string pathofcopyofimage2 = Path.Combine(wwwroot + "/Images/", name2);
                string pathofcopyofimage3 = Path.Combine(wwwroot + "/Images/", name3);
                using (var filestream = new FileStream(pathofcopyofimage, FileMode.Create))
                {
                    await home.ImageFile1.CopyToAsync(filestream);


                }
                using (var filestream = new FileStream(pathofcopyofimage1, FileMode.Create))
                {
                    await home.ImageFile2.CopyToAsync(filestream);
                }
                using (var filestream = new FileStream(pathofcopyofimage2, FileMode.Create))
                {
                    await home.ImageFile3.CopyToAsync(filestream);
                }
                using (var filestream = new FileStream(pathofcopyofimage3, FileMode.Create))
                {
                    await home.ImageFile4.CopyToAsync(filestream);
                }
                home.Imagename1 = name;
                home.Imagename2 = name1;
                home.Imagename3 = name2;
                home.Imagename4 = name3;
                _context.Update(home);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Update(home);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeExists(home.HId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return View(home);
        }

        // GET: Homes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Homes
                .FirstOrDefaultAsync(m => m.HId == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // POST: Homes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var home = await _context.Homes.FindAsync(id);
            _context.Homes.Remove(home);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeExists(decimal id)
        {
            return _context.Homes.Any(e => e.HId == id);
        }
    }
}
