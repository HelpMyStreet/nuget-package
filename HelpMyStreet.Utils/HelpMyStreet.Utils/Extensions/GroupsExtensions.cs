﻿using System;
using System.Collections.Generic;
using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Utils.Extensions
{
    public static class GroupsExtensions
    {
        public static string GroupIdentifier(this Groups groups)
        {
            return groups switch
            {
                Groups.Generic => "HMS",
                Groups.FTLOS => "FTL",
                Groups.AgeUKLSL => "LSL",
                Groups.HLP => "HLP",
                Groups.Tankersley => "TAP",
                Groups.Ruddington => "RUD",
                Groups.AgeUKWirral => "WIR",
                Groups.AgeUKNottsBalderton => "BAL",
                Groups.AgeUKNorthWestKent => "NWK",
                Groups.AgeUKNottsNorthMuskham => "NMK",
                Groups.AgeUKSouthKentCoast => "SKC",
                Groups.AgeUKFavershamAndSittingbourne => "FAS",
                Groups.LincolnshireVolunteers => "LCN",
                Groups.EastLindseyPCN => "EL",
                Groups.GranthamPCN => "GRA",
                Groups.SouthLincolnPCN => "SLN",
                Groups.StamfordPCN => "SFD",
                Groups.SpilsbyPCN => "SBY",
                Groups.BostonPCN => "BTN",
                Groups.LincolnPCN => "APX",
                Groups.LincolnPortlandPCN => "LPL",
                Groups.Sandbox => "TEST",
                Groups.AgeConnectsCardiff => "ACC",
                Groups.MeadowsCommunityHelpers => "MCC",
                Groups.MansfieldCVS => "MAN",
                Groups.MansfieldWickes => "WKS",
                Groups.GamstonCommunityHall => "GMS",
                Groups.RichardHerrodCentre => "RHC",
                Groups.KingsMeadowCampus => "KMC",
                Groups.ForestRecreationGround => "FRG",
                Groups.Southwell => "SW",
                Groups.ApexBankStaff => "ABS",
                Groups.AgeUKMidMersey => "MDM",
                Groups.BostonGNS => "GNS",
                Groups.UkraineRefugees => "UKR",
                Groups.LincolnshireVCS => "VCS",
                Groups.LincolnshireLCVS=> "LCV",
                Groups.NHSVRDemo => "NHS",
                Groups.NottinghamshireCountyCouncil=> "NCC",
                Groups.NottinghamshireIntegratedCareBoard=>"ICB",
                _ => throw new ArgumentException(message: $"Unexpected Group: {groups}", paramName: nameof(groups))
            };
        }

        public static bool IsEnabled(this Groups groups)
        {
            return groups switch
            {
                Groups.HLP => false,
                Groups.GranthamPCN => false,
                Groups.SouthLincolnPCN => false,
                Groups.SpilsbyPCN => false,
                Groups.BostonPCN => false,
                Groups.LincolnPortlandPCN => false,
                Groups.MeadowsCommunityHelpers => false,
                Groups.MansfieldCVS => false,
                Groups.MansfieldWickes => false,
                Groups.GamstonCommunityHall => false,
                Groups.RichardHerrodCentre => false,
                Groups.KingsMeadowCampus => false,
                Groups.ForestRecreationGround => false,
                Groups.BostonGNS => false,
                Groups.UkraineRefugees => false,
                _ => true
            };
        }
    }
}
