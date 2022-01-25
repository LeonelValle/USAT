USE [MWTrace]
GO

/****** Object:  Trigger [dbo].[Crear_ordenes]    Script Date: 1/23/2020 2:47:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE trigger [dbo].[Crear_ordenes] on [dbo].[tb_Orden]
after insert as begin
declare @count as int
declare @serialnumber as varchar(255)
declare @numero as int
declare @id as int
declare @con as int
declare @nome as varchar(50)
declare @id_modelo as int
declare @id_pcb as int
set @con = (select consecutivo from ConfiguracionSistema where id_cs = 1)
set @count = 1
set @numero = (select cantidad from inserted)
set @id = (select id_orden from inserted)
set @id_pcb = (select id_pcb from inserted)
set @id_modelo = (select id_modelo from inserted)
--CAJAS
declare @id_Caja as int
declare @Caja as int
declare @NumeroCaja as int 
declare @Contador as int
declare @ContadorPallete as int
declare @CountP as int
declare @TopCaja as int
declare @pallette as int
declare @id_pallette as int
declare @numeropallette as int
declare @TopPallette as int
set @id_Caja = (select TOP 1 id_caja from tb_caja order by id_caja desc)
set @Caja = (select caja from tb_caja where id_caja = @id_Caja)
set @TopCaja = (select numrocaja from ConfiguracionSistema where id_cs = 2)
set @numeropallette = (select TOP 1 pallette from tb_Pallette order by id_pallette desc)
set @TopPallette = (select CajaPallette from ConfiguracionSistema where id_cs = 3)
set @Contador = 1;
set @ContadorPallete = 1;
set @CountP = 1;
update ConfiguracionSistema set TotalCajas = 0 where id_cs = 2
set @pallette = (select TOP 1 pallette from tb_Pallette order by id_pallette desc)
set @pallette = @pallette + 1;
insert into tb_Pallette values(@pallette)
set @id_pallette = (SELECT IDENT_CURRENT('tb_Pallette') as IdentCurrent)
set @Caja = @Caja + 1
insert into tb_caja (caja,id_pallette) values(@caja,@id_pallette)	
set @id_Caja = (SELECT IDENT_CURRENT('tb_caja') as IdentCurrent)
--CAJAS
while @count <= @numero
	begin
		--CAJAS
		if @Contador <= @TopCaja
			begin
				set @id_Caja = (select TOP 1 id_caja from tb_caja order by id_caja desc)
				set @serialnumber = (select nomenclatura from tb_PCBModelo where id_pcb = (@id_pcb) and id_modelo = (@id_modelo)) + CONVERT(varchar,@con)	
				insert into tb_ModeloOrden (Serialnumber, id_orden, id_caja) values (@serialnumber, @id, @id_Caja)
				set @count = @count + 1
				set @con = @con + 1				
			end
		else
			begin
				set @Contador = 1
				--Pallette
				if @ContadorPallete >= @TopPallette
					begin
						set @pallette = (select TOP 1 pallette from tb_Pallette order by id_pallette desc)
						set @ContadorPallete = 0;		
						set @pallette = @pallette + 1
						insert into tb_Pallette values(@pallette)

						set @serialnumber = (select nomenclatura from tb_PCBModelo where id_pcb = (@id_pcb) and id_modelo = (@id_modelo)) + CONVERT(varchar,@con)	
						set @caja = @caja + 1
						set @count = @count + 1
						set @con = @con + 1
						set @id_pallette = (select TOP 1 id_pallette from tb_Pallette order by id_pallette desc)
						insert into tb_caja (caja,id_pallette) values(@caja,@id_pallette)	
						set @id_Caja = (SELECT IDENT_CURRENT('tb_caja') as IdentCurrent)
						update ConfiguracionSistema set numrocaja = 1 where id_cs = 2
						update ConfiguracionSistema set TotalCajas = 0 where id_cs = 2
						insert into tb_ModeloOrden (Serialnumber, id_orden, id_caja) values (@serialnumber, @id, @id_Caja)
					end
				else
					begin
						set @ContadorPallete = @ContadorPallete + 1
						set @serialnumber = (select nomenclatura from tb_PCBModelo where id_pcb = (@id_pcb) and id_modelo = (@id_modelo)) + CONVERT(varchar,@con)	
						set @caja = @caja + 1
						set @count = @count + 1
						set @con = @con + 1
						set @id_pallette = (select TOP 1 id_pallette from tb_Pallette order by id_pallette desc)
						insert into tb_caja (caja,id_pallette) values(@caja,@id_pallette)	
						set @id_Caja = (SELECT IDENT_CURRENT('tb_caja') as IdentCurrent)
						update ConfiguracionSistema set numrocaja = 1 where id_cs = 2
						update ConfiguracionSistema set TotalCajas = 0 where id_cs = 2
						insert into tb_ModeloOrden (Serialnumber, id_orden, id_caja) values (@serialnumber, @id, @id_Caja)
					end
				--Pallette												
			end
			set @Contador = @Contador + 1
		--CAJAS
update ConfiguracionSistema set consecutivo = @con where id_cs = 1
	end
end
GO

