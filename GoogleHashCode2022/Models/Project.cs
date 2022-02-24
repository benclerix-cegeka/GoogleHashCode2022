using System.Collections.Generic;

namespace GoogleHashCode2022.Models
{
    public class Project
    {
        public string Name { get; set; }
        public List<Skill> RequiredSkills { get; set; }
        public int D_NumberOfDaysToComplete { get; set; }
        public int S_ScoreForCompletion { get; set; }
        public int B_BestBefore { get; set; }
        public int R_NumberOfRoles { get; set; }
    }
}
