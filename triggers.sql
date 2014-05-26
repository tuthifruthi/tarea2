CREATE TRIGGER dbo.N_comentarios ON dbo.Comentario
AFTER INSERT
AS
BEGIN

SET NOCOUNT ON;

DECLARE @id_usuario=(SELECT id_usuario FROM inserted);
DECLARE @cantidad_comentarios=(SELECT cantidad_comentarios FROM Comentario WHERE id_usuario=@id_usuario);

SET @cantidad_comentarios=@cantidad_comentarios+1;

BEGIN
  
  UPDATE Usuario SET @cantidad_comentarios WHERE id_usuario=@id_usuario;

END

END

RETURN