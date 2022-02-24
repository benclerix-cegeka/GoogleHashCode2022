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

            var projects = input.Projects.OrderByDescending(p => p.S_ScoreForCompletion / p.D_NumberOfDaysToComplete / p.RequiredSkills.Count() * p.B_BestBefore);

            foreach (var project in projects)
            {
                var contributors = new List<string>();
                foreach (var requiredSkill in project.RequiredSkills)
                {
                    var contributor = input.Contributors.Find(c => c.HasEnoughSkills(requiredSkill) && !c.IsBusy);

                    if (contributor != null)
                    {
                        contributor.IsBusy = true;
                        contributors.Add(contributor.Name);
                    }
                }

                if (project.R_NumberOfRoles == contributors.Count())
                {
                    var sln = new Solution
                    {
                        ProjectName = project.Name,
                        Contributers = contributors
                    };

                    output.Solutions.Add(sln);
                }
            }

            return output;
        }

    }
}
