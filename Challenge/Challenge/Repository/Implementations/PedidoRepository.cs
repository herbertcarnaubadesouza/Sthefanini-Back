using Microsoft.EntityFrameworkCore;
using Challenge.Data;
using Challenge.Interfaces;
using Challenge.Models;

namespace Challenge.Repository.Implementations
{
    public class PedidoRepository : IPedidoRepository
    {
        private DataContext _context;
        public PedidoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Pedido>> ObterListaPedido()
        {
            return await _context.Pedidos.Include(x => x.ItensPedidos).ThenInclude(x => x.Produto).ToListAsync();
        }

        public async Task<Pedido> ObterPedido(Guid id)
        {
            return await _context.Pedidos.Include(x => x.ItensPedidos).ThenInclude(x => x.Produto).ThenInclude(x => x.ItensPedidos).Where(x => x.PedidoId == id).FirstOrDefaultAsync();
        }

        public bool PedidoExists(Guid id)
        {
            return _context.Pedidos.Any(c => c.PedidoId == id);
        }

        public bool CreatePedido(Pedido pedido)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            _context.Add(pedido);
            return Save();
        }

        public bool UpdatePedido(Pedido pedido)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            _context.Update(pedido);
            return Save();
        }

        private bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task<bool> DeletePedido(Guid id)
        {
            var pedido = await _context.Pedidos.Where(x => x.PedidoId == id).FirstOrDefaultAsync();

            if (pedido == null) return false;

            _context.Pedidos.Remove(pedido);
            return Save();

        }
    }
}
