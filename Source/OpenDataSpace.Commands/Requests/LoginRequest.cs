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

﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace OpenDataSpace.Commands.Requests
{
    class LoginRequest : DataspaceRequest
    {
        private string _username;
        private SecureString _password;

        public LoginRequest(string username, SecureString password)
        {
            RequestName = "Login";
            _username = username;
            _password = password;
        }

        public override RestRequest CreateRestRequest(AuthMethod authMethod, string sessionId)
        {
            // authMethod and sessionId are useless, we're not logged in anyway!
            var request = new RestRequest(ResourceUris.Login, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new {
                username = _username,
                password = Utility.SecureStringToString(_password)
            });
            return request;
        }
    }
}
