namespace Challenge.Dto.Response
{
    public class ItensPedidoDto
    {
        public Guid? ItensPedidoId { get; set; }
        public Guid? ProdutoId { get; set; }
        public string? NomeProduto { get; set; }
        public double? ValorUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
