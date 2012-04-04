using System.Security.Principal;

namespace Directus.Core.Authentication
{
    /// <summary>
    /// Service used for authentication
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Gets the current user
        /// </summary>
        /// <returns></returns>
        IIdentity CurrentUser();
    }
}