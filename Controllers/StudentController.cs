using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.Models;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DbContextSchool _db;
        public StudentController(DbContextSchool db) 
        {
            _db = db;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
        {
            return await _db.Students.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _db.Students.Where(s => s.Id == id).FirstOrDefaultAsync();
            if(student == null) 
            {
                return NotFound();
            }
            return student;
        }
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student ) 
        {
            if (student !=null) 
            {
                await _db.Students.AddAsync(student);
                _db.SaveChanges();
                return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudent(Student student) 
        {
            _db.Students.Update(student);
            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult>DeleteStudent(int id) 
        {
            var student = await _db.Students.FindAsync(id);
            if (student == null) 
            {
                return NotFound();
            }
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
            return NoContent(); 
        }

    }
}
