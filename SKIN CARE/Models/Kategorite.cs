using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKIN_CARE.Models
{
    [Table("Kategorite")]
    public class Kategorite
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Emri i kategorise eshte i kerkuar!")]
        [Display(Name = "Emri Kategorise")]
        public string EmriKategorise { get; set; }
        public virtual ICollection<Produktet> Produktet { get; set; }
    }
}