using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text;

namespace Brokers.Portal.MiddleWares
{
    public class BasicAuthenticationMiddleware : IMiddleware
    {
        //private readonly IManagementServices _managementServices;
        public BasicAuthenticationMiddleware()
        {
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string authHeader = context.Request.Headers["Authorization"];

            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                string encodedUsernameAndPassword = authHeader.Substring("Basic ".Length).Trim();
                Encoding encoding = Encoding.GetEncoding("UTF-8");
                string usernameAndPassword = encoding.GetString(Convert.FromBase64String(encodedUsernameAndPassword));
                int index = usernameAndPassword.IndexOf(':');
                var username = usernameAndPassword.Substring(0, index);
                var password = usernameAndPassword.Substring(index + 1);

                if (username.Equals("Brokers.Portal.Frontend") && password.Equals("bp4321"))
                {
                    await next.Invoke(context);
                }

                else
                {
                    context.Response.StatusCode = 401;
                    return;
                }
            }
            else
            {
                context.Response.StatusCode = 401;
                return;
            }


        }
    }
}
