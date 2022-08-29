using Batuhan.WebApi.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Batuhan.WebApi.Controllers
{

    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public CategoriesController(ApiDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}/cars")]
        public IActionResult GetByCategories(int id)
        {
            var result = _context.Categories.Include(x => x.Cars).SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
            
        }
    }
}
