namespace SagiCore.Communication.Responses
{
    /// <summary>
    /// Resposta padronizada da API seguindo RFC 7807
    /// </summary>
    /// <typeparam name="T">Tipo dos dados retornados</typeparam>
    public sealed class ApiResponse<T>
    {
        public int Status { get; init; }
        public string Message { get; init; } = string.Empty;
        public T? Data { get; init; }
        public IList<string>? Errors { get; init; }
        public DateTime Timestamp { get; init; } = DateTime.UtcNow;

        private ApiResponse() { }

        public static ApiResponse<T> Success(T data, string message = "Operação realizada com sucesso", int status = 200)
            => new()
            {
                Status = status,
                Message = message,
                Data = data
            };

        public static ApiResponse<T> Created(T data, string message = "Recurso criado com sucesso")
            => new()
            {
                Status = 201,
                Message = message,
                Data = data
            };

        public static ApiResponse<T> Fail(string message, int status = 400, IList<string>? errors = null)
            => new()
            {
                Status = status,
                Message = message,
                Errors = errors
            };
    }

    /// <summary>
    /// Resposta padronizada sem dados (para operações void)
    /// </summary>
    public sealed class ApiResponse
    {
        public int Status { get; init; }
        public string Message { get; init; } = string.Empty;
        public IList<string>? Errors { get; init; }
        public DateTime Timestamp { get; init; } = DateTime.UtcNow;

        private ApiResponse() { }

        public static ApiResponse Success(string message = "Operação realizada com sucesso", int status = 200)
            => new() { Status = status, Message = message };

        public static ApiResponse Fail(string message, int status = 400, IList<string>? errors = null)
            => new() { Status = status, Message = message, Errors = errors };
    }
}
