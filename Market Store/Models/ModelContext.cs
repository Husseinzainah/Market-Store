using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Market_Store.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aboutu> Aboutus { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Home> Homes { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<OrderDetial> OrderDetials { get; set; }
        public virtual DbSet<Orderr> Orderrs { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Productcustomer> Productcustomers { get; set; }
        public virtual DbSet<Shopping> Shoppings { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Testimonial> Testimonials { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=train_user237;PASSWORD=HusseinTalat;DATA SOURCE=94.56.229.181:3488/traindb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TRAIN_USER237")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Aboutu>(entity =>
            {
                entity.HasKey(e => e.AboutId)
                    .HasName("SYS_C00213877");

                entity.ToTable("ABOUTUS");

                entity.Property(e => e.AboutId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ABOUT_ID");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");

                entity.Property(e => e.Imagename2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME2");

                entity.Property(e => e.TextA)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TEXT_A");

                entity.Property(e => e.TextB)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TEXT_B");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORIES");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.CategoryDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_DESCRIPTION");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_NAME");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");

                entity.Property(e => e.StoreId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("STORE_ID");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_STORE");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.ContId)
                    .HasName("SYS_C00213875");

                entity.ToTable("CONTACT");

                entity.Property(e => e.ContId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONT_ID");

                entity.Property(e => e.ConDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CON_DESCRIPTION");

                entity.Property(e => e.ContDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CONT_DATE");

                entity.Property(e => e.ContEmail)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CONT_EMAIL");

                entity.Property(e => e.ContPhone)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CONT_PHONE");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("SYS_C00213831");

                entity.ToTable("CUSTOMER");

                entity.Property(e => e.CustId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CUST_ID");

                entity.Property(e => e.CustFname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CUST_FNAME");

                entity.Property(e => e.CustLname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CUST_LNAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLE_ID");
            });

            modelBuilder.Entity<Home>(entity =>
            {
                entity.HasKey(e => e.HId)
                    .HasName("SYS_C00213870");

                entity.ToTable("HOME");

                entity.Property(e => e.HId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("H_ID");

                entity.Property(e => e.Imagename1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME1");

                entity.Property(e => e.Imagename2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME2");

                entity.Property(e => e.Imagename3)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME3");

                entity.Property(e => e.Imagename4)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME4");

                entity.Property(e => e.Text1)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TEXT1");

                entity.Property(e => e.Text2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TEXT2");

                entity.Property(e => e.Text3)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TEXT3");

                entity.Property(e => e.Text4)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TEXT4");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("SYS_C00213868");

                entity.ToTable("LOGIN");

                entity.Property(e => e.LogId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOG_ID");

                entity.Property(e => e.Logintype)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LOGINTYPE");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<OrderDetial>(entity =>
            {
                entity.HasKey(e => e.DetId)
                    .HasName("SYS_C00213843");

                entity.ToTable("ORDER_DETIALS");

                entity.Property(e => e.DetId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DET_ID");

                entity.Property(e => e.DateOrder)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_ORDER");

                entity.Property(e => e.OrdId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ORD_ID");

                entity.Property(e => e.ProId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PRO_ID");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("QUANTITY");

                entity.HasOne(d => d.Ord)
                    .WithMany(p => p.OrderDetials)
                    .HasForeignKey(d => d.OrdId)
                    .HasConstraintName("FK_ORDER");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.OrderDetials)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK_PRODU");
            });

            modelBuilder.Entity<Orderr>(entity =>
            {
                entity.HasKey(e => e.OrdId)
                    .HasName("SYS_C00213837");

                entity.ToTable("ORDERR");

                entity.Property(e => e.OrdId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ORD_ID");

                entity.Property(e => e.CustName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CUST_NAME");

                entity.Property(e => e.CustoId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CUSTO_ID");

                entity.Property(e => e.OrdDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ORD_DATE");

                entity.Property(e => e.Price)
                    .HasColumnType("FLOAT")
                    .HasColumnName("PRICE");

                entity.Property(e => e.ProdId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PROD_ID");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("QUANTITY");

                entity.Property(e => e.UserAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USER_ADDRESS");

                entity.Property(e => e.UserCity)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USER_CITY");

                entity.Property(e => e.UserCountry)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USER_COUNTRY");

                entity.Property(e => e.UserNote)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_NOTE");

                entity.HasOne(d => d.Custo)
                    .WithMany(p => p.Orderrs)
                    .HasForeignKey(d => d.CustoId)
                    .HasConstraintName("FK_CUSTO");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Orderrs)
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK_PROD");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PayId)
                    .HasName("SYS_C00213854");

                entity.ToTable("PAYMENT");

                entity.Property(e => e.PayId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PAY_ID");

                entity.Property(e => e.CutId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CUT_ID");

                entity.Property(e => e.Expiry)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY");

                entity.Property(e => e.PayType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PAY_TYPE");

                entity.Property(e => e.Price)
                    .HasColumnType("FLOAT")
                    .HasColumnName("PRICE");

                entity.HasOne(d => d.Cut)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CutId)
                    .HasConstraintName("FK_CUT");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProId)
                    .HasName("SYS_C00213828");

                entity.ToTable("PRODUCT");

                entity.Property(e => e.ProId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRO_ID");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.ProductColor)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_COLOR");

                entity.Property(e => e.ProductImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_IMAGE");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_NAME");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("FLOAT")
                    .HasColumnName("PRODUCT_PRICE");

                entity.Property(e => e.ProductQuntity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCT_QUNTITY");

                entity.Property(e => e.ProductSale)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCT_SALE");

                entity.Property(e => e.ProductStatus)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCT_STATUS");
                //Note
               
                //End Note2
                //End

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_CAT");
            });

            modelBuilder.Entity<Productcustomer>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("SYS_C00213833");

                entity.ToTable("PRODUCTCUSTOMER");

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.CustId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CUST_ID");

                entity.Property(e => e.Datefrom)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEFROM");

                entity.Property(e => e.Dateto)
                    .HasColumnType("DATE")
                    .HasColumnName("DATETO");

                entity.Property(e => e.ProId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PRO_ID");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("QUANTITY");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Productcustomers)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_CUST");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.Productcustomers)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK_PRO");
            });

            modelBuilder.Entity<Shopping>(entity =>
            {
                entity.HasKey(e => e.ShopId)
                    .HasName("SYS_C00213850");

                entity.ToTable("SHOPPING");

                entity.Property(e => e.ShopId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SHOP_ID");
                //Note
                entity.Property(e => e.NameShop)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAMESHOP");
                //EndNote
                //Note2
                entity.Property(e => e.Total)
                   .HasColumnType("FLOAT")
                   .HasColumnName("TOTAL");
                //End Note2
                //note 3
                entity.Property(e => e.Imagename)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");
                //end not 3
                entity.Property(e => e.CuId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CU_ID");

                entity.Property(e => e.Price)
                    .HasColumnType("FLOAT")
                    .HasColumnName("PRICE");

                //entity.Property(e => e.ProducId)
                //    .HasColumnType("NUMBER(38)")
                //    .HasColumnName("PRODUC_ID");

                entity.Property(e => e.Quantity)
                   .HasColumnType("NUMBER(38)")
                   .HasColumnName("QUANTITY");

                entity.HasOne(d => d.Cu)
                    .WithMany(p => p.Shoppings)
                    .HasForeignKey(d => d.CuId)
                    .HasConstraintName("FK_CU");

                entity.HasOne(d => d.Produc)
                    .WithMany(p => p.Shoppings)
                    .HasForeignKey(d => d.ProducId)
                    .HasConstraintName("FK_PRODUC");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.StoId)
                    .HasName("SYS_C00213858");

                entity.ToTable("STOCK");

                entity.Property(e => e.StoId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STO_ID");

                entity.Property(e => e.PrdId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PRD_ID");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("QUANTITY");

                entity.Property(e => e.StoName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STO_NAME");

                entity.HasOne(d => d.Prd)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.PrdId)
                    .HasConstraintName("FK_PRD");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("STORE");

                entity.Property(e => e.StoreId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STORE_ID");

                entity.Property(e => e.StoreDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STORE_DESCRIPTION");

                entity.Property(e => e.StoreImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STORE_IMAGE");

                entity.Property(e => e.StoreLogo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STORE_LOGO");

                entity.Property(e => e.StoreName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STORE_NAME");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.HasKey(e => e.TestId)
                    .HasName("SYS_C00213863");

                entity.ToTable("TESTIMONIAL");

                entity.Property(e => e.TestId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TEST_ID");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.Masseges)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MASSEGES");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CUSTOMER");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.ToTable("USER_LOGIN");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CustomeId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CUSTOME_ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Custome)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.CustomeId)
                    .HasConstraintName("FK_CUSTOME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
