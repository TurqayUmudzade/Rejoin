using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReJoin.Models;

namespace ReJoin.ViewModels
{
    public class JobListViewModel
    {
        public List<JobAd> jobAds { get; set; }
        public CheckBoxes checkBoxes { get; set; }

    }

    public class CheckBoxes {
       public bool checkbox71 { get; set; }
    }
}