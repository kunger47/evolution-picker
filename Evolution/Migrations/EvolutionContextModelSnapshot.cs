﻿// <auto-generated />
using Evolution.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Evolution.Migrations
{
    [DbContext(typeof(EvolutionContext))]
    partial class EvolutionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Evolution.Models.Classification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Classification_Id");

                    b.Property<string>("Info");

                    b.Property<string>("Name");

                    b.Property<int>("Parent_Id");

                    b.HasKey("Id");

                    b.ToTable("Classifications");
                });

            modelBuilder.Entity("Evolution.Models.ClassificationOfLife", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info");

                    b.Property<string>("LevelName");

                    b.HasKey("Id");

                    b.ToTable("ClassificationsOfLife");
                });

            modelBuilder.Entity("Evolution.Models.EvolutionaryPressure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info");

                    b.Property<string>("PressureName");

                    b.HasKey("Id");

                    b.ToTable("EvolutionaryPressures");
                });

            modelBuilder.Entity("Evolution.Models.GeologicalTimeScale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info");

                    b.Property<string>("LevelName");

                    b.HasKey("Id");

                    b.ToTable("GeologicalTimeScales");
                });

            modelBuilder.Entity("Evolution.Models.Species", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adaption");

                    b.Property<int>("Ancestor_Id");

                    b.Property<int>("Classification_Id");

                    b.Property<string>("CommonName");

                    b.Property<string>("Info");

                    b.Property<int>("Pressure_Id");

                    b.Property<string>("SpeciesName");

                    b.Property<int>("Timespan_Id");

                    b.HasKey("Id");

                    b.ToTable("TheSpecies");
                });

            modelBuilder.Entity("Evolution.Models.Timescale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info");

                    b.Property<string>("Name");

                    b.Property<int>("Parent_Id");

                    b.Property<int>("ScaleID");

                    b.HasKey("Id");

                    b.ToTable("Timescales");
                });
#pragma warning restore 612, 618
        }
    }
}
