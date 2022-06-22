using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
                SupportActivities.MealtimeCompanion => "mealtime companion",
                SupportActivities.MealsToYourDoor => "meals on to your door",
                SupportActivities.VolunteerSupport => "volunteer support",
                SupportActivities.VaccineSupport => "vaccine programme support",
                SupportActivities.EmergencySupport => "emergency support",
                SupportActivities.InPersonBefriending => "in-person befriending",
                SupportActivities.PracticalSupport => "practical support",
                SupportActivities.VolunteerInduction => "volunteer induction",
                SupportActivities.BinDayAssistance => "bin day assistance",
                SupportActivities.Covid19Help => "covid 19 help",
                SupportActivities.DigitalSupport => "digital support",
                SupportActivities.BankStaffVaccinator => "bank staff vaccinator",
                SupportActivities.SkillShare => "skill share",
                SupportActivities.Accommodation => "accommodation",
                SupportActivities.AdvertisingRoles => "advertising roles",
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
                SupportActivities.MealsToYourDoor => "Meals To Your Door",
                SupportActivities.MealtimeCompanion => "Mealtime Companion",
                SupportActivities.VolunteerSupport => "Volunteer Support",
                SupportActivities.VaccineSupport => "Vaccine Support",
                SupportActivities.EmergencySupport => "Emergency Support",
                SupportActivities.InPersonBefriending => "In-Person Befriending",
                SupportActivities.PracticalSupport => "Practical Support",
                SupportActivities.VolunteerInduction => "Volunteer Induction",
                SupportActivities.BinDayAssistance => "Bin Day Assistance",
                SupportActivities.Covid19Help => "Covid 19 Help",
                SupportActivities.DigitalSupport => "Digital Support",
                SupportActivities.BankStaffVaccinator => "Bank Staff Vaccinator",
                SupportActivities.SkillShare => "Skill Share",
                SupportActivities.Accommodation => "Accommodation",
                SupportActivities.AdvertisingRoles => "Advertising Roles",
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
                    SupportActivities.CommunityConnector => "1 community connector task completed",
                    SupportActivities.MedicalAppointmentTransport => "1 person transported to a medical appointment",
                    SupportActivities.Transport => "1 transport task completed",
                    SupportActivities.ColdWeatherArmy => "1 cold weather army task completed",
                    SupportActivities.Other => "1 other task completed",
                    SupportActivities.MealtimeCompanion => "1 mealtime companion task completed",
                    SupportActivities.MealsToYourDoor => "1 meal delivered",
                    SupportActivities.VolunteerSupport => "1 volunteer support task completed",
                    SupportActivities.VaccineSupport => "1 vaccination support shift completed",
                    SupportActivities.EmergencySupport => "1 emergency support task completed",
                    SupportActivities.InPersonBefriending => "1 befriending session completed",
                    SupportActivities.PracticalSupport => "1 person supported",
                    SupportActivities.VolunteerInduction => "1 volunteer induction completed",
                    SupportActivities.BinDayAssistance => "1 bin day assistance completed",
                    SupportActivities.Covid19Help => "1 covid 19 help completed",
                    SupportActivities.DigitalSupport => "1 digital support completed",
                    SupportActivities.BankStaffVaccinator => "1 bank staff vaccinator completed",
                    SupportActivities.SkillShare => "1 skill shared",
                    SupportActivities.Accommodation => "1 group accommodated",
                    SupportActivities.AdvertisingRoles => "1 role accepted",
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
                    SupportActivities.CommunityConnector => $"{count} community connector tasks completed",
                    SupportActivities.MedicalAppointmentTransport => $"{count} people transported to medical appointments",
                    SupportActivities.Transport => $"{count} transport task completed",
                    SupportActivities.ColdWeatherArmy => $"{count} cold weather army tasks completed",
                    SupportActivities.Other => $"{count} other tasks completed",
                    SupportActivities.MealtimeCompanion => $"{count} mealtime companion tasks completed",
                    SupportActivities.MealsToYourDoor => $"{count} meals delivered",
                    SupportActivities.VolunteerSupport => $"{count} volunteer support tasks completed",
                    SupportActivities.VaccineSupport => $"{count} vaccination support shifts completed",
                    SupportActivities.EmergencySupport => $"{count} emergency support tasks completed",
                    SupportActivities.InPersonBefriending => $"{count} befriending sessions completed",
                    SupportActivities.PracticalSupport => $"{count} people supported",
                    SupportActivities.VolunteerInduction => $"{count} volunteer inductions completed",
                    SupportActivities.BinDayAssistance => $"{count} bin day assistance completed",
                    SupportActivities.Covid19Help => $"{count} covid 19 help completed",
                    SupportActivities.DigitalSupport => $"{count} digital support completed",
                    SupportActivities.BankStaffVaccinator => $"{count} bank staff vaccinator completed",
                    SupportActivities.SkillShare => $"{count} skills shared",
                    SupportActivities.Accommodation => $"{count} groups accommodated",
                    SupportActivities.AdvertisingRoles => $"{count} roles accepted",
                    _ => throw new ArgumentException(message: $"Unexpected SupportActivity: {activity}", paramName: nameof(activity))
                };
            }
        }

        public static bool AllowRepeatRequests(this SupportActivities activity)
        {
            return activity switch
            {
                SupportActivities.Shopping => true,
                SupportActivities.CollectingPrescriptions => true,
                SupportActivities.Errands => true,
                SupportActivities.DogWalking => true,
                SupportActivities.MealPreparation => true,
                SupportActivities.PhoneCalls_Friendly => true,
                SupportActivities.Other => true,
                SupportActivities.Transport => true,
                SupportActivities.MealsToYourDoor => true,
                SupportActivities.VolunteerSupport => true,
                SupportActivities.MealtimeCompanion => true,
                SupportActivities.VaccineSupport => true,
                SupportActivities.FaceMask => false,
                SupportActivities.CheckingIn => false,
                SupportActivities.PhoneCalls_Anxious => false,
                SupportActivities.WellbeingPackage => false,
                SupportActivities.MedicalAppointmentTransport => false,
                SupportActivities.ColdWeatherArmy => false,
                SupportActivities.InPersonBefriending => false,
                SupportActivities.PracticalSupport => false,
                SupportActivities.HomeworkSupport => false,
                SupportActivities.CommunityConnector => false,
                SupportActivities.EmergencySupport => false,
                SupportActivities.VolunteerInduction => false,
                SupportActivities.BinDayAssistance => false,
                SupportActivities.Covid19Help => false,
                SupportActivities.DigitalSupport => false,
                SupportActivities.BankStaffVaccinator => false,
                SupportActivities.SkillShare => false,
                SupportActivities.Accommodation => true,
                SupportActivities.AdvertisingRoles => false,
                _ => throw new ArgumentException(message: $"Unexpected SupportActivity: {activity}", paramName: nameof(activity))
            };
        }

        public static bool IsRemoteActivity(this SupportActivities activity)
        {
            return activity switch
            {
                SupportActivities.PhoneCalls_Friendly => true,
                SupportActivities.PhoneCalls_Anxious => true,
                SupportActivities.HomeworkSupport => true,
                SupportActivities.CommunityConnector => true,
                _ => false
            };
        }

        public static bool AddressIsArbitrary(this SupportActivities activity)
        {
            return activity switch
            {
                SupportActivities.Accommodation => true,
                _ => false
            };
        }

        public static List<PersonalDetailsComponent> PersonalDetailsComponent(this SupportActivities activity, RequestRoles roleType, bool isAdmin = false)
        {

            var allData = new List<PersonalDetailsComponent>() {
                Enums.PersonalDetailsComponent.Address,
                Enums.PersonalDetailsComponent.Postcode,
                Enums.PersonalDetailsComponent.Email,
                Enums.PersonalDetailsComponent.Phone,
                Enums.PersonalDetailsComponent.FirstName,
                Enums.PersonalDetailsComponent.LastName
            };

            var reducedData = new List<PersonalDetailsComponent>() {
                Enums.PersonalDetailsComponent.Email,
                Enums.PersonalDetailsComponent.Phone,
                Enums.PersonalDetailsComponent.FirstName,
                Enums.PersonalDetailsComponent.LastName
            };

            if (isAdmin)
            {
                if (roleType == RequestRoles.Volunteer)
                {
                    return new List<PersonalDetailsComponent>() {
                            Enums.PersonalDetailsComponent.Email,
                            Enums.PersonalDetailsComponent.Phone,
                            Enums.PersonalDetailsComponent.FirstName,
                            Enums.PersonalDetailsComponent.LastName,
                            Enums.PersonalDetailsComponent.Locality
                            };
                }
                else if (activity.AddressIsArbitrary())
                {
                    return reducedData;
                }
                else
                {
                    return allData;
                }
            }
            else if (roleType == RequestRoles.Requestor)
            {
                return reducedData;
            }
            else if (activity.AddressIsArbitrary() || activity.IsRemoteActivity())
            {
                return reducedData;
            }
            else
            {
                return allData;
            }

        }


        public static RequestType RequestType(this SupportActivities activity)
        {
            return activity switch
            {
                SupportActivities.VaccineSupport => Enums.RequestType.Shift,
                SupportActivities.BankStaffVaccinator => Enums.RequestType.Shift,
                _ => Enums.RequestType.Task
            };
        }

        public static SupportActivityCategory Category(this SupportActivities activity)
        {
            return activity switch
            {
                SupportActivities.Shopping => SupportActivityCategory.EverydayActivities,
                SupportActivities.CollectingPrescriptions => SupportActivityCategory.EverydayActivities,
                SupportActivities.Errands => SupportActivityCategory.EverydayActivities,
                SupportActivities.DogWalking => SupportActivityCategory.EverydayActivities,
                SupportActivities.MealPreparation => SupportActivityCategory.EverydayActivities,
                SupportActivities.PracticalSupport => SupportActivityCategory.EverydayActivities,
                SupportActivities.DigitalSupport => SupportActivityCategory.EverydayActivities,
                SupportActivities.BinDayAssistance => SupportActivityCategory.EverydayActivities,
                SupportActivities.Covid19Help => SupportActivityCategory.EverydayActivities,
                SupportActivities.PhoneCalls_Friendly => SupportActivityCategory.Befriending,
                SupportActivities.CheckingIn => SupportActivityCategory.Befriending,
                SupportActivities.MealtimeCompanion => SupportActivityCategory.Befriending,
                SupportActivities.InPersonBefriending => SupportActivityCategory.Befriending,
                SupportActivities.WellbeingPackage => SupportActivityCategory.CommunityVolunteering,
                SupportActivities.ColdWeatherArmy => SupportActivityCategory.CommunityVolunteering,
                SupportActivities.MealsToYourDoor => SupportActivityCategory.CommunityVolunteering,
                SupportActivities.VolunteerSupport => SupportActivityCategory.CommunityVolunteering,
                SupportActivities.VaccineSupport => SupportActivityCategory.CommunityVolunteering,
                SupportActivities.BankStaffVaccinator => SupportActivityCategory.CommunityVolunteering,
                SupportActivities.SkillShare => SupportActivityCategory.CommunityVolunteering,
 
                SupportActivities.Other => SupportActivityCategory.AnythingElse,
                SupportActivities.FaceMask => SupportActivityCategory.AnythingElse,
                SupportActivities.PhoneCalls_Anxious => SupportActivityCategory.AnythingElse,
                SupportActivities.MedicalAppointmentTransport => SupportActivityCategory.AnythingElse,
                SupportActivities.HomeworkSupport => SupportActivityCategory.AnythingElse,
                SupportActivities.CommunityConnector => SupportActivityCategory.Befriending,
                SupportActivities.EmergencySupport => SupportActivityCategory.AnythingElse,
                SupportActivities.VolunteerInduction => SupportActivityCategory.AnythingElse,
                SupportActivities.AdvertisingRoles => SupportActivityCategory.AnythingElse,
                _ => throw new ArgumentException(message: $"Unexpected SupportActivity: {activity}", paramName: nameof(activity))
            };
        }
    }
}
