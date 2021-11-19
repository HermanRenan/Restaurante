using Entities.Notify;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application_.Model
{
    public class PedidoModel : Notifies
    {
        public int PedidoId { get; set; }
        [Display(Name = "Nome do Cliente")]
        public string NomeClient { get; set; }
        [Display(Name = "Mesa do Cliente")]
        public int MesaClient { get; set; }
        [Display(Name = "Data/hora Pedido")]
        [DataType(DataType.DateTime)]        
        public System.DateTime HorarioPedidoFeito { get; set; }
        [Display(Name = "Prazo para realização")]
        public Nullable<int> PrazoExecucao { get; set; }
        [Display(Name = "Status Pedido")]
        public string StatusPedido { get; set; }
        public string StatusCopa { get; set; }
        public string StatusCozinha { get; set; }
        public virtual ICollection<PedidoFechadoModel> PedidoFechado { get; set; }        

    }
}
