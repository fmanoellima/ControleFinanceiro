using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.DAL.Entities
{
    [Table("TiposConta")]
    public class TipoConta : EntityBase
    {
        [MaxLength(512)]
        public string Nome { get; set; }

        public virtual ICollection<Conta> Contas { get; set; }
    }
}
