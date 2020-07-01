using HelpMyStreet.Contracts.GroupService.Request;
using System.Collections.Generic;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GetLandingPageContentResponse
    {
        public bool IsLoggedIn { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int ZoomLevel { get; set; }
        public string CommunityName { get; set; }
        public string BannerImageLocation { get; set; }
        public string Header { get; set; }
        public string HeaderSubtitle { get; set; }
        public IEnumerable<string> HeaderBullets { get; set; }
        public string HeaderHelpButtonText { get; set; }
        public string HeaderVolunteerButtonText { get; set; }
        public bool HideHeaderButtons { get; set; } = false;
        public bool HideHeaderVolunteerButton { get; set; } = false;
        public bool HideHeaderHelpButton { get; set; } = false;
        public string CommunityVolunteersHeader { get; set; }
        public string CommunityVolunteersTextHtml { get; set; }
        public bool HideHelpPanel { get; set; } = false;
        public string RequestHelpHeading { get; set; }
        public string RequestHelpText { get; set; }
        public string ProvideHelpHeading { get; set; }
        public string ProvideHelpText { get; set; }
        public IEnumerable<CommunityVolunteer> CommunityVolunteers { get; set; }
        public IEnumerable<string> UsefulLinksHtml { get; set; }
    }
}
