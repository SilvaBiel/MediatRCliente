using MediatorCliente.Application.Commands;
using MediatorCliente.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Cliente> _repository;

        public ClienteController(IMediator mediator, IRepository<Cliente> repository) { 
        this ._mediator = mediator;
        this._repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok (await _repository.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.Get(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CadastraClienteCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Put(AlteraClienteCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = new DeletaClienteCommand { ClienteId = id };
            var result = await _mediator.Send(obj);
            return Ok(result);
        }
    }

}
