namespace ef_fitsense.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExerciseReview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "review", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exercises", "review");
        }
    }
}
