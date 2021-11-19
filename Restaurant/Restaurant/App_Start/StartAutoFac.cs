using Aplication_.Interfaces;
using Aplication_.Mappers;
using Application_.Interfaces;
using Application_.Mappers;
using Application_.Service;
using Autofac;
using AutoMapper;
using Domain.Interfaces.InterfaceProduct;
using Domainn.Interfaces.InterfaceProduct;
using infrastructure.Repository.Repositories;
using Infrastructuree.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Restaurant.App_Start
{
    public class StartAutoFac
    {
        public Autofac.IContainer container { get; set; }
        public void OnStartup()
        {
            var builder = new ContainerBuilder();            
            
            builder.RegisterType<ServicePedido>();
            builder.RegisterType<ServiceEstoque>();
            builder.RegisterType<ServicePedidoFechado>();
                        
            builder.RegisterType<ServicePedido>().As<InterfaceAppProduct>();
            builder.RegisterType<ServiceEstoque>().As<InterfaceEstoque>();
            builder.RegisterType<ServicePedidoFechado>().As<InterfacePedidoFechado>();


            builder.RegisterType<RepositoryPedido>().As<IPedido>();
            builder.RegisterType<RepositoryPedidoFechado>().As<IPedidoFechado>();
            builder.RegisterType<RepositoryEstoque>().As<IEstoque>();

            RegisterMaps(builder);
            
            container = builder.Build();

        }

        private static void RegisterMaps(ContainerBuilder builder)
        {
            var assemblyNames = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            var assembliesTypes = assemblyNames
                .Where(a => a.Name.Equals("Com.Davidsekar.Models", StringComparison.OrdinalIgnoreCase))
                .SelectMany(an => Assembly.Load(an).GetTypes())
                .Where(p => typeof(Profile).IsAssignableFrom(p) && p.IsPublic && !p.IsAbstract)
                .Distinct();

            var autoMapperProfiles = assembliesTypes
                .Select(p => (Profile)Activator.CreateInstance(p)).ToList();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {

                //Add here the news Mappers
                cfg.AddProfile(new EstoqueMappers());
                cfg.AddProfile(new ProductMappers());
                cfg.AddProfile(new PedidoFechadoMappers());


                foreach (var profile in autoMapperProfiles)
                {
                    cfg.AddProfile(profile);
                }
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();            
        }
    }
}