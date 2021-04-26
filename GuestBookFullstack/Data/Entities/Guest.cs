using System;
using System.ComponentModel.DataAnnotations;

namespace GuestBookFullstack.Data.Entities
{
    public class Guest
    {
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string CallbackContact { get; set; }
    }
}