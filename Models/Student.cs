using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;

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
        [NotMapped]
        public Dictionary<int, List<string>> Answers { get; set; } = new Dictionary<int, List<string>>();
        public string JsonTempObj
        {
            get 
            { 
                return Answers == null || !Answers.Any() ? null : JsonConvert.SerializeObject(Answers); 
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) Answers.Clear();
                else Answers = JsonConvert.DeserializeObject<Dictionary<int, List<string>>>(value);
            }
        }
    }
}
