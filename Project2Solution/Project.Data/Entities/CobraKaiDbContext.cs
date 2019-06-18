﻿using System;

using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata;

namespace Project.Data.Entities

{

    public class CobraKaiDbContext : DbContext

    {
        public CobraKaiDbContext()
        {

        }
        public CobraKaiDbContext(DbContextOptions<CobraKaiDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Entities.Journal> Journals { get; set; }

        public virtual DbSet<Entities.Person> People { get; set; }

        public virtual DbSet<Entities.Playlist> Playlists { get; set; }

        public virtual DbSet<Entities.Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            if (!optionsBuilder.IsConfigured)

                optionsBuilder.UseSqlServer("Server=tcp:utadbserverdc.database.windows.net,1433;Initial Catalog=Project2DB;Persist Security Info=False;User ID=danielcoombs005;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        }

    }

}

