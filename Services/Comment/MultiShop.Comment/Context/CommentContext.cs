﻿using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442; initial Catalog=MultiShopCommentDb;User=sa;Password=Burchan1151.;TrustServerCertificate=true;");
        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
