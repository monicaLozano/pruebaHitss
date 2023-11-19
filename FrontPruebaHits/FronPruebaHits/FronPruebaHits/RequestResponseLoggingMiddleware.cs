using System.Buffers;
using System.Text;

namespace FronPruebaHits
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var clientIpAddress = context.Connection.RemoteIpAddress?.ToString();
                var request = await FormatRequest(context.Request, clientIpAddress);
                var originalBodyStream = context.Response.Body;

                // Registrar la dirección IP del cliente en todos los registros
                _logger.LogInformation($"Solicitud desde IP: {clientIpAddress}");

                using (var responseBody = _recyclableMemoryStreamManager.GetStream())
                {
                    context.Response.Body = responseBody;

                    await _next(context);

                    var response = await FormatResponse(context.Response, clientIpAddress);

                    // Agregar la solicitud y respuesta al log

                    _logger.LogInformation($"Solicitud desde IP: {clientIpAddress}");
                    _logger.LogInformation($"Solicitud: {"IP Cliente" + clientIpAddress + " " + request}");
                    _logger.LogInformation($"Respuesta: {"IP Cliente" + clientIpAddress + " " + response}");

                    responseBody.Seek(0, SeekOrigin.Begin);
                    await responseBody.CopyToAsync(originalBodyStream);

                    responseBody.Seek(0, SeekOrigin.Begin); // Restablecer la posición antes de acceder a su contenido
                    var responseContent = await new StreamReader(responseBody).ReadToEndAsync();

                    // Restablecer el Body original
                    context.Response.Body = originalBodyStream;

                    _logger.LogInformation($"Respuesta (contenido): {"IP Cliente = " + clientIpAddress + "  " + responseContent}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task<string> FormatRequest(HttpRequest request, string clientIpAddress)
        {
            request.EnableBuffering();

            var body = await request.BodyReader.ReadAsync();
            var requestBuffer = body.Buffer;
            var requestContent = requestBuffer.IsEmpty ? string.Empty : Encoding.UTF8.GetString(requestBuffer.ToArray());

            request.Body.Position = 0;

            return $"{request.Method} {"IP Cliente: " + clientIpAddress} {request.Path}{request.QueryString} {requestContent}";
        }

        private async Task<string> FormatResponse(HttpResponse response, string clientIpAddress)
        {
            response.Body.Seek(0, SeekOrigin.Begin);

            var responseContent = await new StreamReader(response.Body).ReadToEndAsync();

            response.Body.Seek(0, SeekOrigin.Begin);

            return $"{"IP Cliente: " + clientIpAddress}{response.StatusCode}: {responseContent}";
        }
    }
}
