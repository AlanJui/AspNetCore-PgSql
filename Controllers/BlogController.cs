using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using pgSQL.Models;
using System.Linq;

namespace pgSQL.Controllers
{
  [Route("/api/[controller]")]
  public class BlogController : Controller {
    private readonly AppDbContext _context;

    public BlogController(AppDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IEnumerable<Blog> GetAll()
    {
      return NewMethod();
    }

    private IEnumerable<Blog> NewMethod()
    {
      return _context.Blog.ToList();
    }
  }
}
