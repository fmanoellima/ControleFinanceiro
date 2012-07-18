using System.Reflection;
using AutoMapper;
using Autofac;
using Castle.Components.Validator;
using ControleFinanceiro.CORE.Components;
using ControleFinanceiro.DAL;
using System.Data.Entity;

namespace ControleFinanceiro.CORE
{
    public static class ConfigureAplication
    {
        public static IContainer Components { get; private set; }

        #region Protected Methods
        

        public static void Configure()
        {
            Database.SetInitializer<CFDbContext>(new DbInitializer());
            //Mapeando as Entidades para Modelos
            ModelMapping();


            ConfigureIOC();
        }
      
        private static void ModelMapping()
        {
            Mapper.CreateMap<DAL.Entities.EntityBase, Models.ModelBase>();
            Mapper.CreateMap<DAL.Entities.Categoria, Models.Categoria>();
            Mapper.CreateMap<DAL.Entities.Subcategoria, Models.Subcategoria>();
            Mapper.CreateMap<DAL.Entities.Movimento, Models.Movimento>();
            Mapper.CreateMap<DAL.Entities.Conta, Models.Conta>();
            Mapper.CreateMap<DAL.Entities.TipoConta, Models.TipoConta>();
            Mapper.CreateMap<DAL.Entities.TipoPagamento, Models.TipoPagamento>();
            Mapper.AssertConfigurationIsValid();
        }


        private static void ConfigureIOC()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());

            builder.RegisterType<ValidatorRunner>().As<IValidatorRunner>().SingleInstance();
            builder.RegisterType<CachedValidationRegistry>().As<IValidatorRegistry>().SingleInstance();

            builder.Register(u => new UnitOfWork()).InstancePerLifetimeScope();
            builder.Register(u => new Feedback()).InstancePerDependency();

            Components = builder.Build();
            
        }
        
        #endregion
    }
}
