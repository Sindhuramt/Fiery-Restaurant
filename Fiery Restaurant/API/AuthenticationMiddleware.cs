namespace API
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Authorization header not found.");
                return;
            }

            var authHeader = context.Request.Headers["Authorization"];
            var authHeaderParts = authHeader.ToString().Split(' ');

            if (authHeaderParts.Length != 2 || authHeaderParts[0] != "Bearer")
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid Authorization header.");
                return;
            }

            var token = authHeaderParts[1];

            // TODO: Validate token

            await _next(context);
        }
    }
}
