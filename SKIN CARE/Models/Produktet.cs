using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKIN_CARE.Models
{
    [Table("Produktet")]
    public class Produktet
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Emri i produktit kerkohet!")]
        public string Emri { get; set; }
        [Required(ErrorMessage = "Imazhi i produktit kerkohet!")]
        public string Imazhi { get; set; }
        [Required(ErrorMessage = "Pershkrimi i produktit kerkohet!")]
        public string Pershkrimi { get; set; }
        [Required(ErrorMessage = "Cmimi i produktit kerkohet!")]
        [DataType(DataType.Currency)]
        public decimal Cmimi { get; set; }
        [Required(ErrorMessage = "Kategoria e produktit kerkohet!")]
        public int? KategoriID { get; set; }
        public virtual Kategorite Kategorite { get; set; }
        [Required(ErrorMessage = "Marka e produktit kerkohet!")]
        public int MarkaID { get; set; }
        public virtual Markat Markat { get; set; }
    }
}