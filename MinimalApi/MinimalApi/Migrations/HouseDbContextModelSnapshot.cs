﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinimalApi.Data;

#nullable disable

namespace MinimalApi.Migrations
{
    [DbContext(typeof(HouseDbContext))]
    partial class HouseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("MinimalApi.Data.HouseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Houses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "12 Valley of Kings, Geneva",
                            Country = "Switzerland",
                            Description = "A superb detached Victorian property on one of the town's finest roads, within easy reach of Barnes Village. The property has in excess of 6000 sq/ft of accommodation, a driveway and landscaped garden.",
                            Price = 900000m
                        },
                        new
                        {
                            Id = 2,
                            Address = "89 Road of Forks, Bern",
                            Country = "Switzerland",
                            Description = "This impressive family home, which dates back to approximately 1840, offers original period features throughout and is set back from the road with off street parking for up to six cars and an original Coach House, which has been incorporated into the main house to provide further accommodation. ",
                            Price = 500000m
                        },
                        new
                        {
                            Id = 3,
                            Address = "Grote Hof 12, Amsterdam",
                            Country = "The Netherlands",
                            Description = "This house has been designed and built to an impeccable standard offering luxurious and elegant living. The accommodation is arranged over four floors comprising a large entrance hall, living room with tall sash windows, dining room, study and WC on the ground floor.",
                            Price = 200500m
                        },
                        new
                        {
                            Id = 4,
                            Address = "Meel Kade 321, The Hague",
                            Country = "The Netherlands",
                            Description = "Discreetly situated a unique two storey period home enviably located on the corner of Krom Road and Recht Road offering seclusion and privacy. The house features a magnificent double height reception room with doors leading directly out onto a charming courtyard garden.",
                            Price = 259500m
                        },
                        new
                        {
                            Id = 5,
                            Address = "Oude Gracht 32, Utrecht",
                            Country = "The Netherlands",
                            Description = "This luxurious three bedroom flat is contemporary in style and benefits from the use of a gymnasium and a reserved underground parking space.",
                            Price = 400500m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
