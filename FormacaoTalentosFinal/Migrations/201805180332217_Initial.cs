namespace FormacaoTalentosFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        AlunoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CursoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlunoID)
                .ForeignKey("dbo.Curso", t => t.CursoID, cascadeDelete: true)
                .Index(t => t.CursoID);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        CursoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        UniversidadeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CursoID)
                .ForeignKey("dbo.Universidade", t => t.UniversidadeID, cascadeDelete: true)
                .Index(t => t.UniversidadeID);
            
            CreateTable(
                "dbo.Universidade",
                c => new
                    {
                        UniversidadeID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cidade = c.String(),
                        UF = c.String(),
                    })
                .PrimaryKey(t => t.UniversidadeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aluno", "CursoID", "dbo.Curso");
            DropForeignKey("dbo.Curso", "UniversidadeID", "dbo.Universidade");
            DropIndex("dbo.Curso", new[] { "UniversidadeID" });
            DropIndex("dbo.Aluno", new[] { "CursoID" });
            DropTable("dbo.Universidade");
            DropTable("dbo.Curso");
            DropTable("dbo.Aluno");
        }
    }
}
