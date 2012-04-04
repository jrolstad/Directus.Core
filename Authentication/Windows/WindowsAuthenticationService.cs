using System;
using System.Security.Principal;
using System.Web;

namespace Directus.Core.Authentication.Windows
{
    /// <summary>
    /// Authentication service for windows
    /// </summary>
    public class WindowsAuthenticationService:IAuthenticationService
    {
        /// <summary>
        /// Obtains the name of the user the process is running under
        /// </summary>
        public IIdentity CurrentUser()
        {
            // Get the user from the HttpContext if we can
            if (HttpContext.Current != null)
            {
                var identity = HttpContext.Current.Request.LogonUserIdentity ?? HttpContext.Current.User.Identity;
                if (identity.IsAuthenticated && !String.IsNullOrEmpty(identity.Name))
                    return identity; //only return non-null users
            }

            // Get either the thread user or the impersonating user
            var idThread = WindowsIdentity.GetCurrent(false);
            var idImpersonate = WindowsIdentity.GetCurrent(true);

            return idImpersonate ?? idThread;
        }
    }
}