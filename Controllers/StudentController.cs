using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vaccination_Portal_Backend.Models;
using Vaccination_Portal_Backend.Viewmodel;

namespace Vaccination_Portal_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;
        public StudentController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Student([FromBody] StudentViewModel student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest("Student data is null.");
                }
                StudentsTbl studentsTbl = new StudentsTbl();
                studentsTbl.Student = student.Student;
               
                studentsTbl.ClassName = student.ClassName;
                studentsTbl.Age = student.Age;
                studentsTbl.VaccinationStatus = student.VaccinationStatus;
                //studentsTbl.DateOfBirth = student.Dob;
                //studentsTbl.ParentName = student.ParentName;
                //studentsTbl.ContactNumber = student.ContactNumber;
                //studentsTbl.Gender = student.Gender;
                //studentsTbl.Vaccinated = student.Vaccinated;
                // studentsTbl.VaccineType = student.VaccineType;
                // studentsTbl.VaccinationDate = student.VaccinationDate;
                // studentsTbl.DoseNumber = student.DoseNumber;
                //studentsTbl.MedicalNote = student.MedicalNote;
                _context.Add(studentsTbl);
                _context.SaveChanges();
                return Ok(new { message = "Student saved successfully", student });
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public async Task<IActionResult> Student()
        {
            try
            {
                var students = await _context.StudentsTbl.ToListAsync();
                return Ok(new { message = "Student data fetched successfully", students });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentsTbl student)
        {
            try
            {
                // Find the student by ID in the database
                var existingStudent = await _context.StudentsTbl.FindAsync(id);

                // If student does not exist, return a NotFound result
                if (existingStudent == null)
                {
                    return NotFound(new { message = "Student not found" });
                }

                // Update the student properties
                existingStudent.Student = student.Student;
                existingStudent.ClassName = student.ClassName;
                existingStudent.Age = student.Age;
                existingStudent.VaccinationStatus = student.VaccinationStatus;

                // Save changes to the database
                _context.StudentsTbl.Update(existingStudent);
                await _context.SaveChangesAsync();

                // Return a success response
                return Ok(new { message = "Student updated successfully", student = existingStudent });
            }
            catch (Exception ex)
            {
                // If an error occurs, return an internal server error response
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }


        // DELETE: api/Student/{studentId}
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            int _Id = Convert.ToInt32(Id);
            var student = await _context.StudentsTbl.FirstOrDefaultAsync(s => s.Id == _Id);

            if (student == null)
            {
                return NotFound();
            }

            _context.StudentsTbl.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent(); // 204 No Content
        }

        [HttpPost("upload-file")]
        public async Task<IActionResult> UploadCSVFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is empty.");

            using var reader = new StreamReader(file.OpenReadStream());

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                BadDataFound = null,
                MissingFieldFound = null,
                HeaderValidated = null,
            };

            using var csv = new CsvReader(reader, config);

            // Tell CsvHelper the expected date format for Dob
            csv.Context.TypeConverterOptionsCache.GetOptions<DateTime>().Formats = new[] { "dd-MM-yyyy" };

            try
            {
                var records = csv.GetRecords<StudentViewModel>().ToList();

                if (records == null || !records.Any())
                    return BadRequest("CSV is empty or improperly formatted.");

                var students = records.Select(r => new StudentsTbl
                {
                    //StudentId = r.StudentId,
                    Student = r.Student,
                    Age = r.Age,
                    VaccinationStatus = r.VaccinationStatus,
                    ClassName = r.ClassName,
                    //DateOfBirth = r.Dob,
                    //ParentName = r.ParentName,
                    //ContactNumber = r.ContactNumber,
                    //Gender = r.Gender,
                    //MedicalNote = r.MedicalNote
                }).ToList();

                await _context.StudentsTbl.AddRangeAsync(students);
                await _context.SaveChangesAsync();

                return Ok(new { count = students.Count });
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid CSV format or error: " + ex.Message);
            }
        }



    }

}