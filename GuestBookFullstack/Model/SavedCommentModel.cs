using System;

namespace GuestBookFullstack.Model
{
    public class SavedCommentModel
    {
        public Guid Id { get; set; }
        public GuestModel Author { get; set; }
        public CommentTypeModel CommentType { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Text { get; set; }
    }
}