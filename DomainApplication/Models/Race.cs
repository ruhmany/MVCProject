using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Race
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [ForeignKey(nameof(Address))]
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }
        public RaceCategory RaceCategory { get; set; }
        [ForeignKey(nameof(AppUser))]
        public string UserID { get; set; }
        public AppUser User { get; set; }
    }
}
