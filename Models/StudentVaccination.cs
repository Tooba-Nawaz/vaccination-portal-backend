using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaccination_Portal_Backend.Models
{
    public class StudentVaccination
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public StudentsTbl Student { get; set; }

        [Required]
        public int VaccinationDriveId { get; set; }

        [ForeignKey("VaccinationDriveId")]
        public VaccinationDriveTbl VaccinationDrive { get; set; }

        [Required]
        public DateTime VaccinationDate { get; set; }
    }
}
