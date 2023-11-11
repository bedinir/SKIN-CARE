using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKIN_CARE.Models
{
    [Table("Markat")]
    public class Markat
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Emri i markes eshte i kerkuar!")]
        [Display(Name = "Emri Markes")]
        public string EmriMarkes { get; set; }
        public virtual ICollection<Produktet> Produktet { get; set; }
    }
}