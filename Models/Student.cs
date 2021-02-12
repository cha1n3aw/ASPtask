using System.Collections.Generic;

namespace ASPtask.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public int Course { get; set; }
        public int UniversityID { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
