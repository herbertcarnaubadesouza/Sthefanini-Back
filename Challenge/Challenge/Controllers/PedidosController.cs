namespace Challenge.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Challenge.Dto.Response;
    using Challenge.Dto.Solicitation;
    using Challenge.Interfaces;
    using Challenge.Models;
    using Challenge.Repository;
    using Challenge.Repository.Implementations;
    using Challenge.Services.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : Controller
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;            
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PedidoDto>))]
        public async Task<IActionResult> ObterListaPedido()
        {
            var pedidos = await _pedidoService.ObterListaPedido();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pedidos);
        }

        [HttpGet("{pedidoId}")]
        [ProducesResponseType(200, Type = typeof(Pedido))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> ObterPedido(Guid pedidoId)
        {
            if (!_pedidoService.PedidoExists(pedidoId))
                return NotFound();

            var pedido = await _pedidoService.ObterPedido(pedidoId);            

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pedido);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePedido([FromBody] PedidoSolicitationDto pedido)
        {
            if (pedido == null)
                return BadRequest(ModelState);

            var pedidoCreated = _pedidoService.CreatePedido(pedido);            

            if (!pedidoCreated)
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NoContent();
        }

        [HttpPut("{pedidoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategory(Guid pedidoId, [FromBody] PedidoSolicitationDto pedido)
        {
            if (pedido == null)
                return BadRequest(ModelState);

            if (pedidoId != pedido.PedidoId)
                return BadRequest(ModelState);


            var pedidoUpdated = _pedidoService.UpdatePedido(pedido);

            if (!pedidoUpdated)
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NoContent();
        }

        [HttpDelete("{pedidoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeletePedido(Guid pedidoId)
        {
            if (!_pedidoService.PedidoExists(pedidoId))
            {
                return NotFound();
            }

            var pedidoToDelete = await _pedidoService.DeletePedido(pedidoId);            

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!pedidoToDelete)
            {
                ModelState.AddModelError("", "Something went wrong deleting pedido");
            }

            return NoContent();
        }
    }
}
