using System;
using System.ComponentModel.DataAnnotations;

namespace GuestBookFullstack.Data.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        
        [Required]
        public Guid AuthorId { get; set; }
        
        [Required]
        public Guest Author { get; set; }
        public CommentType CommentType { get; set; }
        
        [Required]
        public string Text { get; set; }
        
        [Required]
        public DateTime? CreatedAt { get; set; }
        public bool Resolved { get; set; }
    }
}