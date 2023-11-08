using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace airdbMVCtry.Models
{
    public partial class AirRDbContext : DbContext
    {
        public AirRDbContext()
        {
        }

        public AirRDbContext(DbContextOptions<AirRDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Flight> Flights { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PF3ZE7G6230817\\SQLEXPRESS;Database=AirRDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("bookings");

                entity.Property(e => e.BookingId)
                    .ValueGeneratedNever()
                    .HasColumnName("booking_id");

                entity.Property(e => e.FlightId).HasColumnName("flight_id");

                entity.Property(e => e.NoOfPassengers).HasColumnName("no_of_passengers");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK__bookings__flight__4222D4EF");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__bookings__user_i__412EB0B6");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("flights");

                entity.Property(e => e.FlightId)
                    .ValueGeneratedNever()
                    .HasColumnName("flight_id");

                entity.Property(e => e.ArrivalDate)
                    .HasColumnType("date")
                    .HasColumnName("arrival_date");

                entity.Property(e => e.ArrivalTime).HasColumnName("arrival_time");

                entity.Property(e => e.Class)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("class");

                entity.Property(e => e.DepartureDate)
                    .HasColumnType("date")
                    .HasColumnName("departure_date");

                entity.Property(e => e.DepartureTime).HasColumnName("departure_time");

                entity.Property(e => e.Destination)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("destination");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("source");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__users__F3DBC57362352DB5");

                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "UQ__users__AB6E616460458C23")
                    .IsUnique();

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.ConfirmPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("confirmPassword");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
