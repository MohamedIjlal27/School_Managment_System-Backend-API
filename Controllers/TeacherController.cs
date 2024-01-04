using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using school_managment_system_backend.Models;

namespace school_managment_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly DataBaseContext _dataBaseContext;

        public TeacherController(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {


            if (_dataBaseContext.Teachers == null)
            {
                return NotFound();
            }

            return await _dataBaseContext.Teachers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {


            if (_dataBaseContext.Teachers == null)
            {
                return NotFound();
            }

            var teacher = await _dataBaseContext.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound(id);
            }
            return teacher;
        }

        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
        {
            _dataBaseContext.Teachers.Add(teacher);
            await _dataBaseContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeacher), new { id = teacher.teachId}, teacher);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTeacher(int id, Teacher teacher)
        {
            if (id != teacher.teachId)
            {
                return BadRequest();
            }
            _dataBaseContext.Entry(teacher).State = EntityState.Modified;

            try
            {
                await _dataBaseContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;

            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeacher(int id)   
        {
            if (_dataBaseContext.Teachers == null)
            {
                return NotFound();
            }

            var teacher = await _dataBaseContext.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _dataBaseContext.Teachers.Remove(teacher);
            await _dataBaseContext.SaveChangesAsync();

            return Ok();
        }


        [HttpGet("GetTeacherNames")]
        public async Task<ActionResult<IEnumerable<string>>> GetTeacherNames()
        {
            var teacherNames = await _dataBaseContext.Teachers
                                                .Select(t => t.teachFirstName)
                                                .ToListAsync();

            return teacherNames;
        }
    }
}
