using HelpMyStreet.Utils.Models;
using System.Collections.Generic;

namespace HelpMyStreet.Contracts.UserService.Response
{
    public class GetHelpersByPostcodeResponse
    {
        public List<User> Users { get; set; }
    }
}
