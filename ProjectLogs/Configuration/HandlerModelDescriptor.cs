using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuMVC.Validation;
using FubuMVC.Core.Registration;
using ProjectLogs.Infrastructure.Common;
using FubuMVC.Core.Registration.Nodes;

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
            ActionCall getCall;
            var attributes = context.Target.Method.GetCustomAttributes(false);
            var handler = context.Target.Method.GetCustomAttributes(false).OfType<ValidationHandlerAttribute>().FirstOrDefault();

            if (handler != null)
            {
                getCall = graph
                    .Behaviors
                    .Where(chain => chain.FirstCall() != null && chain.FirstCall().InputType() == handler.InputType)
                    .Select(chain => chain.FirstCall())
                    .FirstOrDefault();
            }
            else
            {
                var targetNamespace = context.Target.HandlerType.Namespace;
                getCall = graph
                    .Behaviors
                    .Where(chain => chain.FirstCall() != null && chain.FirstCall().HandlerType.Namespace == targetNamespace
                        && chain.Route.AllowedHttpMethods.Contains("GET"))
                    .Select(chain => chain.FirstCall())
                    .FirstOrDefault();
            }

            if (getCall == null)
            {
                return null;
            }

            return getCall.InputType();
        }
    }
}