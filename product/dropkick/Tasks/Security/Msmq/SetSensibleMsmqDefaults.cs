// Copyright 2007-2010 The Apache Software Foundation.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace dropkick.Tasks.Security.Msmq
{
    using System;
    using System.Messaging;
    using DeploymentModel;

    public class SetSensibleMsmqDefaults :
        Task
    {
        readonly string _path;

        public SetSensibleMsmqDefaults(string path)
        {
            _path = path;
        }

        #region Task Members

        public string Name
        {
            get { return "stuff"; }
        }

        public DeploymentResult VerifyCanRun()
        {
            throw new NotImplementedException();
        }

        public DeploymentResult Execute()
        {
            var result = new DeploymentResult();

            var q = new MessageQueue(_path);
            q.SetPermissions(WellKnownRoles.Administrators, MessageQueueAccessRights.FullControl, AccessControlEntryType.Allow);
            q.SetPermissions(WellKnownRoles.CurrentUser, MessageQueueAccessRights.FullControl, AccessControlEntryType.Revoke);
            q.SetPermissions(WellKnownRoles.Everyone, MessageQueueAccessRights.FullControl, AccessControlEntryType.Revoke);
            q.SetPermissions(WellKnownRoles.Anonymous, MessageQueueAccessRights.FullControl, AccessControlEntryType.Revoke);

            return result;
        }

        #endregion
    }
}