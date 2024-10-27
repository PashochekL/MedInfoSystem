namespace MedInfoSystem.Data.DTO.ICD
{
    public class ICDRecordModelDTO
    {
        public Guid ID { get; set; }
        public DateTime CreateTime { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
