﻿using System;
using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Utils.Extensions
{
    public static class SupportActivityExtensions
    {
        [Obsolete("Use FriendlyNameShort")]
        public static string FriendlyNameForEmail(this SupportActivities activity)
        {
            return activity switch
            {
                SupportActivities.Shopping => "shopping",
                SupportActivities.CollectingPrescriptions => "collecting prescriptions",
                SupportActivities.Errands => "local errands",
                SupportActivities.DogWalking => "dog walking",
                SupportActivities.MealPreparation => "a prepared meal",
                SupportActivities.PhoneCalls_Friendly => "a friendly chat",
                SupportActivities.PhoneCalls_Anxious => "a supportive chat",
                SupportActivities.HomeworkSupport => "homework support for parent",
                SupportActivities.CheckingIn => "a neighbourly check-in",
                SupportActivities.FaceMask => "homemade face coverings",
                SupportActivities.WellbeingPackage => "delivering a well-being package",
                SupportActivities.Other => "your requested activity",
                SupportActivities.CommunityConnector => "a community connector",
                SupportActivities.MedicalAppointmentTransport => "medical appointment transport",
                SupportActivities.ColdWeatherArmy => "cold weather army assistance",
                SupportActivities.Transport => "transport",
                _ => throw new ArgumentException(message: $"Unexpected SupportActivity: {activity}", paramName: nameof(activity))
            };
        }

        public static string FriendlyNameShort(this SupportActivities activity)
        {
            return activity switch
            {
                SupportActivities.Shopping => "Shopping",
                SupportActivities.CollectingPrescriptions => "Prescriptions",
                SupportActivities.Errands => "Errands",
                SupportActivities.DogWalking => "Dog Walking",
                SupportActivities.MealPreparation => "Prepared Meal",
                SupportActivities.PhoneCalls_Friendly => "Friendly Chat",
                SupportActivities.PhoneCalls_Anxious => "Supportive Chat",
                SupportActivities.HomeworkSupport => "Homework",
                SupportActivities.CheckingIn => "Check In",
                SupportActivities.FaceMask => "Face Covering",
                SupportActivities.WellbeingPackage => "Wellbeing Package",
                SupportActivities.Other => "Other",
                SupportActivities.CommunityConnector => "Community Connector",
                SupportActivities.MedicalAppointmentTransport => "Medical Appointment Transport",
                SupportActivities.ColdWeatherArmy => "Cold Weather Army",
                SupportActivities.Transport => "Transport",
                _ => throw new ArgumentException(message: $"Unexpected SupportActivity: {activity}", paramName: nameof(activity))
            };
        }

        public static string PerfectTense(this SupportActivities activity, int count)
        {
            if (count == 1)
            {
                return activity switch
                {
                    SupportActivities.Shopping => "1 shopping trip",
                    SupportActivities.FaceMask => "1 request for face coverings",
                    SupportActivities.CheckingIn => "1 person checked on",
                    SupportActivities.CollectingPrescriptions => "1 prescription collected",
                    SupportActivities.Errands => "1 errand run",
                    SupportActivities.DogWalking => "1 dog walked",
                    SupportActivities.MealPreparation => "1 meal prepared",
                    SupportActivities.PhoneCalls_Friendly => "1 friendly chat",
                    SupportActivities.PhoneCalls_Anxious => "1 supportive chat",
                    SupportActivities.HomeworkSupport => "1 homework assignment",
                    SupportActivities.WellbeingPackage => "1 wellbeing package delivered",
                    SupportActivities.CommunityConnector => "1 community connector task",
                    SupportActivities.MedicalAppointmentTransport => "1 person transported to a medical appointment",
                    SupportActivities.ColdWeatherArmy => "1 cold weather army task completed",
                    SupportActivities.Other => "1 other task completed",
                    _ => throw new ArgumentException(message: $"Unexpected SupportActivity: {activity}", paramName: nameof(activity))
                };
            }
            else
            {
                return activity switch
                {
                    SupportActivities.Shopping => $"{count} shopping trips",
                    SupportActivities.FaceMask => $"{count} requests for face coverings",
                    SupportActivities.CheckingIn => $"{count} people checked on",
                    SupportActivities.CollectingPrescriptions => $"{count} prescriptions collected",
                    SupportActivities.Errands => $"{count} errands run",
                    SupportActivities.DogWalking => $"{count} dogs walked",
                    SupportActivities.MealPreparation => $"{count} meals prepared",
                    SupportActivities.PhoneCalls_Friendly => $"{count} friendly chats",
                    SupportActivities.PhoneCalls_Anxious => $"{count} supportive chats",
                    SupportActivities.HomeworkSupport => $"{count} homework assignments",
                    SupportActivities.WellbeingPackage => $"{count} wellbeing packages delivered",
                    SupportActivities.CommunityConnector => $"{count} community connector tasks",
                    SupportActivities.MedicalAppointmentTransport => $"{count} people transported to medical appointments",
                    SupportActivities.ColdWeatherArmy => $"{count} cold weather army tasks completed",
                    SupportActivities.Other => $"{count} other tasks completed",
                    _ => throw new ArgumentException(message: $"Unexpected SupportActivity: {activity}", paramName: nameof(activity))
                };
            }
        }
    }
}
