using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;

namespace ClientInformationSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InteractionsController : ControllerBase
    {
        private readonly IInteractionService _interactionService;

        public InteractionsController(IInteractionService interactionService)
        {
            _interactionService = interactionService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllInteractions()
        {
            var interactions = await _interactionService.GetInteractions();
            if (interactions.Any())
            {
                return Ok(interactions);
            }

            return NotFound("Interactions Not Found.");
        }

        [HttpGet]
        [Route("client/{id:int}")]
        public async Task<IActionResult> GetInterActionsByClient(int clientId)
        {
            var interactions = await _interactionService.GetInteractionsByClientId(clientId);
            if (interactions.Any())
            {
                return Ok(interactions);
            }

            return NotFound("Interactions with the specific Client Id Not Found.");
        }

        [HttpGet]
        [Route("employee/{id:int}")]
        public async Task<IActionResult> GetInteractionsByEmployee(int empId)
        {
            var interactions = await _interactionService.GetInteractionsByEmployeeId(empId);
            if (interactions.Any())
            {
                return Ok(interactions);
            }

            return NotFound("Interactions with the specific Employee Id Not Found.");
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetInteractionDetails(int id)
        {
            var interaction = await _interactionService.GetInteractionDetail(id);
            if (interaction != null)
            {
                return Ok(interaction);
            }

            return NotFound("Interaction with the Specific Interaction Id Not Found");
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddInteraction([FromBody] InteractionRequestModel model)
        {
            var interaction = await _interactionService.AddInteraction(model);
            return Ok(interaction);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateInteraction(int id, [FromBody] InteractionRequestModel model)
        {
            var interaction = await _interactionService.UpdateInteraction(id, model);
            return Ok(interaction);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteInteraction(int id)
        {
            await _interactionService.DeleteInteraction(id);
            return Ok();
        }
    }
}
