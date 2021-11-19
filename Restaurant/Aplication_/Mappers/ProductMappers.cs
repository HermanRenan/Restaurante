using Application_.Model;
using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application_.Mappers
{
    public class ProductMappers : Profile
    {
        public ProductMappers()
        {
            CreateMap<Pedido, PedidoModel>().ReverseMap();
            CreateMap<PedidoModel, Pedido>().ReverseMap();
        }
    }
}
