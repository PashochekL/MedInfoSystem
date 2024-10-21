namespace MedInfoSystem.Data.Entities
{
    public class Diagnosis
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime CreateTime { get; set; }

        public Guid InspectionId { get; set; }
        public Inspection Inspection { get; set; }
    }
}
