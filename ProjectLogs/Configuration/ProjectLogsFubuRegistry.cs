using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuMVC.Core;
using FubuMVC.Spark;
using FubuMVC.Validation;
using ProjectLogs.Handlers;
using FubuValidation;

namespace ProjectLogs.Configuration
{
    public class ProjectLogsFubuRegistry : FubuRegistry
    {
        public ProjectLogsFubuRegistry()
        {
            // This line turns on the basic diagnostics and request tracing
            IncludeDiagnostics(true);

            // All public methods from concrete classes ending in "Controller"
            // in this assembly are assumed to be action methods
            ApplyHandlerConventions<HandlersMarker>();

            // Policies
            //Routes
            //    .HomeIs<Handlers.Home.GetHandler>(h => h.Execute(new Handlers.Home.HomeRequestModel()));

            this.UseSpark();

            // Match views to action methods by matching
            // on model type, view name, and namespace
            Views
                .TryToAttachWithDefaultConventions()
                .RegisterActionLessViews(t => t.ViewModelType == typeof(Notification));

            this.Validation(validation =>
                {
                    validation
                        .Actions
                        .Include(call => call.HasInput && call.InputType().Name.Contains("Input"));

                    validation
                        .Failures
                        .If(f => f.InputType() != null && f.InputType().Name.Contains("Input"))
                        .TransferBy<HandlerModelDescriptor>();
                });
        }
    }
}