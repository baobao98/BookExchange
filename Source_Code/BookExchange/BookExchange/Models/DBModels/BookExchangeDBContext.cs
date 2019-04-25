using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookExchange.Models.DBModels
{
    public partial class BookExchangeDBContext : DbContext
    {
        public BookExchangeDBContext()
        {
        }

        public BookExchangeDBContext(DbContextOptions<BookExchangeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AnhSach> AnhSach { get; set; }
        public virtual DbSet<LoaiMuonNhan> LoaiMuonNhan { get; set; }
        public virtual DbSet<Sach> Sach { get; set; }
        public virtual DbSet<TacGia> TacGia { get; set; }
        public virtual DbSet<TheLoai> TheLoai { get; set; }
        public virtual DbSet<TrangThai> TrangThai { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=bookexchange123.c6hffjdxx48x.ap-southeast-1.rds.amazonaws.com;;user=bookexchange123;password=Anngo0211;database=BookExchangeDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.MaTk);

                entity.Property(e => e.MaTk).HasColumnName("MaTK");

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TaiKhoan)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AnhSach>(entity =>
            {
                entity.HasKey(e => e.Idanh);

                entity.Property(e => e.Idanh).HasColumnName("IDAnh");

                entity.Property(e => e.ImgUrl)
                    .HasColumnName("imgURL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaSach)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaSachNavigation)
                    .WithMany(p => p.AnhSach)
                    .HasForeignKey(d => d.MaSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnhSach_Sach");
            });

            modelBuilder.Entity<LoaiMuonNhan>(entity =>
            {
                entity.HasKey(e => e.IdloaiMuonNhan);

                entity.Property(e => e.IdloaiMuonNhan).HasColumnName("IDLoaiMuonNhan");

                entity.Property(e => e.MaSach)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaTl).HasColumnName("MaTL");

                entity.HasOne(d => d.MaSachNavigation)
                    .WithMany(p => p.LoaiMuonNhan)
                    .HasForeignKey(d => d.MaSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LoaiMuonNhan_Sach");

                entity.HasOne(d => d.MaTlNavigation)
                    .WithMany(p => p.LoaiMuonNhan)
                    .HasForeignKey(d => d.MaTl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LoaiMuonNhan_TheLoai");
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.MaSach);

                entity.Property(e => e.MaSach)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Gia).HasColumnType("money");

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.MaTl).HasColumnName("MaTL");

                entity.Property(e => e.MaTt).HasColumnName("MaTT");

                entity.Property(e => e.NgayDang).HasColumnType("datetime");

                entity.Property(e => e.TenSach)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.Sach)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sach_User");

                entity.HasOne(d => d.MaTlNavigation)
                    .WithMany(p => p.Sach)
                    .HasForeignKey(d => d.MaTl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sach_TheLoai");

                entity.HasOne(d => d.MaTtNavigation)
                    .WithMany(p => p.Sach)
                    .HasForeignKey(d => d.MaTt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sach_TrangThai");
            });

            modelBuilder.Entity<TacGia>(entity =>
            {
                entity.HasKey(e => e.MaTg);

                entity.Property(e => e.MaTg).HasColumnName("MaTG");

                entity.Property(e => e.MaSach)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenTg)
                    .IsRequired()
                    .HasColumnName("TenTG")
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaSachNavigation)
                    .WithMany(p => p.TacGia)
                    .HasForeignKey(d => d.MaSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TacGia_Sach");
            });

            modelBuilder.Entity<TheLoai>(entity =>
            {
                entity.HasKey(e => e.MaTl);

                entity.Property(e => e.MaTl)
                    .HasColumnName("MaTL")
                    .ValueGeneratedNever();

                entity.Property(e => e.TenTl)
                    .IsRequired()
                    .HasColumnName("TenTL")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TrangThai>(entity =>
            {
                entity.HasKey(e => e.MaTt);

                entity.Property(e => e.MaTt).HasColumnName("MaTT");

                entity.Property(e => e.TenTt)
                    .IsRequired()
                    .HasColumnName("TenTT")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.MaKh);

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.DienThoai)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GioiTinh)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Idaccount).HasColumnName("IDAccount");

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.HasOne(d => d.IdaccountNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.Idaccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Account");
            });
        }
    }
}
