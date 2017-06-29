using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SNOW.SHOP.API.Data;

namespace SNOW.SHOP.API.Migrations
{
    [DbContext(typeof(SnowShopAPIDbContext))]
    [Migration("20170628215719_inial")]
    partial class inial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Name");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Brand","Production");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Name");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Category","Production");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Company","Production");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("NameFirst");

                    b.Property<string>("NameLast");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Cutomer","Production");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.ImageInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentType");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Name");

                    b.Property<int?>("ProductId");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ImageInfo","Production");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quality");

                    b.Property<int?>("SizeId");

                    b.Property<int?>("StoreId");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SizeId");

                    b.HasIndex("StoreId");

                    b.ToTable("Inventory","Production");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("DT");

                    b.Property<int?>("OrderStatusId");

                    b.Property<decimal>("PromotionAmount");

                    b.Property<int?>("StoreId");

                    b.Property<int?>("StoreId1");

                    b.Property<decimal>("TotalAmount");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("StoreId");

                    b.HasIndex("StoreId1");

                    b.ToTable("Order","Production");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("OrderId");

                    b.Property<decimal>("Price");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quality");

                    b.Property<int?>("SizeId");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SizeId");

                    b.ToTable("OrderDetail","Production");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("OrderStatus","Production");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("PaymentType","Production");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("BinaryData");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("ImageInfoId");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("ImageInfoId");

                    b.ToTable("Photo","Production");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId");

                    b.Property<int>("CategoryId");

                    b.Property<int>("ClickCount");

                    b.Property<int>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<decimal>("MarketPrice");

                    b.Property<string>("Name");

                    b.Property<decimal>("StockPrice");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Product","Production");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("ProductId");

                    b.Property<decimal>("Rate");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProductId");

                    b.ToTable("Promotion","Production");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.PromotionOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("OrderId");

                    b.Property<int?>("PromotionId");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PromotionId");

                    b.ToTable("PromotionOrder","Production");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.PromotionProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("ProductId");

                    b.Property<int?>("PromotionId");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("PromotionId");

                    b.ToTable("PromotionProduct","Production");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("OrderId");

                    b.Property<int?>("PaymentTypeId");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("Receipt","Production");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Name");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Size","Production");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("City");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Country");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<int?>("CompanyId1");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CompanyId1");

                    b.ToTable("Store","Production");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Brand", b =>
                {
                    b.HasOne("SNOW.SHOP.API.src.Model.Company", "Company")
                        .WithMany("AllBrands")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Category", b =>
                {
                    b.HasOne("SNOW.SHOP.API.src.Model.Company", "Company")
                        .WithMany("AllCategories")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Customer", b =>
                {
                    b.HasOne("SNOW.SHOP.API.src.Model.Company")
                        .WithMany("AllCustomers")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.ImageInfo", b =>
                {
                    b.HasOne("SNOW.SHOP.API.src.Model.Product", "Product")
                        .WithMany("AllImageInfos")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Inventory", b =>
                {
                    b.HasOne("SNOW.SHOP.API.src.Model.Product", "Product")
                        .WithMany("AllInventories")
                        .HasForeignKey("ProductId");

                    b.HasOne("SNOW.SHOP.API.src.Model.Size", "Size")
                        .WithMany("AllInventories")
                        .HasForeignKey("SizeId");

                    b.HasOne("SNOW.SHOP.API.src.Model.Store", "Store")
                        .WithMany("AllInventories")
                        .HasForeignKey("StoreId");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Order", b =>
                {
                    b.HasOne("SNOW.SHOP.API.src.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("SNOW.SHOP.API.src.Model.OrderStatus", "OrderStatus")
                        .WithMany("AllOrders")
                        .HasForeignKey("OrderStatusId");

                    b.HasOne("SNOW.SHOP.API.src.Model.Store")
                        .WithMany("AllOrders")
                        .HasForeignKey("StoreId");

                    b.HasOne("SNOW.SHOP.API.src.Model.User", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId1");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.OrderDetail", b =>
                {
                    b.HasOne("SNOW.SHOP.API.src.Model.Order", "Order")
                        .WithMany("AllOrderDetails")
                        .HasForeignKey("OrderId");

                    b.HasOne("SNOW.SHOP.API.src.Model.Product", "Product")
                        .WithMany("AllOrderDetails")
                        .HasForeignKey("ProductId");

                    b.HasOne("SNOW.SHOP.API.src.Model.Size", "Size")
                        .WithMany("AllOrderDetails")
                        .HasForeignKey("SizeId");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.OrderStatus", b =>
                {
                    b.HasOne("SNOW.SHOP.API.src.Model.Company", "Company")
                        .WithMany("AllOrderStatus")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.PaymentType", b =>
                {
                    b.HasOne("SNOW.SHOP.API.src.Model.Company", "Company")
                        .WithMany("AllPaymentTypes")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Photo", b =>
                {
                    b.HasOne("SNOW.SHOP.API.src.Model.ImageInfo", "ImageInfo")
                        .WithMany()
                        .HasForeignKey("ImageInfoId");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Product", b =>
                {
                    b.HasOne("SNOW.SHOP.API.src.Model.Brand", "Brand")
                        .WithMany("AllProducts")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SNOW.SHOP.API.src.Model.Category", "Category")
                        .WithMany("AllProducts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SNOW.SHOP.API.src.Model.Company", "Company")
                        .WithMany("AllProducts")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Promotion", b =>
                {
                    b.HasOne("SNOW.SHOP.API.src.Model.Company", "Company")
                        .WithMany("AllPromotions")
                        .HasForeignKey("CompanyId");

                    b.HasOne("SNOW.SHOP.API.src.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.PromotionOrder", b =>
                {
                    b.HasOne("SNOW.SHOP.API.src.Model.Order", "Order")
                        .WithMany("AllPromotionOrders")
                        .HasForeignKey("OrderId");

                    b.HasOne("SNOW.SHOP.API.src.Model.Promotion", "Promotion")
                        .WithMany("AllPromotionOrders")
                        .HasForeignKey("PromotionId");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.PromotionProduct", b =>
                {
                    b.HasOne("SNOW.SHOP.API.src.Model.Product", "Product")
                        .WithMany("AllPromotionProducts")
                        .HasForeignKey("ProductId");

                    b.HasOne("SNOW.SHOP.API.src.Model.Promotion", "Promotion")
                        .WithMany("AllPromotionProducts")
                        .HasForeignKey("PromotionId");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Receipt", b =>
                {
                    b.HasOne("SNOW.SHOP.API.src.Model.Order", "Order")
                        .WithMany("AllReceipts")
                        .HasForeignKey("OrderId");

                    b.HasOne("SNOW.SHOP.API.src.Model.PaymentType", "PaymentType")
                        .WithMany()
                        .HasForeignKey("PaymentTypeId");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Size", b =>
                {
                    b.HasOne("SNOW.SHOP.API.src.Model.Category", "Category")
                        .WithMany("AllSizes")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.Store", b =>
                {
                    b.HasOne("SNOW.SHOP.API.src.Model.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("SNOW.SHOP.API.src.Model.User", b =>
                {
                    b.HasOne("SNOW.SHOP.API.src.Model.Company")
                        .WithMany("AllStores")
                        .HasForeignKey("CompanyId");

                    b.HasOne("SNOW.SHOP.API.src.Model.Company")
                        .WithMany("AllUsers")
                        .HasForeignKey("CompanyId1");
                });
        }
    }
}
