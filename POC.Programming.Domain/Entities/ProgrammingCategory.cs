using System.Collections.Generic;

namespace POC.Programming.Domain.Entities
{
    public class ProgrammingCategory : IEntity
    {
        public string ProgrammingCategoryName { get; set; }
        public ICollection<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    }
}
