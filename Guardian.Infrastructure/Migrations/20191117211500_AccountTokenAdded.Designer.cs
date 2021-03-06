// <auto-generated />
using System;
using Guardian.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Guardian.Infrastructure.Migrations
{
    [DbContext(typeof(GuardianDataContext))]
    [Migration("20191117211500_AccountTokenAdded")]
    partial class AccountTokenAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Guardian.Infrastructure.Entity.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("FullName")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("Salt")
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .HasColumnType("character varying(75)")
                        .HasMaxLength(75);

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Guardian.Infrastructure.Entity.FirewallRule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<int>("Action")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Expression")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("RuleFor")
                        .HasColumnType("integer");

                    b.Property<Guid>("TargetId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("TargetId");

                    b.ToTable("FirewallRules");
                });

            modelBuilder.Entity("Guardian.Infrastructure.Entity.HTTPLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("HttpElapsed")
                        .HasColumnType("bigint");

                    b.Property<long>("RequestRulesCheckElapsed")
                        .HasColumnType("bigint");

                    b.Property<long>("RequestSize")
                        .HasColumnType("bigint");

                    b.Property<string>("RequestUri")
                        .HasColumnType("text");

                    b.Property<long>("ResponseRulesCheckElapsed")
                        .HasColumnType("bigint");

                    b.Property<long>("ResponseSize")
                        .HasColumnType("bigint");

                    b.Property<int>("StatusCode")
                        .HasColumnType("integer");

                    b.Property<Guid>("TargetId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TargetId");

                    b.ToTable("HTTPLogs");
                });

            modelBuilder.Entity("Guardian.Infrastructure.Entity.RuleLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("ExecutionMillisecond")
                        .HasColumnType("integer");

                    b.Property<Guid?>("FirewallRuleId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsHitted")
                        .HasColumnType("boolean");

                    b.Property<int>("LogType")
                        .HasColumnType("integer");

                    b.Property<string>("RequestUri")
                        .HasColumnType("text");

                    b.Property<int>("RuleFor")
                        .HasColumnType("integer");

                    b.Property<Guid>("TargetId")
                        .HasColumnType("uuid");

                    b.Property<int>("WafAction")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FirewallRuleId");

                    b.HasIndex("TargetId");

                    b.ToTable("RuleLogs");
                });

            modelBuilder.Entity("Guardian.Infrastructure.Entity.Target", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<bool>("AutoCert")
                        .HasColumnType("boolean");

                    b.Property<string>("CertCrt")
                        .HasColumnType("text");

                    b.Property<string>("CertKey")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Domain")
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.Property<string>("OriginIpAddress")
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.Property<int>("Proto")
                        .HasColumnType("integer");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<bool>("UseHttps")
                        .HasColumnType("boolean");

                    b.Property<bool>("WAFEnabled")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("Domain", "State");

                    b.ToTable("Targets");
                });

            modelBuilder.Entity("Guardian.Infrastructure.Entity.ThrottleLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IPAddress")
                        .HasColumnType("text");

                    b.Property<int>("ThrottleType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ThrottleLogs");
                });

            modelBuilder.Entity("Guardian.Infrastructure.Entity.FirewallRule", b =>
                {
                    b.HasOne("Guardian.Infrastructure.Entity.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Guardian.Infrastructure.Entity.Target", "Target")
                        .WithMany("FirewallRules")
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Guardian.Infrastructure.Entity.HTTPLog", b =>
                {
                    b.HasOne("Guardian.Infrastructure.Entity.Target", "Target")
                        .WithMany()
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Guardian.Infrastructure.Entity.RuleLog", b =>
                {
                    b.HasOne("Guardian.Infrastructure.Entity.FirewallRule", "FirewallRule")
                        .WithMany("RuleLogs")
                        .HasForeignKey("FirewallRuleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Guardian.Infrastructure.Entity.Target", "Target")
                        .WithMany()
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Guardian.Infrastructure.Entity.Target", b =>
                {
                    b.HasOne("Guardian.Infrastructure.Entity.Account", "Account")
                        .WithMany("Targets")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
