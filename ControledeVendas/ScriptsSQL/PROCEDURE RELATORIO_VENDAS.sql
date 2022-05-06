CREATE PROCEDURE SPS_RELATORIOVENDAS @DATAINI DATETIME, @DATAFIM DATETIME 

AS

BEGIN

  SELECT  v.id,data,c.Nome, Cliente,Quant,precoTotal,p.descricao FROM Vendas v
  inner join Categoria c on v.Produtoid = c.id
  inner join pago p on v.Pago = p.id
  WHERE Data BETWEEN @DATAINI AND @DATAFIM 
  ORDER BY DATA DESC

END

--EXEC SPS_RELATORIOVENDAS '2022-02-02','2022-03-02'

SPS_RELATORIOVENDAS '2022-02-03','2022-04-05'