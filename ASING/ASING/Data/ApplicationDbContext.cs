using ASING.Models;
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
        public DbSet<GroupActivity> GroupActivities { get; set; }

        public DbSet<GroupActivityMembership> GroupActivityMemberships { get; set; }



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
                new Group { GroupId = 2, IsOpen = true, MaxNumber = 5, MinNumber = 3, Name = "Group2", OwnerId = 1, UnitId = 2 },
                new Group { GroupId = 3, IsOpen = true, MaxNumber = 5, MinNumber = 3, Name = "Group3", OwnerId = 3, UnitId = 3 },
                new Group { GroupId = 4, IsOpen = true, MaxNumber = 5, MinNumber = 3, Name = "Group4", OwnerId = 4, UnitId = 4 },
                new Group { GroupId = 5, IsOpen = true, MaxNumber = 5, MinNumber = 3, Name = "Group5", OwnerId = 5, UnitId = 3 }
                );

            modelBuilder.Entity<UniversityUser>().HasData(
                new UniversityUser { FirstName = "FirstName1", Surname = "Surname1", UniversityId = 1, Profile = "I am a Master of Information Technology student. Looking for group." },
                new UniversityUser { FirstName = "FirstName2", Surname = "Surname2", UniversityId = 2, Profile = "Student Id 2" },
                new UniversityUser { FirstName = "FirstName3", Surname = "Surname3", UniversityId = 3, Profile = "Student Id 3" },
                new UniversityUser { FirstName = "FirstName4", Surname = "Surname4", UniversityId = 4, Profile = "Student Id 4" },
                new UniversityUser { FirstName = "FirstName5", Surname = "Surname5", UniversityId = 5, Profile = "Student Id 5" },
                new UniversityUser { FirstName = "FirstName6", Surname = "Surname6", UniversityId = 6, Profile = "Student Id 6" },
                new UniversityUser { FirstName = "FirstName7", Surname = "Surname7", UniversityId = 7, Profile = "Student Id 7" },
                new UniversityUser { FirstName = "FirstName8", Surname = "Surname8", UniversityId = 8, Profile = "Student Id 8" }
                );

            modelBuilder.Entity<Unit>().HasData(
                new Unit { UnitId = 1, Code = "Unit1", GroupsAllowed = true, IsAssesementGroup = true, Name = "UnitName1" },
                new Unit { UnitId = 2, Code = "Unit2", GroupsAllowed = true, IsAssesementGroup = true, Name = "UnitName2" },
                new Unit { UnitId = 3, Code = "Unit3", GroupsAllowed = true, IsAssesementGroup = true, Name = "UnitName3" },
                new Unit { UnitId = 4, Code = "Unit4", GroupsAllowed = true, IsAssesementGroup = true, Name = "UnitName4" }
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
                new GroupMembership { GroupMembershipId = 1, GroupId = 1, StudentId = 1, UnitId = 1, StatusId = 1 },
                new GroupMembership { GroupMembershipId = 2, GroupId = 2, StudentId = 1, UnitId = 2, StatusId = 2 },
                //new GroupMembership { GroupMembershipId = 3, GroupId = 3, StudentId = 1, UnitId = 3, StatusId = 3 },

                new GroupMembership { GroupMembershipId = 4, GroupId = 1, StudentId = 2, UnitId = 1, StatusId = 1 },
                new GroupMembership { GroupMembershipId = 5, GroupId = 2, StudentId = 2, UnitId = 2, StatusId = 2 },
                new GroupMembership { GroupMembershipId = 6, GroupId = 3, StudentId = 2, UnitId = 3, StatusId = 3 },
                new GroupMembership { GroupMembershipId = 3, GroupId = 4, StudentId = 2, UnitId = 4, StatusId = 3 },

                new GroupMembership { GroupMembershipId = 7, GroupId = 1, StudentId = 3, UnitId = 1, StatusId = 1 },
                new GroupMembership { GroupMembershipId = 8, GroupId = 2, StudentId = 3, UnitId = 2, StatusId = 2 },
                new GroupMembership { GroupMembershipId = 9, GroupId = 3, StudentId = 3, UnitId = 3, StatusId = 3 },
                new GroupMembership { GroupMembershipId = 13, GroupId = 4, StudentId = 3, UnitId = 4, StatusId = 3 },

                new GroupMembership { GroupMembershipId = 10, GroupId = 1, StudentId = 4, UnitId = 1, StatusId = 1 },
                new GroupMembership { GroupMembershipId = 11, GroupId = 2, StudentId = 4, UnitId = 2, StatusId = 2 },
                new GroupMembership { GroupMembershipId = 12, GroupId = 3, StudentId = 4, UnitId = 3, StatusId = 3 },

                new GroupMembership { GroupMembershipId = 14, GroupId = 5, StudentId = 5, UnitId = 3, StatusId = 3 }

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
                new Registration { RegistrationId = 16, StudentId = 4, UnitId = 4 },

                new Registration { RegistrationId = 17, StudentId = 5, UnitId = 1 },
                new Registration { RegistrationId = 18, StudentId = 5, UnitId = 2 },
                new Registration { RegistrationId = 19, StudentId = 5, UnitId = 3 },
                new Registration { RegistrationId = 20, StudentId = 5, UnitId = 4 },

                new Registration { RegistrationId = 21, StudentId = 6, UnitId = 1 },
                new Registration { RegistrationId = 22, StudentId = 6, UnitId = 2 },
                new Registration { RegistrationId = 23, StudentId = 6, UnitId = 3 },
                new Registration { RegistrationId = 24, StudentId = 6, UnitId = 4 },

                new Registration { RegistrationId = 25, StudentId = 7, UnitId = 1 },
                new Registration { RegistrationId = 26, StudentId = 7, UnitId = 2 },
                new Registration { RegistrationId = 27, StudentId = 7, UnitId = 3 },
                new Registration { RegistrationId = 28, StudentId = 7, UnitId = 4 },

                new Registration { RegistrationId = 29, StudentId = 8, UnitId = 1 },
                new Registration { RegistrationId = 30, StudentId = 8, UnitId = 2 },
                new Registration { RegistrationId = 31, StudentId = 8, UnitId = 3 },
                new Registration { RegistrationId = 32, StudentId = 8, UnitId = 4 }
                );

            modelBuilder.Entity<Timetable>().HasData(
                new Timetable { TimetableId = 1, DayId = 1, UnitId = 1, ClassTypeId =1, StartTime = 9, EndTime = 11 },
                new Timetable { TimetableId = 2, DayId = 1, UnitId = 2, ClassTypeId = 1, StartTime = 13, EndTime = 15 },
                new Timetable { TimetableId = 3, DayId = 2, UnitId = 4, ClassTypeId = 1, StartTime = 10, EndTime = 11 },
                new Timetable { TimetableId = 4, DayId = 2, UnitId = 3, ClassTypeId = 1, StartTime = 11, EndTime = 13 },
                new Timetable { TimetableId = 5, DayId = 3, UnitId = 2, ClassTypeId = 1, StartTime = 14, EndTime = 16 },
                new Timetable { TimetableId = 6, DayId = 3, UnitId = 1, ClassTypeId = 1, StartTime = 11, EndTime = 12 },
                new Timetable { TimetableId = 7, DayId = 5, UnitId = 3, ClassTypeId = 1, StartTime = 8, EndTime = 10 },
                new Timetable { TimetableId = 8, DayId = 5, UnitId = 4, ClassTypeId = 1, StartTime = 15, EndTime = 16 }
                );

            modelBuilder.Entity<BlockedTime>().HasData(
                //student 1 
                new BlockedTime { BlockedTimeId = 1, DayId = 1, StudentId = 1, StartTime = 8, EndTime = 9},
                new BlockedTime { BlockedTimeId = 2, DayId = 1, StudentId = 1, StartTime = 18, EndTime = 20 },
                new BlockedTime { BlockedTimeId = 3, DayId = 2, StudentId = 1, StartTime = 8, EndTime = 9 },
                new BlockedTime { BlockedTimeId = 4, DayId = 2, StudentId = 1, StartTime = 15, EndTime = 16 },
                new BlockedTime { BlockedTimeId = 5, DayId = 3, StudentId = 1, StartTime = 8, EndTime = 9 },
                new BlockedTime { BlockedTimeId = 6, DayId = 3, StudentId = 1, StartTime = 12, EndTime = 13 },
                new BlockedTime { BlockedTimeId = 7, DayId = 4, StudentId = 1, StartTime = 12, EndTime = 14 },
                new BlockedTime { BlockedTimeId = 8, DayId = 4, StudentId = 1, StartTime = 16, EndTime = 18 },
                new BlockedTime { BlockedTimeId = 9, DayId = 5, StudentId = 1, StartTime = 12, EndTime = 14 },
                new BlockedTime { BlockedTimeId = 10, DayId = 5, StudentId = 1, StartTime = 18, EndTime = 20 },

                //student 2 
                new BlockedTime { BlockedTimeId = 11, DayId = 1, StudentId = 2, StartTime = 8, EndTime = 9 },
                new BlockedTime { BlockedTimeId = 12, DayId = 1, StudentId = 2, StartTime = 18, EndTime = 20 },
                new BlockedTime { BlockedTimeId = 13, DayId = 2, StudentId = 2, StartTime = 9, EndTime = 10 },
                new BlockedTime { BlockedTimeId = 14, DayId = 2, StudentId = 2, StartTime = 16, EndTime = 18 },
                new BlockedTime { BlockedTimeId = 15, DayId = 3, StudentId = 2, StartTime = 13, EndTime = 15 },
                new BlockedTime { BlockedTimeId = 16, DayId = 3, StudentId = 2, StartTime = 18, EndTime = 20 },
                new BlockedTime { BlockedTimeId = 17, DayId = 4, StudentId = 2, StartTime = 9, EndTime = 12 },
                new BlockedTime { BlockedTimeId = 18, DayId = 4, StudentId = 2, StartTime = 16, EndTime = 18 },
                new BlockedTime { BlockedTimeId = 19, DayId = 5, StudentId = 2, StartTime = 12, EndTime = 14 },
                new BlockedTime { BlockedTimeId = 20, DayId = 5, StudentId = 2, StartTime = 18, EndTime = 20 },

                //student 3 
                new BlockedTime { BlockedTimeId = 21, DayId = 1, StudentId = 3, StartTime = 12, EndTime = 13 },
                new BlockedTime { BlockedTimeId = 22, DayId = 1, StudentId = 3, StartTime = 16, EndTime = 17 },
                new BlockedTime { BlockedTimeId = 23, DayId = 2, StudentId = 3, StartTime = 12, EndTime = 13 },
                new BlockedTime { BlockedTimeId = 24, DayId = 2, StudentId = 3, StartTime = 18, EndTime = 20 },
                new BlockedTime { BlockedTimeId = 25, DayId = 3, StudentId = 3, StartTime = 8, EndTime = 9 },
                new BlockedTime { BlockedTimeId = 26, DayId = 3, StudentId = 3, StartTime = 17, EndTime = 20 },
                new BlockedTime { BlockedTimeId = 27, DayId = 4, StudentId = 3, StartTime = 10, EndTime = 12 },
                new BlockedTime { BlockedTimeId = 28, DayId = 4, StudentId = 3, StartTime = 13, EndTime = 16 },
                new BlockedTime { BlockedTimeId = 29, DayId = 5, StudentId = 3, StartTime = 10, EndTime = 11 },
                new BlockedTime { BlockedTimeId = 30, DayId = 5, StudentId = 3, StartTime = 16, EndTime = 17 },

                //student 4 
                new BlockedTime { BlockedTimeId = 31, DayId = 1, StudentId = 4, StartTime = 8, EndTime = 9 },
                new BlockedTime { BlockedTimeId = 32, DayId = 1, StudentId = 4, StartTime = 18, EndTime = 20 },
                new BlockedTime { BlockedTimeId = 33, DayId = 2, StudentId = 4, StartTime = 8, EndTime = 9 },
                new BlockedTime { BlockedTimeId = 34, DayId = 2, StudentId = 4, StartTime = 15, EndTime = 16 },
                new BlockedTime { BlockedTimeId = 35, DayId = 3, StudentId = 4, StartTime = 8, EndTime = 9 },
                new BlockedTime { BlockedTimeId = 36, DayId = 3, StudentId = 4, StartTime = 12, EndTime = 13 },
                new BlockedTime { BlockedTimeId = 37, DayId = 4, StudentId = 4, StartTime = 12, EndTime = 14 },
                new BlockedTime { BlockedTimeId = 38, DayId = 4, StudentId = 4, StartTime = 16, EndTime = 18 },
                new BlockedTime { BlockedTimeId = 39, DayId = 5, StudentId = 4, StartTime = 12, EndTime = 14 },
                new BlockedTime { BlockedTimeId = 40, DayId = 5, StudentId = 4, StartTime = 18, EndTime = 20 },

                //student 5 
                new BlockedTime { BlockedTimeId = 41, DayId = 1, StudentId = 5, StartTime = 8, EndTime = 9 },
                new BlockedTime { BlockedTimeId = 42, DayId = 1, StudentId = 5, StartTime = 18, EndTime = 20 },
                new BlockedTime { BlockedTimeId = 43, DayId = 2, StudentId = 5, StartTime = 8, EndTime = 9 },
                new BlockedTime { BlockedTimeId = 44, DayId = 2, StudentId = 5, StartTime = 15, EndTime = 16 },
                new BlockedTime { BlockedTimeId = 45, DayId = 3, StudentId = 5, StartTime = 8, EndTime = 9 },
                new BlockedTime { BlockedTimeId = 46, DayId = 3, StudentId = 5, StartTime = 12, EndTime = 13 },
                new BlockedTime { BlockedTimeId = 47, DayId = 4, StudentId = 5, StartTime = 12, EndTime = 14 },
                new BlockedTime { BlockedTimeId = 48, DayId = 4, StudentId = 5, StartTime = 16, EndTime = 18 },
                new BlockedTime { BlockedTimeId = 49, DayId = 5, StudentId = 5, StartTime = 12, EndTime = 14 },
                new BlockedTime { BlockedTimeId = 50, DayId = 5, StudentId = 5, StartTime = 18, EndTime = 20 },

                //student 6
                new BlockedTime { BlockedTimeId = 51, DayId = 1, StudentId = 6, StartTime = 8, EndTime = 9 },
                new BlockedTime { BlockedTimeId = 52, DayId = 1, StudentId = 6, StartTime = 18, EndTime = 20 },
                new BlockedTime { BlockedTimeId = 53, DayId = 2, StudentId = 6, StartTime = 9, EndTime = 10 },
                new BlockedTime { BlockedTimeId = 54, DayId = 2, StudentId = 6, StartTime = 16, EndTime = 18 },
                new BlockedTime { BlockedTimeId = 55, DayId = 3, StudentId = 6, StartTime = 13, EndTime = 15 },
                new BlockedTime { BlockedTimeId = 56, DayId = 3, StudentId = 6, StartTime = 18, EndTime = 20 },
                new BlockedTime { BlockedTimeId = 57, DayId = 4, StudentId = 6, StartTime = 9, EndTime = 12 },
                new BlockedTime { BlockedTimeId = 58, DayId = 4, StudentId = 6, StartTime = 16, EndTime = 18 },
                new BlockedTime { BlockedTimeId = 59, DayId = 5, StudentId = 6, StartTime = 12, EndTime = 14 },
                new BlockedTime { BlockedTimeId = 60, DayId = 5, StudentId = 6, StartTime = 18, EndTime = 20 },

                //student 7 
                new BlockedTime { BlockedTimeId = 61, DayId = 1, StudentId = 7, StartTime = 12, EndTime = 13 },
                new BlockedTime { BlockedTimeId = 62, DayId = 1, StudentId = 7, StartTime = 16, EndTime = 17 },
                new BlockedTime { BlockedTimeId = 63, DayId = 2, StudentId = 7, StartTime = 12, EndTime = 13 },
                new BlockedTime { BlockedTimeId = 64, DayId = 2, StudentId = 7, StartTime = 18, EndTime = 20 },
                new BlockedTime { BlockedTimeId = 65, DayId = 3, StudentId = 7, StartTime = 8, EndTime = 9 },
                new BlockedTime { BlockedTimeId = 66, DayId = 3, StudentId = 7, StartTime = 17, EndTime = 20 },
                new BlockedTime { BlockedTimeId = 67, DayId = 4, StudentId = 7, StartTime = 10, EndTime = 12 },
                new BlockedTime { BlockedTimeId = 68, DayId = 4, StudentId = 7, StartTime = 13, EndTime = 16 },
                new BlockedTime { BlockedTimeId = 69, DayId = 5, StudentId = 7, StartTime = 10, EndTime = 11 },
                new BlockedTime { BlockedTimeId = 70, DayId = 5, StudentId = 7, StartTime = 16, EndTime = 17 },

                //student 8
                new BlockedTime { BlockedTimeId = 81, DayId = 1, StudentId = 8, StartTime = 8, EndTime = 9 },
                new BlockedTime { BlockedTimeId = 82, DayId = 1, StudentId = 8, StartTime = 18, EndTime = 20 },
                new BlockedTime { BlockedTimeId = 83, DayId = 2, StudentId = 8, StartTime = 8, EndTime = 9 },
                new BlockedTime { BlockedTimeId = 84, DayId = 2, StudentId = 8, StartTime = 15, EndTime = 16 },
                new BlockedTime { BlockedTimeId = 85, DayId = 3, StudentId = 8, StartTime = 8, EndTime = 9 },
                new BlockedTime { BlockedTimeId = 86, DayId = 3, StudentId = 8, StartTime = 12, EndTime = 13 },
                new BlockedTime { BlockedTimeId = 87, DayId = 4, StudentId = 8, StartTime = 12, EndTime = 14 },
                new BlockedTime { BlockedTimeId = 88, DayId = 4, StudentId = 8, StartTime = 16, EndTime = 18 },
                new BlockedTime { BlockedTimeId = 89, DayId = 5, StudentId = 8, StartTime = 12, EndTime = 14 },
                new BlockedTime { BlockedTimeId = 90, DayId = 5, StudentId = 8, StartTime = 18, EndTime = 20 }
                );

            modelBuilder.Entity<GroupActivity>().HasData(
                //group 1
                new GroupActivity { GoupActivityId = 1, GroupId = 1, Summary= "Group 1 Meeting", Location = "Library", Description = "Meeting for group 1", StartTime = new DateTime(2021, 6, 10, 9, 0, 0), EndTime = new DateTime(2021, 6, 10, 10, 0, 0), Isrecurring = true, FrequencyId = 2, OwnerId = 1 },
                new GroupActivity { GoupActivityId = 2, GroupId = 1, Summary = "Group 1 Study", Location = "Online", Description = "Assignment Collaboration for group 1", StartTime = new DateTime(2021, 6, 10, 13, 0, 0), EndTime = new DateTime(2021, 6, 10, 14, 0, 0), Isrecurring = false, FrequencyId = 0, OwnerId = 1 },

                //group 2 
                new GroupActivity { GoupActivityId = 3, GroupId = 2, Summary = "Group 2 Meeting", Location = "Library", Description = "Meeting for group 2", StartTime = new DateTime(2021, 6, 12, 9, 0, 0), EndTime = new DateTime(2021, 6, 12, 10, 0, 0), Isrecurring = true, FrequencyId = 2, OwnerId = 2 },
                new GroupActivity { GoupActivityId = 4, GroupId = 2, Summary = "Group 2 Study", Location = "Online", Description = "Assignment Collaboration for group 2", StartTime = new DateTime(2021, 6, 12, 13, 0, 0), EndTime = new DateTime(2021, 6, 12, 14, 0, 0), Isrecurring = false, FrequencyId = 0, OwnerId = 2 },
                
                //group 3 
                new GroupActivity { GoupActivityId = 5, GroupId = 3, Summary = "Group 3 Meeting", Location = "Library", Description = "Meeting for group 3", StartTime = new DateTime(2021, 6, 14, 9, 0, 0), EndTime = new DateTime(2021, 6, 14, 10, 0, 0), Isrecurring = true, FrequencyId = 2, OwnerId = 3 },
                new GroupActivity { GoupActivityId = 6, GroupId = 3, Summary = "Group 3 Study", Location = "Online", Description = "Assignment Collaboration for group 3", StartTime = new DateTime(2021, 6, 14, 13, 0, 0), EndTime = new DateTime(2021, 6, 14, 14, 0, 0), Isrecurring = false, FrequencyId = 0, OwnerId = 3 },

                //group 4
                new GroupActivity { GoupActivityId = 7, GroupId = 4, Summary = "Group 4 Meeting", Location = "Library", Description = "Meeting for group 4", StartTime = new DateTime(2021, 6, 16, 9, 0, 0), EndTime = new DateTime(2021, 6, 16, 10, 0, 0), Isrecurring = true, FrequencyId = 2, OwnerId = 4 },
                new GroupActivity { GoupActivityId = 8, GroupId = 4, Summary = "Group 4 Study", Location = "Online", Description = "Assignment Collaboration for group 4", StartTime = new DateTime(2021, 6, 16, 13, 0, 0), EndTime = new DateTime(2021, 6, 16, 14, 0, 0), Isrecurring = false, FrequencyId = 0, OwnerId = 4 }
                );

            modelBuilder.Entity<GroupActivityMembership>().HasData(
                //group 1 - first activity
                new GroupActivityMembership { GroupActivityMembershipId = 1, GroupId = 1, GoupActivityId = 1, StudentId = 1, StatusId = 3},
                new GroupActivityMembership { GroupActivityMembershipId = 2, GroupId = 1, GoupActivityId = 1, StudentId = 2, StatusId = 3},
                new GroupActivityMembership { GroupActivityMembershipId = 3, GroupId = 1, GoupActivityId = 1, StudentId = 3, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 4, GroupId = 1, GoupActivityId = 1, StudentId = 4, StatusId = 3 },

                //group 1 - second activity
                new GroupActivityMembership { GroupActivityMembershipId = 5, GroupId = 1, GoupActivityId = 2, StudentId = 1, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 6, GroupId = 1, GoupActivityId = 2, StudentId = 2, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 7, GroupId = 1, GoupActivityId = 2, StudentId = 3, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 8, GroupId = 1, GoupActivityId = 2, StudentId = 4, StatusId = 3 },
                
                //group 2 - first activity
                new GroupActivityMembership { GroupActivityMembershipId = 9, GroupId = 2, GoupActivityId = 3, StudentId = 1, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 10, GroupId = 2, GoupActivityId = 3, StudentId = 2, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 11, GroupId = 2, GoupActivityId = 3, StudentId = 3, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 12, GroupId = 2, GoupActivityId = 3, StudentId = 4, StatusId = 3 },

                //group 2 - second activity
                new GroupActivityMembership { GroupActivityMembershipId = 13, GroupId = 2, GoupActivityId = 4, StudentId = 1, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 14, GroupId = 2, GoupActivityId = 4, StudentId = 2, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 15, GroupId = 2, GoupActivityId = 4, StudentId = 3, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 16, GroupId = 2, GoupActivityId = 4, StudentId = 4, StatusId = 3 },

                //group 3 - first activity
                new GroupActivityMembership { GroupActivityMembershipId = 17, GroupId = 3, GoupActivityId = 5, StudentId = 1, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 18, GroupId = 3, GoupActivityId = 5, StudentId = 2, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 19, GroupId = 3, GoupActivityId = 5, StudentId = 3, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 20, GroupId = 3, GoupActivityId = 5, StudentId = 4, StatusId = 3 },

                //group 3 - second activity
                new GroupActivityMembership { GroupActivityMembershipId = 21, GroupId = 3, GoupActivityId = 6, StudentId = 1, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 22, GroupId = 3, GoupActivityId = 6, StudentId = 2, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 23, GroupId = 3, GoupActivityId = 6, StudentId = 3, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 24, GroupId = 3, GoupActivityId = 6, StudentId = 4, StatusId = 3 },

                //group 4 - first activity
                new GroupActivityMembership { GroupActivityMembershipId = 25, GroupId = 4, GoupActivityId = 7, StudentId = 1, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 26, GroupId = 4, GoupActivityId = 7, StudentId = 2, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 27, GroupId = 4, GoupActivityId = 7, StudentId = 3, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 28, GroupId = 4, GoupActivityId = 7, StudentId = 4, StatusId = 3 },

                //group 4 - second activity
                new GroupActivityMembership { GroupActivityMembershipId = 29, GroupId = 4, GoupActivityId = 8, StudentId = 1, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 30, GroupId = 4, GoupActivityId = 8, StudentId = 2, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 31, GroupId = 4, GoupActivityId = 8, StudentId = 3, StatusId = 3 },
                new GroupActivityMembership { GroupActivityMembershipId = 32, GroupId = 4, GoupActivityId = 8, StudentId = 4, StatusId = 3 }

                );

        }


    }
}
