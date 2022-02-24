using GoogleHashCode2021;
using GoogleHashCode2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleHashCode2022
{
    public static class MoneyMachineMaarten
    {
        public static OutputData CalculateSolution(InputData input)
        {
            List<Solution> solutions = new List<Solution>();

            var feasableOrderedProjects = input.Projects
                .Where(x => x.D_NumberOfDaysToComplete <= x.B_BestBefore)
                .OrderBy(x => x.B_BestBefore);

            foreach (var project in feasableOrderedProjects)
            {
                List<Contributor> availableContributes = input.Contributors;

                Solution solution = new Solution();
                solution.ProjectName = project.Name;
                var projectStartDay = Math.Max(0, project.B_BestBefore - project.D_NumberOfDaysToComplete - 1);
                var projectEndDay = projectStartDay + project.D_NumberOfDaysToComplete;
                solution.Contributers = GetProjectContributors(project.RequiredSkills, availableContributes, projectStartDay, projectEndDay);

                if (solution.Contributers.Count == project.RequiredSkills.Count)
                {
                    solutions.Add(solution);
                }
            }

            return new OutputData { Solutions = solutions };
        }

        private static List<string> GetProjectContributors(List<Skill> projectSkills, List<Contributor> availableContributes, int projectStartDay, int projectEndDay)
        {
            List<Contributor> contributors = new List<Contributor>();

            foreach (var projectSkill in projectSkills)
            {
                var contributor = availableContributes.FirstOrDefault(x =>
                    x.Skills.Any(skill => 
                        skill.Name == projectSkill.Name
                        && skill.Level >= projectSkill.Level)
                    && x.UnOccuppiedFromDay <= projectStartDay);

                if (contributor == null)
                    break;

                contributor.UnOccuppiedFromDay = projectEndDay + 1;
                contributors.Add(contributor);
            }

            return contributors.Select(x => x.Name).ToList();
        }
    }
}
