using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shared
{
    public class UserProfile
    {
        public Guid UserProfileId { get;set;} = Guid.NewGuid();
        public string UserName { get;set;}
        public string Password { get;set;}
        public string Email {get;set;}
        public string Name {get;set;}
        public string LastName { get;set;}
        public string Country {get;set;}
    }
}