namespace WebApi.Services.Core
{
    public class OperationResult<TStatus, TResult>
    {
        public TStatus Status { get; set; }

        public TResult Result { get; set; }
    }
}
