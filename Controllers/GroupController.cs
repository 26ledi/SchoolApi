using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.Models;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly DbContextSchool _db;
        public GroupController(DbContextSchool db) 
        {
            _db= db;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>>GetGroup() 
        {
           return await _db.Groups.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Group>> CreateGroup(Group group) 
        {
            await _db.Groups.AddAsync(group);
            _db.SaveChanges();
            return CreatedAtAction(nameof(GetGroup),new { id=group.Id} ,group);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateGroup(Group group) 
        {
            _db.Groups.Update(group);
            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult>DeleteGroup(int id) 
        {
            var group = await _db.Groups.FindAsync(id);
            _db.Groups.Remove(group);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
