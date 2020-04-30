namespace POC.Programming.Contract.Dtos
{
    public class ProgrammingLanguageDto
    {
        public int Id { get; set; }
        public string ProgrammingLanguageName { get; set; }
        public int ProgrammingCategoryId { get; set; }
        public int NumberOfHits { get; set; }
        public ProgrammingCategoryDto ProgrammingCategory { get; set; }
    }
}
