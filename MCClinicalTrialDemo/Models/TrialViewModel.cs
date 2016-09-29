using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MCClinicalTrialDemo.Models
{
    public class TrialViewModel
    {
        [Required]
        [Display(Name = "Trial Key")]
        public string TrialKey { get; set; }

        [Required]
        [Display(Name = "Trial Date")]
        public DateTime TrialDate { get; set; }

        [Required]
        [Display(Name = "Research Name")]
        public string ResearchName { get; set; }

        [Required]
        [Display(Name = "Researcher Name")]
        public string ResearcherName { get; set; }

        [Display(Name = "Research On")]
        public string ResearchOn { get; set; }

        [Required]
        [Display(Name = "Observation Details")]
        public string Observation { get; set; }

        /// <summary>
        /// Using this property only to hold and save the uploaded file
        /// </summary>
        [Required]
        [Display(Name = "Document")]
        [JsonIgnore]
        public HttpPostedFileBase Document { get; set; }

        [Display(Name = "Document Url")]
        public string DocumentUrl { get; set; }

        [Display(Name = "Document Hash")]
        public string DocumentHash { get; set; }

    }
}