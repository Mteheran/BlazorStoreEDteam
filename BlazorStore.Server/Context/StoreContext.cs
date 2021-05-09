using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shared;

namespace BlazorStore.Server.Context
{
    public class StoreContext : DbContext
    {

        public StoreContext(DbContextOptions<StoreContext> options): base(options){ }

        public DbSet<News> News {get;set;}
        public DbSet<Game> Games {get;set;}
        public DbSet<UserProfile> UserProfiles {get;set;}
        public DbSet<UserGame> UserGames {get;set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);  

            builder.Entity<Game>().ToTable("Game").HasKey(p=> p.GameId); 
            builder.Entity<UserProfile>().ToTable("UserProfile").HasKey(p=> p.UserProfileId);
            builder.Entity<UserGame>().ToTable("UserGame").HasKey(p=> p.UserGameId); 
            builder.Entity<News>().ToTable("News").HasKey(p=> p.NewsId);

            //builder.Entity<UserGame>().HasMany<Game>("GameId");
            //builder.Entity<UserGame>().HasMany<UserProfile>("UserProfileId");
        }
    }
}