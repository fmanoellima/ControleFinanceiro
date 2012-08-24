using System.Data.Entity;

namespace ControleFinanceiro.DAL
{
    public static class DALConfiguration
    {
        public static void Configure()
        {
            Database.SetInitializer<CFDbContext>(new DbInitializer());
        }
    }
}
