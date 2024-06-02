﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MilkyProject.Data.Concrete.EfCore;

#nullable disable

namespace MilkyProject.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240531153607_start4")]
    partial class start4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Milky.Entity.Concrete.About", b =>
                {
                    b.Property<int>("AboutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AboutId"), 1L, 1);

                    b.Property<string>("AboutDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutImage1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutImage2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutImage3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AboutId");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("Milky.Entity.Concrete.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"), 1L, 1);

                    b.Property<string>("MessageContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MessageDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MessageFullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageSubject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Milky.Entity.Concrete.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"), 1L, 1);

                    b.Property<string>("ServiceDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Milky.Entity.Concrete.SocialMedia", b =>
                {
                    b.Property<int>("SocialMediaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SocialMediaId"), 1L, 1);

                    b.Property<string>("SocialMediaIcon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SocialMediaLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("SocialMediaId");

                    b.HasIndex("TeamId");

                    b.ToTable("SocialMedias");
                });

            modelBuilder.Entity("Milky.Entity.Concrete.Subscribe", b =>
                {
                    b.Property<int>("SubscribeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscribeId"), 1L, 1);

                    b.Property<DateTime>("SubscribeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubscribeMail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubscribeId");

                    b.ToTable("Subscribes");
                });

            modelBuilder.Entity("Milky.Entity.Concrete.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"), 1L, 1);

                    b.Property<string>("TeamDepartment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamFullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Milky.Entity.Concrete.Testimonial", b =>
                {
                    b.Property<int>("TestimonialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestimonialId"), 1L, 1);

                    b.Property<string>("TestimonialDepartment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestimonialFullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestimonialImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestimonialId");

                    b.ToTable("Testimonials");
                });

            modelBuilder.Entity("MilkyProject.Entity.Concrete.Slider", b =>
                {
                    b.Property<int>("SliderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SliderId"), 1L, 1);

                    b.Property<string>("SliderImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderSubTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SliderId");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("Milky.Entity.Concrete.SocialMedia", b =>
                {
                    b.HasOne("Milky.Entity.Concrete.Team", "Team")
                        .WithMany("SocialMedias")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Milky.Entity.Concrete.Team", b =>
                {
                    b.Navigation("SocialMedias");
                });
#pragma warning restore 612, 618
        }
    }
}
