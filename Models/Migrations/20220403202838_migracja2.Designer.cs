// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Models.Migrations
{
    [DbContext(typeof(HostelContext))]
    [Migration("20220403202838_migracja2")]
    partial class migracja2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Hostel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hostels");
                });

            modelBuilder.Entity("Models.Klient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Models.Pokoj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CenaZaNocleg")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("HostelId")
                        .HasColumnType("int");

                    b.Property<int>("IloscLozek")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RodzajPokojuId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HostelId");

                    b.HasIndex("RodzajPokojuId");

                    b.ToTable("Pokoje");
                });

            modelBuilder.Entity("Models.RodzajePokojow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RodzajPokoju")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RodzajePokojow");
                });

            modelBuilder.Entity("Models.Wypozyczenie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataRozpoczecia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataUtworzeznia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataZakonczenia")
                        .HasColumnType("datetime2");

                    b.Property<int?>("KlientId")
                        .HasColumnType("int");

                    b.Property<int?>("PokojId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KlientId");

                    b.HasIndex("PokojId");

                    b.ToTable("Wypozyczenia");
                });

            modelBuilder.Entity("Models.Pokoj", b =>
                {
                    b.HasOne("Models.Hostel", "Hostel")
                        .WithMany()
                        .HasForeignKey("HostelId");

                    b.HasOne("Models.RodzajePokojow", "RodzajPokoju")
                        .WithMany()
                        .HasForeignKey("RodzajPokojuId");

                    b.Navigation("Hostel");

                    b.Navigation("RodzajPokoju");
                });

            modelBuilder.Entity("Models.Wypozyczenie", b =>
                {
                    b.HasOne("Models.Klient", "Klient")
                        .WithMany()
                        .HasForeignKey("KlientId");

                    b.HasOne("Models.Pokoj", "Pokoj")
                        .WithMany()
                        .HasForeignKey("PokojId");

                    b.Navigation("Klient");

                    b.Navigation("Pokoj");
                });
#pragma warning restore 612, 618
        }
    }
}
