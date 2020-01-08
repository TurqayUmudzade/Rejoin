using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ReJoin.Models
{
    public class WorkExprience
    {

        [Key]
        public int WorkXPId { get; set; }

        public string CompanyName { get; set; }

        public string Position { get; set; }

        public string PeriodStart { get; set; }

        public string PeriodEnd { get; set; }
    }
}