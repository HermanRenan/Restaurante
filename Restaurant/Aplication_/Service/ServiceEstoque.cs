using Aplication_.Interfaces;
using Application_.Interfaces;
using Application_.Model;
using AutoMapper;
using Domainn.Interfaces.InterfaceProduct;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_.Service
{
    public class ServiceEstoque : InterfaceEstoque
    {
        IEstoque IProduct;
        protected readonly IMapper _mapper;
        public ServiceEstoque(IEstoque IProduct, IMapper _mapper)
        {
            this.IProduct = IProduct;
            this._mapper = _mapper;
        }
        public async Task Add(EstoqueModel product)
        {
            try
            {
                var Document = true;
                var entidade = _mapper.Map<EstoqueModel, Estoque>(product);

                IProduct.Add(entidade);

                product.Notitycoes = new List<Entities.Notify.Notifies>();
                product.Notitycoes = entidade.Notitycoes;
            }
            catch (Exception ex)
            {
                var see = ex.Message;

            }
        }

        public async Task Delete(EstoqueModel Object)
        {
            IProduct.DeleteById(Object.EstoqueId);
        }

        public async Task<EstoqueModel> GetEntityById(int Id)
        {
            var entidade = this.IProduct.GetById(Id);
            return _mapper.Map<EstoqueModel>(entidade);
        }

        public async Task<List<EstoqueModel>> List()
        {
            var listaEntidades = this.IProduct.GetAll();
            var entidade = _mapper.Map<List<EstoqueModel>>(listaEntidades);
            return entidade;
        }

        public async Task Update(EstoqueModel product)
        {
            var entidade = _mapper.Map<Estoque>(product);

            IProduct.Update(entidade);
        }

        public List<EstoqueModel> ListaLL()
        {
            var listaEntidades = this.IProduct.GetAll();
            var entidade = _mapper.Map<List<EstoqueModel>>(listaEntidades);
            return entidade;
        }
    }
}
