using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace AirportMVC.Services
{
    public class IpFilter
    {
        private readonly RequestDelegate _next;
        private readonly ApplicationOptions _applicationOptions;

        public IpFilter(RequestDelegate next, IOptions<ApplicationOptions> applicationOptionsAccessor)
        {
            _next = next;
            _applicationOptions = applicationOptionsAccessor.Value;

        }

        public async Task Invoke(HttpContext context)
        {
            var remoteIp =  context.Request.HttpContext.Connection.RemoteIpAddress;
            List<string> whiteListIPList = _applicationOptions.WhiteList;

            var isInWhiteListIpList = whiteListIPList.Any(a => IPAddress.Parse((string) a).Equals(remoteIp));

            if (!isInWhiteListIpList)
            {
                context.Response.StatusCode = (int) HttpStatusCode.Forbidden;
                return;
            }

            await _next.Invoke(context);
        }
    }
}
