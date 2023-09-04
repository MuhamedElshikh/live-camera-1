using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace live_camera_1.Models.DB;

public partial class LivecamContext : DbContext
{

    

    public LivecamContext(DbContextOptions<LivecamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserRegistration> UserRegistrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server= localhost\\sqlexpress;Initial Catalog=LIVECAM;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRegistration>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_user");

            entity.ToTable("UserRegistration");

            entity.Property(e => e.Confirmpwd).HasMaxLength(150);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaritalStatus).HasMaxLength(100);
            entity.Property(e => e.Pwd).HasMaxLength(150);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
