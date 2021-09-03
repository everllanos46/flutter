﻿// <auto-generated />
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(TiendaContext))]
    partial class TiendaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entidad.Detalle", b =>
                {
                    b.Property<string>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CantidadProducto")
                        .HasColumnType("int");

                    b.Property<double>("Descuento")
                        .HasColumnType("float");

                    b.Property<string>("FacturaCompraFacturaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FacturaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<double>("TotalDescontado")
                        .HasColumnType("float");

                    b.Property<double>("TotalIVA")
                        .HasColumnType("float");

                    b.Property<double>("ValorProducto")
                        .HasColumnType("float");

                    b.HasKey("DetalleId");

                    b.HasIndex("FacturaCompraFacturaId");

                    b.HasIndex("FacturaId");

                    b.ToTable("detalles");
                });

            modelBuilder.Entity("Entidad.Factura", b =>
                {
                    b.Property<string>("FacturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("InteresadoId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<double>("TotalDescontado")
                        .HasColumnType("float");

                    b.Property<double>("TotalIVA")
                        .HasColumnType("float");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacturaId");

                    b.ToTable("facturas");
                });

            modelBuilder.Entity("Entidad.FacturaCompra", b =>
                {
                    b.Property<string>("FacturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProveedorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<double>("TotalDescontado")
                        .HasColumnType("float");

                    b.Property<double>("TotalIVA")
                        .HasColumnType("float");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacturaId");

                    b.ToTable("facturaCompras");
                });

            modelBuilder.Entity("Entidad.Interesado", b =>
                {
                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Identificacion");

                    b.ToTable("interesados");
                });

            modelBuilder.Entity("Entidad.Producto", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Descuento")
                        .HasColumnType("float");

                    b.Property<string>("Fecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdProveedor")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Iva")
                        .HasColumnType("float");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<double>("TotalDescuento")
                        .HasColumnType("float");

                    b.Property<double>("TotalIva")
                        .HasColumnType("float");

                    b.HasKey("Codigo");

                    b.HasIndex("IdProveedor");

                    b.ToTable("productos");
                });

            modelBuilder.Entity("Entidad.Proveedor", b =>
                {
                    b.Property<string>("IdProveedor")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProveedor");

                    b.ToTable("proveedores");
                });

            modelBuilder.Entity("Entidad.Usuario", b =>
                {
                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Identificacion");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("Entidad.Detalle", b =>
                {
                    b.HasOne("Entidad.FacturaCompra", null)
                        .WithMany("DetallesFactura")
                        .HasForeignKey("FacturaCompraFacturaId");

                    b.HasOne("Entidad.Factura", null)
                        .WithMany("DetallesFactura")
                        .HasForeignKey("FacturaId");
                });

            modelBuilder.Entity("Entidad.Producto", b =>
                {
                    b.HasOne("Entidad.Proveedor", null)
                        .WithMany()
                        .HasForeignKey("IdProveedor");
                });

            modelBuilder.Entity("Entidad.Factura", b =>
                {
                    b.Navigation("DetallesFactura");
                });

            modelBuilder.Entity("Entidad.FacturaCompra", b =>
                {
                    b.Navigation("DetallesFactura");
                });
#pragma warning restore 612, 618
        }
    }
}
