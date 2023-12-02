using DomainLayer.Enums;
using DomainLayer.Models;

namespace Booking.com.ViewModels
{
    public class UpdateClubViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public Address Address { get; set; }
        public ClubCategory ClubCategory { get; set; }
    }
}
