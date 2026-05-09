using FoodOrdering.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.Web.Controllers
{
    public class FoodController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? search)
        {
            var foods = _context.FoodItems
                .Include(f => f.Category)
                .Where(f => f.IsAvailable);

            if (!string.IsNullOrWhiteSpace(search))
            {
                foods = foods.Where(f =>
                    f.Name.Contains(search) ||
                    f.Description.Contains(search) ||
                    f.Category!.Name.Contains(search));
            }

            ViewBag.Search = search;

            return View(await foods.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var food = await _context.FoodItems
                .Include(f => f.Category)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }
    }
}