﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminTblTinTucsController : Controller
    {
        private readonly dbLibraryContext _context;

        public AdminTblTinTucsController(dbLibraryContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminTblTinTucs
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 5;
            var IsTblTinTucs = _context.TblTinTucs
                .AsNoTracking()
                .OrderByDescending(x => x.PostId);
            PagedList<TblTinTucs> models = new PagedList<TblTinTucs>(IsTblTinTucs, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }
        //        public async Task<IActionResult> Index()
        //        {
        //            return View(await _context.TblTinTucs.ToListAsync());
        //        }

        // GET: Admin/AdminTblTinTucs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTinTucs = await _context.TblTinTucs
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (tblTinTucs == null)
            {
                return NotFound();
            }

            return View(tblTinTucs);
        }

        // GET: Admin/AdminTblTinTucs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminTblTinTucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,Title,Scontents,Contents,Thumb,Published,Alias,CreatedDate,Author,AccountId,Tags,CatId,IsHot,IsNewfeed,MetaKey,MetaDesc,Views")] TblTinTucs tblTinTucs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTinTucs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblTinTucs);
        }

        // GET: Admin/AdminTblTinTucs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTinTucs = await _context.TblTinTucs.FindAsync(id);
            if (tblTinTucs == null)
            {
                return NotFound();
            }
            return View(tblTinTucs);
        }

        // POST: Admin/AdminTblTinTucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,Title,Scontents,Contents,Thumb,Published,Alias,CreatedDate,Author,AccountId,Tags,CatId,IsHot,IsNewfeed,MetaKey,MetaDesc,Views")] TblTinTucs tblTinTucs)
        {
            if (id != tblTinTucs.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTinTucs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTinTucsExists(tblTinTucs.PostId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblTinTucs);
        }

        // GET: Admin/AdminTblTinTucs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTinTucs = await _context.TblTinTucs
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (tblTinTucs == null)
            {
                return NotFound();
            }

            return View(tblTinTucs);
        }

        // POST: Admin/AdminTblTinTucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblTinTucs = await _context.TblTinTucs.FindAsync(id);
            _context.TblTinTucs.Remove(tblTinTucs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblTinTucsExists(int id)
        {
            return _context.TblTinTucs.Any(e => e.PostId == id);
        }
    }
}
