using HelpMyStreet.Contracts.CommunicationService.Request;

namespace HelpMyStreet.Contracts.CommunicationService.Cosmos
{
    public class SaveMessageParticipant
    {
        public int? UserId { get; set; }
        public EmailDetails EmailDetails { get; set; }
        public SaveUsersFromGroups GroupRoleType { get; set; }
        public RequestRoleType RequestRoleType { get; set; }
    }
}