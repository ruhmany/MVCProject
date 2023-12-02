using DomainLayer.Enums;
using DomainLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.com.ViewModels
{
    public class CreateClubViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        /*[ForeignKey(nameof(Address))]*/
        //public int AddressID { get; set; }
        public Address Address { get; set; }
        public ClubCategory ClubCategory { get; set; }
    }
}
