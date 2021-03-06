// <auto-generated />
using System;
using Bierland.dataaccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bierland.dataaccess.Migrations
{
    [DbContext(typeof(BierlandContext))]
    [Migration("20200928021405_usersessions")]
    partial class usersessions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bierland.domain.Beer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BeerFactoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Qualification")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BeerFactoryId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("Bierland.domain.BeerFactory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BeerFactorys");
                });

            modelBuilder.Entity("Bierland.domain.BeerPubs", b =>
                {
                    b.Property<int>("BeerId")
                        .HasColumnType("int");

                    b.Property<int>("PubId")
                        .HasColumnType("int");

                    b.HasKey("BeerId", "PubId");

                    b.HasIndex("PubId");

                    b.ToTable("BeerPubs");
                });

            modelBuilder.Entity("Bierland.domain.BeerPurchase", b =>
                {
                    b.Property<int>("BeerId")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.HasKey("BeerId", "PurchaseId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("BeerPurchases");
                });

            modelBuilder.Entity("Bierland.domain.Pub", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pubs");
                });

            modelBuilder.Entity("Bierland.domain.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BeerId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PubId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BeerId");

                    b.HasIndex("PubId");

                    b.HasIndex("UserId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("Bierland.domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Bierland.domain.Beer", b =>
                {
                    b.HasOne("Bierland.domain.BeerFactory", null)
                        .WithMany("Beers")
                        .HasForeignKey("BeerFactoryId");
                });

            modelBuilder.Entity("Bierland.domain.BeerPubs", b =>
                {
                    b.HasOne("Bierland.domain.Beer", "Beer")
                        .WithMany("BeerPubs")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bierland.domain.Pub", "Pub")
                        .WithMany("BeerPubs")
                        .HasForeignKey("PubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bierland.domain.BeerPurchase", b =>
                {
                    b.HasOne("Bierland.domain.Beer", "Beer")
                        .WithMany("BeerPurchases")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bierland.domain.Purchase", "Purchase")
                        .WithMany("BeerPurchases")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bierland.domain.Purchase", b =>
                {
                    b.HasOne("Bierland.domain.Beer", "Beer")
                        .WithMany()
                        .HasForeignKey("BeerId");

                    b.HasOne("Bierland.domain.Pub", "Pub")
                        .WithMany()
                        .HasForeignKey("PubId");

                    b.HasOne("Bierland.domain.User", "User")
                        .WithMany("Purchases")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
