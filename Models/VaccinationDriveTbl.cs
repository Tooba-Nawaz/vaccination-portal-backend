using System;
using System.Collections.Generic;

namespace Vaccination_Portal_Backend.Models;

public partial class VaccinationDriveTbl
{
    public int VaccineId { get; set; }

    public string VaccineName { get; set; } = null!;

    public string? Location { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Description { get; set; }
}
