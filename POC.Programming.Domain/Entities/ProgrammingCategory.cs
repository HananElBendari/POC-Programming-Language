using System.Collections.Generic;

namespace POC.Programming.Domain.Entities
{
    public class ProgrammingCategory : Entity
    {
        public string ProgrammingCategoryName { get; set; }
        public ICollection<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    }
}
