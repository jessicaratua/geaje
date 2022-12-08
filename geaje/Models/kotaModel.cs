using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace geaje.Models
{
    [Table("kota", Schema = "public")]
    public class kotaModel
    {
        [Key]
        [Display(Name = "Kota")]
        public int kota_id { get; set; }
        [Display(Name = "Kota")]
        public string kota_name { get; set; }
    }
}