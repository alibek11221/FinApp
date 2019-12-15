using FinAppUi.Library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinAppUi.Library.Api
{
    public class WalletEndPoint : IWalletEndPoint
    {
        private readonly IAPIHelper _aPIHelper;
        public WalletEndPoint(IAPIHelper aPIHelper)
        {
            _aPIHelper = aPIHelper;
        }

        public async Task<List<WalletModel>> GetAll()
        {
            using (HttpResponseMessage response = await _aPIHelper.ApiClient.GetAsync("api/Wallet"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<WalletModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public async Task Add(WalletModel wallet)
        {
            HttpResponseMessage httpResponse = await _aPIHelper.ApiClient.PostAsJsonAsync("api/Wallet", wallet);
            httpResponse.Dispose();
        }
    }
}
