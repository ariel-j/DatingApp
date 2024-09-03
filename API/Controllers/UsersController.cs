using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

[ApiController]
[Route("api/[controller]")]

public class UsersController(DataContext contex) : ControllerBase
{
[HttpGet]
public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() {
    var users = await contex.Users.ToListAsync();
    return users;
}

[HttpGet("{id:int}")] 
public async Task<ActionResult<AppUser>> GetUsers(int id) {
    var user = await contex.Users.FindAsync(id);
    if(user ==null) return NotFound();
    return user;
}
}


