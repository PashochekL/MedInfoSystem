﻿namespace MedInfoSystem.Data.DTO.Comment
{
    public class CommentGetDTO
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public string Author { get; set; }
        public Guid? ParentId { get; set; }
    }
}
