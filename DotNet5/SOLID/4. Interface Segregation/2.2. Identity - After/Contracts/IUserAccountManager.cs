using System.Collections.Generic;

namespace InterfaceSegregationIdentityAfter.Contracts
{
    public interface IUserAccountManager
    {
        IEnumerable<IUser> GetAllUsersOnline();

        IEnumerable<IUser> GetAllUsers();

        IUser GetUserByName(string name);
    }
}