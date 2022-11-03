using Challenge.Dto.Response;

namespace Challenge.Dto.Solicitation
{
    public class PedidoSolicitationDto
    {
        public Guid PedidoId { get; set; }
        public string? NomeCliente { get; set; }
        public string? EmailCliente { get; set; }
        public double ValorTotal { get; set; }
        public bool? Pago { get; set; }
    }
}
