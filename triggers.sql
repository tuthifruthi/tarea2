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


CREATE TRIGGER dbo.MensajesLeidos ON dbo.MensajePrivado
AFTER UPDATE
AS
BEGIN

DECLARE @id_buzon INTEGER
DECLARE @estadoactual INTEGER
DECLARE @estadoanterior INTEGER
DECLARE @mensajes_sin_leer INTEGER

SELECT @id_buzon=id_buzon FROM inserted;
SELECT @estadoactual=leido FROM inserted;
SELECT @estadoanterior=leido FROM deleted;
SELECT @mensajes_sin_leer=(SELECT mensajes_sin_leer FROM BuzonEntrada WHERE id_buzon=@id_buzon);

IF(@estadoactual=1 AND @estadoanterior=0)
BEGIN
SET @mensajes_sin_leer=@mensajes_sin_leer-1;
UPDATE BuzonEntrada SET mensajes_sin_leer=@mensajes_sin_leer WHERE id_buzon=@id_buzon;

END
END
RETURN


CREATE TRIGGER dbo.N_mensajes ON dbo.MensajePrivado
AFTER INSERT
AS
BEGIN

DECLARE @id_buzon INTEGER
DECLARE @mensajes INTEGER
DECLARE @mensajes_sin_leer INTEGER

SELECT @id_buzon=id_buzon FROM inserted;
SELECT @mensajes=(SELECT mensajes FROM BuzonEntrada WHERE id_buzon=@id_buzon);
SELECT @mensajes_sin_leer=(SELECT mensajes_sin_leer FROM BuzonEntrada WHERE id_buzon=@id_buzon);

BEGIN

SET @mensajes=@mensajes+1;
SET @mensajes_sin_leer=@mensajes_sin_leer+1;
UPDATE BuzonEntrada SET mensajes=@mensajes, mensajes_sin_leer=@mensajes_sin_leer WHERE id_buzon=@id_buzon;

END
END
RETURN


