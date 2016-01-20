using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Channels;
using System.Configuration;

namespace Diversia.WCF.Proxies
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WcfProxies<T> : IDisposable where T: class
    {
        /// <summary>
        /// 
        /// </summary>
        ChannelFactory<T> _factory;

        /// <summary>
        /// 
        /// </summary>
        private T _channel;
 
        /// <summary>
        /// 
        /// </summary>
        private readonly BasicHttpBinding binding;

        /// <summary>
        /// 
        /// </summary>
        private readonly EndpointAddress endpoint;
 
        /// <summary>
        /// 
        /// </summary>
        private readonly object lockObject = new object();

        /// <summary>
        /// 
        /// </summary>
        private bool disposed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configName"></param>
        public WcfProxies(string configName)
        {
            if (ConfigurationManager.AppSettings[configName] == null)
            {
                throw new ConfigurationErrorsException(configName + " is not present in the config file");
            }
 
            binding = new BasicHttpBinding();
            endpoint = new EndpointAddress(ConfigurationManager.AppSettings[configName]);
            disposed = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public WcfProxies()
        {
            var pam = typeof(T);
            //string name = pam.Name.TrimStart('I');
            binding = new BasicHttpBinding();
            endpoint = new EndpointAddress(ConfigurationManager.AppSettings[pam.Name]);
            disposed = false;
        }
        /// <summary>
        /// 
        /// </summary>
        public T Channel
        {
            get
            {
                if (disposed)
                {
                    throw new ObjectDisposedException("Resource ServiceWrapper<"+typeof(T)+"> has been disposed");
                }
 
                lock (lockObject)
                {
                    if (_factory != null) return _channel;
                    _factory = new ChannelFactory<T>(binding, endpoint);
                    _channel = _factory.CreateChannel();
                }
                return _channel;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        public void Dispose(bool disposing)
        {
            if (disposed) return;
            if (!disposing) return;
            lock (lockObject)
            {
                ((IClientChannel) _channel)?.Close();
                _factory?.Close();
            }
 
            _channel = null;
            _factory = null;
            disposed = true;
        }
    }
}