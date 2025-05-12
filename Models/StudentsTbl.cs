using System;
using System.Collections.Generic;

namespace Vaccination_Portal_Backend.Models;

public partial class StudentsTbl
{
    public int Id { get; set; }
    public int Age { get; set; }
    

    public string Student { get; set; } = null!;

    public int ClassName { get; set; } 
    public string VaccinationStatus { get; set; } = null!;

    //public DateOnly DateOfBirth { get; set; }

   
    //public string ContactNumber { get; set; } = null!;

    //public string Gender { get; set; } = null!;

   

    //public string? VaccineType { get; set; }

    //public int? DoseNumber { get; set; }

    //public DateOnly? VaccinationDate { get; set; }

//    public string? MedicalNote { get; set; }
}