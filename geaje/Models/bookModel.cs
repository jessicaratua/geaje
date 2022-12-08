using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace geaje.Models
{
    [Table("booking", Schema = "public")]
    public class bookModel
    {
        [Key]
        public int booking_id { get; set; }
        [Required]
        [Display(Name ="Nama Customer")]
        public string customer_name { get; set; }
        [Display(Name = "Venue")]
        [ForeignKey("venueModel")]
        public int id_venue { get; set; }
        public venueModel? venueModel { get; set; }
        [Display(Name = "Tanggal Booking")]
        public DateTime tanggal_book { get; set; }
        [Display(Name = "Lama Booking (Hari)")]
        public int lama_book { get; set; }
        [Display(Name = "No Hp")]
        public string no_hp { get; set; }

    }
}