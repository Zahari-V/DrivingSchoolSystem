using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrivingSchoolSystem.Infrastructure.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        private List<Category> CreateCategories()
        {
            var categories = new List<Category>();

            categories.Add(new Category()
            {
                Id = 1,
                Name = "А",
                ImageUrl = "https://imgs.search.brave.com/FHh0vvdqKaQ4tRliDZYO09P2VZALnkDn_GFTCPyXHBs/rs:fit:400:250:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWEtZnRy/LWltZy00MDB4MjUw/LnBuZw"
            });

            categories.Add(new Category()
            {
                Id = 2,
                Name = "А1",
                ImageUrl = "https://imgs.search.brave.com/Vtxrn9269ymjU-lrju3p0RDU-Bxyg6U4DvRJ0tVZcVo/rs:fit:480:367:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWExLTQ4/MHgzNjcucG5n"
            });

            categories.Add(new Category()
            {
                Id = 3,
                Name = "A2",
                ImageUrl = "https://imgs.search.brave.com/rZn_i_U4QdfSN8tIwPHyUNL_ibsMrcjHkt-fhUaVH5U/rs:fit:900:900:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWEyLWZ0/ci1pbWcucG5n"
            });

            categories.Add(new Category()
            {
                Id = 4,
                Name = "B",
                ImageUrl = "https://imgs.search.brave.com/U0QAzA_anbbMsvGsPUXODhJd2HT74Q_TuXixh8DaZFg/rs:fit:700:536:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWItYjEu/cG5n"
            });

            categories.Add(new Category()
            {
                Id = 5,
                Name = "B+E",
                ImageUrl = "https://imgs.search.brave.com/UjwXBg0qLe2ers5_rw0ppBO_2oGTca4RL2eOkKMrkyc/rs:fit:900:900:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWItZS1m/dHItaW1nLnBuZw"
            });

            categories.Add(new Category()
            {
                Id = 6,
                Name = "C",
                ImageUrl = "https://imgs.search.brave.com/2vqlr1hK8Wa03qE8uEY-dqWxXBF9Yp8wA8P9UNPKZ4Y/rs:fit:900:900:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWMtZnRy/LWltZy5wbmc"
            });

            categories.Add(new Category()
            {
                Id = 7,
                Name = "C+E",
                ImageUrl = "https://imgs.search.brave.com/rYXho7__cqZo4sr1c--T7_B7D6u9HNWUsSp2DzTr3eI/rs:fit:900:900:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWMtZS1m/dHItaW1nLnBuZw"
            });

            categories.Add(new Category()
            {
                Id = 8,
                Name = "D",
                ImageUrl = "https://imgs.search.brave.com/VqKsfSA7_cYdRAeDKi-wMgnheJbvUh5HCzfhLWHzUXc/rs:fit:700:548:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWQucG5n"
            });

            categories.Add(new Category()
            {
                Id = 9,
                Name = "D1",
                ImageUrl = "https://imgs.search.brave.com/Gd30GUaVD8I_B2tdcJbfMf7_wO4cBmYmubk01_fpYwk/rs:fit:400:250:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWQxLWZ0/ci1pbWctNDAweDI1/MC5wbmc"
            });

            return categories;
        }
    }
}
