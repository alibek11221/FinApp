using FinAppUi.Library.Models;
using System.Threading.Tasks;

namespace FinAppUi.Library.Api
{
    public interface ITransitionEndPoint
    {
        Task Make(TranstitionModel transtition);
    }
}