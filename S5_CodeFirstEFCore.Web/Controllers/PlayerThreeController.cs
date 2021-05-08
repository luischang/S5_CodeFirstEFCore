using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using S5_CodeFirstEFCore.Web.Models;

namespace S5_CodeFirstEFCore.Web.Controllers
{
    public class PlayerThreeController : Controller
    {
        private readonly CopaLibertadoresDBContext _context;

        public PlayerThreeController(CopaLibertadoresDBContext context)
        {
            _context = context;
        }

        // GET: PlayerThree
        public async Task<IActionResult> Index()
        {
            var copaLibertadoresDBContext = _context.Player.Include(p => p.SoccerPosition);
            return View(await copaLibertadoresDBContext.ToListAsync());
        }

        // GET: PlayerThree/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .Include(p => p.SoccerPosition)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: PlayerThree/Create
        public IActionResult Create()
        {
            ViewData["SoccerPositionId"] = new SelectList(_context.SoccerPosition, "Id", "Code");
            return View();
        }

        // POST: PlayerThree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Dorsal,DateofBirth,SoccerPositionId")] Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SoccerPositionId"] = new SelectList(_context.SoccerPosition, "Id", "Code", player.SoccerPositionId);
            return View(player);
        }

        // GET: PlayerThree/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            ViewData["SoccerPositionId"] = new SelectList(_context.SoccerPosition, "Id", "Code", player.SoccerPositionId);
            return View(player);
        }

        // POST: PlayerThree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Dorsal,DateofBirth,SoccerPositionId")] Player player)
        {
            if (id != player.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.Id))
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
            ViewData["SoccerPositionId"] = new SelectList(_context.SoccerPosition, "Id", "Code", player.SoccerPositionId);
            return View(player);
        }

        // GET: PlayerThree/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .Include(p => p.SoccerPosition)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: PlayerThree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await _context.Player.FindAsync(id);
            _context.Player.Remove(player);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.Id == id);
        }
    }
}
