namespace Vaccination_Portal_Backend.Viewmodel
{
    public class VaccinationDriveViewModel
    {
        public int VaccineId { get; set; }

        public string? VaccineName { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public string? Location { get; set; }
    }
}