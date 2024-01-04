using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using school_managment_system_backend.Models;

namespace school_managment_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocateClassroomController : ControllerBase
    {
        private readonly DataBaseContext _dataBaseContext;

        public AllocateClassroomController(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Allocate_Classroom>>> GetAllocate_Classrooms()
        {


            if (_dataBaseContext.Allocate_Classroom == null)
            {
                return NotFound();
            }

            return await _dataBaseContext.Allocate_Classroom.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Allocate_Classroom>> GetAllocate_Classroom(int id)
        {


            if (_dataBaseContext.Allocate_Classroom == null)
            {
                return NotFound();
            }

            var allocate_classroom = await _dataBaseContext.Allocate_Classroom.FindAsync(id);
            if (allocate_classroom == null)
            {
                return NotFound(id);
            }
            return allocate_classroom;
        }

        [HttpPost]
        public async Task<ActionResult<Allocate_Classroom>> PostAllocate_Classroom(Allocate_Classroom allocate_classroom)
        {
            _dataBaseContext.Allocate_Classroom.Add(allocate_classroom);
            await _dataBaseContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllocate_Classroom), new { id = allocate_classroom.allocateClassRoomId }, allocate_classroom);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAllocate_Classroom(int id, Allocate_Classroom allocate_classroom)
        {
            if (id != allocate_classroom.allocateClassRoomId)
            {
                return BadRequest();
            }
            _dataBaseContext.Entry(allocate_classroom).State = EntityState.Modified;

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
        public async Task<ActionResult> DeleteAllocate_Classroom(int id)
        {
            if (_dataBaseContext.Allocate_Classroom == null)
            {
                return NotFound();
            }

            var allocate_classroom = await _dataBaseContext.Allocate_Classroom.FindAsync(id);
            if (allocate_classroom == null)
            {
                return NotFound();
            }

            _dataBaseContext.Allocate_Classroom.Remove(allocate_classroom);
            await _dataBaseContext.SaveChangesAsync();

            return Ok();
        }
    }
}
