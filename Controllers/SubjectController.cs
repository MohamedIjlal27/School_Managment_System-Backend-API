using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using school_managment_system_backend.Models;

namespace school_managment_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly DataBaseContext _dataBaseContext;

        public SubjectController(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        {


            if (_dataBaseContext.Subjects == null)
            {
                return NotFound();
            }

            return await _dataBaseContext.Subjects.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(int id)
        {


            if (_dataBaseContext.Subjects == null)
            {
                return NotFound();
            }

            var subject = await _dataBaseContext.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound(id);
            }
            return subject;
        }

        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(Subject subject)
        {
            _dataBaseContext.Subjects.Add(subject);
            await _dataBaseContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSubject), new { id = subject.subId }, subject);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSubject(int id, Subject subject)
        {
            if (id != subject.subId)
            {
                return BadRequest();
            }
            _dataBaseContext.Entry(subject).State = EntityState.Modified;

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
        public async Task<ActionResult> DeleteSubject(int id)
        {
            if (_dataBaseContext.Subjects == null)
            {
                return NotFound();
            }

            var subject = await _dataBaseContext.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            _dataBaseContext.Subjects.Remove(subject);
            await _dataBaseContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("GetSubjectNames")]
        public async Task<ActionResult<IEnumerable<string>>> GetSubjectNames()
        {
            var subjectNames = await _dataBaseContext.Subjects
                                                .Select(t => t.subName)
                                                .ToListAsync();

            return subjectNames;
        }

    }
}
