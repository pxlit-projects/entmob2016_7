namespace ef_fitsense.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        ExerciseID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CategoryID = c.Int(nullable: false),
                        Selected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ExerciseID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.ExercisePoints",
                c => new
                    {
                        ExerciseID = c.Int(nullable: false, identity: true),
                        ChangeX = c.Int(nullable: false),
                        ChangeY = c.Int(nullable: false),
                        ChangeZ = c.Int(nullable: false),
                        Exercise_ExerciseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExerciseID)
                .ForeignKey("dbo.Exercises", t => t.Exercise_ExerciseID, cascadeDelete: true)
                .Index(t => t.Exercise_ExerciseID);
            
            CreateTable(
                "dbo.Sets",
                c => new
                    {
                        SetID = c.Int(nullable: false, identity: true),
                        Reps = c.Int(nullable: false),
                        ExerciseID = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SetID)
                .ForeignKey("dbo.Exercises", t => t.ExerciseID, cascadeDelete: true)
                .Index(t => t.ExerciseID);
            
            CreateTable(
                "dbo.CompletedSets",
                c => new
                    {
                        CompletedSetID = c.Int(nullable: false, identity: true),
                        SetID = c.Int(nullable: false),
                        Time = c.Long(nullable: false),
                        Duration = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompletedSetID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Sets", t => t.SetID, cascadeDelete: true)
                .Index(t => t.SetID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercises", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Sets", "ExerciseID", "dbo.Exercises");
            DropForeignKey("dbo.CompletedSets", "SetID", "dbo.Sets");
            DropForeignKey("dbo.CompletedSets", "UserID", "dbo.Users");
            DropForeignKey("dbo.ExercisePoints", "Exercise_ExerciseID", "dbo.Exercises");
            DropIndex("dbo.CompletedSets", new[] { "UserID" });
            DropIndex("dbo.CompletedSets", new[] { "SetID" });
            DropIndex("dbo.Sets", new[] { "ExerciseID" });
            DropIndex("dbo.ExercisePoints", new[] { "Exercise_ExerciseID" });
            DropIndex("dbo.Exercises", new[] { "CategoryID" });
            DropTable("dbo.Users");
            DropTable("dbo.CompletedSets");
            DropTable("dbo.Sets");
            DropTable("dbo.ExercisePoints");
            DropTable("dbo.Exercises");
            DropTable("dbo.Categories");
        }
    }
}
