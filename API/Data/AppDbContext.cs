﻿using Microsoft.EntityFrameworkCore;
using PhobosReact.API.Data.Dto;
using PhobosReact.API.Models;
using PhobosReact.API.Models.Warehouse;

namespace PhobosReact.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ItemDto> Items { get; set; }
        public DbSet<BoxDto> Boxes { get; set; }
        public DbSet<SpaceDto> Spaces { get; set; }
    }
}
