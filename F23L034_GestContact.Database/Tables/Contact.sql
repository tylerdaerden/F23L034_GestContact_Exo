CREATE TABLE [dbo].[Contact]
(
	[Id] INT NOT NULL IDENTITY, 
    [Nom] NVARCHAR(50) NOT NULL, 
    [Prenom] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(384) NOT NULL, 
    [DateNaiss] DATE NOT NULL, 
    [Tel] NVARCHAR(20) NOT NULL, 
    [UtilisateurId] INT NOT NULL, 
    CONSTRAINT [PK_Contact] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Contact_Utilisateur] FOREIGN KEY ([UtilisateurId]) REFERENCES [Utilisateur]([Id])
)
