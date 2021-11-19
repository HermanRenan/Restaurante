using Application_.Model;
using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication_.Mappers
{
    public class PedidoFechadoMappers : Profile
    {
        public PedidoFechadoMappers()
        {
            CreateMap<PedidoFechado, PedidoFechadoModel>().ReverseMap();
            CreateMap<PedidoFechadoModel, PedidoFechado>().ReverseMap();

            CreateMap<Pedido, PedidoFechadoModel>().ReverseMap();
            CreateMap<PedidoFechadoModel, Pedido>().ReverseMap();

            CreateMap<Pedido, EstoqueModel>().ReverseMap();
            CreateMap<EstoqueModel, Pedido>().ReverseMap();
        }
    }
}
