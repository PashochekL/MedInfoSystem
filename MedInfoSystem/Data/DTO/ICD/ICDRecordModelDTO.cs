namespace MedInfoSystem.Data.DTO.ICD
{
    public class ICDRecordModelDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
