using HelpMyStreet.Contracts.UserService.Response;
using MediatR;
using System.Collections.Generic;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class PostUsersForListOfUserIDRequest : IRequest<PostUsersForListOfUserIDResponse>
    {
        public ListUserID ListUserID { get; set; }
    }

    public class ListUserID
    {
        public List<int> UserIDs { get; set; }
    }
}
