namespace LoghanAPI.ViewModels
{
    public class ResultViewModel
    {
        public ResultViewModel() { }
        public ResultViewModel(bool isSuccess, object data, string message)
        {
            isSuccess = isSuccess;
            Data = data;
            Message = message;
        }
        public void SetValues(bool isSuccess, object data, string message)
        {
            isSuccess = isSuccess;
            Data = data;
            Message = message;
        }
        public ResultViewModel(bool isSuccess, object data, string message, bool isRedirect, string redirectUrl)
        {
            IsSuccess = isSuccess;
            Data = data;
            Message = message;
            IsRedirect = isRedirect;
            RedirectUrl = redirectUrl;
        }

        public void SetValues(bool isSuccess, object data, string message, bool isRedirect, string redirectUrl)
        {
            IsSuccess = isSuccess;
            Data = data;
            Message = message;
            IsRedirect = isRedirect;
            RedirectUrl = redirectUrl;
        }
        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public int ItemsCount { get; set; }
        public string Message { get; set; }
        public string RedirectUrl { get; set; }
        public bool IsRedirect { get; set; }
    }
}
