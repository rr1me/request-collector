namespace requestCollector;

public class Middleware(RequestDelegate next)
{
	public async Task InvokeAsync(HttpContext context, DatabaseContext databaseContext)
	{
		Console.WriteLine(context);

		var headers = context.Request.Headers;

		var request = new Request();
		
		foreach (var (key, value) in headers)
		{
			var headerKey = key.ToLower().Replace('-', '_');
			var property = typeof(Request).GetProperty(headerKey);
			property?.SetValue(request, value.ToString());
		}

		request.date = DateTime.UtcNow;

		databaseContext.Requests.Add(request);
		await databaseContext.SaveChangesAsync();
		
		context.Response.StatusCode = 200;
	}
}

public static class MiddlewareExtensions
{
	public static IApplicationBuilder UseCollectorMiddleware(this IApplicationBuilder builder) =>
		builder.UseMiddleware<Middleware>();
}