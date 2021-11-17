using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Data;

namespace Infrastructure.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IInteractionRepository _interactionRepository;

        public ClientService(IClientRepository clientRepository, IInteractionRepository interactionRepository)
        {
            _clientRepository = clientRepository;
            _interactionRepository = interactionRepository;
        }

        public async Task<List<ClientResponseModel>> GetClientList()
        {
            var clients = await _clientRepository.ListAllAsync();
            List<ClientResponseModel> clientResponseModels = new List<ClientResponseModel>();
            foreach (var client in clients)
            {
                clientResponseModels.Add( new ClientResponseModel
                    {
                        Id = client.Id,
                        Name = client.Name,
                        Email = client.Email,
                        Phones = client.Phones,
                        Address = client.Address,
                        AddedOn = client.AddedOn
                    }
                    );
            }

            return clientResponseModels;
        }

        public async Task<ClientResponseModel> GetClientDetails(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            var clientDetails = new ClientResponseModel
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Phones = client.Phones,
                Address = client.Address,
                AddedOn = client.AddedOn
            };
            return clientDetails;
        }

        public async Task<ClientResponseModel> AddClient(ClientRequestModel clientRequestModel)
        {
            var client = new Client
            {
                Name = clientRequestModel.Name,
                Email = clientRequestModel.Email,
                Phones = clientRequestModel.Phones,
                Address = clientRequestModel.Address,
                AddedOn = clientRequestModel.AddedOn
            };
            var clientResponse = new ClientResponseModel
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Phones = client.Phones,
                Address = client.Address,
                AddedOn = client.AddedOn
            };
            await _clientRepository.AddAsync(client);
            return clientResponse;
        }

        public async Task<ClientResponseModel> UpdateClientById(int id, ClientRequestModel clientRequestModel)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            client.Name = clientRequestModel.Name;
            client.Email = clientRequestModel.Email;
            client.Phones = clientRequestModel.Phones;
            client.Address = clientRequestModel.Address;
            client.AddedOn = clientRequestModel.AddedOn;

            var clientResponse = new ClientResponseModel
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Phones = client.Phones,
                Address = client.Address,
                AddedOn = client.AddedOn
            };
            await _clientRepository.UpdateAsync(client);
            return clientResponse;
        }

        public async Task DeleteClientById(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            var clientInteractions = await _interactionRepository.GetInteractionByClient(id);
            foreach (var clientInteraction in clientInteractions)
            {
                clientInteraction.ClientId = null;
            }
            await _clientRepository.DeleteAsync(client);
        }
    }
}
