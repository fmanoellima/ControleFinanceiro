using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.DAL.Entities
{
    [Table("Contas")]
    public class Conta : EntityBase
    {
        [MaxLength(512)]
        public string Nome { get; set; }

        [ForeignKey("TipoConta")]
        public int TipoContaID { get; set; }
        public virtual TipoConta TipoConta { get; set; }

        public virtual ICollection<Movimento> Movimentos { get; set; }

    }
}
