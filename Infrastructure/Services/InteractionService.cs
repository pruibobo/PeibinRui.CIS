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
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class InteractionService : IInteractionService
    {
        private readonly IInteractionRepository _interactionRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public InteractionService(IInteractionRepository interactionRepository, IClientRepository clientRepository, IEmployeeRepository employeeRepository)
        {
            _interactionRepository = interactionRepository;
            _clientRepository = clientRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<List<InteractionResponseModel>> GetInteractions()
        {
            var interactions = await _interactionRepository.GetInteractionByClientAndEmployee();
            List<InteractionResponseModel> interactionResponseModels = new List<InteractionResponseModel>();
            foreach (var interaction in interactions)
            {
                var model = new InteractionResponseModel();
                model.Id = interaction.Id;
                model.ClientId = interaction.ClientId;
                if (interaction.ClientId != null)
                {
                    model.ClientName = interaction.Client.Name;
                }
                model.EmpId = interaction.EmpId;
                if (interaction.EmpId != null)
                {
                    model.EmployeeName = interaction.Employee.Name;
                }
                model.IntType = interaction.IntType;
                model.IntDate = interaction.IntDate;
                model.Remarks = interaction.Remarks;
                interactionResponseModels.Add(model);
            }
            return interactionResponseModels;
        }

        public async Task<List<InteractionResponseModel>> GetInteractionsByClientId(int clientId)
        {
            var interactions = await _interactionRepository.GetInteractionByClient(clientId);
            List<InteractionResponseModel> interactionList = new List<InteractionResponseModel>();
            foreach (var interaction in interactions)
            {
                var model = new InteractionResponseModel();
                model.Id = interaction.Id;
                model.ClientId = interaction.ClientId;
                if (interaction.ClientId != null)
                {
                    model.ClientName = interaction.Client.Name;
                }
                model.EmpId = interaction.EmpId;
                if (interaction.EmpId != null)
                {
                    model.EmployeeName = interaction.Employee.Name;
                }
                model.IntType = interaction.IntType;
                model.IntDate = interaction.IntDate;
                model.Remarks = interaction.Remarks;
                interactionList.Add(model);
            }
            return interactionList;
        }

        public async Task<List<InteractionResponseModel>> GetInteractionsByEmployeeId(int employeeId)
        {
            var interactions = await _interactionRepository.GetInteractionByEmployee(employeeId);
            List<InteractionResponseModel> interactionList = new List<InteractionResponseModel>();
            foreach (var interaction in interactions)
            {
                var model = new InteractionResponseModel();
                model.Id = interaction.Id;
                model.ClientId = interaction.ClientId;
                if (interaction.ClientId != null)
                {
                    model.ClientName = interaction.Client.Name;
                }
                model.EmpId = interaction.EmpId;
                if (interaction.EmpId != null)
                {
                    model.EmployeeName = interaction.Employee.Name;
                }
                model.IntType = interaction.IntType;
                model.IntDate = interaction.IntDate;
                model.Remarks = interaction.Remarks;
                interactionList.Add(model);
            }
            return interactionList;
        }

        public async Task<InteractionResponseModel> GetInteractionDetail(int id)
        {
            var interaction = await _interactionRepository.GetByIdAsync(id);
            var interactionDetails = new InteractionResponseModel
            {
                Id = interaction.Id,
                ClientId = interaction.ClientId,
                EmpId = interaction.EmpId,
                IntType = interaction.IntType,
                IntDate = interaction.IntDate,
                Remarks = interaction.Remarks
            };
            return interactionDetails;
        }

        public async Task<InteractionResponseModel> AddInteraction(InteractionRequestModel interactionRequestModel)
        {
            var interaction = new Interaction
            {
                ClientId = interactionRequestModel.ClientId,
                EmpId = interactionRequestModel.EmpId,
                IntType = interactionRequestModel.IntType,
                IntDate = interactionRequestModel.IntDate,
                Remarks = interactionRequestModel.Remarks
            };

            var newInteraction = new InteractionResponseModel
            {
                Id = interaction.Id,
                ClientId = interaction.ClientId,
                EmpId = interaction.EmpId,
                IntType = interaction.IntType,
                IntDate = interaction.IntDate,
                Remarks = interaction.Remarks
            };
            await _interactionRepository.AddAsync(interaction);
            return newInteraction;
        }

        public async Task<InteractionResponseModel> UpdateInteraction(int id, InteractionRequestModel interactionRequestModel)
        {
            var interaction = await _interactionRepository.GetByIdAsync(id);
            interaction.ClientId = interactionRequestModel.ClientId;
            interaction.EmpId = interactionRequestModel.EmpId;
            interaction.IntType = interactionRequestModel.IntType;
            interaction.IntDate = interactionRequestModel.IntDate;
            interaction.Remarks = interactionRequestModel.Remarks;

            var updatedInteraction = new InteractionResponseModel
            {
                Id = interaction.Id,
                ClientId = interaction.ClientId,
                EmpId = interaction.EmpId,
                IntType = interaction.IntType,
                IntDate = interaction.IntDate,
                Remarks = interaction.Remarks
            };

            await _interactionRepository.UpdateAsync(interaction);

            return updatedInteraction;
        }

        public async Task DeleteInteraction(int id)
        {
            var interaction = await _interactionRepository.GetByIdAsync(id);
            await _interactionRepository.DeleteAsync(interaction);
        }
    }
}
