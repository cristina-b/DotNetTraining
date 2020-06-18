namespace InterfaceSegregationIdentityAfter
{
    using System.Collections.Generic;

    using InterfaceSegregationIdentityAfter.Contracts;

    public class AccountManager : IUserAccountManager
    {        

        public IEnumerable<IUser> GetAllUsers()
        {
            //return all users
        }

        public IEnumerable<IUser> GetAllUsersOnline()
        {
            //return online users
        }

        public IUser GetUserByName(string name)
        {
            //return get users by name
        }
    }
}
