using Application_.Model;
using Application_.Interfaces;
using AutoMapper;
using Domain.Interfaces.InterfaceProduct;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_.Service
{
    public class ServicePedido : InterfaceAppProduct
    {
        IPedido IProduct;
        protected readonly IMapper _mapper;
        public ServicePedido(IPedido IProduct, IMapper _mapper)
        {
            this.IProduct = IProduct;
            this._mapper = _mapper;
        }
        public async Task Add(PedidoModel product)
        {
            try
            {
                var Document = true;
                var entidade = _mapper.Map<PedidoModel, Pedido>(product);

                IProduct.Add(entidade);

                product.Notitycoes = new List<Entities.Notify.Notifies>();
                product.Notitycoes = entidade.Notitycoes;
            }
            catch (Exception ex)
            {
                var see = ex.Message;

            }
        }

        public async Task Delete(PedidoModel Object)
        {
            if (String.IsNullOrEmpty(Object.NomeClient) && (Object.MesaClient != 0))
            {
                var entidade = _mapper.Map<Pedido>(Object);
                IProduct.Delete(entidade);
            }
            else
            {
                IProduct.DeleteById(Object.PedidoId);
            }
        }

        public async Task<PedidoModel> GetEntityById(int Id)
        {
            var entidade = this.IProduct.GetById(Id);
            return _mapper.Map<PedidoModel>(entidade);
        }

        public async Task<List<PedidoModel>> List()
        {
            var listaEntidades = this.IProduct.GetAll(null, "PedidoFechado");
            var entidade = _mapper.Map<List<PedidoModel>>(listaEntidades);
            return entidade;
        }

        public async Task Update(PedidoModel product)
        {
            var entidade = _mapper.Map<Pedido>(product);

            //var validName = entidade.ValidarPropriedadeString(product.Name, "Name");
            //var validprice = entidade.ValidarPropriedadeDecimal(product.Price, "Price");

            IProduct.Update(entidade);
        }

        public List<PedidoModel> ListaLL()
        {
            var listaEntidades = this.IProduct.GetAll();
            var entidade = _mapper.Map<List<PedidoModel>>(listaEntidades);
            return entidade;
        }
    }
}
