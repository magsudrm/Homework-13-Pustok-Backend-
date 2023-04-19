using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.DAL;

namespace Pustok.Areas.manage.Controllers
{
    [Area("manage")]

    public class AuthorController : Controller
    {
        private readonly PustokDbContext _context;

        public AuthorController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            var model = _context.Authors
                .Include(x => x.Books)
                .Skip((page - 1) * 3)
                .Take(3).ToList();
            return View(model);
        }
    }
}
