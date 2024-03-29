﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using ProjectLogs.Configuration;
using Bottles;
using StructureMap;
using Raven.Client.Document;
using Raven.Client;

namespace ProjectLogs
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var documentStore = new DocumentStore() { ConnectionStringName = "RavenDB" };
            var registry = new ProjectLogsRegistry(documentStore);

            // FubuApplication "guides" the bootstrapping of the FubuMVC
            // application
            FubuApplication.For<ProjectLogsFubuRegistry>()
                .StructureMapObjectFactory(x => x.AddRegistry(registry))
                .Bootstrap();

            // Ensure that no errors occurred during bootstrapping
            PackageRegistry.AssertNoFailures();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}