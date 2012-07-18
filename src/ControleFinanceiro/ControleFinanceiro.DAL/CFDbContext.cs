using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Configuration;
using ControleFinanceiro.DAL.Entities;
using System.Data.Entity.Infrastructure;

namespace ControleFinanceiro.DAL
{
    public sealed class CFDbContext: DbContext
    {
        #region DbSets
        
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Subcategoria> Subcategorias { get; set; }
        public DbSet<TipoConta> TiposConta { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Movimento> Movimentos { get; set; }
        public DbSet<TipoPagamento> TiposPagamento { get; set; }

        #endregion

        #region Private Constants

        private const string CONN_STR_NAME = "CFDbContext";

        #endregion

        #region Private Constructors

        private CFDbContext()
		{
			Initialize();
		}
        
		#endregion

        #region Public Static Methods

        public static CFDbContext New()
        {
            return new CFDbContext();
        }

        #endregion

        #region Protected Override Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //descomente esta linha caso queira alterar o modelo utilizando um Database Existente e não queira atualizar a tabela EdmMetaData que o entity framework cria
           // modelBuilder.Conventions.Remove<IncludeMetadataConvention>();

            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region Private Methods

        private void Initialize()
        {
            var connStr = ConfigurationManager.ConnectionStrings[CONN_STR_NAME];

            Database.Connection.ConnectionString = connStr.ConnectionString;


            Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Configuration.ValidateOnSaveEnabled = true;

        }

        #endregion

    }
}
