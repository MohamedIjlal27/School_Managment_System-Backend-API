using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using school_managment_system_backend.Models;

namespace school_managment_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DataBaseContext _dataBaseContext;

        public StudentController(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
          

            if (_dataBaseContext.Students == null)
            {
                return NotFound();
            }

            return await _dataBaseContext.Students.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {


            if (_dataBaseContext.Students == null)
            {
                return NotFound();
            }

            var student =await _dataBaseContext.Students.FindAsync(id);
            if(student == null)
            {
                return NotFound(id);
            }
            return student;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _dataBaseContext.Students.Add(student);
            await _dataBaseContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.id }, student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutStudent(int id, Student student)
        {
            if (id != student.id)
            {
                return BadRequest();
            }
            _dataBaseContext.Entry(student).State = EntityState.Modified;

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
        public async Task<ActionResult> DeleteStudent(int id)
        {
            if(_dataBaseContext.Students == null)
            {
                return NotFound();
            }

            var student = await _dataBaseContext.Students.FindAsync(id);
            if(student == null)
            {
                return NotFound();
            }

            _dataBaseContext.Students.Remove(student);
            await _dataBaseContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("CalculateAge")]
        public IActionResult CalculateAge([FromBody] Student student)
        {
            if (student == null || student.dateofbirth == null)
            {
                return BadRequest(new { Error = "Invalid request. Date of Birth is required." });
            }

            try
            {
                
                DateTime dob = student.dateofbirth.Date;
                DateTime today = DateTime.Today;
                int age = today.Year - dob.Year;
                if (dob.Date > today.AddYears(-age)) age--;

                return Ok(new { Age = age });
            }
            catch (Exception ex)
            {
                
                return BadRequest(new { Error = "Error calculating age." });
            }
        }


    }
}
