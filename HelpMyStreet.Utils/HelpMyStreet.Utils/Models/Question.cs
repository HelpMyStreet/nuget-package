using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public QuestionType Type {get;set;}
        public bool Required { get; set; }
    }
}
