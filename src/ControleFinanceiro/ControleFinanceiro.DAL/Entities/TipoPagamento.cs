using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.DAL.Entities
{
    [Table("TiposPagamento")]
    public class TipoPagamento : EntityBase
    {
        [MaxLength(512)]
        public string Nome { get; set; }

        public virtual ICollection<Movimento> Movimentos { get; set; }
    }
}
