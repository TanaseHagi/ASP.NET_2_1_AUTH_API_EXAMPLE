﻿// <auto-generated />
using System;
using ASP.NET_2_1_AUTH_API_EXAMPLE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ASP.NET_2_1_AUTH_API_EXAMPLE.Migrations
{
    [DbContext(typeof(ToDoItemContext))]
    partial class ToDoItemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799");

            modelBuilder.Entity("ASP.NET_2_1_AUTH_API_EXAMPLE.Models.ToDoItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsComplete");

                    b.Property<string>("Name");

                    b.Property<string>("ToDoUserIdId");

                    b.HasKey("Id");

                    b.HasIndex("ToDoUserIdId");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("ASP.NET_2_1_AUTH_API_EXAMPLE.Models.ToDoUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("ToDoUser");
                });

            modelBuilder.Entity("ASP.NET_2_1_AUTH_API_EXAMPLE.Models.ToDoItem", b =>
                {
                    b.HasOne("ASP.NET_2_1_AUTH_API_EXAMPLE.Models.ToDoUser", "ToDoUserId")
                        .WithMany()
                        .HasForeignKey("ToDoUserIdId");
                });
#pragma warning restore 612, 618
        }
    }
}
