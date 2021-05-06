using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shared
{
    public class Game
    {
        public Guid GameId {get; set;} = Guid.NewGuid();
        public string Title {get;set;}
        public string Description {get;set;}
        public string Image {get;set;}
        public decimal Price { get;set;}
        public decimal DiscountRate {get;set;}
        
    }
}