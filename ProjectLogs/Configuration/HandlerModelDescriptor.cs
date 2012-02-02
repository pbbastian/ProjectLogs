using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuMVC.Validation;
using FubuMVC.Core.Registration;

namespace ProjectLogs.Configuration
{
    public class HandlerModelDescriptor : IFubuContinuationModelDescriptor
    {
        private readonly BehaviorGraph graph;

        public HandlerModelDescriptor(BehaviorGraph graph)
        {
            this.graph = graph;
        }

        public Type DescribeModelFor(ValidationFailure context)
        {
            var targetNamespace = context.Target.HandlerType.Namespace;
            var getCall = graph
                .Behaviors
                .Where(chain => chain.FirstCall() != null && chain.FirstCall().HandlerType.Namespace == targetNamespace
                    && chain.Route.AllowedHttpMethods.Contains("GET"))
                .Select(chain => chain.FirstCall())
                .FirstOrDefault();

            if (getCall == null)
            {
                return null;
            }

            return getCall.InputType();
        }
    }
}