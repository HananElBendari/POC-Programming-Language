using System.Collections.Generic;

namespace POC.Programming.Domain.Entities
{
    public class ProgrammingLanguage : IEntity
    {
        public string ProgrammingLanguageName { get; set; }
        public int ProgrammingCategoryId { get; set; }
        public int NumberOfHits { get; set; }
        public ProgrammingCategory ProgrammingCategory { get; set; }
        public ICollection<ProgrammingLanguageDetails> ProgrammingLanguageDetails { get; set; }
    }
}
