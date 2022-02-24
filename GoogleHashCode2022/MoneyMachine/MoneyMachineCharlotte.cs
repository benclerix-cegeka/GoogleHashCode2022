using GoogleHashCode2021;
using GoogleHashCode2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleHashCode2022
{
    public static class MoneyMachineCharlotte
    {
        public static OutputData CalculateSolution(InputData input)
        {
            var output = new OutputData
            {
                Solutions = new List<Solution>()
            };

            Dictionary<string, Tuple<int, string>> skillOverview = new Dictionary<string, Tuple<int, string>>();
            foreach (var contributor in input.Contributors)
            {
                foreach (var skill in contributor.Skills)
                {
                    skillOverview.Add(skill.Name, new Tuple<int, string>(skill.Level, contributor.Name));
                }
            }

            foreach (var project in input.Projects)
            {
                foreach (var requiredSkill in project.RequiredSkills)
                {
                    input.Contributors.Find(c => c.Skills.Any(s => s.Name == requiredSkill.Name && s.Level >= requiredSkill.Level));
                }

                var contributors = input.Contributors;

                var sln = new Solution
                {
                    ProjectName = project.Name,
                };

                output.Solutions.Add(sln);
            }

            return output;
        }

    }
}
