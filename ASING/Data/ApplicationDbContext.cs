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
        public DbSet<BlockedTime> BlockedTimes { get; set; }
        public DbSet<ClassType> ClassTypes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMembership> GroupMemberships { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UniversityUser> UniversityUsers { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }




        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Group>().HasData(
                new Group { GroupId = 1, IsOpen = true, MaxNumber = 5, MinNumber = 3, Name = "Group1", OwnerId = 1, UnitId = 1 },
                new Group { GroupId = 2, IsOpen = true, MaxNumber = 5, MinNumber = 3, Name = "Group2", OwnerId = 2, UnitId = 2 },
                new Group { GroupId = 3, IsOpen = true, MaxNumber = 5, MinNumber = 3, Name = "Group3", OwnerId = 3, UnitId = 3 },
                new Group { GroupId = 4, IsOpen = true, MaxNumber = 5, MinNumber = 3, Name = "Group4", OwnerId = 4, UnitId = 4 }
                );

            modelBuilder.Entity<UniversityUser>().HasData(
                new UniversityUser { FirstName = "FirstName1", Surname = "Surname1", UniversityId = 1, Profile = "I am a Master of Information Technology student. Looking for group." },
                new UniversityUser { FirstName = "FirstName2", Surname = "Surname2", UniversityId = 2, Profile = "Student Id 2" },
                new UniversityUser { FirstName = "FirstName3", Surname = "Surname3", UniversityId = 3, Profile = "Student Id 3" },
                new UniversityUser { FirstName = "FirstName4", Surname = "Surname4", UniversityId = 4, Profile = "Student Id 4" }
                );

            modelBuilder.Entity<Unit>().HasData(
                new Unit { UnitId = 1, Code = "Unit1", GroupsAllowed = true, IsAssesementGroup = true, Name = "UnintName1" },
                new Unit { UnitId = 2, Code = "Unit2", GroupsAllowed = true, IsAssesementGroup = true, Name = "UnintName2" },
                new Unit { UnitId = 3, Code = "Unit3", GroupsAllowed = true, IsAssesementGroup = true, Name = "UnintName3" },
                new Unit { UnitId = 4, Code = "Unit4", GroupsAllowed = true, IsAssesementGroup = true, Name = "UnintName4" }
                );

            modelBuilder.Entity<WorkDay>().HasData(
                new WorkDay { DayId = 1, DayName = "Monday" },
                new WorkDay { DayId = 2, DayName = "Tuesday" },
                new WorkDay { DayId = 3, DayName = "Wednesday" },
                new WorkDay { DayId = 4, DayName = "Thursday" },
                new WorkDay { DayId = 5, DayName = "Friday" }
                );

            modelBuilder.Entity<ClassType>().HasData(
                new ClassType { ClassTypeId = 1, ClassTypeDescription = "Lecture" },
                new ClassType { ClassTypeId = 2, ClassTypeDescription = "Tutorial" }
                );

            modelBuilder.Entity<GroupMembership>().HasData(
                new GroupMembership { GroupMembershipId = 1, GroupId = 1, StudentId = 1, UnitId = 1 },
                new GroupMembership { GroupMembershipId = 2, GroupId = 2, StudentId = 1, UnitId = 2 },
                new GroupMembership { GroupMembershipId = 3, GroupId = 3, StudentId = 1, UnitId = 3 },

                new GroupMembership { GroupMembershipId = 4, GroupId = 1, StudentId = 2, UnitId = 1 },
                new GroupMembership { GroupMembershipId = 5, GroupId = 2, StudentId = 2, UnitId = 2 },
                new GroupMembership { GroupMembershipId = 6, GroupId = 3, StudentId = 2, UnitId = 3 },

                new GroupMembership { GroupMembershipId = 7, GroupId = 1, StudentId = 3, UnitId = 1 },
                new GroupMembership { GroupMembershipId = 8, GroupId = 2, StudentId = 3, UnitId = 2 },
                new GroupMembership { GroupMembershipId = 9, GroupId = 3, StudentId = 3, UnitId = 3 },

                new GroupMembership { GroupMembershipId = 10, GroupId = 1, StudentId = 4, UnitId = 1 },
                new GroupMembership { GroupMembershipId = 11, GroupId = 2, StudentId = 4, UnitId = 2 },
                new GroupMembership { GroupMembershipId = 12, GroupId = 3, StudentId = 4, UnitId = 3 }

                );

            modelBuilder.Entity<Registration>().HasData(
                new Registration { RegistrationId = 1, StudentId = 1, UnitId = 1 },
                new Registration { RegistrationId = 2, StudentId = 1, UnitId = 2 },
                new Registration { RegistrationId = 3, StudentId = 1, UnitId = 3 },
                new Registration { RegistrationId = 4, StudentId = 1, UnitId = 4 },

                new Registration { RegistrationId = 5, StudentId = 2, UnitId = 1 },
                new Registration { RegistrationId = 6, StudentId = 2, UnitId = 2 },
                new Registration { RegistrationId = 7, StudentId = 2, UnitId = 3 },
                new Registration { RegistrationId = 8, StudentId = 2, UnitId = 4 },

                new Registration { RegistrationId = 9, StudentId = 3, UnitId = 1 },
                new Registration { RegistrationId = 10, StudentId = 3, UnitId = 2 },
                new Registration { RegistrationId = 11, StudentId = 3, UnitId = 3 },
                new Registration { RegistrationId = 12, StudentId = 3, UnitId = 4 },

                new Registration { RegistrationId = 13, StudentId = 4, UnitId = 1 },
                new Registration { RegistrationId = 14, StudentId = 4, UnitId = 2 },
                new Registration { RegistrationId = 15, StudentId = 4, UnitId = 3 },
                new Registration { RegistrationId = 16, StudentId = 4, UnitId = 4 }
                );


        }
    }
}
