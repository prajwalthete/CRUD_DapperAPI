namespace ModelLayer.Resposes
{
    public class CreateCompanyResponse<T>
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; }
        public T Data { get; set; }
    }

}
