namespace POC.Programming.Domain.Entities
{
    public class ProgrammingLanguageDetails : Entity
    {
        public string UserIp { get; set; }
        public bool? Like { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
    }
}
