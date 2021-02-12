using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPtask.Models;

namespace ASPtask.Data
{
    public class InitDB
    {
        public static void Initialize(StudentsDB context)
        {
            context.Database.EnsureCreated();
            if (!context.Universities.Any())
            {
                var universities = new University[]
                {
                    new University{UniversityID=1,UniversityName="SUSU",UniversityPoints=1},
                    new University{UniversityID=2,UniversityName="CSU",UniversityPoints=2},
                    new University{UniversityID=3,UniversityName="KFU",UniversityPoints=3}
                };
                foreach (University unv in universities)
                    context.Universities.Add(unv);
                context.SaveChanges();
            }

            if (!context.Students.Any())
            {
                var students = new Student[]
                {
                    new Student{StudentID=1,FirstName="Carson",LastName="Alexander",Course=1,UniversityID=1,CompletedSurvey=false},
                    new Student{StudentID=2,FirstName="Meredith",LastName="Alonso",Course=2,UniversityID=2,CompletedSurvey=false},
                    new Student{StudentID=3,FirstName="Arturo",LastName="Anand",Course=3,UniversityID=3,CompletedSurvey=false},
                    new Student{StudentID=4,FirstName="Gytis",LastName="Barzdukas",Course=4,UniversityID=1,CompletedSurvey=false}
                };
                foreach (Student std in students)
                    context.Students.Add(std);
                context.SaveChanges();
            }
            if (!context.Questions.Any())
            {
                var questions = new Question[]
                {
                    new Question{ID=1,HasOptions=true,MultipleSelect=false,QuestionContents="Are you interested in what you are doing?",AnswerOptions=new List<AnswerOption> { new AnswerOption { Option = "Yes" }, new AnswerOption { Option = "No" } }},
                    new Question{ID=2,HasOptions=true,MultipleSelect=false,QuestionContents="Do you like your teachers?",AnswerOptions=new List<AnswerOption> { new AnswerOption { Option = "Yes" }, new AnswerOption { Option = "No" } } },
                    new Question{ID=3,HasOptions=false,MultipleSelect=false,QuestionContents="Describe yourself"}
                };
                foreach (Question que in questions)
                    context.Questions.Add(que);
                context.SaveChanges();
            }
        }
    }
}
