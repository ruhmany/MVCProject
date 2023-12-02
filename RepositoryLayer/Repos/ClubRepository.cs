using DomainLayer.Interfaces;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    public class ClubRepository : IClubRepository<Club>, IClubRepository
    {
        private readonly AppDbContext _appDbContext;
        public ClubRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<Club> GetByIdWithNoTrakingAsync(int id)
        {
            return _appDbContext.Clubs.AsNoTracking().FirstOrDefaultAsync(i=> i.ID == id);
        }
    }
}
