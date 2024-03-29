﻿using EndProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models.AllTourInfo
{
    public class TourDay:BaseNameEntity
    {
        public int TourId { get; set; }
        public  Tour? Tour { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public ICollection<TourDaysImage>? TourDaysImages { get; set; }
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }


    }
}
