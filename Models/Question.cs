﻿namespace ASPtask.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string QuestionContents { get; set; }
        public bool HasOptions { get; set; }
        public bool MultipleSelect { get; set; }
        public string Options { get; set; }
    }
}
