﻿using FinAppUi.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinAppUi.Library.Api
{
    public interface IWalletEndPoint
    {
        Task<List<WalletModel>> GetAll();
    }
}