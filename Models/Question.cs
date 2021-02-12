using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPtask.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string QuestionContents { get; set; }
        public bool HasOptions { get; set; }
        public bool MultipleSelect { get; set; }
        public List<AnswerOption> AnswerOptions { get; set; }
    }
}
