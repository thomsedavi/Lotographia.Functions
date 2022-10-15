using Lotographia.Functions.Models;
using Lotographia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lotographia.Functions.Data
{
    public class LotographiaContext : DbContext
    {
        public LotographiaContext(DbContextOptions<LotographiaContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<User>();

            user.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(255);

            user.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            user.Property(u => u.Provider)
                .IsRequired()
                .HasMaxLength(255);

            user.Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(255);

            user.Property(u => u.CreatedDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("getutcdate()");

            user.HasIndex(u => u.Name)
                .IsUnique();

            user.HasIndex(u => new { u.Email, u.Provider })
                .IsUnique();

            var paperFolliesGame = modelBuilder.Entity<PaperFolliesGame>();

            paperFolliesGame.Property(b => b.Code)
                .IsRequired()
                .HasMaxLength(255);

            paperFolliesGame.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(255);

            paperFolliesGame.Property(b => b.Description)
                .HasMaxLength(4000);

            paperFolliesGame.Property(b => b.CreatedDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("getutcdate()");

            paperFolliesGame.Property(b => b.EndedDate)
                .HasColumnType("datetime2");

            paperFolliesGame.HasIndex(b => b.Code)
                .IsUnique();

            var paperFolliesParticipant = modelBuilder.Entity<PaperFolliesParticipant>();

            paperFolliesParticipant.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(255);

            paperFolliesParticipant.Property(b => b.Biography)
                .HasMaxLength(4000);

            paperFolliesParticipant.Property(b => b.HashedPassword)
                .HasMaxLength(255);

            paperFolliesParticipant.Property(b => b.Content)
                .HasMaxLength(4000);

            paperFolliesParticipant.HasOne(a => a.PrecedingPlayer)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
            
            paperFolliesParticipant.HasOne(a => a.FollowingPlayer)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            var lexicologerGame = modelBuilder.Entity<LexicologerGame>();

            lexicologerGame.Property(b => b.Title)
                .HasMaxLength(255);

            lexicologerGame.Property(b => b.Details)
                .HasMaxLength(4000);

            var valueComparer = new ValueComparer<List<LexicologerWord>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());

            lexicologerGame.Property(g => g.Words)
                .HasConversion(w => JsonConvert.SerializeObject(w), w => JsonConvert.DeserializeObject<List<LexicologerWord>>(w))
                .Metadata.SetValueComparer(valueComparer);

            var asinoPuzzleCollection = modelBuilder.Entity<AsinoPuzzleCollection>();

            asinoPuzzleCollection.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(255);

            asinoPuzzleCollection.Property(c => c.CreatedDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("getutcdate()");

            asinoPuzzleCollection.Property(c => c.UpdatedDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("getutcdate()");

            asinoPuzzleCollection.HasOne(c => c.CurrentVersion)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            var asinoPuzzleCollectionVersion = modelBuilder.Entity<AsinoPuzzleCollectionVersion>();

            asinoPuzzleCollectionVersion.Property(v => v.Title)
                .IsRequired()
                .HasMaxLength(255);

            asinoPuzzleCollectionVersion.Property(v => v.CreatedDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("getutcdate()");

            asinoPuzzleCollectionVersion.Property(v => v.UpdatedDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("getutcdate()");

            var asinoPuzzle = modelBuilder.Entity<AsinoPuzzle>();

            asinoPuzzle.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(255);

            asinoPuzzle.Property(s => s.CreatedDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("getutcdate()");

            asinoPuzzle.Property(s => s.UpdatedDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("getutcdate()");

            asinoPuzzle.HasOne(a => a.CurrentVersion)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            var asinoDailyPuzzle = modelBuilder.Entity<AsinoDailyPuzzle>();

            asinoDailyPuzzle.Property(d => d.Date)
                .IsRequired()
                .HasColumnType("datetime2");

            asinoDailyPuzzle
                .HasOne(up => up.Puzzle)
                .WithMany(t => t.AsinoDailyPuzzles)
                .HasForeignKey(up => up.PuzzleId);

            asinoDailyPuzzle.HasIndex(u => u.Date)
                .IsUnique();

            var asinoPuzzleVersion = modelBuilder.Entity<AsinoPuzzleVersion>();

            asinoPuzzleVersion.Property(v => v.Title)
                .IsRequired()
                .HasMaxLength(255);

            asinoPuzzleVersion.Property(v => v.CreatedDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("getutcdate()");

            asinoPuzzleVersion.Property(v => v.UpdatedDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("getutcdate()");

            var asinoUserPuzzleCollection = modelBuilder.Entity<AsinoUserPuzzleCollection>();

            asinoUserPuzzleCollection.Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(255);

            asinoUserPuzzleCollection.HasIndex(p => p.UserId);
            asinoUserPuzzleCollection.HasIndex(p => p.PuzzleCollectionId);

            asinoUserPuzzleCollection
                .HasKey(t => new { t.UserId, t.PuzzleCollectionId });

            asinoUserPuzzleCollection
                .HasOne(up => up.User)
                .WithMany(u => u.AsinoUserPuzzleCollections)
                .HasForeignKey(up => up.UserId);

            asinoUserPuzzleCollection
                .HasOne(up => up.PuzzleCollection)
                .WithMany(t => t.AsinoUserPuzzleCollections)
                .HasForeignKey(up => up.PuzzleCollectionId);

            var asinoUserGraphicSet = modelBuilder.Entity<AsinoUserGraphicSet>();

            asinoUserGraphicSet.Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(255);

            asinoUserGraphicSet.HasIndex(p => p.UserId);
            asinoUserGraphicSet.HasIndex(p => p.GraphicSetId);

            asinoUserGraphicSet
                .HasKey(t => new { t.UserId, t.GraphicSetId });

            asinoUserGraphicSet
                .HasOne(up => up.User)
                .WithMany(u => u.AsinoUserGraphicSets)
                .HasForeignKey(up => up.UserId);

            asinoUserGraphicSet
                .HasOne(up => up.GraphicSet)
                .WithMany(t => t.AsinoUserGraphicSets)
                .HasForeignKey(up => up.GraphicSetId);

            var asinoUserPuzzle = modelBuilder.Entity<AsinoUserPuzzle>();

            asinoUserPuzzle.Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(255);

            asinoUserPuzzle.HasIndex(p => p.UserId);
            asinoUserPuzzle.HasIndex(p => p.PuzzleId);

            asinoUserPuzzle
                .HasKey(t => new { t.UserId, t.PuzzleId });

            asinoUserPuzzle
                .HasOne(up => up.User)
                .WithMany(u => u.AsinoUserPuzzles)
                .HasForeignKey(up => up.UserId);

            asinoUserPuzzle
                .HasOne(up => up.Puzzle)
                .WithMany(t => t.AsinoUserPuzzles)
                .HasForeignKey(up => up.PuzzleId);

            var asinoGraphicSet = modelBuilder.Entity<AsinoGraphicSet>();

            asinoGraphicSet.Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(255);

            asinoGraphicSet.Property(s => s.CreatedDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("getutcdate()");

            asinoGraphicSet.Property(s => s.UpdatedDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("getutcdate()");

            var asinoGraphic = modelBuilder.Entity<AsinoGraphic>();

            asinoGraphic.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(255);

            asinoGraphic.Property(p => p.Type)
                .IsRequired()
                .HasMaxLength(255);

            asinoGraphic.Property(s => s.CreatedDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("getutcdate()");

            asinoGraphic.Property(s => s.UpdatedDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("getutcdate()");

            asinoGraphic.HasOne(a => a.CurrentVersion)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            var asinoGraphicVersion = modelBuilder.Entity<AsinoGraphicVersion>();

            asinoGraphicVersion.Property(v => v.Title)
                .IsRequired()
                .HasMaxLength(255);

            asinoGraphicVersion.Property(v => v.CreatedDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("getutcdate()");

            asinoGraphicVersion.Property(v => v.UpdatedDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("getutcdate()");

            var whitelistedEmail = modelBuilder.Entity<WhitelistedEmail>();

            whitelistedEmail.Property(v => v.Email)
                .IsRequired()
                .HasMaxLength(255);

            whitelistedEmail.HasIndex(u => u.Email)
                .IsUnique();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PaperFolliesGame> PaperFolliesGames { get; set; }
        public DbSet<PaperFolliesParticipant> PaperFolliesParticipants { get; set; }
        public DbSet<LexicologerGame> LexicologerGames { get; set; }
        public DbSet<AsinoPuzzle> AsinoPuzzles { get; set; }
        public DbSet<AsinoDailyPuzzle> AsinoDailyPuzzles { get; set; }
        public DbSet<AsinoPuzzleVersion> AsinoPuzzleVersions { get; set; }
        public DbSet<AsinoPuzzleCollection> AsinoPuzzleCollections { get; set; }
        public DbSet<AsinoPuzzleCollectionVersion> AsinoPuzzleCollectionVersions { get; set; }
        public DbSet<AsinoGraphic> AsinoGraphics { get; set; }
        public DbSet<AsinoGraphicVersion> AsinoGraphicVersions { get; set; }
        public DbSet<AsinoGraphicSet> AsinoGraphicSets { get; set; }
        public DbSet<AsinoUserPuzzle> AsinoUserPuzzles { get; set; }
        public DbSet<AsinoUserPuzzleCollection> AsinoUserPuzzleCollections { get; set; }
        public DbSet<AsinoUserGraphicSet> AsinoUserGraphicSets { get; set; }
        public DbSet<WhitelistedEmail> WhitelistedEmails { get; set; }
    }
}
