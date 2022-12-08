using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace geaje.Models
{
    [Table("desa", Schema = "public")]
    public class desaModel
    {
        [Key]
        [Display(Name = "Desa")]
        public int desa_id { get; set; }
        [Display(Name = "Desa")]
        public string desa_name { get; set; }
    }
}