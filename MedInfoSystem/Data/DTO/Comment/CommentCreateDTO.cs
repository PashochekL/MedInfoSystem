namespace MedInfoSystem.Data.DTO.Comment
{
    public class CommentCreateDTO
    {
        public string Content { get; set; }
        public Guid ParentId { get; set; }
    }
}
