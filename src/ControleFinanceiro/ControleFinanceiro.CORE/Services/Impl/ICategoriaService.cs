using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControleFinanceiro.CORE.Components;
using ControleFinanceiro.CORE.Models;

namespace ControleFinanceiro.CORE.Services.Impl
{
    public interface ICategoriaService
    {
        Feedback ListarCategorias();
    }
}
