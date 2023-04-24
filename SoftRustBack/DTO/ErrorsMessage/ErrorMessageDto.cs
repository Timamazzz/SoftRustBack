namespace SoftRustBack.DTO.ErrorsMessage
{
    public class ErrorMessageDto
    {
        public string? Key { get; set; }
        public string? Method { get; set; }
        public string? Message { get; set; }
        public string? StackTrace { get; set; }

/*        ErrorMessageDto(string? key, string? method, string? message, string? stackTrace)
        {
            Key = key;
            Method = method;
            Message = message;
            StackTrace = stackTrace;
        }*/
    }
}
