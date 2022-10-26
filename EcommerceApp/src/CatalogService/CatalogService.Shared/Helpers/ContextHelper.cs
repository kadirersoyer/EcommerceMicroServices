using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System.Text;
using System.Xml;

namespace CatalogService.Shared.Helpers
{
    public static class ContextHelper
    {
        public static async Task<string> ReadRequestBody(HttpContext context)
        {
            var formString = await new StreamReader(context.Request.Body).ReadToEndAsync();
            var injectedRequestStream = new MemoryStream();
            byte[] bytesToWrite = Encoding.UTF8.GetBytes(formString);
            injectedRequestStream.Write(bytesToWrite, 0, bytesToWrite.Length);
            injectedRequestStream.Seek(0, SeekOrigin.Begin);
            context.Request.Body = injectedRequestStream;

            return formString;

        }

        public static async Task<string> ReadResponseBody(HttpContext context, RequestDelegate _next)
        {
            var originalBody = context.Response.Body;

            string responseBody = string.Empty;
            using (var memStream = new MemoryStream())
            {
                context.Response.Body = memStream;
                await _next(context);
                memStream.Position = 0;
                responseBody = await new StreamReader(memStream).ReadToEndAsync();

                memStream.Position = 0;
                await memStream.CopyToAsync(originalBody);
            }
            context.Response.Body = originalBody;
            return responseBody;
        }
    }
}
