using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using pgSQL.Models;
using System.Linq;
using System;

namespace pgSQL.Controllers
{
  [Route("/api/[controller]")]
  public class UserController : Controller {
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
      _context = context;

      if (_context.Users.Count() == 0)
      {
        _context.Users.AddRange(
            new User
            {
                FirstName = "Alan",
                LastName = "Jui",
                BlogSiteUrl = "https://www.facebook.com/AlanJui",
                Birthday = DateTime.Parse("1960-9-25")  
            },

            new User
            {
                FirstName = "Stacy",
                LastName = "Wu",
                BlogSiteUrl = null,
                Birthday = DateTime.Parse("1967-8-18")  
            },

            new User
            {
                FirstName = "Amos",
                LastName = "Jui",
                BlogSiteUrl = "https://www.facebook.com/AmosJui",
                Birthday = DateTime.Parse("2003-6-4")  
            }
        );
        _context.SaveChanges();
      }
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
