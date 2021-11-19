using Aplication_.Interfaces;
using Application_.Model;
using AutoMapper;
using Domain.Interfaces.InterfaceProduct;
using Domainn.Interfaces.InterfaceProduct;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_.Service
{
    public class ServicePedidoFechado : InterfacePedidoFechado
    {
        IPedidoFechado IProduct;
        protected readonly IMapper _mapper;
        public ServicePedidoFechado(IPedidoFechado IProduct, IMapper _mapper)
        {
            this.IProduct = IProduct;
            this._mapper = _mapper;
        }

        public async Task Add(PedidoFechadoModel Object)
        {
            try
            {
                var Document = true;
                var entidade = _mapper.Map<PedidoFechadoModel, PedidoFechado>(Object);

                IProduct.Add(entidade);

                Object.Notitycoes = new List<Entities.Notify.Notifies>();
                Object.Notitycoes = entidade.Notitycoes;
            }
            catch (Exception ex)
            {
                var see = ex.Message;
            }
        }

        public Task Delete(PedidoFechadoModel Object)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoFechadoModel> GetEntityById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PedidoFechadoModel>> List()
        {
            throw new NotImplementedException();
        }

        public List<PedidoFechadoModel> ListaLL()
        {
            throw new NotImplementedException();
        }

        public Task Update(PedidoFechadoModel Object)
        {
            throw new NotImplementedException();
        }
    }
}
