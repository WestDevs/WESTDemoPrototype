using System;
using System.Collections.Generic;
using System.Linq;
using WESTDemo.Domain.Models;
using WESTDemo.Infrastracture.Context;

namespace WESTDemo.Infrastracture.Context
{
    public class DbInitializer
    {
        public static void Initialize(UsersContext context)
        {
            if(context.UserTypes.Any()) return;

            var userTypes = new UserType[]
            {
                new UserType { Name = "Admin"},
                new UserType { Name = "Tutor"},
                new UserType { Name = "Learner"},
                new UserType { Name = "Other"}
            };

            foreach (var userType in userTypes)
                context.UserTypes.Add(userType); 
            
            context.SaveChanges();

            if(context.Organisations.Any()) return;

            var orgs = new Organisation[]
            {
                new Organisation { Name = "WEST" },
                new Organisation { Name = "Tribal" },
                new Organisation { Name = "Others" },
                new Organisation { Name = "ACT Training Group" }
            };

            foreach (var org in orgs)
                context.Organisations.Add(org);
            context.SaveChanges();

            if (context.Centres.Any()) return;

            var centres = new Centre[]
            {
                new Centre { OrganisationId = orgs.Single(o => o.Name == "ACT Training Group").Id, Name = "Academy of Hair and Beauty" },
                new Centre { OrganisationId = orgs.Single(o => o.Name == "ACT Training Group").Id, Name = "ACT Enhance" },
                new Centre { OrganisationId = orgs.Single(o => o.Name == "ACT Training Group").Id, Name = "ACT Staff Initial Assessments" }
            };

            if (context.Users.Any()) return;

            foreach (var centre in centres)
                context.Centres.Add(centre);
            context.SaveChanges();

            var users = new User[]
            {
                new User
                    {  
                        Username = "admin0",
                        FirstName = "Admin0 FN",
                        LastName = "Admin0 LN",
                        OrganisationId = 1,
                        Birthdate = DateTime.Parse("1990-01-01"),
                        TypeId = 1                        
                    },
                new User
                    {  
                        Username = "tutor0",
                        FirstName = "Tutor0 FN",
                        LastName = "Tutor0 LN",
                        OrganisationId = 2,
                        Birthdate = DateTime.Parse("1991-01-01"),
                        TypeId = 2                        
                    },
                new User
                    {  
                        Username = "learner0",
                        FirstName = "Learner0 FN",
                        LastName = "Learner0 LN",
                        OrganisationId = 2,
                        Birthdate = DateTime.Parse("2005-01-01"),
                        TypeId = 3                        
                    }                
            };
            foreach(var user in users)
                context.Users.Add(user);
            context.SaveChanges();


            if (context.Groups.Any()) return;

            var groups = new Group[] {
                new Group { Name = "default" }
            };
            foreach (var group in groups)
                context.Groups.Add(group);
            context.SaveChanges();

            if (context.Learners.Any()) return;
            
            var learnerUsers =  users.Where(u => u.TypeId == 3);
            var learners = new List<Learner>();
            foreach (var learnerUser in learnerUsers)
            {
                var learner = new Learner { UserId = learnerUser.Id, GroupId = 1 };
                learners.Add(learner);
                context.Learners.Add(learner);             
            }
            context.SaveChanges();

            if (context.Courses.Any()) return;

            var courses = new Course[] {
                new Course { Name = "Application of Number 2015" , IconPath = "./assets/esm.png" },
                new Course { Name = "Communication (English) 2015" , IconPath = "./assets/esl.png" },
                new Course { Name = "Communication (Welsh) 2015" , IconPath = "./assets/esw.png" },
                new Course { Name = "Digital Literacy" , IconPath = "./assets/esd.png" },
                new Course { Name = "ESOL" , IconPath = "./assets/esol.png" }
            };
            foreach (var course in courses)
                context.Courses.Add(course);
            context.SaveChanges();


            if (context.LearnerStatuses.Any()) return;


            var learnerStatuses = new LearnerStatus[] {
                new LearnerStatus {
                    LearnerId = learners.Single(l => l.User.Username == "learner0").Id,
                    CourseId = courses.Single(c => c.Name == "Application of Number 2015").Id
                },
                new LearnerStatus {
                    LearnerId = learners.Single(l => l.User.Username == "learner0").Id,
                    CourseId = courses.Single(c => c.Name == "ESOL").Id
                }
            };

            foreach (var learnerStatus in learnerStatuses)
                context.LearnerStatuses.Add(learnerStatus);
            context.SaveChanges();
            
        }
    }
}