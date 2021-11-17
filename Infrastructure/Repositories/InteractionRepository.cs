using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class InteractionRepository : EfRepository<Interaction> , IInteractionRepository
    {
        public InteractionRepository(ClientInformationSystemDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Interaction>> GetInteractionByClientAndEmployee()
        {
            return await _dbContext.Interactions.Include(i => i.Client).Include(i => i.Employee).ToListAsync();
        }

        public async Task<IEnumerable<Interaction>> GetInteractionByClient(int clientId)
        {
            return await _dbContext.Interactions.Where(i => i.ClientId == clientId).Include(i => i.Client)
                .Include(i => i.Employee).ToListAsync();
        }

        public async Task<IEnumerable<Interaction>> GetInteractionByEmployee(int employeeId)
        {
            return await _dbContext.Interactions.Where(i => i.EmpId == employeeId).Include(i => i.Client)
                .Include(i => i.Employee).ToListAsync();
        }
    }
}
