using System.ComponentModel.DataAnnotations;

namespace GuestBookFullstack.Model
{
    public class NewCommentModel
    {
        [Required]
        public GuestModel Author { get; set; }
        
        [Required]
        public CommentTypeModel CommentType { get; set; }
        
        [Required, StringLength(500, MinimumLength = 20)]
        public string Text { get; set; }
    }
}