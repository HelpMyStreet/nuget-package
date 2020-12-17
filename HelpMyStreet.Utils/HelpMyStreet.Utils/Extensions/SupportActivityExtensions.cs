using System;
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

        public static string PerfectTense(this SupportActivities activity, bool pleural = false)
        {
            if (pleural)
            {
                return activity switch
                {
                    SupportActivities.Shopping => "shopping trips",
                    SupportActivities.FaceMask => "requests for face coverings",
                    SupportActivities.CheckingIn => "people checked on",
                    SupportActivities.CollectingPrescriptions => "prescriptions collected",
                    SupportActivities.Errands => "errands run",
                    SupportActivities.DogWalking => "dogs walked",
                    SupportActivities.MealPreparation => "meals prepared",
                    SupportActivities.PhoneCalls_Friendly => "friendly chats",
                    SupportActivities.PhoneCalls_Anxious => "supportive chats",
                    SupportActivities.HomeworkSupport => "homework assignments",
                    SupportActivities.WellbeingPackage => "wellbeing packages sent",
                    SupportActivities.CommunityConnector => "community connector tasks",
                    SupportActivities.MedicalAppointmentTransport => "medical appointments transported",
                    SupportActivities.ColdWeatherArmy => "cold weather army tasks completed",
                    SupportActivities.Other => "other tasks",
                    _ => throw new ArgumentException(message: $"Unexpected SupportActivity: {activity}", paramName: nameof(activity))
                };
            }
            else
            {
                return activity switch
                {
                    SupportActivities.Shopping => "shopping trip",
                    SupportActivities.FaceMask => "request for face coverings",
                    SupportActivities.CheckingIn => "person checked on",
                    SupportActivities.CollectingPrescriptions => "prescription collected",
                    SupportActivities.Errands => "errand run",
                    SupportActivities.DogWalking => "dog walked",
                    SupportActivities.MealPreparation => "meal prepared",
                    SupportActivities.PhoneCalls_Friendly => "friendly chat",
                    SupportActivities.PhoneCalls_Anxious => "supportive chat",
                    SupportActivities.HomeworkSupport => "homework assignment",
                    SupportActivities.WellbeingPackage => "wellbeing package sent",
                    SupportActivities.CommunityConnector => "community connector task",
                    SupportActivities.MedicalAppointmentTransport => "medical appointment transported",
                    SupportActivities.ColdWeatherArmy => "cold weather army task completed",
                    SupportActivities.Other => "other task",
                    _ => throw new ArgumentException(message: $"Unexpected SupportActivity: {activity}", paramName: nameof(activity))
                };
            }
        }
    }
}
