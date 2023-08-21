using Microsoft.EntityFrameworkCore;
using SchoolApi.Models;

namespace SchoolApi.Data
{
    public class DbContextSchool:DbContext
    {
        public DbContextSchool(DbContextOptions<DbContextSchool> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new List<Student>
            {
                new()
                {
                    Id=1,
                    Name="Maroc DeBellevue",
                    GroupId=-1

                },
                new()
                {
                    Id=2,
                    Name="Tommy Harveg",
                    GroupId=-2
                },
                new()
                {
                    Id=3,
                    Name="Matt Connor",
                    GroupId=-3

                },
                new()
                {
                    Id=4,
                    Name="Dan Potter",
                    GroupId=-4
                }
            });
            modelBuilder.Entity<Course>().HasData(new List<Course>
            {
                new()
                {
                    Id=1,
                    Name="Machine Learning",
                    StudentId=1

                            },
                             new()
                            {
                                Id=2,
                                Name="Chemistry",
                                StudentId=2

                            },
                            new()
                            {
                                Id=3,
                                Name="C#",
                                StudentId=3

                            },
                            new()
                            {
                                Id=4,
                                Name="Mathematic",
                                StudentId=4

                            }

                        });
            modelBuilder.Entity<Group>().HasData(new List<Group>
                        {
                            new()
                            {
                                Id=-1,
                                Name="ИТП 22",

                            },
                            new()
                            {
                                Id=-2,
                                Name="ИТИ 21",

                            },
                            new()
                            {
                                Id=-3,
                                Name="ИТП 21",
                            },

                            new()
                            {
                                Id=-4,
                                Name="ИТИ 22",

                            }
                        });
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
