using FinAppUi.Library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinAppUi.Library.Api
{
    public class TransitionEndPoint : ITransitionEndPoint
    {
        private readonly IAPIHelper _aPIHelper;

        public TransitionEndPoint(IAPIHelper aPIHelper)
        {
            _aPIHelper = aPIHelper;
        }
        public async Task Make(TranstitionModel transtition)
        {
            HttpResponseMessage httpResponse = await _aPIHelper.ApiClient.PostAsJsonAsync("api/Transition", transtition);
            httpResponse.Dispose();
        }
    }
}
