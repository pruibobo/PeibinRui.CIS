using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IInteractionRepository : IAsyncRepository<Interaction>
    {
        Task<IEnumerable<Interaction>> GetInteractionByClientAndEmployee();
        Task<IEnumerable<Interaction>> GetInteractionByClient(int clientId);
        Task<IEnumerable<Interaction>> GetInteractionByEmployee(int employeeId);
    }
}
