using System.Linq;

namespace TNRD.AdventOfCode.DayFour.Shared
{
    public class PasswordValidator
    {
        private readonly IPasswordRule[] rules;

        public PasswordValidator(params IPasswordRule[] rules)
        {
            this.rules = rules;
        }

        public bool Validate(int password)
        {
            return rules.All(x => x.Validate(password));
        }
    }
}
