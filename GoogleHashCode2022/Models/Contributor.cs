using System.Collections.Generic;
using System.Linq;

namespace GoogleHashCode2022.Models
{
    public class Contributor
    {
        public string Name { get; set; }
        public List<Skill> Skills { get; set; }
        public bool IsBusy { get; set; }

        public bool HasEnoughSkills(Skill requiredSkill)
        {
            return Skills.Any(s => s.Name == requiredSkill.Name && s.Level >= requiredSkill.Level);
        }
    }
}
