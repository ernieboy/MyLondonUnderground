using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLondonUnderground.Application.Commands;
using MyLondonUnderground.Application.Scaffolding;
using MediatR;

namespace MyLondonUnderground.Admin.Controllers
{
    public class TubeLinesController : Controller
    {
        private readonly ScaffoldingContext _context;
        private IMediator _mediatr; 

        public TubeLinesController(ScaffoldingContext context, IMediator mediatr)
        {
            _context = context;
            _mediatr = mediatr;
        }

        // GET: TubeLines
        public async Task<IActionResult> Index()
        {
            var listCommand = new ListTubeLinesCommand { };
            var items = await _mediatr.Send(listCommand);
            return View(await _context.AddNewTubeLineCommand.ToListAsync());
        }

        // GET: TubeLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addNewTubeLineCommand = await _context.AddNewTubeLineCommand
                .SingleOrDefaultAsync(m => m.Id == id);
            if (addNewTubeLineCommand == null)
            {
                return NotFound();
            }

            return View(addNewTubeLineCommand);
        }

        // GET: TubeLines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TubeLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description")] AddNewTubeLineCommand addNewTubeLineCommand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addNewTubeLineCommand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addNewTubeLineCommand);
        }

        // GET: TubeLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addNewTubeLineCommand = await _context.AddNewTubeLineCommand.SingleOrDefaultAsync(m => m.Id == id);
            if (addNewTubeLineCommand == null)
            {
                return NotFound();
            }
            return View(addNewTubeLineCommand);
        }

        // POST: TubeLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description")] AddNewTubeLineCommand addNewTubeLineCommand)
        {
            if (id != addNewTubeLineCommand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addNewTubeLineCommand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddNewTubeLineCommandExists(addNewTubeLineCommand.Id))
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
            return View(addNewTubeLineCommand);
        }

        // GET: TubeLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addNewTubeLineCommand = await _context.AddNewTubeLineCommand
                .SingleOrDefaultAsync(m => m.Id == id);
            if (addNewTubeLineCommand == null)
            {
                return NotFound();
            }

            return View(addNewTubeLineCommand);
        }

        // POST: TubeLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addNewTubeLineCommand = await _context.AddNewTubeLineCommand.SingleOrDefaultAsync(m => m.Id == id);
            _context.AddNewTubeLineCommand.Remove(addNewTubeLineCommand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddNewTubeLineCommandExists(int id)
        {
            return _context.AddNewTubeLineCommand.Any(e => e.Id == id);
        }
    }
}
