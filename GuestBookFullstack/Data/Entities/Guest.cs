using System;
using System.ComponentModel.DataAnnotations;

namespace GuestBookFullstack.Data.Entities
{
    public class Guest
    {
        public Guid Id { get; set; }
        
        [Required, StringLength(50, MinimumLength = 4)]
        public string Name { get; set; }
        public string CallbackContact { get; set; }
    }
}