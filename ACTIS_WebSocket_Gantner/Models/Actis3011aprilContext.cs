using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class Actis3011aprilContext : DbContext
{
    public Actis3011aprilContext()
    {
    }

    public Actis3011aprilContext(DbContextOptions<Actis3011aprilContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplMenuItem> ApplMenuItems { get; set; }

    public virtual DbSet<ApplUser> ApplUsers { get; set; }

    public virtual DbSet<ApplUsersDtl> ApplUsersDtls { get; set; }

    public virtual DbSet<ApplUsersLog> ApplUsersLogs { get; set; }

    public virtual DbSet<ApplUsersType> ApplUsersTypes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientDataLibrary> ClientDataLibraries { get; set; }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<ClubsCoach> ClubsCoaches { get; set; }

    public virtual DbSet<ClubsDiscountType> ClubsDiscountTypes { get; set; }

    public virtual DbSet<ClubsGroup> ClubsGroups { get; set; }

    public virtual DbSet<ClubsMember> ClubsMembers { get; set; }

    public virtual DbSet<ClubsMembersHist> ClubsMembersHists { get; set; }

    public virtual DbSet<ClubsXClubsCoach> ClubsXClubsCoaches { get; set; }

    public virtual DbSet<DailyInterval> DailyIntervals { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventsAdditionalDatum> EventsAdditionalData { get; set; }

    public virtual DbSet<EventsView> EventsViews { get; set; }

    public virtual DbSet<Gate> Gates { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Metadata> Metadata { get; set; }

    public virtual DbSet<Pass> Passes { get; set; }

    public virtual DbSet<PassesArch> PassesArches { get; set; }

    public virtual DbSet<PassesArchView> PassesArchViews { get; set; }

    public virtual DbSet<PassesView> PassesViews { get; set; }

    public virtual DbSet<Po> Pos { get; set; }

    public virtual DbSet<PosDailyReport> PosDailyReports { get; set; }

    public virtual DbSet<PosDailyReportsArch> PosDailyReportsArches { get; set; }

    public virtual DbSet<PosDailyReportsArchXPosTransactionArch> PosDailyReportsArchXPosTransactionArches { get; set; }

    public virtual DbSet<PosDailyReportsXPosTransaction> PosDailyReportsXPosTransactions { get; set; }

    public virtual DbSet<PosTransaction> PosTransactions { get; set; }

    public virtual DbSet<PosTransactionArch> PosTransactionArches { get; set; }

    public virtual DbSet<PosTransactionLine> PosTransactionLines { get; set; }

    public virtual DbSet<PosTransactionLinesArch> PosTransactionLinesArches { get; set; }

    public virtual DbSet<PosTransactionLinesDtl> PosTransactionLinesDtls { get; set; }

    public virtual DbSet<PosTransactionLinesDtlArch> PosTransactionLinesDtlArches { get; set; }

    public virtual DbSet<PosTransactionPaymentMthd> PosTransactionPaymentMthds { get; set; }

    public virtual DbSet<PosTransactionPaymentMthdArch> PosTransactionPaymentMthdArches { get; set; }

    public virtual DbSet<PrintingTasksDtl> PrintingTasksDtls { get; set; }

    public virtual DbSet<PrintingTasksDtlHist> PrintingTasksDtlHists { get; set; }

    public virtual DbSet<PrintingTasksHdr> PrintingTasksHdrs { get; set; }

    public virtual DbSet<PrintingTasksList> PrintingTasksLists { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<ResourcesBooking> ResourcesBookings { get; set; }

    public virtual DbSet<ResourcesBookingXTicket> ResourcesBookingXTickets { get; set; }

    public virtual DbSet<ResourcesType> ResourcesTypes { get; set; }

    public virtual DbSet<ResourcesTypesXDailyInterval> ResourcesTypesXDailyIntervals { get; set; }

    public virtual DbSet<TagsEvidention> TagsEvidentions { get; set; }

    public virtual DbSet<TagsEvidentionTransaction> TagsEvidentionTransactions { get; set; }

    public virtual DbSet<TagsEvidentionXTagsEvidentionTransaction> TagsEvidentionXTagsEvidentionTransactions { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketType> TicketTypes { get; set; }

    public virtual DbSet<TicketTypesCustomisedValue> TicketTypesCustomisedValues { get; set; }

    public virtual DbSet<TicketTypesInterface> TicketTypesInterfaces { get; set; }

    public virtual DbSet<TicketTypesXEvent> TicketTypesXEvents { get; set; }

    public virtual DbSet<TicketsArch> TicketsArches { get; set; }

    public virtual DbSet<TicketsArchView> TicketsArchViews { get; set; }

    public virtual DbSet<TicketsHist> TicketsHists { get; set; }

    public virtual DbSet<TicketsHistArch> TicketsHistArches { get; set; }

    public virtual DbSet<TicketsView> TicketsViews { get; set; }

    public virtual DbSet<ValidationTerminal> ValidationTerminals { get; set; }

    public virtual DbSet<ValidationTerminalsSetting> ValidationTerminalsSettings { get; set; }

    public virtual DbSet<WeekSchedule> WeekSchedules { get; set; }

    public virtual DbSet<WeekSchedulesXGate> WeekSchedulesXGates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=VIKTORCPSECURIT\\SQLEXPRESS;Database=ACTIS30_11April;User Id=actismgr;Password=actismgr2005;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("actismgr")
            .UseCollation("SQL_Latin1_General_CP1_CS_AS");

        modelBuilder.Entity<ApplMenuItem>(entity =>
        {
            entity.ToTable("appl_menu_items");

            entity.Property(e => e.ApplMenuItemId)
                .HasMaxLength(200)
                .HasColumnName("appl_menu_item_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Position)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("position");
            entity.Property(e => e.PrivilegeLvl)
                .HasDefaultValue(50)
                .HasColumnName("privilege_lvl");
        });

        modelBuilder.Entity<ApplUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("appl_users");

            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_id");
            entity.Property(e => e.ApplUsersTypeId).HasColumnName("appl_users_type_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PrivilegeLvl).HasColumnName("privilege_lvl");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("ACTIVE")
                .HasColumnName("status");
        });

        modelBuilder.Entity<ApplUsersDtl>(entity =>
        {
            entity.HasKey(e => e.RecId);

            entity.ToTable("appl_users_dtl");

            entity.Property(e => e.RecId).HasColumnName("rec_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Purpose)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("purpose");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_id");
            entity.Property(e => e.Value)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("value");

            entity.HasOne(d => d.User).WithMany(p => p.ApplUsersDtls)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_appl_users_dtl_appl_users");
        });

        modelBuilder.Entity<ApplUsersLog>(entity =>
        {
            entity.HasKey(e => e.LoginId);

            entity.ToTable("appl_users_log");

            entity.Property(e => e.LoginId).HasColumnName("login_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Host)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("host");
            entity.Property(e => e.LoginTime)
                .HasColumnType("datetime")
                .HasColumnName("login_time");
            entity.Property(e => e.LogoutTime)
                .HasColumnType("datetime")
                .HasColumnName("logout_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<ApplUsersType>(entity =>
        {
            entity.ToTable("appl_users_types");

            entity.Property(e => e.ApplUsersTypeId)
                .ValueGeneratedNever()
                .HasColumnName("appl_users_type_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("clients");

            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Data1)
                .HasMaxLength(128)
                .HasColumnName("data_1");
            entity.Property(e => e.Data10)
                .HasMaxLength(128)
                .HasColumnName("data_10");
            entity.Property(e => e.Data2)
                .HasMaxLength(128)
                .HasColumnName("data_2");
            entity.Property(e => e.Data3)
                .HasMaxLength(128)
                .HasColumnName("data_3");
            entity.Property(e => e.Data4)
                .HasMaxLength(128)
                .HasColumnName("data_4");
            entity.Property(e => e.Data5)
                .HasMaxLength(128)
                .HasColumnName("data_5");
            entity.Property(e => e.Data6)
                .HasMaxLength(128)
                .HasColumnName("data_6");
            entity.Property(e => e.Data7)
                .HasMaxLength(128)
                .HasColumnName("data_7");
            entity.Property(e => e.Data8)
                .HasMaxLength(128)
                .HasColumnName("data_8");
            entity.Property(e => e.Data9)
                .HasMaxLength(128)
                .HasColumnName("data_9");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<ClientDataLibrary>(entity =>
        {
            entity.HasKey(e => e.RecId);

            entity.ToTable("client_data_libraries");

            entity.HasIndex(e => new { e.Data, e.Type }, "UNIQ_client_data_libraries").IsUnique();

            entity.Property(e => e.RecId).HasColumnName("rec_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Data)
                .HasMaxLength(128)
                .HasColumnName("data");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Club>(entity =>
        {
            entity.ToTable("clubs");

            entity.Property(e => e.ClubId).HasColumnName("club_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ClubsCoach>(entity =>
        {
            entity.HasKey(e => e.CoachId);

            entity.ToTable("clubs_coaches");

            entity.HasIndex(e => e.Name, "UNIQ_clubs_coaches_name").IsUnique();

            entity.Property(e => e.CoachId).HasColumnName("coach_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ClubsDiscountType>(entity =>
        {
            entity.HasKey(e => new { e.ClubId, e.DiscountTypeId });

            entity.ToTable("clubs_discount_types");

            entity.Property(e => e.ClubId).HasColumnName("club_id");
            entity.Property(e => e.DiscountTypeId).HasColumnName("discount_type_id");
            entity.Property(e => e.Amount)
                .HasDefaultValueSql("('0.00')")
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");

            entity.HasOne(d => d.Club).WithMany(p => p.ClubsDiscountTypes)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_clubs_discount_types_clubs");
        });

        modelBuilder.Entity<ClubsGroup>(entity =>
        {
            entity.HasKey(e => new { e.ClubId, e.GroupId });

            entity.ToTable("clubs_groups");

            entity.Property(e => e.ClubId).HasColumnName("club_id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.CoachId).HasColumnName("coach_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.TicketTypeId).HasColumnName("ticket_type_id");
            entity.Property(e => e.ValidationRule)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("validation_rule");

            entity.HasOne(d => d.Club).WithMany(p => p.ClubsGroups)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_clubs_groups_clubs");

            entity.HasOne(d => d.Coach).WithMany(p => p.ClubsGroups)
                .HasForeignKey(d => d.CoachId)
                .HasConstraintName("FK_clubs_groups_clubs_coaches");
        });

        modelBuilder.Entity<ClubsMember>(entity =>
        {
            entity.HasKey(e => e.ClubMemberId);

            entity.ToTable("clubs_members");

            entity.Property(e => e.ClubMemberId).HasColumnName("club_member_id");
            entity.Property(e => e.Adress)
                .HasMaxLength(50)
                .HasColumnName("adress");
            entity.Property(e => e.Citizenship)
                .HasMaxLength(50)
                .HasColumnName("citizenship");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.ClubId).HasColumnName("club_id");
            entity.Property(e => e.CoachId).HasColumnName("coach_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.DiscountTypeId).HasColumnName("discount_type_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.PassportNum)
                .HasMaxLength(50)
                .HasColumnName("passport_num");
            entity.Property(e => e.PersonalNum)
                .HasMaxLength(50)
                .HasColumnName("personal_num");
            entity.Property(e => e.PlaceBirth)
                .HasMaxLength(50)
                .HasColumnName("place_birth");
            entity.Property(e => e.RegNum)
                .HasMaxLength(50)
                .HasColumnName("reg_num");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TelHome)
                .HasMaxLength(50)
                .HasColumnName("tel_home");
            entity.Property(e => e.TelMob)
                .HasMaxLength(50)
                .HasColumnName("tel_mob");
            entity.Property(e => e.TicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ticket_id");

            entity.HasOne(d => d.Club).WithMany(p => p.ClubsMembers)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_clubs_members_clubs");

            entity.HasOne(d => d.Coach).WithMany(p => p.ClubsMembers)
                .HasForeignKey(d => d.CoachId)
                .HasConstraintName("FK_clubs_members_clubs_coaches");

            entity.HasOne(d => d.ClubsDiscountType).WithMany(p => p.ClubsMembers)
                .HasForeignKey(d => new { d.ClubId, d.DiscountTypeId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_clubs_members_clubs_discount_types");

            entity.HasOne(d => d.ClubsGroup).WithMany(p => p.ClubsMembers)
                .HasForeignKey(d => new { d.ClubId, d.GroupId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_clubs_members_clubs_groups");
        });

        modelBuilder.Entity<ClubsMembersHist>(entity =>
        {
            entity.HasKey(e => e.RecD);

            entity.ToTable("clubs_members_hist");

            entity.Property(e => e.RecD).HasColumnName("rec_d");
            entity.Property(e => e.Adress)
                .HasMaxLength(50)
                .HasColumnName("adress");
            entity.Property(e => e.Citizenship)
                .HasMaxLength(50)
                .HasColumnName("citizenship");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.ClubId).HasColumnName("club_id");
            entity.Property(e => e.ClubMemberId).HasColumnName("club_member_id");
            entity.Property(e => e.CoachId).HasColumnName("coach_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.DiscountTypeId).HasColumnName("discount_type_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.PassportNum)
                .HasMaxLength(50)
                .HasColumnName("passport_num");
            entity.Property(e => e.PersonalNum)
                .HasMaxLength(50)
                .HasColumnName("personal_num");
            entity.Property(e => e.PlaceBirth)
                .HasMaxLength(50)
                .HasColumnName("place_birth");
            entity.Property(e => e.RegNum)
                .HasMaxLength(50)
                .HasColumnName("reg_num");
            entity.Property(e => e.Remark)
                .HasMaxLength(50)
                .HasColumnName("remark");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TelHome)
                .HasMaxLength(50)
                .HasColumnName("tel_home");
            entity.Property(e => e.TelMob)
                .HasMaxLength(50)
                .HasColumnName("tel_mob");
            entity.Property(e => e.TicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ticket_id");
        });

        modelBuilder.Entity<ClubsXClubsCoach>(entity =>
        {
            entity.HasKey(e => new { e.CoachId, e.ClubId });

            entity.ToTable("clubs_x_clubs_coaches");

            entity.Property(e => e.CoachId).HasColumnName("coach_id");
            entity.Property(e => e.ClubId).HasColumnName("club_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");

            entity.HasOne(d => d.Club).WithMany(p => p.ClubsXClubsCoaches)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_clubs_x_clubs_coaches_clubs");

            entity.HasOne(d => d.Coach).WithMany(p => p.ClubsXClubsCoaches)
                .HasForeignKey(d => d.CoachId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_clubs_x_clubs_coaches_clubs_coaches");
        });

        modelBuilder.Entity<DailyInterval>(entity =>
        {
            entity.ToTable("daily_intervals");

            entity.Property(e => e.DailyIntervalId).HasColumnName("daily_interval_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("end_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("start_time");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.ToTable("events");

            entity.HasIndex(e => e.Name, "UNIQ_events_name").IsUnique();

            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.DateEnd)
                .HasColumnType("datetime")
                .HasColumnName("date_end");
            entity.Property(e => e.DateStart)
                .HasColumnType("datetime")
                .HasColumnName("date_start");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TicketSaleEnd)
                .HasColumnType("datetime")
                .HasColumnName("ticket_sale_end");
            entity.Property(e => e.TicketSaleStart)
                .HasColumnType("datetime")
                .HasColumnName("ticket_sale_start");
        });

        modelBuilder.Entity<EventsAdditionalDatum>(entity =>
        {
            entity.HasKey(e => e.RecId);

            entity.ToTable("events_additional_data");

            entity.Property(e => e.RecId)
                .ValueGeneratedNever()
                .HasColumnName("rec_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.LogoAdditional1)
                .HasColumnType("image")
                .HasColumnName("logo_additional_1");
            entity.Property(e => e.LogoAdditional2)
                .HasColumnType("image")
                .HasColumnName("logo_additional_2");
            entity.Property(e => e.LogoAdditional3)
                .HasColumnType("image")
                .HasColumnName("logo_additional_3");
            entity.Property(e => e.LogoDisplay1)
                .HasColumnType("image")
                .HasColumnName("logo_display_1");
            entity.Property(e => e.LogoDisplay2)
                .HasColumnType("image")
                .HasColumnName("logo_display_2");
            entity.Property(e => e.LogoDisplay3)
                .HasColumnType("image")
                .HasColumnName("logo_display_3");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.XmlTemplate)
                .HasColumnType("xml")
                .HasColumnName("xml_template");

            entity.HasOne(d => d.Event).WithMany(p => p.EventsAdditionalData)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_events_additional_data_events");
        });

        modelBuilder.Entity<EventsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("events_view");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.DateEnd)
                .HasColumnType("datetime")
                .HasColumnName("date_end");
            entity.Property(e => e.DateStart)
                .HasColumnType("datetime")
                .HasColumnName("date_start");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.EventId)
                .ValueGeneratedOnAdd()
                .HasColumnName("event_id");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TicketSaleEnd)
                .HasColumnType("datetime")
                .HasColumnName("ticket_sale_end");
            entity.Property(e => e.TicketSaleStart)
                .HasColumnType("datetime")
                .HasColumnName("ticket_sale_start");
        });

        modelBuilder.Entity<Gate>(entity =>
        {
            entity.ToTable("gates");

            entity.HasIndex(e => e.Name, "UNIQ_gates_name").IsUnique();

            entity.Property(e => e.GateId).HasColumnName("gate_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.Location).WithMany(p => p.Gates)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_gates_locations");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__locations__1BFD2C07");

            entity.ToTable("locations");

            entity.HasIndex(e => e.Name, "UNIQ_locations_name").IsUnique();

            entity.Property(e => e.LocationId)
                .ValueGeneratedNever()
                .HasColumnName("location_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ParentLocationId).HasColumnName("parent_location_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("ACTIVE")
                .HasColumnName("status");

            entity.HasOne(d => d.ParentLocation).WithMany(p => p.InverseParentLocation)
                .HasForeignKey(d => d.ParentLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_locations_locations");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("log");

            entity.Property(e => e.Arguments)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("arguments");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.EventTime)
                .HasColumnType("datetime")
                .HasColumnName("event_time");
            entity.Property(e => e.Exception)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("exception");
            entity.Property(e => e.Host)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("host");
            entity.Property(e => e.LogId)
                .ValueGeneratedOnAdd()
                .HasColumnName("log_id");
            entity.Property(e => e.MethodName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("method_name");
            entity.Property(e => e.Result).HasColumnName("result");
        });

        modelBuilder.Entity<Metadata>(entity =>
        {
            entity.HasKey(e => e.Attribute);

            entity.ToTable("metadata");

            entity.Property(e => e.Attribute)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("attribute");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.Value)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("value");
        });

        modelBuilder.Entity<Pass>(entity =>
        {
            entity.HasKey(e => new { e.PassId, e.TicketId, e.OrdNum });

            entity.ToTable("passes");

            entity.Property(e => e.PassId)
                .ValueGeneratedOnAdd()
                .HasColumnName("pass_id");
            entity.Property(e => e.TicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ticket_id");
            entity.Property(e => e.OrdNum)
                .HasDefaultValue(1)
                .HasColumnName("ord_num");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Direction)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("direction");
            entity.Property(e => e.EventTime)
                .HasColumnType("datetime")
                .HasColumnName("event_time");
            entity.Property(e => e.GateId).HasColumnName("gate_id");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.ValidationTerminalId).HasColumnName("validation_terminal_id");

            entity.HasOne(d => d.Gate).WithMany(p => p.Passes)
                .HasForeignKey(d => d.GateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_passes_gates");

            entity.HasOne(d => d.Location).WithMany(p => p.Passes)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_passes_locations");

            entity.HasOne(d => d.ValidationTerminal).WithMany(p => p.Passes)
                .HasForeignKey(d => d.ValidationTerminalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_passes_validation_terminals");

            entity.HasOne(d => d.Ticket).WithMany(p => p.Passes)
                .HasForeignKey(d => new { d.TicketId, d.OrdNum })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_passes_tickets");
        });

        modelBuilder.Entity<PassesArch>(entity =>
        {
            entity.HasKey(e => new { e.PassId, e.TicketId, e.OrdNum });

            entity.ToTable("passes_arch");

            entity.Property(e => e.PassId).HasColumnName("pass_id");
            entity.Property(e => e.TicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ticket_id");
            entity.Property(e => e.OrdNum).HasColumnName("ord_num");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Direction)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("direction");
            entity.Property(e => e.EventTime)
                .HasColumnType("datetime")
                .HasColumnName("event_time");
            entity.Property(e => e.GateId).HasColumnName("gate_id");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.ValidationTerminalId).HasColumnName("validation_terminal_id");
        });

        modelBuilder.Entity<PassesArchView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("passes_arch_view");

            entity.Property(e => e.ApplUserName)
                .HasMaxLength(50)
                .HasColumnName("appl_user_name");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.ClientName)
                .HasMaxLength(128)
                .HasColumnName("client_name");
            entity.Property(e => e.Direction)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("direction");
            entity.Property(e => e.EventTime)
                .HasColumnType("datetime")
                .HasColumnName("event_time");
            entity.Property(e => e.Expr1).HasColumnName("EXPR1");
            entity.Property(e => e.Expr2)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("EXPR2");
            entity.Property(e => e.Expr3).HasColumnName("EXPR3");
            entity.Property(e => e.GateId).HasColumnName("gate_id");
            entity.Property(e => e.GateName)
                .HasMaxLength(50)
                .HasColumnName("gate_name");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.LocationName)
                .HasMaxLength(50)
                .HasColumnName("location_name");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .HasColumnName("name");
            entity.Property(e => e.OrdNum).HasColumnName("ord_num");
            entity.Property(e => e.PassId).HasColumnName("pass_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ticket_id");
            entity.Property(e => e.TicketTypeId).HasColumnName("ticket_type_id");
            entity.Property(e => e.TicketTypesName)
                .HasMaxLength(64)
                .HasColumnName("ticket_types_name");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_id");
            entity.Property(e => e.ValidationTerminalId).HasColumnName("validation_terminal_id");
        });

        modelBuilder.Entity<PassesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("passes_view");

            entity.Property(e => e.ApplUserName)
                .HasMaxLength(50)
                .HasColumnName("appl_user_name");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.ClientName)
                .HasMaxLength(128)
                .HasColumnName("client_name");
            entity.Property(e => e.Direction)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("direction");
            entity.Property(e => e.EventTime)
                .HasColumnType("datetime")
                .HasColumnName("event_time");
            entity.Property(e => e.Expr1).HasColumnName("EXPR1");
            entity.Property(e => e.Expr2)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("EXPR2");
            entity.Property(e => e.Expr3).HasColumnName("EXPR3");
            entity.Property(e => e.GateId).HasColumnName("gate_id");
            entity.Property(e => e.GateName)
                .HasMaxLength(50)
                .HasColumnName("gate_name");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.LocationName)
                .HasMaxLength(50)
                .HasColumnName("location_name");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .HasColumnName("name");
            entity.Property(e => e.OrdNum).HasColumnName("ord_num");
            entity.Property(e => e.PassId).HasColumnName("pass_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ticket_id");
            entity.Property(e => e.TicketTypeId).HasColumnName("ticket_type_id");
            entity.Property(e => e.TicketTypesName)
                .HasMaxLength(64)
                .HasColumnName("ticket_types_name");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_id");
            entity.Property(e => e.ValidationTerminalId).HasColumnName("validation_terminal_id");
        });

        modelBuilder.Entity<Po>(entity =>
        {
            entity.HasKey(e => e.PosId);

            entity.ToTable("pos");

            entity.HasIndex(e => e.Name, "UNIQ_pos_name").IsUnique();

            entity.HasIndex(e => e.TagId, "UNIQ_pos_tag_id").IsUnique();

            entity.Property(e => e.PosId)
                .ValueGeneratedNever()
                .HasColumnName("pos_id");
            entity.Property(e => e.ComMonitor).HasColumnName("com_monitor");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.TagId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("((1))")
                .HasColumnName("tag_id");
        });

        modelBuilder.Entity<PosDailyReport>(entity =>
        {
            entity.HasKey(e => e.ReportId);

            entity.ToTable("pos_daily_reports");

            entity.Property(e => e.ReportId).HasColumnName("report_id");
            entity.Property(e => e.Content)
                .HasColumnType("ntext")
                .HasColumnName("content");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Pos).WithMany(p => p.PosDailyReports)
                .HasForeignKey(d => d.PosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ppos_daily_reports_pos");

            entity.HasOne(d => d.User).WithMany(p => p.PosDailyReports)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pos_daily_reports_appl_users");
        });

        modelBuilder.Entity<PosDailyReportsArch>(entity =>
        {
            entity.HasKey(e => e.ReportId);

            entity.ToTable("pos_daily_reports_arch");

            entity.Property(e => e.ReportId)
                .ValueGeneratedNever()
                .HasColumnName("report_id");
            entity.Property(e => e.Content)
                .HasColumnType("ntext")
                .HasColumnName("content");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Pos).WithMany(p => p.PosDailyReportsArches)
                .HasForeignKey(d => d.PosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pos_daily_reports_arch_pos");

            entity.HasOne(d => d.User).WithMany(p => p.PosDailyReportsArches)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pos_daily_reports_arch_appl_users");
        });

        modelBuilder.Entity<PosDailyReportsArchXPosTransactionArch>(entity =>
        {
            entity.HasKey(e => new { e.ReportId, e.TransactionId });

            entity.ToTable("pos_daily_reports_arch_x_pos_transaction_arch");

            entity.Property(e => e.ReportId).HasColumnName("report_id");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");

            entity.HasOne(d => d.Report).WithMany(p => p.PosDailyReportsArchXPosTransactionArches)
                .HasForeignKey(d => d.ReportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pos_daily_reports_arch_x_pos_transaction_arch_pos_daily_reports_arch");

            entity.HasOne(d => d.Transaction).WithMany(p => p.PosDailyReportsArchXPosTransactionArches)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pos_daily_reports_arch_x_pos_transaction_arch_pos_transaction_arch");
        });

        modelBuilder.Entity<PosDailyReportsXPosTransaction>(entity =>
        {
            entity.HasKey(e => new { e.ReportId, e.TransactionId });

            entity.ToTable("pos_daily_reports_x_pos_transaction");

            entity.Property(e => e.ReportId).HasColumnName("report_id");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");

            entity.HasOne(d => d.Report).WithMany(p => p.PosDailyReportsXPosTransactions)
                .HasForeignKey(d => d.ReportId)
                .HasConstraintName("FK_pos_daily_reports_x_pos_transaction_pos_daily_reports");

            entity.HasOne(d => d.Transaction).WithMany(p => p.PosDailyReportsXPosTransactions)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pos_daily_reports_x_pos_transaction_pos_transaction");
        });

        modelBuilder.Entity<PosTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId);

            entity.ToTable("pos_transaction");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.AmountReceived)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount_received");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Pos).WithMany(p => p.PosTransactions)
                .HasForeignKey(d => d.PosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pos_transaction_pos");

            entity.HasOne(d => d.User).WithMany(p => p.PosTransactions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pos_transaction_appl_users");
        });

        modelBuilder.Entity<PosTransactionArch>(entity =>
        {
            entity.HasKey(e => e.TransactionId);

            entity.ToTable("pos_transaction_arch");

            entity.Property(e => e.TransactionId)
                .ValueGeneratedNever()
                .HasColumnName("transaction_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.AmountReceived)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount_received");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Pos).WithMany(p => p.PosTransactionArches)
                .HasForeignKey(d => d.PosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pos_transaction_arch_pos");

            entity.HasOne(d => d.User).WithMany(p => p.PosTransactionArches)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pos_transaction_arch_appl_users");
        });

        modelBuilder.Entity<PosTransactionLine>(entity =>
        {
            entity.HasKey(e => new { e.TransactionId, e.LineNum });

            entity.ToTable("pos_transaction_lines");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.LineNum).HasColumnName("line_num");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.PeopleNum).HasColumnName("people_num");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.TicketTypeId).HasColumnName("ticket_type_id");

            entity.HasOne(d => d.TicketType).WithMany(p => p.PosTransactionLines)
                .HasForeignKey(d => d.TicketTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pos_transaction_lines_ticket_types");

            entity.HasOne(d => d.Transaction).WithMany(p => p.PosTransactionLines)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("FK_pos_transaction_lines_pos_transaction");
        });

        modelBuilder.Entity<PosTransactionLinesArch>(entity =>
        {
            entity.HasKey(e => new { e.TransactionId, e.LineNum });

            entity.ToTable("pos_transaction_lines_arch");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.LineNum).HasColumnName("line_num");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.PeopleNum).HasColumnName("people_num");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.TicketTypeId).HasColumnName("ticket_type_id");

            entity.HasOne(d => d.TicketType).WithMany(p => p.PosTransactionLinesArches)
                .HasForeignKey(d => d.TicketTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pos_transaction_lines_arch_ticket_types");

            entity.HasOne(d => d.Transaction).WithMany(p => p.PosTransactionLinesArches)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pos_transaction_lines_arch_pos_transaction_arch");
        });

        modelBuilder.Entity<PosTransactionLinesDtl>(entity =>
        {
            entity.HasKey(e => new { e.TransactionId, e.LineNum, e.TicketId, e.OrdNum });

            entity.ToTable("pos_transaction_lines_dtl");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.LineNum).HasColumnName("line_num");
            entity.Property(e => e.TicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ticket_id");
            entity.Property(e => e.OrdNum).HasColumnName("ord_num");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.PrintOrd)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("print_ord");

            entity.HasOne(d => d.PosTransactionLine).WithMany(p => p.PosTransactionLinesDtls)
                .HasForeignKey(d => new { d.TransactionId, d.LineNum })
                .HasConstraintName("FK_pos_transaction_lines_dtl_pos_transaction_lines");
        });

        modelBuilder.Entity<PosTransactionLinesDtlArch>(entity =>
        {
            entity.HasKey(e => new { e.TransactionId, e.LineNum, e.TicketId, e.OrdNum });

            entity.ToTable("pos_transaction_lines_dtl_arch");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.LineNum).HasColumnName("line_num");
            entity.Property(e => e.TicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ticket_id");
            entity.Property(e => e.OrdNum).HasColumnName("ord_num");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.PrintOrd)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("print_ord");

            entity.HasOne(d => d.PosTransactionLinesArch).WithMany(p => p.PosTransactionLinesDtlArches)
                .HasForeignKey(d => new { d.TransactionId, d.LineNum })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pos_transaction_lines_dtl_arch_pos_transaction_lines_arch");
        });

        modelBuilder.Entity<PosTransactionPaymentMthd>(entity =>
        {
            entity.HasKey(e => e.TransactionId);

            entity.ToTable("pos_transaction_payment_mthd");

            entity.Property(e => e.TransactionId)
                .ValueGeneratedNever()
                .HasColumnName("transaction_id");
            entity.Property(e => e.AmountMthd1)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount_mthd_1");
            entity.Property(e => e.AmountMthd2)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount_mthd_2");
            entity.Property(e => e.AmountMthd3)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount_mthd_3");
            entity.Property(e => e.AmountMthd4)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount_mthd_4");
            entity.Property(e => e.AmountMthd5)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount_mthd_5");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");

            entity.HasOne(d => d.Transaction).WithOne(p => p.PosTransactionPaymentMthd)
                .HasForeignKey<PosTransactionPaymentMthd>(d => d.TransactionId)
                .HasConstraintName("FK_pos_transaction_payment_mthd_pos_transaction");
        });

        modelBuilder.Entity<PosTransactionPaymentMthdArch>(entity =>
        {
            entity.HasKey(e => e.TransactionId);

            entity.ToTable("pos_transaction_payment_mthd_arch");

            entity.Property(e => e.TransactionId)
                .ValueGeneratedNever()
                .HasColumnName("transaction_id");
            entity.Property(e => e.AmountMthd1)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount_mthd_1");
            entity.Property(e => e.AmountMthd2)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount_mthd_2");
            entity.Property(e => e.AmountMthd3)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount_mthd_3");
            entity.Property(e => e.AmountMthd4)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount_mthd_4");
            entity.Property(e => e.AmountMthd5)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("amount_mthd_5");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
        });

        modelBuilder.Entity<PrintingTasksDtl>(entity =>
        {
            entity.HasKey(e => e.RecId);

            entity.ToTable("printing_tasks_dtl");

            entity.Property(e => e.RecId).HasColumnName("rec_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Data1)
                .HasMaxLength(100)
                .HasColumnName("data_1");
            entity.Property(e => e.Data10)
                .HasMaxLength(100)
                .HasColumnName("data_10");
            entity.Property(e => e.Data2)
                .HasMaxLength(100)
                .HasColumnName("data_2");
            entity.Property(e => e.Data3)
                .HasMaxLength(100)
                .HasColumnName("data_3");
            entity.Property(e => e.Data4)
                .HasMaxLength(100)
                .HasColumnName("data_4");
            entity.Property(e => e.Data5)
                .HasMaxLength(100)
                .HasColumnName("data_5");
            entity.Property(e => e.Data6)
                .HasMaxLength(100)
                .HasColumnName("data_6");
            entity.Property(e => e.Data7)
                .HasMaxLength(100)
                .HasColumnName("data_7");
            entity.Property(e => e.Data8)
                .HasMaxLength(100)
                .HasColumnName("data_8");
            entity.Property(e => e.Data9)
                .HasMaxLength(100)
                .HasColumnName("data_9");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.PrintingTaskId).HasColumnName("printing_task_id");
            entity.Property(e => e.PrintingTime)
                .HasColumnType("datetime")
                .HasColumnName("printing_time");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Symbol)
                .HasColumnType("image")
                .HasColumnName("symbol");
            entity.Property(e => e.TicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ticket_id");
            entity.Property(e => e.TicketTypeId).HasColumnName("ticket_type_id");
        });

        modelBuilder.Entity<PrintingTasksDtlHist>(entity =>
        {
            entity.HasKey(e => e.RecId);

            entity.ToTable("printing_tasks_dtl_hist");

            entity.Property(e => e.RecId)
                .ValueGeneratedNever()
                .HasColumnName("rec_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Data1)
                .HasMaxLength(100)
                .HasColumnName("data_1");
            entity.Property(e => e.Data10)
                .HasMaxLength(100)
                .HasColumnName("data_10");
            entity.Property(e => e.Data2)
                .HasMaxLength(100)
                .HasColumnName("data_2");
            entity.Property(e => e.Data3)
                .HasMaxLength(100)
                .HasColumnName("data_3");
            entity.Property(e => e.Data4)
                .HasMaxLength(100)
                .HasColumnName("data_4");
            entity.Property(e => e.Data5)
                .HasMaxLength(100)
                .HasColumnName("data_5");
            entity.Property(e => e.Data6)
                .HasMaxLength(100)
                .HasColumnName("data_6");
            entity.Property(e => e.Data7)
                .HasMaxLength(100)
                .HasColumnName("data_7");
            entity.Property(e => e.Data8)
                .HasMaxLength(100)
                .HasColumnName("data_8");
            entity.Property(e => e.Data9)
                .HasMaxLength(100)
                .HasColumnName("data_9");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.PrintingTaskId).HasColumnName("printing_task_id");
            entity.Property(e => e.PrintingTime)
                .HasColumnType("datetime")
                .HasColumnName("printing_time");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Symbol)
                .HasColumnType("image")
                .HasColumnName("symbol");
            entity.Property(e => e.TicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ticket_id");
            entity.Property(e => e.TicketTypeId).HasColumnName("ticket_type_id");
        });

        modelBuilder.Entity<PrintingTasksHdr>(entity =>
        {
            entity.HasKey(e => e.PrintingTaskId);

            entity.ToTable("printing_tasks_hdr");

            entity.HasIndex(e => e.Description, "UNIQ_printing_tasks_hdr").IsUnique();

            entity.Property(e => e.PrintingTaskId).HasColumnName("printing_task_id");
            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("approved_by");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Remark)
                .HasMaxLength(128)
                .HasColumnName("remark");
        });

        modelBuilder.Entity<PrintingTasksList>(entity =>
        {
            entity.HasKey(e => e.RecId);

            entity.ToTable("printing_tasks_list");

            entity.Property(e => e.RecId)
                .ValueGeneratedNever()
                .HasColumnName("rec_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Data1)
                .HasMaxLength(100)
                .HasColumnName("data_1");
            entity.Property(e => e.Data10)
                .HasMaxLength(100)
                .HasColumnName("data_10");
            entity.Property(e => e.Data2)
                .HasMaxLength(100)
                .HasColumnName("data_2");
            entity.Property(e => e.Data3)
                .HasMaxLength(100)
                .HasColumnName("data_3");
            entity.Property(e => e.Data4)
                .HasMaxLength(100)
                .HasColumnName("data_4");
            entity.Property(e => e.Data5)
                .HasMaxLength(100)
                .HasColumnName("data_5");
            entity.Property(e => e.Data6)
                .HasMaxLength(100)
                .HasColumnName("data_6");
            entity.Property(e => e.Data7)
                .HasMaxLength(100)
                .HasColumnName("data_7");
            entity.Property(e => e.Data8)
                .HasMaxLength(100)
                .HasColumnName("data_8");
            entity.Property(e => e.Data9)
                .HasMaxLength(100)
                .HasColumnName("data_9");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.PrintingTaskId).HasColumnName("printing_task_id");
            entity.Property(e => e.PrintingTime)
                .HasColumnType("datetime")
                .HasColumnName("printing_time");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Symbol)
                .HasColumnType("image")
                .HasColumnName("symbol");
            entity.Property(e => e.TicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ticket_id");
            entity.Property(e => e.TicketTypeId).HasColumnName("ticket_type_id");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => new { e.ResourceTypeId, e.ResourceId });

            entity.ToTable("resources");

            entity.HasIndex(e => e.Name, "UNIQ_resources_name").IsUnique();

            entity.Property(e => e.ResourceTypeId).HasColumnName("resource_type_id");
            entity.Property(e => e.ResourceId).HasColumnName("resource_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.ResourceType).WithMany(p => p.Resources)
                .HasForeignKey(d => d.ResourceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_resources_resources_types");
        });

        modelBuilder.Entity<ResourcesBooking>(entity =>
        {
            entity.HasKey(e => e.RecId);

            entity.ToTable("resources_booking");

            entity.HasIndex(e => new { e.ResourceTypeId, e.ResourceId, e.Date, e.DailyIntervalId }, "UNIQ_resources_booking").IsUnique();

            entity.Property(e => e.RecId).HasColumnName("rec_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.DailyIntervalId).HasColumnName("daily_interval_id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.ResourceId).HasColumnName("resource_id");
            entity.Property(e => e.ResourceTypeId).HasColumnName("resource_type_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Client).WithMany(p => p.ResourcesBookings)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_resources_booking_clients");

            entity.HasOne(d => d.DailyInterval).WithMany(p => p.ResourcesBookings)
                .HasForeignKey(d => d.DailyIntervalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_resources_booking_daily_intervals");

            entity.HasOne(d => d.ResourceType).WithMany(p => p.ResourcesBookings)
                .HasForeignKey(d => d.ResourceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_resources_booking_resources_types");

            entity.HasOne(d => d.Resource).WithMany(p => p.ResourcesBookings)
                .HasForeignKey(d => new { d.ResourceTypeId, d.ResourceId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_resources_booking_resources");
        });

        modelBuilder.Entity<ResourcesBookingXTicket>(entity =>
        {
            entity.HasKey(e => new { e.RecId, e.TicketId });

            entity.ToTable("resources_booking_x_tickets");

            entity.Property(e => e.RecId).HasColumnName("rec_id");
            entity.Property(e => e.TicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ticket_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");

            entity.HasOne(d => d.Rec).WithMany(p => p.ResourcesBookingXTickets)
                .HasForeignKey(d => d.RecId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_resources_booking_x_tickets_resources_booking");
        });

        modelBuilder.Entity<ResourcesType>(entity =>
        {
            entity.HasKey(e => e.ResourceTypeId);

            entity.ToTable("resources_types");

            entity.HasIndex(e => e.Name, "UNIQ_resources_types_name").IsUnique();

            entity.Property(e => e.ResourceTypeId)
                .ValueGeneratedNever()
                .HasColumnName("resource_type_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.TicketTypeId).HasColumnName("ticket_type_id");
        });

        modelBuilder.Entity<ResourcesTypesXDailyInterval>(entity =>
        {
            entity.HasKey(e => new { e.ResourceTypeId, e.DailyIntervalId });

            entity.ToTable("resources_types_x_daily_intervals");

            entity.Property(e => e.ResourceTypeId).HasColumnName("resource_type_id");
            entity.Property(e => e.DailyIntervalId).HasColumnName("daily_interval_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");

            entity.HasOne(d => d.DailyInterval).WithMany(p => p.ResourcesTypesXDailyIntervals)
                .HasForeignKey(d => d.DailyIntervalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_resources_types_x_daily_intervals");

            entity.HasOne(d => d.ResourceType).WithMany(p => p.ResourcesTypesXDailyIntervals)
                .HasForeignKey(d => d.ResourceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_resources_types_x_daily_intervals_resources_types");
        });

        modelBuilder.Entity<TagsEvidention>(entity =>
        {
            entity.HasKey(e => e.TagId);

            entity.ToTable("tags_evidention");

            entity.Property(e => e.TagId)
                .ValueGeneratedNever()
                .HasColumnName("tag_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<TagsEvidentionTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId);

            entity.ToTable("tags_evidention_transaction");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<TagsEvidentionXTagsEvidentionTransaction>(entity =>
        {
            entity.HasKey(e => new { e.TransactionId, e.TagId });

            entity.ToTable("tags_evidention_x_tags_evidention_transaction");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.TagId).HasColumnName("tag_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => new { e.TicketId, e.OrdNum });

            entity.ToTable("tickets");

            entity.Property(e => e.TicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ticket_id");
            entity.Property(e => e.OrdNum)
                .HasDefaultValue(1)
                .HasColumnName("ord_num");
            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("approved_by");
            entity.Property(e => e.AuthorisedTo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("authorised_to");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.IssuedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("issued_by");
            entity.Property(e => e.LimitTotal).HasColumnName("limit_total");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.OrigOrdNum).HasColumnName("orig_ord_num");
            entity.Property(e => e.OrigTicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("orig_ticket_id");
            entity.Property(e => e.PeopleNum).HasColumnName("people_num");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("price");
            entity.Property(e => e.RefuseMessage)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("refuse_message");
            entity.Property(e => e.SoldBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sold_by");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TicketTypeId).HasColumnName("ticket_type_id");
            entity.Property(e => e.TimeIssued)
                .HasColumnType("datetime")
                .HasColumnName("time_issued");
            entity.Property(e => e.TimeSold)
                .HasColumnType("datetime")
                .HasColumnName("time_sold");
            entity.Property(e => e.ValidFrom)
                .HasColumnType("datetime")
                .HasColumnName("valid_from");
            entity.Property(e => e.ValidTo)
                .HasColumnType("datetime")
                .HasColumnName("valid_to");

            entity.HasOne(d => d.Pos).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.PosId)
                .HasConstraintName("FK_tickets_pos");

            entity.HasOne(d => d.TicketType).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TicketTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tickets_ticket_types");
        });

        modelBuilder.Entity<TicketType>(entity =>
        {
            entity.ToTable("ticket_types");

            entity.HasIndex(e => e.Name, "UNIQ_ticket_types_name").IsUnique();

            entity.Property(e => e.TicketTypeId).HasColumnName("ticket_type_id");
            entity.Property(e => e.ArticleId).HasColumnName("article_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasColumnName("description");
            entity.Property(e => e.IssuingMethod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("issuing_method");
            entity.Property(e => e.IssuingTechnology)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("issuing_technology");
            entity.Property(e => e.LimitRule)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("limit_rule");
            entity.Property(e => e.LimitRuleValue).HasColumnName("limit_rule_value");
            entity.Property(e => e.LimitRuleValueMax).HasColumnName("limit_rule_value_max");
            entity.Property(e => e.LimitRuleValueMin).HasColumnName("limit_rule_value_min");
            entity.Property(e => e.LimitTail).HasColumnName("limit_tail");
            entity.Property(e => e.MasterTicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("master_ticket_id");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.MultipleIssuingRule)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("multiple_issuing_rule");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .HasColumnName("name");
            entity.Property(e => e.PayPerHrsRule).HasColumnName("pay_per_hrs_rule");
            entity.Property(e => e.Personalised).HasColumnName("personalised");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ScheduleType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("schedule_type");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TailingAllowed).HasColumnName("tailing_allowed");
            entity.Property(e => e.TypeGroups)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("type_groups");
            entity.Property(e => e.TypeObject)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("type_object");
            entity.Property(e => e.TypeRegularity)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("type_regularity");
            entity.Property(e => e.ValidityRuleCustomised)
                .HasMaxLength(200)
                .HasColumnName("validity_rule_customised");
            entity.Property(e => e.ValidityRuleDuration)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("validity_rule_duration");
            entity.Property(e => e.ValidityRuleDurationValue).HasColumnName("validity_rule_duration_value");
            entity.Property(e => e.ValidityRuleDurationValueOffset).HasColumnName("validity_rule_duration_value_offset");
            entity.Property(e => e.ValidityRuleMasterValue).HasColumnName("validity_rule_master_value");
            entity.Property(e => e.ValidityRuleStart)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("validity_rule_start");
            entity.Property(e => e.ValidityRuleStartValue).HasColumnName("validity_rule_start_value");
            entity.Property(e => e.ValidityRuleTailing)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("validity_rule_tailing");
            entity.Property(e => e.ValidityRuleTailingIntervalValue).HasColumnName("validity_rule_tailing_interval_value");
            entity.Property(e => e.ValidityRuleTailingValue).HasColumnName("validity_rule_tailing_value");
            entity.Property(e => e.WeekScheduleId).HasColumnName("week_schedule_id");
        });

        modelBuilder.Entity<TicketTypesCustomisedValue>(entity =>
        {
            entity.HasKey(e => e.TicketTypeId);

            entity.ToTable("ticket_types_customised_values");

            entity.Property(e => e.TicketTypeId)
                .ValueGeneratedNever()
                .HasColumnName("ticket_type_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.DatetimeValue1)
                .HasColumnType("datetime")
                .HasColumnName("datetime_value_1");
            entity.Property(e => e.DatetimeValue10)
                .HasColumnType("datetime")
                .HasColumnName("datetime_value_10");
            entity.Property(e => e.DatetimeValue2)
                .HasColumnType("datetime")
                .HasColumnName("datetime_value_2");
            entity.Property(e => e.DatetimeValue3)
                .HasColumnType("datetime")
                .HasColumnName("datetime_value_3");
            entity.Property(e => e.DatetimeValue4)
                .HasColumnType("datetime")
                .HasColumnName("datetime_value_4");
            entity.Property(e => e.DatetimeValue5)
                .HasColumnType("datetime")
                .HasColumnName("datetime_value_5");
            entity.Property(e => e.DatetimeValue6)
                .HasColumnType("datetime")
                .HasColumnName("datetime_value_6");
            entity.Property(e => e.DatetimeValue7)
                .HasColumnType("datetime")
                .HasColumnName("datetime_value_7");
            entity.Property(e => e.DatetimeValue8)
                .HasColumnType("datetime")
                .HasColumnName("datetime_value_8");
            entity.Property(e => e.DatetimeValue9)
                .HasColumnType("datetime")
                .HasColumnName("datetime_value_9");
            entity.Property(e => e.IntegerValue1).HasColumnName("integer_value_1");
            entity.Property(e => e.IntegerValue10).HasColumnName("integer_value_10");
            entity.Property(e => e.IntegerValue2).HasColumnName("integer_value_2");
            entity.Property(e => e.IntegerValue3).HasColumnName("integer_value_3");
            entity.Property(e => e.IntegerValue4).HasColumnName("integer_value_4");
            entity.Property(e => e.IntegerValue5).HasColumnName("integer_value_5");
            entity.Property(e => e.IntegerValue6).HasColumnName("integer_value_6");
            entity.Property(e => e.IntegerValue7).HasColumnName("integer_value_7");
            entity.Property(e => e.IntegerValue8).HasColumnName("integer_value_8");
            entity.Property(e => e.IntegerValue9).HasColumnName("integer_value_9");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.NvarcharValue1)
                .HasMaxLength(256)
                .HasColumnName("nvarchar_value_1");
            entity.Property(e => e.NvarcharValue10)
                .HasMaxLength(256)
                .HasColumnName("nvarchar_value_10");
            entity.Property(e => e.NvarcharValue2)
                .HasMaxLength(256)
                .HasColumnName("nvarchar_value_2");
            entity.Property(e => e.NvarcharValue3)
                .HasMaxLength(256)
                .HasColumnName("nvarchar_value_3");
            entity.Property(e => e.NvarcharValue4)
                .HasMaxLength(256)
                .HasColumnName("nvarchar_value_4");
            entity.Property(e => e.NvarcharValue5)
                .HasMaxLength(256)
                .HasColumnName("nvarchar_value_5");
            entity.Property(e => e.NvarcharValue6)
                .HasMaxLength(256)
                .HasColumnName("nvarchar_value_6");
            entity.Property(e => e.NvarcharValue7)
                .HasMaxLength(256)
                .HasColumnName("nvarchar_value_7");
            entity.Property(e => e.NvarcharValue8)
                .HasMaxLength(256)
                .HasColumnName("nvarchar_value_8");
            entity.Property(e => e.NvarcharValue9)
                .HasMaxLength(256)
                .HasColumnName("nvarchar_value_9");

            entity.HasOne(d => d.TicketType).WithOne(p => p.TicketTypesCustomisedValue)
                .HasForeignKey<TicketTypesCustomisedValue>(d => d.TicketTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ticket_types_customised_values_ticket_types");
        });

        modelBuilder.Entity<TicketTypesInterface>(entity =>
        {
            entity.HasKey(e => e.RecId);

            entity.ToTable("ticket_types_interface");

            entity.Property(e => e.RecId).HasColumnName("rec_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .HasColumnName("name");
            entity.Property(e => e.TicketTypeId).HasColumnName("ticket_type_id");
            entity.Property(e => e.TicketTypeInterfaceId).HasColumnName("ticket_type_interface_id");

            entity.HasOne(d => d.TicketType).WithMany(p => p.TicketTypesInterfaces)
                .HasForeignKey(d => d.TicketTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ticket_types_interface_ticket_types");
        });

        modelBuilder.Entity<TicketTypesXEvent>(entity =>
        {
            entity.HasKey(e => new { e.TicketTypeId, e.EventId });

            entity.ToTable("ticket_types_x_events");

            entity.Property(e => e.TicketTypeId).HasColumnName("ticket_type_id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Purpose)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("purpose");
            entity.Property(e => e.SecNum)
                .HasDefaultValue(1)
                .HasColumnName("sec_num");

            entity.HasOne(d => d.Event).WithMany(p => p.TicketTypesXEvents)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ticket_types_x_events_events");

            entity.HasOne(d => d.TicketType).WithMany(p => p.TicketTypesXEvents)
                .HasForeignKey(d => d.TicketTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ticket_types_x_events_ticket_types");
        });

        modelBuilder.Entity<TicketsArch>(entity =>
        {
            entity.HasKey(e => e.RecId);

            entity.ToTable("tickets_arch");

            entity.Property(e => e.RecId).HasColumnName("rec_id");
            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("approved_by");
            entity.Property(e => e.AuthorisedTo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("authorised_to");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.IssuedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("issued_by");
            entity.Property(e => e.LimitTotal).HasColumnName("limit_total");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.OrdNum).HasColumnName("ord_num");
            entity.Property(e => e.OrigOrdNum).HasColumnName("orig_ord_num");
            entity.Property(e => e.OrigTicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("orig_ticket_id");
            entity.Property(e => e.PeopleNum).HasColumnName("people_num");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("price");
            entity.Property(e => e.SoldBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sold_by");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ticket_id");
            entity.Property(e => e.TicketTypeId).HasColumnName("ticket_type_id");
            entity.Property(e => e.TimeIssued)
                .HasColumnType("datetime")
                .HasColumnName("time_issued");
            entity.Property(e => e.TimeSold)
                .HasColumnType("datetime")
                .HasColumnName("time_sold");
            entity.Property(e => e.ValidFrom)
                .HasColumnType("datetime")
                .HasColumnName("valid_from");
            entity.Property(e => e.ValidTo)
                .HasColumnType("datetime")
                .HasColumnName("valid_to");

            entity.HasOne(d => d.Pos).WithMany(p => p.TicketsArches)
                .HasForeignKey(d => d.PosId)
                .HasConstraintName("FK_tickets_arch_pos");

            entity.HasOne(d => d.TicketType).WithMany(p => p.TicketsArches)
                .HasForeignKey(d => d.TicketTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tickets_arch_ticket_types");
        });

        modelBuilder.Entity<TicketsArchView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("tickets_arch_view");

            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("approved_by");
            entity.Property(e => e.AuthorisedTo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("authorised_to");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Data1)
                .HasMaxLength(128)
                .HasColumnName("data_1");
            entity.Property(e => e.Data10)
                .HasMaxLength(128)
                .HasColumnName("data_10");
            entity.Property(e => e.Data2)
                .HasMaxLength(128)
                .HasColumnName("data_2");
            entity.Property(e => e.Data3)
                .HasMaxLength(128)
                .HasColumnName("data_3");
            entity.Property(e => e.Data4)
                .HasMaxLength(128)
                .HasColumnName("data_4");
            entity.Property(e => e.Data5)
                .HasMaxLength(128)
                .HasColumnName("data_5");
            entity.Property(e => e.Data6)
                .HasMaxLength(128)
                .HasColumnName("data_6");
            entity.Property(e => e.Data7)
                .HasMaxLength(128)
                .HasColumnName("data_7");
            entity.Property(e => e.Data8)
                .HasMaxLength(128)
                .HasColumnName("data_8");
            entity.Property(e => e.Data9)
                .HasMaxLength(128)
                .HasColumnName("data_9");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.IssuedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("issued_by");
            entity.Property(e => e.LimitTotal).HasColumnName("limit_total");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.OrdNum).HasColumnName("ord_num");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("price");
            entity.Property(e => e.SoldBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sold_by");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ticket_id");
            entity.Property(e => e.TicketTypeId).HasColumnName("ticket_type_id");
            entity.Property(e => e.TicketTypeName)
                .HasMaxLength(64)
                .HasColumnName("ticket_type_name");
            entity.Property(e => e.TimeIssued)
                .HasColumnType("datetime")
                .HasColumnName("time_issued");
            entity.Property(e => e.TimeSold)
                .HasColumnType("datetime")
                .HasColumnName("time_sold");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.ValidFrom)
                .HasColumnType("datetime")
                .HasColumnName("valid_from");
            entity.Property(e => e.ValidTo)
                .HasColumnType("datetime")
                .HasColumnName("valid_to");
        });

        modelBuilder.Entity<TicketsHist>(entity =>
        {
            entity.HasKey(e => e.RecId);

            entity.ToTable("tickets_hist");

            entity.Property(e => e.RecId).HasColumnName("rec_id");
            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("approved_by");
            entity.Property(e => e.AuthorisedTo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("authorised_to");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.IssuedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("issued_by");
            entity.Property(e => e.LimitTotal).HasColumnName("limit_total");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.OrdNum)
                .HasDefaultValue(1)
                .HasColumnName("ord_num");
            entity.Property(e => e.OrigOrdNum).HasColumnName("orig_ord_num");
            entity.Property(e => e.OrigTicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("orig_ticket_id");
            entity.Property(e => e.PeopleNum).HasColumnName("people_num");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Remark)
                .HasMaxLength(200)
                .HasColumnName("remark");
            entity.Property(e => e.SoldBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sold_by");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ticket_id");
            entity.Property(e => e.TicketTypeId).HasColumnName("ticket_type_id");
            entity.Property(e => e.TimeIssued)
                .HasColumnType("datetime")
                .HasColumnName("time_issued");
            entity.Property(e => e.TimeSold)
                .HasColumnType("datetime")
                .HasColumnName("time_sold");
            entity.Property(e => e.ValidFrom)
                .HasColumnType("datetime")
                .HasColumnName("valid_from");
            entity.Property(e => e.ValidTo)
                .HasColumnType("datetime")
                .HasColumnName("valid_to");

            entity.HasOne(d => d.Pos).WithMany(p => p.TicketsHists)
                .HasForeignKey(d => d.PosId)
                .HasConstraintName("FK_tickets_hist_pos");

            entity.HasOne(d => d.TicketType).WithMany(p => p.TicketsHists)
                .HasForeignKey(d => d.TicketTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tickets_hist_ticket_types");
        });

        modelBuilder.Entity<TicketsHistArch>(entity =>
        {
            entity.HasKey(e => e.RecId);

            entity.ToTable("tickets_hist_arch");

            entity.Property(e => e.RecId).HasColumnName("rec_id");
            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("approved_by");
            entity.Property(e => e.AuthorisedTo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("authorised_to");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.IssuedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("issued_by");
            entity.Property(e => e.LimitTotal).HasColumnName("limit_total");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.OrdNum).HasColumnName("ord_num");
            entity.Property(e => e.OrigOrdNum).HasColumnName("orig_ord_num");
            entity.Property(e => e.OrigTicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("orig_ticket_id");
            entity.Property(e => e.PeopleNum).HasColumnName("people_num");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Remark)
                .HasMaxLength(200)
                .HasColumnName("remark");
            entity.Property(e => e.SoldBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sold_by");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ticket_id");
            entity.Property(e => e.TicketTypeId).HasColumnName("ticket_type_id");
            entity.Property(e => e.TimeIssued)
                .HasColumnType("datetime")
                .HasColumnName("time_issued");
            entity.Property(e => e.TimeSold)
                .HasColumnType("datetime")
                .HasColumnName("time_sold");
            entity.Property(e => e.ValidFrom)
                .HasColumnType("datetime")
                .HasColumnName("valid_from");
            entity.Property(e => e.ValidTo)
                .HasColumnType("datetime")
                .HasColumnName("valid_to");

            entity.HasOne(d => d.Pos).WithMany(p => p.TicketsHistArches)
                .HasForeignKey(d => d.PosId)
                .HasConstraintName("FK_tickets_hist_arch_pos");

            entity.HasOne(d => d.TicketType).WithMany(p => p.TicketsHistArches)
                .HasForeignKey(d => d.TicketTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tickets_hist_arch_ticket_types");
        });

        modelBuilder.Entity<TicketsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("tickets_view");

            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("approved_by");
            entity.Property(e => e.AuthorisedTo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("authorised_to");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Data1)
                .HasMaxLength(128)
                .HasColumnName("data_1");
            entity.Property(e => e.Data10)
                .HasMaxLength(128)
                .HasColumnName("data_10");
            entity.Property(e => e.Data2)
                .HasMaxLength(128)
                .HasColumnName("data_2");
            entity.Property(e => e.Data3)
                .HasMaxLength(128)
                .HasColumnName("data_3");
            entity.Property(e => e.Data4)
                .HasMaxLength(128)
                .HasColumnName("data_4");
            entity.Property(e => e.Data5)
                .HasMaxLength(128)
                .HasColumnName("data_5");
            entity.Property(e => e.Data6)
                .HasMaxLength(128)
                .HasColumnName("data_6");
            entity.Property(e => e.Data7)
                .HasMaxLength(128)
                .HasColumnName("data_7");
            entity.Property(e => e.Data8)
                .HasMaxLength(128)
                .HasColumnName("data_8");
            entity.Property(e => e.Data9)
                .HasMaxLength(128)
                .HasColumnName("data_9");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.IssuedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("issued_by");
            entity.Property(e => e.LimitTotal).HasColumnName("limit_total");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.OrdNum).HasColumnName("ord_num");
            entity.Property(e => e.OrigTicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("orig_ticket_id");
            entity.Property(e => e.PosId).HasColumnName("pos_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("price");
            entity.Property(e => e.SoldBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sold_by");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TicketId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ticket_id");
            entity.Property(e => e.TicketTypeId).HasColumnName("ticket_type_id");
            entity.Property(e => e.TicketTypeName)
                .HasMaxLength(64)
                .HasColumnName("ticket_type_name");
            entity.Property(e => e.TimeIssued)
                .HasColumnType("datetime")
                .HasColumnName("time_issued");
            entity.Property(e => e.TimeSold)
                .HasColumnType("datetime")
                .HasColumnName("time_sold");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.ValidFrom)
                .HasColumnType("datetime")
                .HasColumnName("valid_from");
            entity.Property(e => e.ValidTo)
                .HasColumnType("datetime")
                .HasColumnName("valid_to");
        });

        modelBuilder.Entity<ValidationTerminal>(entity =>
        {
            entity.ToTable("validation_terminals");

            entity.HasIndex(e => e.IpAddress, "UNIQ_validation_terminals_ip_address").IsUnique();

            entity.HasIndex(e => e.Name, "UNIQ_validation_terminals_name").IsUnique();

            entity.Property(e => e.ValidationTerminalId).HasColumnName("validation_terminal_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasColumnName("description");
            entity.Property(e => e.Direction)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("direction");
            entity.Property(e => e.DropArm).HasColumnName("drop_arm");
            entity.Property(e => e.GateId).HasColumnName("gate_id");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ip_address");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .HasColumnName("name");
            entity.Property(e => e.Remark)
                .HasMaxLength(128)
                .HasColumnName("remark");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Virtual).HasColumnName("virtual");

            entity.HasOne(d => d.Gate).WithMany(p => p.ValidationTerminals)
                .HasForeignKey(d => d.GateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_validation_terminals_gates");
        });

        modelBuilder.Entity<ValidationTerminalsSetting>(entity =>
        {
            entity.HasKey(e => e.ValidationTerminalId);

            entity.ToTable("validation_terminals_settings");

            entity.Property(e => e.ValidationTerminalId)
                .ValueGeneratedNever()
                .HasColumnName("validation_terminal_id");
            entity.Property(e => e.BlockPassInterval).HasColumnName("block_pass_interval");
            entity.Property(e => e.CameraIp1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("camera_ip_1");
            entity.Property(e => e.CameraIp2)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("camera_ip_2");
            entity.Property(e => e.CameraIp3)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("camera_ip_3");
            entity.Property(e => e.CameraIp4)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("camera_ip_4");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.LogDebugMessages).HasColumnName("log_debug_messages");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.PassTimeOut).HasColumnName("pass_time_out");
            entity.Property(e => e.PrinterType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("printer_type");
            entity.Property(e => e.PrinterUsed).HasColumnName("printer_used");
            entity.Property(e => e.ReaderPingPeriod).HasColumnName("reader_ping_period");
            entity.Property(e => e.TicketTransactionTimeout).HasColumnName("ticket_transaction_timeout");
            entity.Property(e => e.VirtualValidationTerminalId).HasColumnName("virtual_validation_terminal_id");

            entity.HasOne(d => d.ValidationTerminal).WithOne(p => p.ValidationTerminalsSettingValidationTerminal)
                .HasForeignKey<ValidationTerminalsSetting>(d => d.ValidationTerminalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_validation_terminals_settings_validation_terminals");

            entity.HasOne(d => d.VirtualValidationTerminal).WithMany(p => p.ValidationTerminalsSettingVirtualValidationTerminals)
                .HasForeignKey(d => d.VirtualValidationTerminalId)
                .HasConstraintName("FK_validation_terminals_settings_validation_terminals_1");
        });

        modelBuilder.Entity<WeekSchedule>(entity =>
        {
            entity.HasKey(e => new { e.WeekScheduleId, e.Day, e.DailyIntervalId });

            entity.ToTable("week_schedules");

            entity.Property(e => e.WeekScheduleId).HasColumnName("week_schedule_id");
            entity.Property(e => e.Day).HasColumnName("day");
            entity.Property(e => e.DailyIntervalId).HasColumnName("daily_interval_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.LimitDay).HasColumnName("limit_day");
            entity.Property(e => e.LimitInterval).HasColumnName("limit_interval");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.ValidityRuleMultipleUssing)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("validity_rule_multiple_ussing");
            entity.Property(e => e.ValidityRuleMultipleUssingValue).HasColumnName("validity_rule_multiple_ussing_value");
            entity.Property(e => e.ValidityRuleMultipleUssingValueExit).HasColumnName("validity_rule_multiple_ussing_value_exit");

            entity.HasOne(d => d.DailyInterval).WithMany(p => p.WeekSchedules)
                .HasForeignKey(d => d.DailyIntervalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_week_schedules_daily_intervals");
        });

        modelBuilder.Entity<WeekSchedulesXGate>(entity =>
        {
            entity.HasKey(e => new { e.WeekScheduleId, e.Day, e.DailyIntervalId, e.GateId });

            entity.ToTable("week_schedules_x_gates");

            entity.Property(e => e.WeekScheduleId).HasColumnName("week_schedule_id");
            entity.Property(e => e.Day).HasColumnName("day");
            entity.Property(e => e.DailyIntervalId).HasColumnName("daily_interval_id");
            entity.Property(e => e.GateId).HasColumnName("gate_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedTime)
                .HasColumnType("datetime")
                .HasColumnName("modified_time");
            entity.Property(e => e.Purpose)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("purpose");

            entity.HasOne(d => d.Gate).WithMany(p => p.WeekSchedulesXGates)
                .HasForeignKey(d => d.GateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_week_schedules_x_gates_gates");

            entity.HasOne(d => d.WeekSchedule).WithMany(p => p.WeekSchedulesXGates)
                .HasForeignKey(d => new { d.WeekScheduleId, d.Day, d.DailyIntervalId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_week_schedules_x_gates_week_schedules");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
