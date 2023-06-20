CREATE PROCEDURE [dbo].[CSP_Register]
	@Nom NVARCHAR(50), 
    @Prenom NVARCHAR(50), 
    @Email NVARCHAR(384), 
    @Passwd NVARCHAR(20) 
AS
BEGIN
    /*
        Test de valeurs
    */
    INSERT INTO Utilisateur (Nom, Prenom, Email, Passwd) VALUES (@Nom, @Prenom, @Email, HASHBYTES('SHA2_512', CONCAT(dbo.CSF_GetPreSalt(), @Passwd, dbo.CSF_GetPostSalt())));
    RETURN 0
END
	

