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

            var projects = input.Projects.OrderByDescending(p =>
                p.S_ScoreForCompletion / p.D_NumberOfDaysToComplete / p.RequiredSkills.Count() * p.B_BestBefore);

            foreach (var project in projects)
            {
                var contributors = new List<Contributor>();
                foreach (var requiredSkill in project.RequiredSkills)
                {
                    var contributor = input.Contributors.Find(c => !c.IsBusy &&
                        (c.HasEnoughSkills(requiredSkill) || c.CanUseMentor(requiredSkill) && contributors.Any(x => x.CanBeMentor(requiredSkill))));

                    if (contributor != null)
                    {
                        contributor.IsBusy = true;
                        contributors.Add(contributor);
                    }
                }

                if (project.R_NumberOfRoles == contributors.Count())
                {
                    var sln = new Solution
                    {
                        ProjectName = project.Name,
                        Contributers = contributors.Select(x => x.Name).ToList()
                    };

                    output.Solutions.Add(sln);
                }
            }

            return output;
        }

    }
}
