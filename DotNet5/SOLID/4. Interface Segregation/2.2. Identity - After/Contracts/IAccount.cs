namespace InterfaceSegregationIdentityAfter.Contracts
{
    using System.Collections.Generic;

    public interface IAccount : IPasswordManager
    {
        bool RequireUniqueEmail { get; set; }        
    }
}
