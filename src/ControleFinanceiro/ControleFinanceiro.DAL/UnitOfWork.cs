using System;
using ControleFinanceiro.DAL.Entities;

namespace ControleFinanceiro.DAL
{
    public class UnitOfWork : IDisposable
    {
        #region Private Objects
        private readonly CFDbContext _context = CFDbContext.New();
        private GenericRepository<Categoria>                    _categoriaRepository;
        private GenericRepository<Conta>                        _contaRepository;
        private GenericRepository<Movimento>                    _movimentoRepository;
        private GenericRepository<Subcategoria>                 _subCategoriaRepository;
        private GenericRepository<TipoConta>                    _tipoContaRepository;
        private GenericRepository<TipoPagamento>                _tipoPagamentoRepository;

        #endregion

        #region Public Repositories

        public GenericRepository<Categoria> CategoriaRepository
        {
            get { return _categoriaRepository ?? (_categoriaRepository = new GenericRepository<Categoria>(_context)); }
        }

        public GenericRepository<Conta> ContaRepository
        {
            get { return _contaRepository ?? (_contaRepository = new GenericRepository<Conta>(_context)); }
        }

        public GenericRepository<Movimento> MovimentoRepository
        {
            get { return _movimentoRepository ?? (_movimentoRepository = new GenericRepository<Movimento>(_context)); }
        }

        public GenericRepository<Subcategoria> SubcategoriaRepository
        {
            get {
                return _subCategoriaRepository ??
                       (_subCategoriaRepository = new GenericRepository<Subcategoria>(_context));
            }
        }

        public GenericRepository<TipoConta> TipoContaRepository
        {
            get { return _tipoContaRepository ?? (_tipoContaRepository = new GenericRepository<TipoConta>(_context)); }
        }

        public GenericRepository<TipoPagamento> TipoPagamentoRepository
        {
            get {
                return _tipoPagamentoRepository ??
                       (_tipoPagamentoRepository = new GenericRepository<TipoPagamento>(_context));
            }
        }

        #endregion

        #region Public Methods

        public void Save()
        {
            _context.SaveChanges();
        }


        #endregion

        #region Dispose

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
