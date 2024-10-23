namespace MedInfoSystem.Data.Entities
{
    public class Speciality
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }

        //List<Consultation> Consultation { get; set; }
        //List<Doctor> doctors { get; set; }
    }
}
