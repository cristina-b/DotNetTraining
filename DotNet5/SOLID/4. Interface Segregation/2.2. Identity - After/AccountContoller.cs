namespace InterfaceSegregationIdentityAfter
{
    using InterfaceSegregationIdentityAfter.Contracts;

    public class AccountContoller : IPasswordManager
    {
        public int MinRequiredPasswordLength { get; set; }
        public int MaxRequiredPasswordLength { get; set; }

        private readonly IAccount manager;

        public AccountContoller(IAccount manager)
        {
            this.manager = manager;
        }        

        public void ChangePassword(string oldPass, string newPass)
        {
            this.manager.ChangePassword(oldPass, newPass);
        }
    }
}
