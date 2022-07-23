using System.Security.Claims;
using Tools.JWT;

namespace API.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, JwtService jwt)
        {
            IEnumerable<string> values
                = context.Request.Headers.FirstOrDefault(h => h.Key == "Authorization").Value;

            string? token = values.FirstOrDefault(v => v.StartsWith("Bearer "))?.Split(" ")[1];

            if (!(token is null))
            {
                try
                {
                    ClaimsPrincipal claims = jwt.ValidateToken(token);
                    context.User = claims;
                }
                catch (Exception ex) { }
            }

            await _next(context);
        }
    }
}
