namespace TranscendenceChatServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TranscendencePointsDevice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDevices", "TranscendencePoints", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDevices", "TranscendencePoints");
        }
    }
}
