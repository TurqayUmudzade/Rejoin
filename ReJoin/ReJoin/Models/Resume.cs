using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ReJoin.Models
{
    public class Resume
    {
        [Key]
        [Required]
        public int ResumeID { get; set; }

        //Personal Date
        [MaxLength(100)]
        public string Fullname { get; set; }

        [MaxLength(100)]
        public string JobProfession { get; set; }

        public int ExprienceYear { get; set; }

        public int ExprienceMonth { get; set; }

        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        public string Picture { get; set; }

        [NotMapped]
        public HttpPostedFileBase UploadProfilePicture { get; set; }



        //Education Work

        public List<Education> Educations { get; set; }

        public List<WorkExprience> WorkExpriences { get; set; }

        //skills

        public List<string> ProfessionalSkills { get; set; }

        [MaxLength(250)]
        public string PersonalSkill { get; set; }

        [NotMapped]
        public HttpPostedFileBase UploadResume { get; set; }

    }
}