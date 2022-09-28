using AppCitas.Service.Data;
using AppCitas.Service.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;

namespace AppCitas.Service.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    // GET api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    // GET api/users/:id
    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUserById(int id)
    {
        return await _context.Users.FindAsync (id);
    }
}