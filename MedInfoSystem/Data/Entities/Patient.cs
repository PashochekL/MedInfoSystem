namespace MedInfoSystem.Data.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public DateTime CreateTime { get; set; }

        public List<Inspection> Inspection { get; set; }
    }
}
