﻿using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeApi.Domain.Entities;


namespace YoutubeApi.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            Category category1 = new Category { Id = 1, Name = "Elektrik", Priorty = 1, ParentId = 0, IsDeleted = false, CreateDate = DateTime.Now };
            Category parent1 = new Category { Id = 3, Name = "Bilgisayar", Priorty = 1, ParentId = 1, IsDeleted = false, CreateDate = DateTime.Now };

            Category category2 = new Category { Id = 2, Name = "Moda", Priorty = 2, ParentId = 0, IsDeleted = false, CreateDate = DateTime.Now };
            Category parent2 = new Category { Id = 4, Name = "Kadın", Priorty = 1, ParentId = 2, IsDeleted = false, CreateDate = DateTime.Now };

            builder.HasData(category1, category2, parent1, parent2);
        }
    }
}
