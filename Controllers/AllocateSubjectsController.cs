using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using school_managment_system_backend.Models;

namespace school_managment_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocateSubjectsController : ControllerBase
    {
        private readonly DataBaseContext _dataBaseContext;

        public AllocateSubjectsController(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Allocate_Subjects>>> GetAllocate_Subjects()
        {


            if (_dataBaseContext.Allocate_Subjects == null)
            {
                return NotFound();
            }

            return await _dataBaseContext.Allocate_Subjects.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Allocate_Subjects>> GetAllocate_Subject(int id)
        {


            if (_dataBaseContext.Allocate_Subjects == null)
            {
                return NotFound();
            }

            var allocate_subjects = await _dataBaseContext.Allocate_Subjects.FindAsync(id);
            if (allocate_subjects == null)
            {
                return NotFound(id);
            }
            return allocate_subjects;
        }

        [HttpPost]
        public async Task<ActionResult<Allocate_Subjects>> PostAllocate_Subjects(Allocate_Subjects allocate_subjects)
        {
            _dataBaseContext.Allocate_Subjects.Add(allocate_subjects);
            await _dataBaseContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllocate_Subject), new { id = allocate_subjects.allocatedSubId }, allocate_subjects);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAllocate_Subjects(int id, Allocate_Subjects allocate_subjects)
        {
            if (id != allocate_subjects.allocatedSubId)
            {
                return BadRequest();
            }
            _dataBaseContext.Entry(allocate_subjects).State = EntityState.Modified;

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
        public async Task<ActionResult> DeleteAllocate_Subjects(int id)
        {
            if (_dataBaseContext.Allocate_Subjects == null)
            {
                return NotFound();
            }

            var allocate_subjects = await _dataBaseContext.Allocate_Subjects.FindAsync(id);
            if (allocate_subjects == null)
            {
                return NotFound();
            }

            _dataBaseContext.Allocate_Subjects.Remove(allocate_subjects);
            await _dataBaseContext.SaveChangesAsync();

            return Ok();
        }


       
    }
}
