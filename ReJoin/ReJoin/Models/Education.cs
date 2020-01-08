using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ReJoin.Models
{
    public class Education
    {
        [Key]
        public int EducationId { get; set; }

        public string SchoolName { get; set; }

        public string Qualification { get; set; }

        public string PeriodStart { get; set; }

        public string PeriodEnd { get; set; }

        public string Board { get; set; }
    }
}