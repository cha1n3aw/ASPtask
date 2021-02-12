using System.Collections.Generic;

namespace ASPtask.Models
{
    public class ViewModel
    {
        public List<University> AllUniversities { get; set; }
        public List<Question> AllQuestions { get; set; }
        public List<Student> AllStudents { get; set; }
        public Student OneStudent { get; set; }
    }
}
