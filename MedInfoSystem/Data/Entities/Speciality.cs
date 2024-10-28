namespace MedInfoSystem.Data.Entities
{
    public class Speciality
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }

        public List<Consultation> Consultation { get; set; } = new List<Consultation>();
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
