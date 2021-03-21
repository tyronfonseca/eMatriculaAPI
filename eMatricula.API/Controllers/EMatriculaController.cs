using eMatricula.API.Classes;
using eMatricula.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMatricula.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class EMatriculaController : ControllerBase
    {
        private readonly EMatriculaContext _context;

        public EMatriculaController(EMatriculaContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        //===================== STUDENT =====================
        [HttpGet("student/{id:int}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _context.Students
                    .Include(x => x.Careers)
                    .Include(x => x.Enrollments)
                    .Include(x => x.Counselors)
                        .ThenInclude(x => x.Professor)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

            if (student == null) {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost("student/{id:int}")]
        public async Task<ActionResult<Student>> PostStudent([FromBody] Student student, int id)
        {
            var career = await _context.Careers.FindAsync(id);

            if (career == null)
            {
                return NotFound();
            }

            student.Careers = new List<Career> { career };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();           

            return CreatedAtAction(
                "GetStudent",
                new { id = student.Id },
                student
                );
        }

        [HttpPut("student/{id:int}")]
        public async Task<IActionResult> PutStudent([FromRoute] int id, [FromBody] Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Students.Find(id) == null)
                {
                    return NotFound();
                }

                return Conflict();
            }

            return NoContent();
        }

        [HttpDelete("student/{id:int}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await _context.Students.Include(x => x.Careers).FirstOrDefaultAsync(x => x.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return Ok(student);
        }


        //===================== COURSE =====================
        [HttpGet("course/{id:int}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var course = await _context.Courses                
                .Include(x => x.Requirements)
                    .ThenInclude(x => x.CourseReq)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost("course")]
        public async Task<ActionResult<Course>> PostCourse([FromBody] Course course, [FromQuery] QueryMatricula query)
        {
            if(query.Id == null)
            {
                return BadRequest();
            }

            var carerra = await _context.Careers.FirstOrDefaultAsync(x => x.Id == query.Id);

            if (carerra == null)
            {
                return BadRequest();
            }

            course.Career = carerra;
            
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetCourse",
                new { id = course.Id },
                course
                );
        }

        [HttpPut("course/{id:int}")]
        public async Task<IActionResult> PutCourse([FromRoute] int id, [FromBody] Course course)
        {

            if (id != course.Id)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Courses.Find(id) == null)
                {
                    return NotFound();
                }
                return Conflict();
            }

            return NoContent();
        }

        [HttpDelete("course/{id:int}")]
        public async Task<ActionResult<Course>> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return Ok(course);
        }       

        //===================== CAREER =====================
        [HttpGet("career/{id:int}")]
        public async Task<IActionResult> GetCareer(int id)
        {
            var career = await _context.Careers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            if (career == null)
            {
                return NotFound();
            }

            return Ok(career);
        }

        [HttpPost("career")]
        public async Task<ActionResult<Career>> PostCareer([FromBody] Career career)
        {
            _context.Careers.Add(career);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetCareer",
                new { id = career.Id },
                career
                );
        }

        [HttpPut("career/{id:int}")]
        public async Task<IActionResult> PutCareer([FromRoute] int id, [FromBody] Career career) 
        { 
            if(id != career.Id)
            {
                return BadRequest();
            }

            _context.Entry(career).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Careers.Find(id) == null)
                {
                    return NotFound();
                }
                return Conflict();
            }

            return NoContent();
        }

        [HttpDelete("career/{id:int}")]
        public async Task<ActionResult<Career>> DeleteCareer(int id) 
        {
            var career = await _context.Careers.FindAsync(id);

            if(career == null)
            {
                return NotFound();
            }

            _context.Careers.Remove(career);
            await _context.SaveChangesAsync();

            return Ok(career);
        }

        //===================== CAREERS EXTRA =====================
        [HttpGet("careers")]
        public async Task<IActionResult> GetCareers() {
            var careers = await _context.Careers.AsNoTracking().ToArrayAsync();

            if(careers == null || careers.Count() == 0)
            {
                return NotFound();
            }

            return Ok(careers);
        }

        [HttpGet("getStudentsByCareer/{id:int}")]
        public async Task<IActionResult> GetStudentsByCareer(int id) {
            var carrera = await _context.Careers
                .Include(x => x.Students)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);            
            if(carrera == null )
            {
                return NotFound();
            }            
            return Ok(carrera.Students.ToArray());
        }

        //===================== COURSES STATE =====================
        [HttpGet("courses/{id:int}")]
        public async Task<IActionResult> GetCourseState(int id)
        {
            var courses = _context.Enrollment
                .Include(x => x.Course)
                .Include(x => x.CourseSchedules)
                .Include(x => x.Professor)
                .Where(x => x.Student.Id == id)
                .AsNoTracking();

            if (courses.Count() == 0 || courses == null)
            {
                return NotFound();
            }

            return Ok(await courses.ToArrayAsync());
        }

        [HttpGet("careerCourses/{id:int}")]
        public async Task<IActionResult> GetCoursesByCareer(int id)
        {
            var courses = _context.Courses.Where(x => x.Career.Id == id).AsNoTracking();

            if (courses.Count() == 0 || courses == null)
            {
                return NotFound();
            }

            return Ok(await courses.ToArrayAsync());
        }
        
        //MATRICULAR
        [HttpPost("enrollment")]
        public async Task<ActionResult<Enrollment>> PostEnrollment([FromQuery] QueryMatricula queryParams, [FromBody] Enrollment curso)
        {
            if (queryParams.IdStudent != null && queryParams.IdCourse != null && queryParams.IdProfessor != null)
            {
                var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == queryParams.IdStudent);
                var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == queryParams.IdCourse);
                var professor = await _context.Professors.FirstOrDefaultAsync(x => x.Id == queryParams.IdProfessor);

                if (student == null || course == null || professor == null)
                {
                    return NotFound();
                }
                //var curso = new CourseState {
                //    Cycle = MatriculaHelper.CicloActual,
                //    Grade = MatriculaHelper.GradeMatriculado,
                //    State = MatriculaHelper.Matriculado,
                //    Student = student,
                //    Course = course,
                //    Professor = professor
                //};
                curso.Student = student;
                curso.Course = course;
                curso.Professor = professor;

                _context.Enrollment.Add(curso);
                await _context.SaveChangesAsync();
                return CreatedAtAction(
                   "GetCourseState",
                   new { id = course.Id},
                   curso
               );
            }
            return BadRequest();
        }

        //RENUNCIA
        [HttpPut("enrollment")]
        public async Task<IActionResult> PutEnrollment([FromQuery] QueryMatricula queryParams)
        {
            if (queryParams.Id != null)
            {
                var curso = await _context.Enrollment.FirstOrDefaultAsync(x => x.Id == queryParams.Id);

                if(curso == null)
                {
                    return NotFound();
                }

                curso.State = MatriculaHelper.Retirado;
                curso.Grade = MatriculaHelper.GradeRetirado;

                _context.Entry(curso).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_context.Enrollment.Find(curso.Id) == null)
                    {
                        return NotFound();
                    }
                    return Conflict();
                }

                return NoContent();
            }

            return BadRequest();
        }

        //RETIRO
        [HttpDelete("enrollment/{id:int}")]
        public async Task<ActionResult<Enrollment>> DeleteEnrollment(int id)
        {
            var curso = await _context.Enrollment.FindAsync(id);

            if(curso == null)
            {
                return NotFound();
            }

            _context.Enrollment.Remove(curso);
            await _context.SaveChangesAsync();

            return Ok(curso);
        }

        //===================== PROFESSOR =====================
        [HttpGet("professor/{id:int}")]
        public async Task<IActionResult> GetProfessor(int id)
        {
            var professor = await _context.Professors
                .Include(x => x.Counselours)
                .Include(x => x.Enrollments)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            if(professor == null)
            {
                return NotFound();
            }
            return Ok(professor);
        }

        [HttpPost("professor")]
        public async Task<ActionResult<Professor>> PostProfessor([FromBody] Professor professor)
        {
            _context.Professors.Add(professor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                    "GetProfessor",
                    new { id = professor.Id},
                    professor
                );
        }

        [HttpPut("professor/{id:int}")]
        public async Task<IActionResult> PutProfessor([FromRoute] int id, [FromBody] Professor professor)
        {
            if (id != professor.Id)
            {
                return BadRequest();
            }

            _context.Entry(professor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Professors.Find(id) == null) 
                {
                    return NotFound();
                }
                return Conflict();
            }

            return NoContent();
        }

        [HttpDelete("professor/{id:int}")]
        public async Task<IActionResult> DeleteProfessor(int id)
        {
            var profesor = await _context.Professors.FirstOrDefaultAsync(x => x.Id == id);
            if(profesor == null)
            {
                return NotFound();
            }

            _context.Professors.Remove(profesor);
            await _context.SaveChangesAsync();

            return Ok(profesor);
        }

        //===================== CONSEJERO =====================
        [HttpPost("counselor")]
        public async Task<IActionResult> PostConsejero([FromQuery] QueryMatricula query)
        {
            if (!string.IsNullOrEmpty(query.Oficina) 
                && !string.IsNullOrEmpty(query.HorarioAtencion) 
                && !string.IsNullOrEmpty(query.Telefono)
                && query.IdStudent != null && query.IdProfessor != null) {

                var estudiante = await _context.Students.FirstOrDefaultAsync(x => x.Id == query.IdStudent);
                var professor = await _context.Professors.FirstOrDefaultAsync(x => x.Id == query.IdProfessor);
                
                if(estudiante == null || professor == null)
                {
                    return NotFound();
                }

                var consejero = new ProfessorCounselor { 
                    Office = query.Oficina,
                    TimeTable = query.HorarioAtencion,
                    Telephone = query.Telefono,
                    Professor = professor,
                    Student = estudiante                   
                };

                _context.ProfessorCounselors.Add(consejero);
                await _context.SaveChangesAsync();

                return Ok(consejero);
            }
            return BadRequest();
        }

        [HttpPut("counselor/{id:int}")]
        public async Task<IActionResult> PutConsejero([FromRoute] int id, [FromBody] ProfessorCounselor consejero)
        {
            if (id != consejero.Id)
            {
                return BadRequest();
            }

            _context.Entry(consejero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(_context.ProfessorCounselors.Find(id) == null)
                {
                    return NotFound();
                }
                return Conflict();
            }

            return NoContent();
        }
    }
}