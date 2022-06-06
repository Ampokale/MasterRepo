using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EntityLayer.Models
{
    public partial class NetFSDContext : DbContext
    {
        public NetFSDContext()
        {
        }

        public NetFSDContext(DbContextOptions<NetFSDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectMember> ProjectMembers { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<StatusTable> StatusTables { get; set; }
        public virtual DbSet<TbTask> TbTasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=LAPTOP-2I0JAS32;database=NetFSD;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectId).HasColumnName("projectId");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("createdBy");

                entity.Property(e => e.ProjectDesc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("projectDesc");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("projectName");

                entity.Property(e => e.Startdate)
                    .HasColumnType("date")
                    .HasColumnName("startdate")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Projects)
                    .HasPrincipalKey(p => p.Email)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Projects__create__45BE5BA9");
            });

            modelBuilder.Entity<ProjectMember>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("projectMembers");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.ProjectId).HasColumnName("projectId");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany()
                    .HasPrincipalKey(p => p.Email)
                    .HasForeignKey(d => d.Email)
                    .HasConstraintName("FK__projectMe__email__4F47C5E3");

                entity.HasOne(d => d.Project)
                    .WithMany()
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__projectMe__proje__4D5F7D71");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__projectMe__UserI__4E53A1AA");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("report");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.PId).HasColumnName("pId");

                entity.Property(e => e.ReportedOn)
                    .HasColumnType("date")
                    .HasColumnName("reportedOn")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TaskDetails)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("taskDetails");

                entity.Property(e => e.Taskstatus).HasColumnName("taskstatus");

                entity.Property(e => e.WhatAction)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("whatAction");

                entity.HasOne(d => d.PIdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PId)
                    .HasConstraintName("FK__report__pId__634EBE90");
            });

            modelBuilder.Entity<StatusTable>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__statusTa__36257A18B33680BD");

                entity.ToTable("statusTable");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.SDetail)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("sDetail");
            });

            modelBuilder.Entity<TbTask>(entity =>
            {
                entity.HasKey(e => e.TId)
                    .HasName("PK__tb_Task__DC11576792592C7A");

                entity.ToTable("tb_Task");

                entity.Property(e => e.TId).HasColumnName("tId");

                entity.Property(e => e.AssignedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("assignedBy");

                entity.Property(e => e.AssignedTo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PId).HasColumnName("pId");

                entity.Property(e => e.TaskDetails)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("taskDetails");

                entity.Property(e => e.TaskStatus).HasColumnName("taskStatus");

                entity.HasOne(d => d.PIdNavigation)
                    .WithMany(p => p.TbTasks)
                    .HasForeignKey(d => d.PId)
                    .HasConstraintName("FK__tb_Task__pId__531856C7");

                entity.HasOne(d => d.TaskStatusNavigation)
                    .WithMany(p => p.TbTasks)
                    .HasForeignKey(d => d.TaskStatus)
                    .HasConstraintName("FK__tb_Task__taskSta__540C7B00");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__A9D10534A77A9C9F")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Roles)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Member')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
