namespace Challenge.Models
{
    public class ItensPedido
    {
        public Guid ItensPedidoId { get; set; }
        public Guid? PedidoId { get; set; }
        public Guid? ProdutoId { get; set; }
        public int? Quantidade { get; set; }

        public virtual Pedido? Pedido { get; set; }
        public virtual Produto? Produto { get; set; }
    }
}
