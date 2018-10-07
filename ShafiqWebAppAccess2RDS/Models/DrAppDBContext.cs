using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShafiqWebAppAccess2RDS.Models
{
    public partial class DrAppDBContext : DbContext
    {
        public DrAppDBContext()
        {
        }

        public DrAppDBContext(DbContextOptions<DrAppDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Appointments> Appointments { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Users> Users { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=drappserver.database.windows.net,1433; database=DrAppDB; User ID=shafiq; Password=Password1;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointments>(entity =>
            {
                entity.HasKey(e => e.IdAppointment);

                entity.HasIndex(e => e.IdUser)
                    .HasName("IX_FK_UserAppointment");

                entity.Property(e => e.IdAppointment).HasColumnName("Id_Appointment");

                entity.Property(e => e.AppointmentTime).IsRequired();

                entity.Property(e => e.Clinic).IsRequired();

                entity.Property(e => e.CreationTime).IsRequired();

                entity.Property(e => e.Doctor).IsRequired();

                entity.Property(e => e.DrAvailable).HasMaxLength(1);

                entity.Property(e => e.IdDoc).HasColumnName("Id_Doc");

                entity.Property(e => e.IdUser).HasColumnName("Id_User");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAppointment");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseCode);

                entity.Property(e => e.CourseCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CourseTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.School)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.HasKey(e => e.IdDoc);

                entity.ToTable("doctors");

                entity.Property(e => e.IdDoc).HasColumnName("id_doc");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(30);

                entity.Property(e => e.IdUser).HasColumnName("Id_User");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(15);

                entity.Property(e => e.Specialty)
                    .HasColumnName("specialty")
                    .HasDefaultValueSql("('Physician')");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__doctors__Id_User__5812160E");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseCode });

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CourseCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.CourseCodeNavigation)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.CourseCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enrollment_Course");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enrollment_Student");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LoginName);

                entity.Property(e => e.LoginName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.LoginNameNavigation)
                    .WithOne(p => p.Login)
                    .HasForeignKey<Login>(d => d.LoginName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Login_Student");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Program)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.IdUser).HasColumnName("Id_User");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.LoginName)
                    .IsRequired()
                    .HasColumnName("loginName");

                entity.Property(e => e.NameOfUser).HasColumnName("nameOfUser");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone");

                entity.Property(e => e.Pw)
                    .IsRequired()
                    .HasColumnName("pw");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('1')");
            });
        }
    }
}
