using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Autofac;
using ControleFinanceiro.CORE.Components;
using ControleFinanceiro.DAL;
using ControleFinanceiro.CORE.Services.Impl;

namespace ControleFinanceiro.CORE.Services
{
    
    public class CategoriaService: ICategoriaService
    {

        #region Private fields

        private Feedback _feed;
        private UnitOfWork _repository;

        #endregion

        #region Constructor

        public CategoriaService()
        {
            _feed = COREConfiguration.Components.Resolve<Feedback>();
            _repository = COREConfiguration.Components.Resolve<UnitOfWork>();
        }

        #endregion

        public Feedback ListarCategorias()
        {
            try
            {
                List<Models.Categoria> listCategorias = Mapper.Map<List<DAL.Entities.Categoria>, List<Models.Categoria>>(_repository.CategoriaRepository.Get().ToList());
                _feed.Output = listCategorias;
                _feed.Status = Feedback.TypeFeedback.Success;
             
            }
            catch (Exception ex) 
            {
                _feed.Status = Feedback.TypeFeedback.Error;
                _feed.Message = new List<string> {ex.Message};
            }
            return _feed;
        }
    }
}
