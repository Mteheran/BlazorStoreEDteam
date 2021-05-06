using System;

namespace shared
{
    public class News
    {
        public Guid NewsId {get; set;} = Guid.NewGuid();
        public string Description {get;set;}
        public string Image {get;set;}
        public string Url {get;set;}
    }
}
