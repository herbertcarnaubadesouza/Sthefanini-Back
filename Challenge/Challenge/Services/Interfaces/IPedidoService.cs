using Microsoft.AspNetCore.Mvc;
using Challenge.Dto.Response;
using Challenge.Dto.Solicitation;
using Challenge.Models;

namespace Challenge.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<ICollection<PedidoDto>> ObterListaPedido();
        Task<PedidoDto> ObterPedido(Guid pedidoId);
        bool CreatePedido(PedidoSolicitationDto pedido);
        bool UpdatePedido(PedidoSolicitationDto pedido);
        bool PedidoExists(Guid id);
        Task<bool> DeletePedido(Guid id);
    }
}
