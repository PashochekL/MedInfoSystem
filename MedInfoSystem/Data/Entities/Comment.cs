namespace MedInfoSystem.Data.Entities
{
    public class Comment
    {
        public Guid ID { get; set; }
        public Guid? ParentId { get; set; }
        public string Content { get; set; }

        public Guid AuthorId { get; set; }
        public Doctor Author { get; set; }

        public Guid ConsultationId { get; set; }
        public Consultation Consultation { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
    }
}
