using Domain.Interfaces.InterfaceProduct;
using Entities;
using LayerDataBase.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace infrastructure.Repository.Repositories
{
    public class RepositoryPedido : BaseRepository<Pedido>, IPedido
    {
    }
}
