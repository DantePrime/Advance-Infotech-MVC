using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IP_App.Models
{
    public class Plan_Details
    {
        [Required]
        public int Plan_ID { get; set; }
        [Required]
        [Display(Name ="Plan")]
        public string Plan_Name { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        public Nullable<int> Amount { get; set; }
        [Required]
        [Display(Name = "FUP(in GB)")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        public Nullable<int> Usage_Limit { get; set; }
        [Required]
        [Display(Name = "Speed(in Mbps)")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        public Nullable<int> Speed { get; set; }
        [Required]
        [Display(Name = "Renewal Duration(in Days)")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        public Nullable<int> Renewal_Duration { get; set; }

        [Required]
        [Display(Name = "Additional Subscriptions")]
        public string Subscriptions_Included { get; set; }
        [Required]
        [Display(Name = "Type(Prepaid/Postpaid)")]
        public string Plan_Type { get; set; }
        [Required]
        [Display(Name = "Installation Charges")]
        public Nullable<int> Installation_Charges { get; set; }
    }
}