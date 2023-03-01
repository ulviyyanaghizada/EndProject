using EndProject.Models.AllTourInfo;
using EndProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models
{
    public class Booking:BaseEntity
    {

        
        public int? TrekkingId { get; set; }
        public int TourId { get; set; }

        [StringLength(60)]
        public string FullName { get; set; }

        [StringLength(40)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phones { get; set; }
        public int guestNumber { get; set; }

        public DateTime date { get; set; }

        public bool IsComfirm { get; set; } = false;


        public Tour? Tour { get; set; }

        public Trekking? Trekking { get; set; }

    }
}
