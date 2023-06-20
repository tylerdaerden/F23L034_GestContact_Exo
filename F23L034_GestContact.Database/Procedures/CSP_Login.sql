CREATE PROCEDURE [dbo].[CSP_Login]
	@Email NVARCHAR(384), 
    @Passwd NVARCHAR(20) 
AS
BEGIN
	/*
        Test de valeurs
    */
	SELECT Id, Nom, Prenom, @Email AS Email
	FROM Utilisateur
	WHERE Email = @Email AND Passwd = HASHBYTES('SHA2_512', CONCAT(dbo.CSF_GetPreSalt(), @Passwd, dbo.CSF_GetPostSalt()));
	RETURN 0;
END
