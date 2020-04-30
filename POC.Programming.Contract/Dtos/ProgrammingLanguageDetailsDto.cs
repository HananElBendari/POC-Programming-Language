namespace POC.Programming.Contract.Dtos
{
    public class ProgrammingLanguageDetailsDto
    {
        public int Id { get; set; }
        public string UserIp { get; set; }
        public bool? Like { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public ProgrammingLanguageDto ProgrammingLanguage { get; set; }
    }
}
