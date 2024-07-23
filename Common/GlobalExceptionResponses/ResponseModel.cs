namespace Common.GlobalExceptionResponses;

public class ResponseModel
{
    public int Code { get; set; }
    public string Message { get; set; }
    public string ErrorType { get; set; }
    public ResponseModel(string message, ErrorType errorType)
    {
        Message = message;
        ErrorType = errorType.ToString();
        Code = (int)errorType;
    }
    public ResponseModel()
    {

    }
}

public enum ErrorType
{
    BAD_REQUEST = 1,
    NOT_FOUND = 2,
    VALIDATION_ERROR = 3
}