﻿using System;
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
                RequestHelpFormVariant.AgeUKNorthWestKent_RequestSubmitter => false,
                RequestHelpFormVariant.AgeUKFavershamAndSittingbourne_RequestSubmitter => false,
                RequestHelpFormVariant.AgeUKSouthKentCoast_RequestSubmitter => false,
                RequestHelpFormVariant.AgeConnectsCardiff_RequestSubmitter=> false,
                RequestHelpFormVariant.MeadowsCommunityHelpers_RequestSubmitter => false,
                RequestHelpFormVariant.Sandbox_RequestSubmitter => false,
                RequestHelpFormVariant.AgeUKWirral => false,
                RequestHelpFormVariant.VitalsForVeterans => false,
                RequestHelpFormVariant.AgeUKMidMersey_RequestSubmitter => false,
                RequestHelpFormVariant.BostonGNS_RequestSubmitter => false,
                RequestHelpFormVariant.UkraineRefugees_RequestSubmitter => false,
                _ => true
            };
        }

        public static bool UseAppliedForStatusIfApplicable(this RequestHelpFormVariant requestHelpFormVariant)
        {
            return requestHelpFormVariant switch
            {
                RequestHelpFormVariant.LincolnshireVolunteersRequests_RequestSubmitter => true,
                _ => false
            };
        }
    }
}
