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
                solution.Contributers = GetProjectContributors(project, availableContributes);

                if (solution.Contributers.Count == project.RequiredSkills.Count)
                {
                    solutions.Add(solution);
                }
            }

            return new OutputData { Solutions = solutions };
        }

        private static int GetProjectStartDay(Project project)
            => Math.Max(0, project.B_BestBefore - project.D_NumberOfDaysToComplete - 1);

        private static int GetProjectEndDay(Project project)
            => GetProjectStartDay(project) + project.D_NumberOfDaysToComplete;

        private static List<string> GetProjectContributors(Project project, List<Contributor> availableContributes)
        {
            List<Contributor> contributors = new List<Contributor>();

            while (contributors.Count != project.RequiredSkills.Count)
            {
                contributors.Clear();

                foreach (var projectSkill in project.RequiredSkills)
                {
                    var contributor = availableContributes
                        .Except(contributors)
                        .FirstOrDefault(x =>
                            x.Skills.Any(skill =>
                                skill.Name == projectSkill.Name
                                && skill.Level >= projectSkill.Level)
                            && x.UnOccuppiedFromDay <= GetProjectStartDay(project));

                    if (contributor == null)
                    {
                        IEnumerable<Contributor> contributorsWithRequiredSkill =
                            availableContributes
                                .Where(x =>
                                    x.Skills.Any(skill =>
                                        skill.Name == projectSkill.Name
                                        && skill.Level >= projectSkill.Level));

                        if (contributorsWithRequiredSkill.Any())
                        {
                            // Push deadline
                            var newProjectStartDay = contributorsWithRequiredSkill
                                .Select(x => x.UnOccuppiedFromDay)
                                .Min();
                            project.B_BestBefore = Math.Max(project.B_BestBefore, newProjectStartDay + project.D_NumberOfDaysToComplete + 1);

                            // Rescan all skills with new deadline
                            break;
                        }
                        else
                        {
                            // Can't do project. Probably need skill levelling support
                            return new List<string>();
                        }
                    }

                    contributors.Add(contributor);
                }
            }

            AssignContributorsToProject(project, contributors);

            return contributors.Select(x => x.Name).ToList();
        }

        private static void AssignContributorsToProject(Project project, List<Contributor> contributors)
        {
            foreach (var contributor in contributors)
            {
                contributor.UnOccuppiedFromDay = GetProjectEndDay(project) + 1;
            }
        }
    }
}
