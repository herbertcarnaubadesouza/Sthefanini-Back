using Challenge.Models;

namespace Challenge.Interfaces
{
    public interface IPedidoRepository
    {
        Task<ICollection<Pedido>> ObterListaPedido();
        Task<Pedido> ObterPedido(Guid id);
        bool CreatePedido(Pedido pedido);
        bool UpdatePedido(Pedido pedido);
        bool PedidoExists(Guid id);
        Task<bool> DeletePedido(Guid id); 
    }

}
