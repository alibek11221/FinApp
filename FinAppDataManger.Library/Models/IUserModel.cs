using System;

namespace FinAppDataManger.Library.Models
{
    public interface IUserModel
    {
        DateTime CreateDate { get; set; }
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string Id { get; set; }
        string LastName { get; set; }
    }
}