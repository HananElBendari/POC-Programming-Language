namespace POC.Programming.Contract.Request
{
    public class ErrorRequest
    {
        public string Error { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
        public bool Ok { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }
        public string Url { get; set; }
    }

}
