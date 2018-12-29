using LDAP.Models;
using Novell.Directory.Ldap;

namespace LDAP.Utilities
{
    class LDAP
    {
        public bool LDAPAuthAsync(Domain userLogin)
        {
            if (!string.IsNullOrEmpty(userLogin.Username) && !string.IsNullOrEmpty(userLogin.Password))
            {
                try
                {
                    using (var connection = new LdapConnection { SecureSocketLayer = false })
                    {
                        string fullDomain = $"{userLogin.Username}@{userLogin.DomainName}";

                        connection.Connect(userLogin.DomainName, LdapConnection.DEFAULT_PORT);
                        connection.Bind(fullDomain, userLogin.Password);

                        return connection.Bound;
                    }
                }
                catch (LdapException)
                {
                    return false;
                }
            }

            else
                return false;
        }
    }
}
