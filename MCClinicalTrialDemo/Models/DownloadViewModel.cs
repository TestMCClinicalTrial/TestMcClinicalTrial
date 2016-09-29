using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MCClinicalTrialDemo.Models
{
    public class DownloadViewModel
    {
        [Required]
        [Display(Name = "Trial Key")]
        public string TrialKey { get; set; }
        [Required]
        [Display(Name = "Download Date")]
        public DateTime DownloadDate { get; set; }
        [Required]
        [Display(Name = "Downloader Name")]
        public string DownloaderName { get; set; }
    }
}