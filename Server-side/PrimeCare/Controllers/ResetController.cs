using System.Web;
using System.Web.Http;

namespace PrimeCare.Controllers
{
    [RoutePrefix("api")]
    public class ResetController : ApiController
    {
        [Route("fake/reset")]
        [HttpDelete]
        public void Get()
        {
            HttpContext.Current.Application["Count"] = 0;
        }
    }
}
