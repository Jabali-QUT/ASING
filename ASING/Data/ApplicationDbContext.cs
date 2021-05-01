﻿using ASING.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASING.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        
        public DbSet<Group> Groups { get; set; }
        public DbSet<Unit> Units { get; set; } 
        public DbSet<UniversityUser> UniversityUsers { get; set; } 

        


        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Group>().HasData(
                new Group { GroupId = 1, IsOpen = true, MaxNumber = 5, MinNumber = 3, Name = "Group1", OwnerId=1, UnitId=1 },
                new Group { GroupId = 2, IsOpen = true, MaxNumber = 5, MinNumber = 3, Name = "Group2", OwnerId = 2, UnitId = 2 },
                new Group { GroupId = 3, IsOpen = true, MaxNumber = 5, MinNumber = 3, Name = "Group3", OwnerId = 3, UnitId = 3 },
                new Group { GroupId = 4, IsOpen = true, MaxNumber = 5, MinNumber = 3, Name = "Group4", OwnerId = 4, UnitId = 4 }
                );

            modelBuilder.Entity<UniversityUser>().HasData(
                new UniversityUser { FirstName = "FirstName1", Surname="Surname1", UniversityId=1 },
                new UniversityUser { FirstName = "FirstName2", Surname = "Surname2", UniversityId = 2 },
                new UniversityUser { FirstName = "FirstName3", Surname = "Surname3", UniversityId = 3 },
                new UniversityUser { FirstName = "FirstName4", Surname = "Surname4", UniversityId = 4 }
                );

            modelBuilder.Entity<Unit>().HasData(
                new Unit { UnitId = 1, Code="Unit1", GroupsAllowed=true, IsAssesementGroup=true, Name = "UnintName1"},
                new Unit { UnitId = 2, Code = "Unit2", GroupsAllowed = true, IsAssesementGroup = true, Name = "UnintName2" },
                new Unit { UnitId = 3, Code = "Unit3", GroupsAllowed = true, IsAssesementGroup = true, Name = "UnintName3" },
                new Unit { UnitId = 4, Code = "Unit4", GroupsAllowed = true, IsAssesementGroup = true, Name = "UnintName4" }
                );

            modelBuilder.Entity<WorkDay>().HasData(
                new WorkDay { DayId = 1, DayName = "Monday"},
                new WorkDay { DayId = 2, DayName = "Tuesday" },
                new WorkDay { DayId = 3, DayName = "Wednesday" },
                new WorkDay { DayId = 4, DayName = "Thursday" },
                new WorkDay { DayId = 5, DayName = "Friday" }
                );

            modelBuilder.Entity<ClassType>().HasData(
                new ClassType { ClassTypeId = 1, ClassTypeDescription = "Lecture"},
                new ClassType { ClassTypeId = 2, ClassTypeDescription = "Tutorial" }
                );
        }
    }
}
