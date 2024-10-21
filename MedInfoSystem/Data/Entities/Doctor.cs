namespace MedInfoSystem.Data.Entities
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreateTime { get; set; }

        public List<Inspection> Inspection { get; set; }

        public Guid SpecialityId { get; set; }
        public Speciality speciality { get; set; }
    }
}
