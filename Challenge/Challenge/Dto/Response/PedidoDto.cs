namespace Challenge.Dto.Response
{
    public class PedidoDto
    {
        public Guid PedidoId { get; private set; }
        public string? NomeCliente { get; set; }
        public string? EmailCliente { get; set; }

        public double ValorTotal { get; set; }
        public bool? Pago { get; set; }
        public ICollection<ItensPedidoDto>? ItensPedidos { get; set; } = null;
    }
}
