namespace MedInfoSystem.Data.Entities
{
    public class Consultation
    {
        public Guid Id { get; set; }

        public Guid InspectionId { get; set; }
        public Inspection Inspection { get; set; }

        public Guid SpecialityId { get; set; }
        public Speciality Speciality { get; set; }

        public List<Comment> RootComment { get; set; } = new List<Comment>();

        public int CommentsNumber { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
