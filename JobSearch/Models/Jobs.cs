using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobSearch.Models
{
    public class Jobs
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name ="اسم الوظيفة")]
        public string JobName { get; set; }

        [Required]
        [DisplayName("وصف الظيفة")]
        public string JobDiscription { get; set; }


        [DisplayName("صورة الوظيفة")]
        public string JobImage { get; set; }

        [ForeignKey("categories")]
        [Display(Name ="فئة الوظيفة")]
        public int CategoryId { get; set; }
        public virtual Categories categories { get; set; }
    }
}