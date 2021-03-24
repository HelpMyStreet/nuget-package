﻿using System;
using HelpMyStreet.Utils.Models;
using HelpMyStreet.Utils.Enums;
namespace HelpMyStreet.Utils.Extensions
{
    public static class JobSummaryQuestionExtensions
    {
        public static bool ShowOnTaskManagement(this Question question, bool showSensitiveData)
        {
            return question.Id switch
            {
                (int)Questions.SensitiveInformation => showSensitiveData,
                (int)Questions.IsHealthCritical => false,
                (int)Questions.WillYouCompleteYourself => false,
                (int)Questions.FtlosDonationInformation => false,
                (int)Questions.AgeUKReference => false,
                (int)Questions.Location => false,
                (int)Questions.NumberOfSlots => false,
                (int)Questions.RecipientAge => false,
                _ => true
            };
        }

        public static string FriendlyName(this Question question)
        {
            return question.Id switch
            {
                (int)Questions.FaceMask_SpecificRequirements => "Request Description",
                (int)Questions.SupportRequesting => "Request Description",
                (int)Questions.CommunicationNeeds => "Communication Needs",
                (int)Questions.AnythingElseToTellUs => "Request Details",
                (int)Questions.Shopping_List => "Shopping List",
                (int)Questions.Prescription_PharmacyAddress => "Pharmacy Address",
                (int)Questions.SensitiveInformation => "Further Details",
                _ => question.Name
            };
        }

        public static int TaskManagementDisplayOrder(this Question question)
        {
            return question.Id switch
            {
                (int)Questions.Shopping_List => 1,
                (int)Questions.Prescription_PharmacyAddress => 1,
                (int)Questions.FaceMask_Amount => 1,
                (int)Questions.FaceMask_Recipient => 2,
                (int)Questions.FaceMask_Cost => 3,
                (int)Questions.FaceMask_SpecificRequirements => 4,
                (int)Questions.SupportRequesting => 10,
                (int)Questions.CommunicationNeeds => 98,
                (int)Questions.AnythingElseToTellUs => 99,
                (int)Questions.SensitiveInformation => 100,
                _ => 50
            };
        }
    }
}