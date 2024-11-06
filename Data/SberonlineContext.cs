using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SberBanOnline.Models;

namespace SberBanOnline.Data;

public partial class SberonlineContext : DbContext
{
    public SberonlineContext()
    {
    }

    public SberonlineContext(DbContextOptions<SberonlineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<CardType> CardTypes { get; set; }

    public virtual DbSet<ExchangeRate> ExchangeRates { get; set; }

    public virtual DbSet<HomeAdress> HomeAdresses { get; set; }

    public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }

    public virtual DbSet<TransactionType> TransactionTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("C");

        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("card_pkey");

            entity.ToTable("card");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Balance).HasColumnName("balance");
            entity.Property(e => e.CardTypeId).HasColumnName("card_type_id");
            entity.Property(e => e.Cvv).HasColumnName("cvv");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .HasColumnName("number");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.CardType).WithMany(p => p.Cards)
                .HasForeignKey(d => d.CardTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("card_card_type_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Cards)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("card_user_id_fkey");
        });

        modelBuilder.Entity<CardType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("card_type_pkey");

            entity.ToTable("card_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ExchangeRate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("exchange_rate_pkey");

            entity.ToTable("exchange_rate");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<HomeAdress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("home_adress_pkey");

            entity.ToTable("home_adress");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adress)
                .HasMaxLength(100)
                .HasColumnName("adress");
            entity.Property(e => e.Apartment).HasColumnName("apartment");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.Home)
                .HasMaxLength(50)
                .HasColumnName("home");
        });

        modelBuilder.Entity<TransactionHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("transaction_history_pkey");

            entity.ToTable("transaction_history");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DatetimeDearture)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datetime_dearture");
            entity.Property(e => e.RecipientCardId).HasColumnName("recipient_card_id");
            entity.Property(e => e.SendCardId).HasColumnName("send_card_id");
            entity.Property(e => e.SunOfMoney).HasColumnName("sun_of_money");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

            entity.HasOne(d => d.RecipientCard).WithMany(p => p.TransactionHistoryRecipientCards)
                .HasForeignKey(d => d.RecipientCardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transaction_history_recipient_card_id_fkey");

            entity.HasOne(d => d.SendCard).WithMany(p => p.TransactionHistorySendCards)
                .HasForeignKey(d => d.SendCardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transaction_history_send_card_id_fkey");

            entity.HasOne(d => d.Transaction).WithMany(p => p.TransactionHistories)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transaction_history_transaction_id_fkey");
        });

        modelBuilder.Entity<TransactionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("transaction_type_pkey");

            entity.ToTable("transaction_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.HomeAdress).HasColumnName("home_adress");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Telephone)
                .HasMaxLength(15)
                .HasColumnName("telephone");

            entity.HasOne(d => d.HomeAdressNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.HomeAdress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_home_adress_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_role_id_fkey");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_role_pkey");

            entity.ToTable("user_role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
