using GoogleHashCode2021;
using GoogleHashCode2022.Models;
using System.Collections.Generic;
using System.Linq;

namespace GoogleHashCode2022
{
    public static class MoneyMachineMaarten
    {
        public static OutputData CalculateSolution(InputData input)
        {
            List<Solution> solutions = new List<Solution>();

            foreach (var project in input.Projects)
            {
                List<Contributor> availableContributes = input.Contributors;

                Solution solution = new Solution();
                solution.ProjectName = project.Name;
                solution.Contributers = GetProjectContributors(project.RequiredSkills, availableContributes);

                if (solution.Contributers.Count == project.RequiredSkills.Count)
                {
                    solutions.Add(solution);
                }
            }

            return new OutputData { Solutions = solutions };
        }

        private static List<string> GetProjectContributors(List<Skill> projectSkills, List<Contributor> availableContributes)
        {
            List<Contributor> contributors = new List<Contributor>();

            foreach (var projectSkill in projectSkills)
            {
                var contributor = availableContributes.FirstOrDefault(x => x
                    .Skills.Any(skill => 
                        skill.Name == projectSkill.Name
                        && skill.Level >= projectSkill.Level));

                if (contributor == null)
                    break;

                availableContributes.Remove(contributor);

                contributors.Add(contributor);
            }

            return contributors.Select(x => x.Name).ToList();
        }
    }
}
