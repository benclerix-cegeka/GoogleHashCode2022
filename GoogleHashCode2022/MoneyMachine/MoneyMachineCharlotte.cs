﻿using GoogleHashCode2021;
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

            //Dictionary<string, Tuple<int, string>> skillOverview = new Dictionary<string, Tuple<int, string>>();
            //foreach (var contributor in input.Contributors)
            //{
            //    foreach (var skill in contributor.Skills)
            //    {
            //        skillOverview.Add(skill.Name, new Tuple<int, string>(skill.Level, contributor.Name));
            //    }
            //}

            foreach (var project in input.Projects)
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
