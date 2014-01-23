﻿using OpenDataSpace.Commands.Objects;
using OpenDataSpace.Commands.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace OpenDataSpace.Commands
{
    [Cmdlet(VerbsCommon.Add, ODSNouns.User, SupportsShouldProcess = true)]
    public class AddODSUserCommand : ODSGroupCommandBase
    {

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string UserName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string FamilyName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string GivenName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string EMail { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Language { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Role { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public long MaxSpace { get; set; }

        protected override void ProcessRecord()
        {
            var addableUser = new UpdatableUserObject()
            {
                UserName = UserName,
                FamilyName = FamilyName,
                GivenName = GivenName,
                EMail = EMail,
                Language = Language,
                Role = Role,
                MaxSpace = MaxSpace
            };
            try
            {
                var request = UserRequestFactory.CreateAddUserRequest(addableUser);
                if (ShouldProcess("Add user"))
                {
                    WriteObject(RequestHandler.ExecuteAndUnpack<UserObject>(request));
                }
            }
            catch (ReportableException e)
            {
                WriteError(e.ErrorRecord);
            }
        }
    }
}