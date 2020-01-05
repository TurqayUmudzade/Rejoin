using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ReJoin.Models
{
    public class ContactInfo
    {
        [Key]
        public int ContactInfoID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(250)]
        public string Message { get; set; }

    }
}