using System.ComponentModel.DataAnnotations;

namespace GuestBookFullstack.Model
{
    public class GuestModel
    {
        [Required]
        public string Name { get; set; }
        public string CallbackContact { get; set; }
    }
}