﻿using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class PostCreateGroupRequest :IRequest<PostCreateGroupResponse>
    {
        [Required]
        public string GroupName { get; set; }
        public string ParentGroupName { get; set; }
    }
}
