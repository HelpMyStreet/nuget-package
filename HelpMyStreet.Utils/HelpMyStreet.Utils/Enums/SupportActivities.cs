using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Enums
{
    public enum SupportActivities : int
    {
        Shopping  = 1,
        //Picking up groceries and other essentials(e.g.food, toiletries, household products)

        CollectingPrescriptions,
        //Collecting prescriptions from a local pharmacy

        Errands,
        //Running essential local errands(e.g.posting mail)

        MedicalAppointmentTransport,
        //Providing transport for essential medical appointments(where it is safe to do so)

        DogWalking,
        //Dog walking

        MealPreparation,
        //Delivering a hot / pre-prepared meal

        PhoneCalls_Friendly,
        //Making / receiving phone calls for those in need of a friendly chat

        PhoneCalls_Anxious,
        //Making / receiving phone calls for those who may be anxious

        HomeworkSupport,
        //Homework support for children being home-schooled

        CheckingIn,
        //Reaching out to people in my area to check-in

        Other,
        //I may be able to help with other tasks. Please check with me.
    }
}