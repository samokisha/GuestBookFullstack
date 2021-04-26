using System.ComponentModel.DataAnnotations;

namespace GuestBookFullstack.Model
{
    public class NewCommentModel
    {
        [Required]
        public GuestModel Author { get; set; }
        [Required]
        public CommentTypeModel CommentType { get; set; }
        [Required]
        public string Text { get; set; }
    }
}