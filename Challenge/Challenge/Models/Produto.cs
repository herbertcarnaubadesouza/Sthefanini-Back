namespace Challenge.Models
{
    public class Produto
    {
        public Produto()
        {
            ItensPedidos = new HashSet<ItensPedido>();
        }

        public Guid ProdutoId { get;  set; }
        public string? NomeProduto { get; set; }
        public double? Valor { get; set; }

        public virtual ICollection<ItensPedido> ItensPedidos { get; set; }
    }
}
