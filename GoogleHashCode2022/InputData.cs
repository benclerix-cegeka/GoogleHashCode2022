using System;
using System.Collections.Generic;
using System.IO;
using GoogleHashCode2022.Models;

namespace GoogleHashCode2021
{
    public class InputData
    {

        public int NumberOfProjects { get; set; }
        public int NumberOfContributors { get; set; }

        public List<Contributor> Contributors { get; set; }

        public List<Project> Projects { get; set; }

        public InputData(string file)
        {
            ReadInputFile(file);
        }

        private void ReadInputFile(string file)
        {
            using (var reader = new StreamReader(file))
            {
                // First line
                var line = reader.ReadLine();
                var l = line.Split(' ');

                NumberOfContributors = Int32.Parse(l[0]);
                NumberOfProjects = Int32.Parse(l[1]);

                Contributors = new List<Contributor>();

                for (int j = 0; j < NumberOfContributors; j++)
                {
                    var lineContributor = reader.ReadLine();
                    var contributorSplit = lineContributor.Split(' ');
                    var name = contributorSplit[0];
                    var numberOfSkills = Int32.Parse(contributorSplit[1]);

                    List<Skill> skills = new List<Skill>();
                    for (int k = 0; k < numberOfSkills; k++)
                    {
                        var lineSkill = reader.ReadLine();
                        var skillSplit = lineSkill.Split(' ');
                        skills.Add(new Skill
                        {
                            Name = skillSplit[0],
                            Level = Int32.Parse(skillSplit[1])
                        });
                    }
                    
                    Contributors.Add(new Contributor
                    {
                        Name = name,
                        Skills = skills
                    });
                }
                
                Projects = new List<Project>();

                for (int j = 0; j < NumberOfProjects; j++)
                {

                    var lineProject = reader.ReadLine();
                    var projectSplit = lineProject.Split(' ');
                    var name = projectSplit[0];
                    var D_NumberOfDaysToComplete = Int32.Parse(projectSplit[1]);
                    var S_ScoreForCompletion = Int32.Parse(projectSplit[2]);
                    var B_BestBefore = Int32.Parse(projectSplit[3]);
                    var R_NumberOfRoles = Int32.Parse(projectSplit[4]);

                    List<Skill> skills = new List<Skill>();
                    for (int k = 0; k < R_NumberOfRoles; k++)
                    {
                        var lineSkill = reader.ReadLine();
                        var skillSplit = lineSkill.Split(' ');
                        skills.Add(new Skill
                        {
                            Name = skillSplit[0],
                            Level = Int32.Parse(skillSplit[1])
                        });
                    }

                    Projects.Add(new Project
                    {
                        Name = name,
                        D_NumberOfDaysToComplete = D_NumberOfDaysToComplete,
                        B_BestBefore = B_BestBefore,
                        R_NumberOfRoles = R_NumberOfRoles,
                        S_ScoreForCompletion = S_ScoreForCompletion,
                        RequiredSkills = skills
                    });
                }
            }
        }
    }
}
