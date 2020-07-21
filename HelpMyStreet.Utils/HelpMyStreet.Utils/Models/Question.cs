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
        public QuestionType Type {get;set;}
        public bool Required { get; set; }
        public string Answer { get; set; }
        public List<AdditonalQuestionData> AddtitonalData { get; set; }
    }


}
