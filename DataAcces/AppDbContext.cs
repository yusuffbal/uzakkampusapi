using DataAcces.Helpers;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationManager = DataAcces.Helpers.ConfigurationManager;

namespace DataAcces
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connString = ConfigurationManager.Configuration.GetConnectionString("MsSqlConnString");
                if (!string.IsNullOrEmpty(connString))
                    optionsBuilder.UseSqlServer(connString, options => options.EnableRetryOnFailure());
            }

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Assigments> Assigments { get; set; }
        public DbSet<CourseDocument> CourseDocuments { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<CourseVideos> CourseVideos { get; set; }
        public DbSet<Exams> Exams { get; set; }
        public DbSet<ExamsDetail> ExamsDetails { get; set; }
        public DbSet<ForumParticipants> forumParticipants { get; set; }
        public DbSet<ForumPosts> ForumPosts { get; set; }
        public DbSet<Forums> Forums { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<QuizDetail> QuizDetails { get; set; }
        public DbSet<StudentAssigment> StudentAssigments { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<StudentExams> StudentExams { get; set; }
        public DbSet<StudentQuiz> StudentQuiz { get; set; }
        public DbSet<Users> Users { get; set; }

    }
}
