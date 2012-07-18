using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ControleFinanceiro.DAL.Entities
{
    [Table("Categorias")]
    public class Categoria : EntityBase
    {
        [MaxLength(512)]
        public string Nome { get; set; }

        public virtual ICollection<Subcategoria> SubCategorias { get; set; }
    }
}
