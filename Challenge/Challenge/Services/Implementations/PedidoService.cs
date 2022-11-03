using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Challenge.Dto.Response;
using Challenge.Dto.Solicitation;
using Challenge.Interfaces;
using Challenge.Models;
using Challenge.Services.Interfaces;

namespace Challenge.Services.Implementations
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public bool PedidoExists(Guid id)
        {
            return _pedidoRepository.PedidoExists(id);
        }

        public async Task<ICollection<PedidoDto>> ObterListaPedido()
        {
            var completePedidos = await _pedidoRepository.ObterListaPedido();

            var pedidos = _mapper.Map<List<PedidoDto>>(completePedidos);

            foreach (var itensPedidos in completePedidos.Select(x => x.ItensPedidos))
            {
                foreach (var produto in itensPedidos.Select(x => x.Produto))
                {
                    foreach (var pedido in pedidos)
                    {
                        if (produto != null) pedido.ValorTotal += (produto.Valor != null ? produto.Valor.Value : 0);

                        if (pedido.ItensPedidos != null)
                        {
                            foreach (var itemPedido in pedido.ItensPedidos)
                            {
                                if (pedido.ItensPedidos != null && itemPedido.ProdutoId == produto?.ProdutoId)
                                {
                                    itemPedido.NomeProduto = produto?.NomeProduto;
                                    itemPedido.ValorUnitario = produto?.Valor;
                                }
                            }
                        }

                    }
                }
            }

            return pedidos;
        }

        public async Task<PedidoDto> ObterPedido(Guid pedidoId)
        {
            var completePedido = await _pedidoRepository.ObterPedido(pedidoId);

            if (completePedido == null) return null;

            var pedido = _mapper.Map<PedidoDto>(completePedido);

            foreach (var itensPedidos in completePedido.ItensPedidos)
            {
                if (itensPedidos.Produto != null)
                {
                    pedido.ValorTotal += (itensPedidos.Produto.Valor != null ? itensPedidos.Produto.Valor.Value : 0);

                    if (pedido.ItensPedidos != null)
                    {
                        foreach (var itemPedido in pedido.ItensPedidos)
                        {
                            if (pedido.ItensPedidos != null && itemPedido.ProdutoId == itensPedidos.Produto?.ProdutoId)
                            {
                                itemPedido.NomeProduto = itensPedidos.Produto?.NomeProduto;
                                itemPedido.ValorUnitario = itensPedidos.Produto?.Valor;
                            }
                        }
                    }
                }
            }

            return pedido;
        }

        public bool CreatePedido(PedidoSolicitationDto pedido)
        {
            var existPedido = ObterPedido(pedido.PedidoId);

            if (existPedido.Result != null) return false;

            var pedidoMap = _mapper.Map<Pedido>(pedido);

            pedidoMap.DataCriacao = DateTime.Now;

            return _pedidoRepository.CreatePedido(pedidoMap);
        }

        public bool UpdatePedido(PedidoSolicitationDto pedido)
        {            
            var pedidoMap = _mapper.Map<Pedido>(pedido);

            return _pedidoRepository.UpdatePedido(pedidoMap);
        }

        public async Task<bool> DeletePedido(Guid id)
        {
            return await _pedidoRepository.DeletePedido(id);
        }
    }
}
