using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using pgSQL.Models;
using System.Linq;

namespace pgSQL.Controllers
{
  [Route("/api/[controller]")]
  public class UserController : Controller {
    private readonly BloggingContext _context;

    public UserController(BloggingContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IEnumerable<User> GetAll()
    {
      return _context.Users.ToList();
    }

    private List<User> NewMethod()
    {
      return _context.Users.ToList();
    }
  }
}
