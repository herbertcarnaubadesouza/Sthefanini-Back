using Challenge.Data;
using Challenge.Models;

namespace Challenge
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {            
            if (!dataContext.Pedidos.Any())
            {
                var pedidoId = Guid.NewGuid();
                var pedidos = new List<Pedido>()
                {
                    new Pedido()
                    {

                        DataCriacao = new DateTime(1903,1,1),
                        EmailCliente = "herbertcarnaubadesouza@gmail.com",
                        NomeCliente = "Herbert",
                        Pago = true,
                        PedidoId = pedidoId,
                        ItensPedidos = new List<ItensPedido>()
                        {
                            new ItensPedido()
                            {
                                ItensPedidoId = Guid.NewGuid(),
                                PedidoId = pedidoId,
                                ProdutoId = Guid.NewGuid(),
                                Quantidade = 10,
                                Produto = new Produto()
                                {
                                    Valor = 20,
                                    ProdutoId = Guid.NewGuid(),
                                    NomeProduto = "Nome de produto",
                                },
                                Pedido = new Pedido()
                                {
                                    DataCriacao = new DateTime(1903,1,1),
                                    EmailCliente = "herbertcarnaubadesouza@gmail.com",
                                    NomeCliente = "Herbert",
                                    Pago = true,
                                    PedidoId = pedidoId,
                                }
                            }
                        },                        
                    },                    
                };
                dataContext.Pedidos.AddRange(pedidos);
                dataContext.SaveChanges();
            }
        }
    }
}
