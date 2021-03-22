using System;
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
                Groups.Generic => "GNR",
                Groups.FTLOS => "FTL",
                Groups.AgeUKLSL => "LSL",
                Groups.HLP => "HLP",
                Groups.Tankersley => "TAN",
                Groups.Ruddington => "RUD",
                Groups.AgeUKWirral => "WIR",
                Groups.AgeUKNottsBalderton => "BAL",
                Groups.AgeUKNorthWestKent => "NWK",
                Groups.AgeUKNottsNorthMuskham => "MUS",
                Groups.AgeUKSouthKentCoast => "SKC",
                Groups.AgeUKFavershamAndSittingbourne => "FAS",
                Groups.LincolnshireVolunteers => "VOL",
                Groups.LouthPCN => "LOU",
                Groups.GranthamPCN => "GRA",
                Groups.SouthLincolnPCN => "SOL",
                Groups.StamfordPCN => "STA",
                Groups.SpilsbyPCN => "SPI",
                Groups.BostonPCN => "BOS",
                Groups.LincolnPCN => "LIP",
                Groups.LincolnPortlandPCN => "LPP",
                Groups.Sandbox => "SAN",
                Groups.AgeConnectsCardiff => "ACC",
                Groups.MeadowsCommunityHelpers => "MCC",
                _ => throw new ArgumentException(message: $"Unexpected Group: {groups}", paramName: nameof(groups))
            };
        }
    }
}
