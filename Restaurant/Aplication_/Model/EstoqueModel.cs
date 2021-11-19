using Entities.Notify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_.Model
{
    public class EstoqueModel : Notifies
    {
        public int EstoqueId { get; set; }
        public string Produto { get; set; }
        public string Quantidade { get; set; }
        public Nullable<bool> EBebida { get; set; }
        public Nullable<bool> EComida { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public System.DateTime DataUltimaAtualização { get; set; }                
        public virtual ICollection<PedidoFechadoModel> PedidoFechado { get; set; }
    }
}
