using HelpMyStreet.Utils.Models;
using System.Collections.Generic;

namespace HelpMyStreet.Contracts.UserService.Response
{
    public class GetChampionsByPostcodeResponse
    {
        public IReadOnlyList<User> Users { get; set; }
    }
}
