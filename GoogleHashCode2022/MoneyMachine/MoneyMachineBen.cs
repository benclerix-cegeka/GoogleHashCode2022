using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleHashCode2021;
using GoogleHashCode2022.Models;

namespace GoogleHashCode2022
{
    public class MoneyMachineBen
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
                var projectMembers = GetProjectContributors(project.RequiredSkills, availableContributes, projectStartDay, projectEndDay);
                solution.Contributers = projectMembers.Select(x => x.Name).ToList();

                foreach (var projectMember in projectMembers)
                {
                    LevelUp(projectMember, input);
                }

                if (solution.Contributers.Count == project.RequiredSkills.Count)
                {
                    solutions.Add(solution);
                }
            }

            return new OutputData { Solutions = solutions };
        }

        private static void LevelUp(ProjecMember projectMember, InputData inputData)
        {
            var contributor = inputData.Contributors.SingleOrDefault(c => c.Name == projectMember.Name);
            var skill = contributor?.Skills.Single(s => s.Name == projectMember.Skill.Name && s.Level == projectMember.Skill.Level);
            if (skill != null)
            {
                skill.Level++;
            }
        }

        private static List<ProjecMember> GetProjectContributors(List<Skill> projectSkills, List<Contributor> availableContributes, int projectStartDay, int projectEndDay)
        {
            List<ProjecMember> projectMembers = new List<ProjecMember>();

            foreach (var projectSkill in projectSkills)
            {
                Contributor contributor = null;
                Skill contributedSkill = null;
                foreach (var availableContribute in availableContributes)
                {
                    var contributedSkills = availableContribute.Skills.Where(skill =>
                        skill.Name == projectSkill.Name
                        && skill.Level >= projectSkill.Level).ToList();
                    if (contributedSkills.Any() && availableContribute.UnOccuppiedFromDay <= projectStartDay)
                    {
                        contributor = availableContribute;
                        contributedSkill = contributedSkills.FirstOrDefault();
                    }
                }

                if (contributor == null || contributedSkill == null)
                    break;

                contributor.UnOccuppiedFromDay = projectEndDay + 1;
                projectMembers.Add(new ProjecMember { Name = contributor.Name, Skill = contributedSkill });
            }

            return projectMembers;
        }
    }
}
