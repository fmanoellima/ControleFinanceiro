using System;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.DAL.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int ID { get; set; }

        public Guid Usuario { get; set; }

        [MaxLength(512)]
        public string Descricao { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }
    }
}
