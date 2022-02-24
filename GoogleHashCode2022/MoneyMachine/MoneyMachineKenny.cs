using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using GoogleHashCode2021;
using GoogleHashCode2022.Models;

namespace GoogleHashCode2022
{
    internal class MoneyMachineKenny
    {
        public static OutputData CalculateSolution(InputData input)
        {
            var output = new OutputData();

            var result = Calculate(input.Contributors, input.Projects);

            output.Solutions = result;

            return output;
        }

        public static List<Solution> Calculate(List<Contributor> contributors, List<Project> projects)
        {
            var solutions = new List<Solution>();

            while (projects.Any(x => !x.Done)) { 
                foreach (var project in projects.Where(x=>!x.Done))
                {
                    var result = GetSolution(project, contributors);
                    if (result == null)
                    {
                        continue;
                    }

                    LevelUp(contributors, result);
                    
                    solutions.Add(result);
                }
            }

            return solutions;
        }

        private static Solution GetSolution(Project project, List<Contributor> contributors)
        {
            var solution = new Solution { ProjectName = project.Name, Contributers = new List<string>() };

            foreach (var skill in project.RequiredSkills)
            {
                var skilledContributors = contributors.Where(x => x.Skills.Select(s => s.Name).Contains(skill.Name));
                var result = skilledContributors.FirstOrDefault(x => x.Skills.Select(s => s.Level).Any(y => y >= skill.Level));
                if (result == null)
                {
                    return null;
                }

                solution.Contributers.Add(result.Name);
            }

            return solution;
        }

        private static void LevelUp(List<Contributor> contributors, Solution solutionContributers)
        {
            foreach (var contributer in solutionContributers.Contributers)
            {
                
            }
            return;
        }
    }
}
