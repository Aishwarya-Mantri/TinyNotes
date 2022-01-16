using System;
using System.Collections.Generic;
using System.Text;

namespace TinyNotes.Domain
{
    public class UserSession
    {
        static Dictionary<Guid, bool> UserSessionRecord = new Dictionary<Guid, bool>();

        public static bool GetUserSession(Guid userId)
        {
            var userRecord = UserSessionRecord.ContainsKey(userId);
            return userRecord == true ? UserSessionRecord[userId] : false;
        }
        public static void SetUserSession(Guid userId)
        {
            UserSessionRecord[userId] = true;
        }
        public static void RemoveUserSession(Guid userId)
        {
            UserSessionRecord[userId] = false;
        }

    }
}
