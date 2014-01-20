﻿using OpenDataSpace.Commands.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace OpenDataSpace.Commands
{

    [Cmdlet(VerbsCommon.Remove, ODSNouns.Group, SupportsShouldProcess = true)]
    public class RemoveODSGroupCommand : ODSGroupCommandBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public long[] Id { get; set; }

        protected override void ProcessRecord()
        {
            foreach (var curId in Id)
            {
                try
                {
                    var request = GroupRequestFactory.CreateDeleteGroupRequest(curId);
                    if (ShouldProcess(curId.ToString()))
                    {
                        RequestHandler.ExecuteSuccessfully<DataspaceResponse>(request);
                    }
                }
                catch (ReportableException e)
                {
                    WriteError(e.ErrorRecord);
                }
            }
        }

    }
}
