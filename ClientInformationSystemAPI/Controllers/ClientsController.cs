using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;

namespace ClientInformationSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IInteractionService _interactionService;

        public ClientsController(IClientService clientService, IInteractionService interactionService)
        {
            _clientService = clientService;
            _interactionService = interactionService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _clientService.GetClientList();
            if (clients.Any())
            {
                return Ok(clients);
            }
            return NotFound("Client Not Found");
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetClientDetail(int id)
        {
            var client = await _clientService.GetClientDetails(id);
            if (client != null)
            {
                return Ok(client);
            }
            return NotFound("Client Not Found");
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddClient([FromBody] ClientRequestModel model)
        {
            var newClient = await _clientService.AddClient(model);
            return Ok(newClient);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _clientService.DeleteClientById(id);
            return Ok();
        }

        [HttpPut] 
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] ClientRequestModel model)
        {
            var clientUpdated = await _clientService.UpdateClientById(id, model);
            return Ok(clientUpdated);
        }
    }
}
