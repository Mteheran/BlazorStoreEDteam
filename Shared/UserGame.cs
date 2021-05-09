using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shared
{
    public class UserGame
    {
        public Guid UserGameId { get;set;} = Guid.NewGuid();
        public Guid UserProfileId { get;set;}
        public Guid GameId {get; set;}
    }
}