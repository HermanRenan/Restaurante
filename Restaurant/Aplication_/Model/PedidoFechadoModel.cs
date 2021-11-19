using Entities.Notify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_.Model
{
    public class PedidoFechadoModel : Notifies
    {
        public int Id { get; set; }
        public int EstoqueId { get; set; }
        public int PedidoId { get; set; }
        public Nullable<int> QuantidadeItem { get; set; }

        public virtual EstoqueModel Estoque { get; set; }
        public virtual EstoqueModel Pedido { get; set; }
    }
}
