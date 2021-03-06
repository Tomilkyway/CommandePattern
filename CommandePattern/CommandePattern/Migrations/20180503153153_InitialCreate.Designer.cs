﻿// <auto-generated />
using CommandePattern;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace CommandePattern.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20180503153153_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("CommandePattern.Article", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("content");

                    b.Property<string>("title");

                    b.HasKey("id");

                    b.ToTable("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
