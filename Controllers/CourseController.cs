using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.Models;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly DbContextSchool _db;
        public CourseController(DbContextSchool db) 
        {
            _db = db;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourse() 
        {
            return await _db.Courses.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse(Course course) 
        {
           await _db.Courses.AddAsync(course);
           _db.SaveChanges();
            return CreatedAtAction(nameof(CreateCourse),new{id=course.Id }, course);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCourse(Course course)
        {
            _db.Courses.Update(course);
            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult>DeleteCourse(int id) 
        {
            var course = await _db.Courses.FindAsync(id);
            _db.Courses.Remove(course);
            await _db.SaveChangesAsync();
            return NoContent();
        }

    }
}
