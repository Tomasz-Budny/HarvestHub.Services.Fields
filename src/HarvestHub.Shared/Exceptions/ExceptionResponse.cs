using System.Net;

namespace HarvestHub.Shared.Exceptions
{
    public sealed record Error(string Code, string Message);
    public sealed record ExceptionResponse(Error Error, HttpStatusCode StatusCode);
}
