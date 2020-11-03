using System;
using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Utils.Extensions
{
    public static class SupportActivityExtensions
    {
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
    }
}
