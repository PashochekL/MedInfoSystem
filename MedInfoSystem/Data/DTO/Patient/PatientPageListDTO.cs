using MedInfoSystem.Data.Entities;

namespace MedInfoSystem.Data.DTO.Patient
{
    public class PatientPageListDTO
    {
        public List<PatientGetDTO>? Patients { get; set; }
        public Pagination Pagination { get; set; }
    }
}
