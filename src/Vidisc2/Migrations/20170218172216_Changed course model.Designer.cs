using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Vidisc2.Data;

namespace Vidisc2.Migrations
{
    [DbContext(typeof(DgContext))]
    [Migration("20170218172216_Changed course model")]
    partial class Changedcoursemodel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vidisc2.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("HolesStr");

                    b.Property<string>("Location");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Vidisc2.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Vidisc2.Models.Round", b =>
                {
                    b.Property<int>("RoundId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseId");

                    b.Property<DateTime>("FinishedAt");

                    b.Property<DateTime>("StartedAt");

                    b.HasKey("RoundId");

                    b.HasIndex("CourseId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("Vidisc2.Models.Scorecard", b =>
                {
                    b.Property<int>("ScorecardId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PlayerId");

                    b.Property<int>("RoundId");

                    b.Property<string>("ScoreSetStr")
                        .IsRequired();

                    b.HasKey("ScorecardId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("RoundId");

                    b.ToTable("Scorecards");
                });

            modelBuilder.Entity("Vidisc2.Models.Round", b =>
                {
                    b.HasOne("Vidisc2.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vidisc2.Models.Scorecard", b =>
                {
                    b.HasOne("Vidisc2.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vidisc2.Models.Round", "Round")
                        .WithMany("Scorecards")
                        .HasForeignKey("RoundId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
