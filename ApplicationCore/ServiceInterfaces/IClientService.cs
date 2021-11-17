using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IClientService
    {
        Task<List<ClientResponseModel>> GetClientList();
        Task<ClientResponseModel> GetClientDetails(int id);
        Task<ClientResponseModel> AddClient(ClientRequestModel clientRequestModel);
        Task<ClientResponseModel> UpdateClientById(int id, ClientRequestModel clientRequestModel);
        Task DeleteClientById(int id);

    }
}
