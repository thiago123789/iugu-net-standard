using iugu.net.standard.Entity;
using System;
using System.Threading.Tasks;

namespace iugu.net.standard.Lib
{
    public class PaymentMethod : APIResource
    {
        public string CustomerId { get; set; }

        public PaymentMethod(string customerId)
        {
            CustomerId = customerId;
            BaseURI = $"/customers/{CustomerId}/payment_methods";
        }

        public PaymentMethod(string customerId, string apiToken) : base(new StandardHttpClient(), apiToken)
        {
            CustomerId = customerId;
            BaseURI = $"/customers/{CustomerId}/payment_methods";
        }

        public void ChangeBaseUrl(string customerId)
        {
            BaseURI = $"/customers/{customerId}/payment_methods";
        }
        
        public async Task<PaymentMethodModel> GetAsync()
        {
            return await GetAsync<PaymentMethodModel>().ConfigureAwait(false);
        }
        
        public async Task<PaymentMethodModel> GetAsync(string id)
        {
            return await GetAsync<PaymentMethodModel>(id).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Cria uma Forma de Pagamento de Cliente.
        /// </summary>
        /// <param name="description">Descrição</param>
        /// <param name="data">(opcional se enviar o token)	Dados da Forma de Pagamento (Em breve, este parâmetro será descontinuado. Para evitar problemas, use a partir de agora o parâmetro  token)</param>
        /// <param name="setAsDefault">(opcional)	Tipo da Forma de Pagamento. Atualmente suportamos apenas Cartão de Crédito (tipo credit_card). Só deve ser enviado caso não envie token.</param>
        /// <param name="token">(opcional)	Token de Pagamento, pode ser utilizado em vez de enviar os dados da forma de pagamento</param>
        /// <param name="itemType">(opcional)	Tipo da Forma de Pagamento. Atualmente suportamos apenas Cartão de Crédito (tipo credit_card). Só deve ser enviado caso não envie token.</param>
        public async Task<PaymentMethodModel> CreateAsync(string description, CreditCard data, bool? setAsDefault = null, string token = "", string itemType = "")
        {
            object paymentMethod = null;

            if (data == null && !string.IsNullOrEmpty(token))
            {
                paymentMethod = new
                {
                    description = description,
                    set_as_default = setAsDefault,
                    token = token
                };
            }
            else
            {
                paymentMethod = new
                {
                    description = description,
                    data = data,
                    set_as_default = setAsDefault,
                    item_type = itemType
                };
            }

            return await PostAsync<PaymentMethodModel>(paymentMethod).ConfigureAwait(false);
        }
        
        public async Task<PaymentMethodModel> DeleteAsync(string id)
        {
            return await DeleteAsync<PaymentMethodModel>(id).ConfigureAwait(false);
        }
        
        public async Task<PaymentMethodModel> PutAsync(string id, PaymentMethodModel model)
        {
            return await PutAsync<PaymentMethodModel>(id, model).ConfigureAwait(false);
        }
    }
}
