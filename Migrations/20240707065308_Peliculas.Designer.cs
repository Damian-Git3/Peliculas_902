﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TareasAPI_902.Models;

#nullable disable

namespace TareasAPI_902.Migrations
{
    [DbContext(typeof(BdTareas902Context))]
    [Migration("20240707065308_Peliculas")]
    partial class Peliculas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TareasAPI_902.Models.Pelicula", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("anio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("categorias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sinopsis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Pelicula");
                });

            modelBuilder.Entity("TareasAPI_902.Models.Tarea", b =>
                {
                    b.Property<int>("IdTarea")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_tarea");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTarea"));

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.HasKey("IdTarea")
                        .HasName("PK__tarea__C0ECF7075BEFB7FD");

                    b.ToTable("tarea", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
