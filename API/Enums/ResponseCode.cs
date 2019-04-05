namespace API.Enums
{
    /// <summary>
    /// HTTP Status Codes
    /// </summary>
    public enum StatusCode
    {
        Ok = 200,
        Created = 201,
        NoContent = 204,
        MovedPermanently = 301,
        Found = 302,
        BadRequest = 400,
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500
    }
}
