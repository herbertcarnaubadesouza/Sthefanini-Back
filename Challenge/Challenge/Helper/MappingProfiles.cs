using AutoMapper;
using Challenge.Dto.Response;
using Challenge.Dto.Solicitation;
using Challenge.Models;

namespace Challenge.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {            
            CreateMap<Pedido, PedidoDto>();
            CreateMap<PedidoSolicitationDto, Pedido>();
            CreateMap<ItensPedido, ItensPedidoDto>();
        }
    }
}
