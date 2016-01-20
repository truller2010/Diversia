using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Diversia.WCF.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public class ExceptionMarshallingBehavior: Attribute, IServiceBehavior, IEndpointBehavior, IContractBehavior
    {
        #region IContractBehavior Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="endpoint"></param>
        /// <param name="parameters"></param>
        void IContractBehavior.AddBindingParameters(ContractDescription contract, ServiceEndpoint endpoint, BindingParameterCollection parameters)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="endpoint"></param>
        /// <param name="runtime"></param>
        void IContractBehavior.ApplyClientBehavior(ContractDescription contract, ServiceEndpoint endpoint, ClientRuntime runtime)
        {
            Debug.WriteLine(string.Format("Applying client ExceptionMarshallingBehavior to contract {0}", contract.ContractType));
            this.ApplyClientBehavior(runtime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="endpoint"></param>
        /// <param name="runtime"></param>
        void IContractBehavior.ApplyDispatchBehavior(ContractDescription contract, ServiceEndpoint endpoint, DispatchRuntime runtime)
        {
            Debug.WriteLine(string.Format("Applying dispatch ExceptionMarshallingBehavior to contract {0}", contract.ContractType.FullName));
            this.ApplyDispatchBehavior(runtime.ChannelDispatcher);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="endpoint"></param>
        void IContractBehavior.Validate(ContractDescription contract, ServiceEndpoint endpoint)
        {
        }

        #endregion

        #region IEndpointBehavior Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="parameters"></param>
        void IEndpointBehavior.AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection parameters)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="runtime"></param>
        void IEndpointBehavior.ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime runtime)
        {
            Debug.WriteLine(string.Format("Applying client ExceptionMarshallingBehavior to endpoint {0}", endpoint.Address));
            this.ApplyClientBehavior(runtime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="dispatcher"></param>
        void IEndpointBehavior.ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher dispatcher)
        {
            Debug.WriteLine(string.Format("Applying dispatch ExceptionMarshallingBehavior to endpoint {0}", endpoint.Address));
            this.ApplyDispatchBehavior(dispatcher.ChannelDispatcher);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        void IEndpointBehavior.Validate(ServiceEndpoint endpoint)
        {
        }

        #endregion

        #region IServiceBehavior Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="host"></param>
        /// <param name="endpoints"></param>
        /// <param name="parameters"></param>
        void IServiceBehavior.AddBindingParameters(ServiceDescription service, ServiceHostBase host, Collection<ServiceEndpoint> endpoints, BindingParameterCollection parameters)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="host"></param>
        void IServiceBehavior.ApplyDispatchBehavior(ServiceDescription service, ServiceHostBase host)
        {
            Debug.WriteLine(string.Format("Applying dispatch ExceptionMarshallingBehavior to service {0}", service.ServiceType.FullName));
            foreach (ChannelDispatcher dispatcher in host.ChannelDispatchers)
            {
                this.ApplyDispatchBehavior(dispatcher);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="host"></param>
        void IServiceBehavior.Validate(ServiceDescription service, ServiceHostBase host)
        {
        }

        #endregion

        #region Private Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="runtime"></param>
        private void ApplyClientBehavior(ClientRuntime runtime)
        {
            // Don't add a message inspector if it already exists
            foreach (IClientMessageInspector messageInspector in runtime.MessageInspectors)
            {
                if (messageInspector is ExceptionMarshallingMessageInspector)
                {
                    return;
                }
            }

            runtime.MessageInspectors.Add(new ExceptionMarshallingMessageInspector());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dispatcher"></param>
        private void ApplyDispatchBehavior(ChannelDispatcher dispatcher)
        {
            // Don't add an error handler if it already exists
            foreach (IErrorHandler errorHandler in dispatcher.ErrorHandlers)
            {
                if (errorHandler is ExceptionMarshallingErrorHandler)
                {
                    return;
                }
            }

            dispatcher.ErrorHandlers.Add(new ExceptionMarshallingErrorHandler());
        }

        #endregion
    }
}
