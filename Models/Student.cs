using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPtask.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private int _course { get; set; }
        public int Course 
        { 
            get { return _course; } 
            set 
            {
                if (Enumerable.Range(1, 6).Contains(value)) _course = value;
                else throw new ArgumentException("Value is outside of bounds", nameof(Course));
            } 
        }
        public List<Answer> Answers { get; set; }
        public int UniversityID { get; set; }
        public bool CompletedSurvey = false;
    }
}
