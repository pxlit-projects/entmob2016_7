using fitsense.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_fitsense.DataLayer
{
    public class FitsenseContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<CompletedSet> CompletedSets { get; set; }
        public DbSet<ExercisePoint> ExercisePoints { get; set; }
        public DbSet<User> Users { get; set; }

        public FitsenseContext() : base("FitsenseDB")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(category => category.ID);
            modelBuilder.Entity<Exercise>().HasKey(exercise => exercise.ID);
            modelBuilder.Entity<Set>().HasKey(set => set.ID);
            modelBuilder.Entity<CompletedSet>().HasKey(completedSet => completedSet.ID);
            modelBuilder.Entity<ExercisePoint>().HasKey(exercisePoint => exercisePoint.ID);
            modelBuilder.Entity<User>().HasKey(user => user.ID);

            modelBuilder.Entity<Exercise>().HasRequired(category => category.Category);
            modelBuilder.Entity<ExercisePoint>().HasRequired(exercisePoint => exercisePoint.Exercise).WithMany(exercise => exercise.ExercisePoints);
            modelBuilder.Entity<Set>().HasRequired(set => set.Exercise).WithMany(exercise => exercise.Sets);
            modelBuilder.Entity<CompletedSet>().HasRequired(completedSet => completedSet.Set);
            modelBuilder.Entity<CompletedSet>().HasRequired(completedSet => completedSet.User);

            modelBuilder.Entity<Set>().Ignore(set => set.ShowCompletedSets);
            modelBuilder.Entity<Set>().Ignore(set => set.MaxTime);
            modelBuilder.Entity<User>().Ignore(user => user.Height);
            modelBuilder.Entity<User>().Ignore(user => user.Weight);

            modelBuilder.Entity<Set>().HasMany(set => set.CompletedSets);
            modelBuilder.Entity<Category>().HasMany(category => category.Exercises);
            modelBuilder.Entity<Exercise>().HasMany(exercise => exercise.ExercisePoints);
            modelBuilder.Entity<Exercise>().HasMany(exercise => exercise.Sets);
            modelBuilder.Entity<User>().HasMany(user => user.CompletedSets);

            base.OnModelCreating(modelBuilder);
        }
    }
}
