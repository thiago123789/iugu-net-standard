using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using iugu.net.standard.Request;
using iugu.net.standard.Response;

namespace iugu.net.standard.Lib
{
    public class Triggers : APIResource
    {
        private Triggers()
        {
            BaseURI = "/web_hooks";
        }

        public Triggers(string apiKey) : base(new StandardHttpClient(), apiKey)
        {
            BaseURI = "/web_hooks";
        }

        public async Task<IList<string>> GetEventListAsync()
        {
            return await GetAsync<IList<string>>("", "supported_events", null);
        }

        public async Task<TriggerResponseMessage> GetOneByIdAsync(string id)
        {
            return await GetAsync<TriggerResponseMessage>(id);
        }

        public async Task<IList<TriggerResponseMessage>> GetAllTriggersAsync()
        {
            return await GetAsync<IList<TriggerResponseMessage>>();
        }

        public async Task<TriggerResponseMessage> CreateTriggerAsync(TriggerRequestMessage request)
        {
            return await PostAsync<TriggerResponseMessage>(request);
        }

        public async Task<TriggerResponseMessage> UpdateTriggerAsync(string id, TriggerRequestMessage request)
        {
            return await PutAsync<TriggerResponseMessage>(id, request);
        }

        public async Task<TriggerResponseMessage> DeleteTriggerAsync(string id)
        {
            return await DeleteAsync<TriggerResponseMessage>(id);
        }
    }
}