using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using StructureMap.Configuration.DSL;
using FubuValidation.StructureMap;
using Raven.Client;

namespace ProjectLogs.Configuration
{
    public class ProjectLogsRegistry : Registry
    {
        public ProjectLogsRegistry(IDocumentStore documentStore)
        {
            For<IDocumentStore>().Singleton().Use(documentStore);
            For<IDocumentSession>().HttpContextScoped().Use(context => context.GetInstance<IDocumentStore>().OpenSession());

            Scan(x =>
            {
                x.TheCallingAssembly();
                x.WithDefaultConventions();
            });

            this.FubuValidation();
        }
    }
}