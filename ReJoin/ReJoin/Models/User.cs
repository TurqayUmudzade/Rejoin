using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReJoin.Models
{
    public class User
    {
        [Key]
        [Required]
        public int UserID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Fullname { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [MaxLength(100)]
        public string Token { get; set; }

        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [MaxLength(100)]
        public string Adress { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string PostolZipCode { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(500)]
        public string AboutMe{ get; set; }

        public string picture { get; set; }

        [MaxLength(50)]
        public string FacebookLink { get; set; }

        [MaxLength(50)]
        public string TwitterLink { get; set; }

        [MaxLength(50)]
        public string GoogleLink { get; set; }

        [MaxLength(50)]
        public string PinteresLink { get; set; }

        public Resume Resume { get; set; }

        public List<JobAd> MyPublishedJobs { get; set; }

        [NotMapped]
        public HttpPostedFileBase Upload { get; set; }

        
    }
}