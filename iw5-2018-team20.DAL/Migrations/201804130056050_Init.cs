namespace iw5_2018_team20.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhotoEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        Format = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        Note = c.String(),
                        Album_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AlbumEntities", t => t.Album_Id)
                .Index(t => t.Album_Id);
            
            CreateTable(
                "dbo.ObjectEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Firstname = c.String(),
                        Surname = c.String(),
                        Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        PhotoEntity_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PhotoEntities", t => t.PhotoEntity_Id)
                .Index(t => t.PhotoEntity_Id);
            
            CreateTable(
                "dbo.ObjectOnPhotoEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PositionX = c.Int(nullable: false),
                        PositionY = c.Int(nullable: false),
                        Object_Id = c.Guid(nullable: false),
                        Photo_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ObjectEntities", t => t.Object_Id, cascadeDelete: true)
                .ForeignKey("dbo.PhotoEntities", t => t.Photo_Id, cascadeDelete: true)
                .Index(t => t.Object_Id)
                .Index(t => t.Photo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ObjectOnPhotoEntities", "Photo_Id", "dbo.PhotoEntities");
            DropForeignKey("dbo.ObjectOnPhotoEntities", "Object_Id", "dbo.ObjectEntities");
            DropForeignKey("dbo.ObjectEntities", "PhotoEntity_Id", "dbo.PhotoEntities");
            DropForeignKey("dbo.PhotoEntities", "Album_Id", "dbo.AlbumEntities");
            DropIndex("dbo.ObjectOnPhotoEntities", new[] { "Photo_Id" });
            DropIndex("dbo.ObjectOnPhotoEntities", new[] { "Object_Id" });
            DropIndex("dbo.ObjectEntities", new[] { "PhotoEntity_Id" });
            DropIndex("dbo.PhotoEntities", new[] { "Album_Id" });
            DropTable("dbo.ObjectOnPhotoEntities");
            DropTable("dbo.ObjectEntities");
            DropTable("dbo.PhotoEntities");
            DropTable("dbo.AlbumEntities");
        }
    }
}
