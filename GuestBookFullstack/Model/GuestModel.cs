using System.ComponentModel.DataAnnotations;

namespace GuestBookFullstack.Model
{
    public class GuestModel
    {
        [Required, StringLength(50, MinimumLength = 4)]
        public string Name { get; set; }
        public string CallbackContact { get; set; }
    }
}