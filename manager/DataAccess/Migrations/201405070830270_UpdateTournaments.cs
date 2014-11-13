﻿namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTournaments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "TournamentItemId", c => c.Guid(nullable: false));

            Sql("INSERT INTO Seasons values ('542905E0-DCAD-48DD-A907-A19253F5275C','1');" +
                  "INSERT INTO Tournaments values ('A2DC2E03-E7D8-49A0-9D11-C308961D8264','Украинская Премьер-лига',6,'542905E0-DCAD-48DD-A907-A19253F5275C','47A4EC4D-D649-4374-B43F-3056BED72DD3'); INSERT INTO Tournaments values ('E8F717E6-E9AC-42AD-8023-AC7BD309E66F','Английская Премьер-лига',6,'542905E0-DCAD-48DD-A907-A19253F5275C','BF2061D0-4230-49F0-830A-92F2C016BE38'); INSERT INTO Tournaments values ('5F099904-82B0-4473-AC17-F8344708A0B0','Испанская Ла-лига',6,'542905E0-DCAD-48DD-A907-A19253F5275C','FA00FF8D-89F8-4E1B-AB55-A1A83F1F8F8B');" +
                  "INSERT INTO TournamentItems values ('D019F0F1-CE0D-450A-85D0-48ACDDB336F4',1,GETDATE(),'A2DC2E03-E7D8-49A0-9D11-C308961D8264'); INSERT INTO TournamentItems values ('A57744C4-F659-4691-A640-40786CA0AC4E',2,GETDATE(),'A2DC2E03-E7D8-49A0-9D11-C308961D8264'); INSERT INTO TournamentItems values ('F932C32B-BD8D-49AB-A26D-34965364C866',3,GETDATE(),'A2DC2E03-E7D8-49A0-9D11-C308961D8264'); INSERT INTO TournamentItems values ('F4C1FC00-0F2D-4574-A2C3-FA0E4CD59E73',4,GETDATE(),'A2DC2E03-E7D8-49A0-9D11-C308961D8264'); INSERT INTO TournamentItems values ('95A533C6-071D-493C-A824-4053C81E5240',5,GETDATE(),'A2DC2E03-E7D8-49A0-9D11-C308961D8264'); INSERT INTO TournamentItems values ('B9A1C5D3-92FD-4E2D-9821-4A26565302B7',6,GETDATE(),'A2DC2E03-E7D8-49A0-9D11-C308961D8264'); " +
                  "INSERT INTO TournamentItems values ('25648CCC-7CD3-43F8-BB04-C0EA3184B44E',1,GETDATE(),'E8F717E6-E9AC-42AD-8023-AC7BD309E66F'); INSERT INTO TournamentItems values ('15633985-ADB3-4A92-946D-3EC9AA73CB97',2,GETDATE(),'E8F717E6-E9AC-42AD-8023-AC7BD309E66F'); INSERT INTO TournamentItems values ('BD215F27-A8BC-48FB-ADF9-CD9532F83C76',3,GETDATE(),'E8F717E6-E9AC-42AD-8023-AC7BD309E66F'); INSERT INTO TournamentItems values ('1E81AF12-6503-46B7-BC05-9AD35F7331A0',4,GETDATE(),'E8F717E6-E9AC-42AD-8023-AC7BD309E66F'); INSERT INTO TournamentItems values ('04612AC1-8439-4F8C-9E8A-6E0B7AD504A7',5,GETDATE(),'E8F717E6-E9AC-42AD-8023-AC7BD309E66F'); INSERT INTO TournamentItems values ('50E78C85-CC5D-49B7-8B44-9D31EE109DF9',6,GETDATE(),'E8F717E6-E9AC-42AD-8023-AC7BD309E66F'); " +
                  "INSERT INTO TournamentItems values ('00600143-DC23-4247-9981-86BFF5FE2E17',1,GETDATE(),'5F099904-82B0-4473-AC17-F8344708A0B0'); INSERT INTO TournamentItems values ('094875DC-5C02-4F72-9953-12D855572EF0',2,GETDATE(),'5F099904-82B0-4473-AC17-F8344708A0B0'); INSERT INTO TournamentItems values ('9C0A9C1C-FDAF-4872-9AB7-F7AD219C1F86',3,GETDATE(),'5F099904-82B0-4473-AC17-F8344708A0B0'); INSERT INTO TournamentItems values ('510BDEFE-E944-467D-9409-2FB73ADD3129',4,GETDATE(),'5F099904-82B0-4473-AC17-F8344708A0B0'); INSERT INTO TournamentItems values ('F6AF8D73-2138-488E-BD90-0ECE327C5836',5,GETDATE(),'5F099904-82B0-4473-AC17-F8344708A0B0'); INSERT INTO TournamentItems values ('62AB5151-36F6-4E35-B288-A14EAFBAB4BE',6,GETDATE(),'5F099904-82B0-4473-AC17-F8344708A0B0');" +
                  "Update Matches SET TournamentItemId = 'D019F0F1-CE0D-450A-85D0-48ACDDB336F4' WHERE Id = 'FB8A3E3B-7EC1-4EA6-A20F-D31CB65D9E00';" +
                  "Update Matches SET TournamentItemId = '25648CCC-7CD3-43F8-BB04-C0EA3184B44E' WHERE Id = '60E6F3B3-986B-437C-8EE2-7EF8164C978A'");
        
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matches", "TournamentItemId");
        }
    }
}
