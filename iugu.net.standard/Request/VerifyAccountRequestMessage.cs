﻿using iugu.net.standard.Entity;
using Newtonsoft.Json;

namespace iugu.net.standard.Request
{
    /// <summary>
    /// Request para solicitar validação dos dados de uma conta
    /// </summary>
    public class VerifyAccountRequestMessage
    {
        /// <summary>
        /// Informações da conta a ser verificada
        /// Obs: Essas informações serão adicionadas as informações da conta
        /// </summary>
        [JsonProperty("data")]
        public readonly AccountModel Data;

        /// <summary>
        /// Habilitar a rerificação automática dos dados bancários
        /// </summary>
        [JsonProperty("automatic_validation")]
        public readonly bool AutomaticValidation;

        public VerifyAccountRequestMessage(AccountModel account, bool automaticValidation)
        {
            Data = account;
            AutomaticValidation = automaticValidation;
        }
    }
}