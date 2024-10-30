using MedInfoSystem.Data.DTO.Consultations;
using MedInfoSystem.Data.DTO.Diagnosis;
using MedInfoSystem.Data.DTO.Doctor;
using MedInfoSystem.Data.DTO.Patient;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Data.Entities.Enums;

namespace MedInfoSystem.Data.DTO.Inspection
{
    public class InspectionGetDTO
    {
        public Guid Id { get; set; }

        public DateTime CreateTime { get; set; }

        public string Anamnesis { get; set; }

        public string Complaints { get; set; }

        public string Treatment { get; set; }

        public Conclusion Conclusion { get; set; }

        public DateTime? NextVisitDate { get; set; }

        public DateTime? LastVisitDate { get; set; }

        public DateTime? DeathDate { get; set; }

        public Guid? BaseInspectionId { get; set; }

        public Guid? PreviousInspectionId { get; set; }

        public PatientGetDTO Patient { get; set; }

        public DoctorModelDTO Doctor { get; set; }

        public List<DiagnosisGetDTO> Diagnoses { get; set; } = new List<DiagnosisGetDTO>();

        public List<ConsultationGetDTO> Consultations { get; set; } = new List<ConsultationGetDTO>();
    }
}
