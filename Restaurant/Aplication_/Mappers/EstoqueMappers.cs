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
    public class EstoqueMappers : Profile
    {
        public EstoqueMappers()
        {
            CreateMap<Estoque, EstoqueModel>().ReverseMap();
            CreateMap<EstoqueModel, Estoque>().ReverseMap();
        }

    }
}
