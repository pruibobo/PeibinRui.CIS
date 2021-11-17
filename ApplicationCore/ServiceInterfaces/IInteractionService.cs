using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IInteractionService
    {
        Task<List<InteractionResponseModel>> GetInteractions();
        Task<List<InteractionResponseModel>> GetInteractionsByClientId(int clientId);
        Task<List<InteractionResponseModel>> GetInteractionsByEmployeeId(int employeeId);
        Task<InteractionResponseModel> GetInteractionDetail(int id);
        Task<InteractionResponseModel> AddInteraction(InteractionRequestModel interactionRequestModel);
        Task<InteractionResponseModel> UpdateInteraction(int id, InteractionRequestModel interactionRequestModel);
        Task DeleteInteraction(int id);
    }
}
