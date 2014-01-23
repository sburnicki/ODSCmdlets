// ODSCmdlets - Cmdlets for Powershell and Pash for Open Data Space Management
// Copyright (C) GRAU DATA 2013-2014
//
// Author(s): Stefan Burnicki <stefan.burnicki@graudata.com>
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace OpenDataSpace.Commands
{
    [RunInstaller(true)]
    public class ODSCmdlets : PSSnapIn
    {

        public override string Description
        {
            get { return "Cmdlets to manage an OpenDataSpace"; }
        }

        public override string Name
        {
            get { return "ODSCmdlets"; }
        }

        public override string Vendor
        {
            get { return "OpenDataSpace"; }
        }
    }
}
