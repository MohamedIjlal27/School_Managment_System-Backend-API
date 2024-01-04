using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using school_managment_system_backend.Models;

namespace school_managment_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly DataBaseContext _dataBaseContext;

        public ClassroomController(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classroom>>> GetClassrooms()
        {


            if (_dataBaseContext.Classroom == null)
            {
                return NotFound();
            }

            return await _dataBaseContext.Classroom.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Classroom>> GetClassroom(int id)
        {


            if (_dataBaseContext.Classroom == null)
            {
                return NotFound();
            }

            var classroom = await _dataBaseContext.Classroom.FindAsync(id);
            if (classroom == null)
            {
                return NotFound(id);
            }
            return classroom;
        }

        [HttpPost]
        public async Task<ActionResult<Classroom>> PostClassroom(Classroom classroom)
        {
            _dataBaseContext.Classroom.Add(classroom);
            await _dataBaseContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClassroom), new { id = classroom.clsID }, classroom);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutClassroom(int id, Classroom classroom)
        {
            if (id != classroom.clsID)
            {
                return BadRequest();
            }
            _dataBaseContext.Entry(classroom).State = EntityState.Modified;

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
        public async Task<ActionResult> DeleteClassroom(int id)
        {
            if (_dataBaseContext.Classroom == null)
            {
                return NotFound();
            }

            var classroom = await _dataBaseContext.Classroom.FindAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }

            _dataBaseContext.Classroom.Remove(classroom);
            await _dataBaseContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("GetClassRoomNames")]
        public async Task<ActionResult<IEnumerable<string>>> GetClassRoomsNumber()
        {
            var classrooms = await _dataBaseContext.Classroom
                                                .Select(t => t.clsName)
                                                .ToListAsync();

            return classrooms;
        }
    }
}
