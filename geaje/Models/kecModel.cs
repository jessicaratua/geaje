using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace geaje.Models
{
    [Table("kec", Schema = "public")]
    public class kecModel
    {
        [Key]
        [Display(Name = "Kecamatan")]
        public int kec_id { get; set; }
        [Display(Name = "Kecamatan")]
        public string kec_name  { get; set; }

    }
}