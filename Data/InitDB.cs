using System.Linq;
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
                    new University{UniversityName="SUSU",UniversityPoints=1},
                    new University{UniversityName="CSU",UniversityPoints=2},
                    new University{UniversityName="KFU",UniversityPoints=3}
                };
                foreach (University unv in universities) context.Universities.Add(unv);
                context.SaveChanges();
            }

            if (!context.Students.Any())
            {
                /*
                using (var transaction = context.Database.BeginTransaction())
                {
                    var students = new Student[]
                    {
                        new Student{StudentID=1,FirstName="Carson",LastName="Alexander",Course=1,UniversityID=1,EMail="fdf@gmail.com"},
                        new Student{StudentID=2,FirstName="Meredith",LastName="Alonso",Course=2,UniversityID=2,EMail="dfery@yahoo.com"},
                        new Student{StudentID=3,FirstName="Arturo",LastName="Anand",Course=3,UniversityID=3,EMail="somemail@ya.ru"},
                        new Student{StudentID=4,FirstName="Gytis",LastName="Barzdukas",Course=4,UniversityID=1,EMail="fdfdf@mail.ru"}
                    };
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Students] ON"); //overrides IDENTITY_INSERT OFF to set unique id
                    foreach (Student std in students) context.Students.Add(std);
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Students] OFF");
                    transaction.Commit();
                }
                */
                var students = new Student[]
                {
                    new Student{FirstName="Carson",LastName="Alexander",Course=1,UniversityID=1,EMail="fdf@gmail.com"},
                    new Student{FirstName="Meredith",LastName="Alonso",Course=2,UniversityID=2,EMail="dfery@yahoo.com"},
                    new Student{FirstName="Arturo",LastName="Anand",Course=3,UniversityID=3,EMail="somemail@ya.ru"},
                    new Student{FirstName="Gytis",LastName="Barzdukas",Course=4,UniversityID=1,EMail="fdfdf@mail.ru"}
                };
                foreach (Student std in students) context.Students.Add(std);
                context.SaveChanges();
            }

            if (!context.Questions.Any())
            {
                var questions = new Question[]
                {
                    new Question{HasOptions=true,MultipleSelect=false,QuestionContents="Are you interested in what you are doing?",Options="Yes&No"},
                    new Question{HasOptions=true,MultipleSelect=false,QuestionContents="Do you like your teachers?",Options="Yes&No"},
                    new Question{HasOptions=false,MultipleSelect=false,QuestionContents="Describe yourself"}
                };
                foreach (Question que in questions) context.Questions.Add(que);
                context.SaveChanges();
            }
        }
    }
}
