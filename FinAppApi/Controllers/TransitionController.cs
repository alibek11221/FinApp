using System.Web.Http;

namespace FinAppApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/Transition")]
    public class TransitionController : ApiController
    {
    }
}
