﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReJoin.Models
{
    public class JobAd
    {
        [Key]
        [Required]
        public int JobID { get; set; }

        [Required]
        [MaxLength(50)]
        public string JobTitle { get; set; }

        [Required]
        [MaxLength(50)]
        public string JobType { get; set; }

        [Required]
        [MaxLength(50)]
        public string JobRole { get; set; }

        [Required]

        public int SalaryMin { get; set; }

        [Required]

        public int SalaryMax { get; set; }

        [Required]

        public int Exprience { get; set; }

        [Required]
        [MaxLength(100)]
        public string Eligibility { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }


        //Req Details
        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }



        public string picture { get; set; }
        [Required]
        [MaxLength(100)]
        public string RecruiterEmail { get; set; }
        [Required]
        [MaxLength(100)]
        public string RecruiterPhoneNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string RecruiterAdress { get; set; }



        public int? PostUserID { get; set; }

       
        public User User{ get; set; }

        public DateTime CreatedAt { get; set; }




    }
}