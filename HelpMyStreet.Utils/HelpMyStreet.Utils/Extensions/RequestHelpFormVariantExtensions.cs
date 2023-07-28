using System;
using System.Collections.Generic;
using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Utils.Extensions
{
    public static class RequestHelpFormVariantExtensions
    {
        public static bool IsPublic(this RequestHelpFormVariant requestHelpFormVariant)
        {
            return requestHelpFormVariant switch
            {
                RequestHelpFormVariant.Sandbox_RequestSubmitter => false,
                RequestHelpFormVariant.AgeUKWirral => false,
                _ => true
            };
        }

        public static bool UseAppliedForStatusIfApplicable(this RequestHelpFormVariant requestHelpFormVariant)
        {
            return requestHelpFormVariant switch
            {
                _ => false
            };
        }
    }
}
