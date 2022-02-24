using System.Collections.Generic;
using System.Linq;

namespace GoogleHashCode2022.Models
{
    public class Contributor
    {
        public string Name { get; set; }
        public List<Skill> Skills { get; set; }
        public bool IsBusy { get; set; }
        public Dictionary<int, bool> IsBusyInTime { get; set; } = new Dictionary<int, bool>();


        public void DoProject(int startTime, int nTimeToComplete)
        {
            for (int t = startTime; t < nTimeToComplete; t++)
            {
                IsBusyInTime.Add(t, true);
            }
        }

        public int UnOccuppiedFromDay { get; set; }

        public bool HasEnoughSkills(Skill requiredSkill)
        {
            return Skills.Any(s => s.Name == requiredSkill.Name && s.Level >= requiredSkill.Level);
        }

        public bool CanBeMentor(Skill requiredSkill)
        {
            return Skills.Any(s => s.Name == requiredSkill.Name && s.Level > requiredSkill.Level);
        }

        public bool CanUseMentor(Skill requiredSkill)
        {
            return Skills.Any(s => s.Name == requiredSkill.Name && s.Level == requiredSkill.Level - 1);
        }

        public void CompleteProject(Skill skill)
        {
            skill.Level++;
        }
    }
}
