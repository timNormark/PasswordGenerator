using System.Collections.Generic;

namespace PasswordGenerator.Core
{
    public class PasswordGeneratorSettings
    {
        public string ValidEmailPostfix { get; set; }
        public IEnumerable<int> ValidSchoolYears { get; set; }
        public IEnumerable<string> Words { get; set; }
    }
}
