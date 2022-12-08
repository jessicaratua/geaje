using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace geaje.Models
{
    [Table("venue", Schema = "public")]
    public class venueModel
    {
        [Key]
        [Display(Name = "Venue")]
        public int venue_id { get; set; }
        [Required]
        [Display(Name = "Venue")]
        public string venue_name { get; set; }
        [Display(Name = "Kota")]
        [ForeignKey("kotaModel")]
        public int id_kota { get; set; }
        public kotaModel? kotaModel { get; set; }
        [Display(Name = "Kecamatan")]
        [ForeignKey("kecModel")]
        public int id_kec { get; set; }
        public kecModel? kecModel { get; set; }
        [Display(Name = "Desa")]
        [ForeignKey("desaModel")]
        public int id_desa { get; set; }
        public desaModel? desaModel { get; set; }
        [Display(Name = "Alamat")]
        public string alamat { get; set; }
        [Display(Name = "Deskripsi Venue")]
        public string deskripsi { get; set; }
        [Display(Name = "Harga /hari")]
        public int harga { get; set; }
    }
}