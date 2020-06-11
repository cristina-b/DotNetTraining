namespace InterfaceSegregationIdentityAfter.Contracts
{
    using System.Collections.Generic;

    public interface IPasswordManager
    {
        int MinRequiredPasswordLength { get; set; }

        int MaxRequiredPasswordLength { get; set; }

        void ChangePassword(string oldPass, string newPass);
    }
}
