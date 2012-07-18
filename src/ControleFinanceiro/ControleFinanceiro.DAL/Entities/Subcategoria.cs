using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ControleFinanceiro.DAL.Entities
{
    [Table("SubCategorias")]
    public class Subcategoria : EntityBase
    {
        [MaxLength(512)]
        public string Nome { get; set; }

        public bool Favorito { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<Movimento> Movimentos { get; set; }
    }
}
