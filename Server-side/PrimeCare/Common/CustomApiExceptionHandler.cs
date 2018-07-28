using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Core.Logging;

namespace PrimeCare.Common
{
    public class CustomApiExceptionHandler : ExceptionHandler
    { 
        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }
        
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new ErrorResult
            {
                Request = context.ExceptionContext.Request,
                Content = "Please contact our support team so we can try to fix it. " + context.Exception.GetBaseException()
            };
        }

        private class ErrorResult : IHttpActionResult
        {
            public HttpRequestMessage Request { get; set; }

            public string Content { get; set; }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(Content),
                    RequestMessage = Request
                };
                return Task.FromResult(response);
            }
        }
    }
}
