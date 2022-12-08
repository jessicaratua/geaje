using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace geaje.Models
{
    [Table("admin", Schema = "public")]
    public class adminModel
    {
        [Key]
        public int admin_id { get; set; }
        [Required]
        [Display(Name = "Nama Admin")]
        public string admin_name { get; set; }
        [Display(Name = "Username")]
        public string username { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
        

    }
}