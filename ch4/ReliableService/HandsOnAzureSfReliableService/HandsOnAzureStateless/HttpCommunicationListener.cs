using System.Fabric;
using System.Fabric.Description;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Communication.Runtime;

namespace HandsOnAzureStateless
{
    public class HttpCommunicationListener : ICommunicationListener
    {
        private readonly StatelessServiceContext _context;
        private string _address;
        private object _publishAddress;

        public HttpCommunicationListener(StatelessServiceContext context)
        {
            _context = context;
        }

        public Task<string> OpenAsync(CancellationToken cancellationToken)
        {
            var serviceEndpoint = _context.CodePackageActivationContext.GetEndpoint("ServiceEndpoint");

            _address = string.Format(
                CultureInfo.InvariantCulture,
                "http://+:{0}/",
                serviceEndpoint.Port);

            _publishAddress = _address.Replace("+", FabricRuntime.GetNodeContext().IPAddressOrFQDN);
            //_app = WebApp.Start(_address, appBuilder => this.startup.Invoke(appBuilder));

            return Task.FromResult(_address);
        }

        public Task CloseAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public void Abort()
        {
            throw new System.NotImplementedException();
        }
    }
}