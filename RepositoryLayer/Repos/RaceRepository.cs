using DomainLayer.Interfaces;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    public class RaceRepository: IClubRepository<Race>, IRaceRepository
    {
        public RaceRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
