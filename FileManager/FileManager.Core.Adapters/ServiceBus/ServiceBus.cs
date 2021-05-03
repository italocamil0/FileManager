using FileManager.Core.Adapters.Helpers;
using FileManager.Core.Application.Entities;
using FileManager.Core.Application.Port;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace FileManager.Core.Adapters.ServiceBus
{
    public class ServiceBus : ISendMessagePort
    {
        private readonly IConfiguration _configuration;

        public ServiceBus(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMessageAsync(Arquivo arquivo)
        {
            string endpointServiceBus = _configuration["EndpointServiceBusConnection"];
            string nomeFila = _configuration["FilaServiceBus"];
            var serviceBusTopicClient = new TopicClient(endpointServiceBus, nomeFila);

            var arquivoJson = JsonConvert.SerializeObject(arquivo).ToJsonBytes();
            
            var message = new Message(arquivoJson)
            {
                ContentType = "application/json"
            };

            await serviceBusTopicClient.SendAsync(message);
            await serviceBusTopicClient.CloseAsync();
        }
    }
}
