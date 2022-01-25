create database MWTrace

create table tb_PCB(id_pcb int primary key identity(1,1), pcb varchar(100))

create table tb_Modelo(id_modelo int primary key identity(1,1), modelo varchar(100))

create table tb_PCBModelo(id_PM int primary key identity(1,1), id_pcb int, id_modelo int, descripcion varchar(255), nomenclatura varchar(50)
foreign key(id_pcb) references tb_PCB(id_pcb) on delete cascade on update cascade,
foreign key(id_modelo) references tb_Modelo(id_modelo) on delete cascade on update cascade)

create table tb_SIM(id_sim int primary key identity(1,1), sim varchar(50))

create table tb_ModeloModem(id_mm int primary key identity(1,1), modelo varchar(20), numero int)

create table tb_ScanModem(id_scanmodem int primary key identity(1,1), SerialModem varchar(50), Modelo varchar(20), id_modeloOrden int,
foreign key(id_modeloOrden) references tb_ModeloOrden(id_modeloOrden))

--ALTER TABLE tb_ScanModem
--    ADD id_modeloOrden INT,
--    ADD CONSTRAINT FOREIGN KEY(id_modeloOrden) REFERENCES tb_ModeloOrden(id_modeloOrden);

create table tb_ScanSim(id_scansim int primary key identity(1,1), id_sim int, id_ModeloOrden int,
foreign key(id_sim) references tb_SIM(id_sim) on delete cascade on update cascade,
foreign key(id_ModeloOrden) references tb_ModeloOrden(id_ModeloOrden))

create table tb_Operador(id_operador int primary key identity(1,1), nombre varchar(100), numeroempleado int)

create table tb_Orden(id_orden int primary key identity(1,1), orden float unique, cantidad int, fechaOrden date, FechaCierre date, id_operador int, id_pcb int, id_modelo int, id_sim int,
foreign key(id_operador) references tb_Operador(id_operador),
foreign key(id_sim) references tb_SIM(id_sim) on delete cascade on update cascade,
foreign key(id_pcb) references tb_PCB(id_pcb) on delete cascade on update cascade,
foreign key(id_modelo) references tb_Modelo(id_modelo) on delete cascade on update cascade)

create table tb_ModeloOrden(id_modeloOrden int primary key identity(1,1), scanmodem varchar(100), scansim varchar(100), Serialnumber varchar(255) unique, id_orden int, checked bit, fecharegistro datetime, id_caja int, Prueba bit, Problema varchar(255),
foreign key(id_orden) references tb_Orden(id_orden) on delete cascade on update cascade,
foreign key(id_caja) references tb_Caja(id_caja) on delete cascade on update cascade)

create table tb_caja(id_caja int primary key identity(1,1), caja int unique, id_pallette int,
foreign key(id_pallette) references tb_Pallette(id_pallette))

create table tb_Pallette(id_pallette int primary key identity(1,1), pallette int unique)

create table ConfiguracionSistema(id_cs int primary key identity(1,1), consecutivo int, nomenclatura varchar(50), numrocaja int, numeropallette int, conexion varchar(100), TotalCajas bit)

create table tb_Test(id_prueba int primary key identity(1,1), Nbr varchar(255), SerNum varchar(255), MN varchar(255), SN varchar(255), AV varchar(255), CGMI varchar(255),
CGMM varchar(255), CGMR varchar(255), CFVR varchar(255), CGSN varchar(255), MEID varchar(255), IMSI varchar(255), SChex varchar(255))

create table tb_CajaVerificar(id_cv int primary key identity(1,1), serialnumber varchar(255), serialnumberComprobar varchar(255) ,id_orden int, id_caja int, checked bit,
foreign key(id_orden) references tb_Orden(id_orden) on delete cascade on update cascade,
foreign key(id_caja) references tb_Caja(id_caja) on delete cascade on update cascade)

select * from ConfiguracionSistema


go
create trigger Crear_pallette on tb_caja
after insert,update as begin
declare @contador as int
declare @nuevo as int
declare @pallette as int
declare @numeropallette as int
declare @ContadorCajas as int
set @ContadorCajas = (select COUNT(*) from ConfiguracionSistema where id_cs = 2 and TotalCajas = 1) 
set @numeropallette = (select TOP 1 pallette from tb_Pallette order by id_pallette desc)
set @TopPellette = (select CajaPallette from ConfiguracionSistema where id_cs = 3)
set @contador = (select numeropallette from ConfiguracionSistema where id_cs = 3)
if @contador <= @TopPellette and @ContadorCajas = 0
	begin
		set @contador = @contador + 1
		set @pallette = (select TOP 1 id_pallette from tb_Pallette order by id_pallette desc)
		update tb_caja set id_pallette = @pallette where id_caja = (select id_caja from inserted)
		update ConfiguracionSistema set numeropallette = @contador where id_cs = 3
		---------------
	end
else
	begin
		------------------------------------------------
		set @numeropallette = @numeropallette + 1
		update ConfiguracionSistema set numeropallette = @numeropallette where id_cs = 3
		insert into tb_Pallette values(@numeropallette) 
		set @pallette = (select TOP 1 id_pallette from tb_Pallette order by id_pallette desc)
		update tb_caja set id_pallette = @pallette where id_caja = (select id_caja from inserted)
		update ConfiguracionSistema set TotalCajas = 0 where id_cs = 2
	end
end


---------Probar que se creen cajas nuevas con la nueva orden ------------------------------
------------Genera los modelos que requiere la orden---------------
go
ALTER trigger Crear_ordenes on tb_Orden
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
while @count <= @numero+1
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


-----------Scanmodem
--Cuando se inserta en la tabla tb_ModeloOrden se inserta en la tabla tb_ScanModem
go
create trigger Insertar_id_ScanModem on tb_ModeloOrden
after insert as begin
declare @id as int
set @id = (select id_modeloOrden from inserted)
insert into tb_ScanModem (id_modeloOrden) values(@id)
insert into tb_ScanSim (id_modeloOrden) values(@id)
end



go
create trigger ActualizarScanmodem on tb_ModeloOrden
after update as begin
declare @ScanModem as varchar(100)
declare @id_sim as int
declare @id as int
declare @Numeromodelo as varchar(20)
declare @modelo as varchar(50)
declare @serial as varchar(50)
set @ScanModem = (select scanmodem from inserted)
set @Numeromodelo = (select SUBSTRING(@ScanModem,1,2) from inserted)
set @serial = (select SUBSTRING(@ScanModem,1,15) from inserted)
set @modelo = (select top 1 modelo from tb_ModeloModem where numero = @Numeromodelo)
set @id = (select id_modeloOrden from inserted)
set @id_sim = (select o.id_sim from tb_ModeloOrden mo, tb_Orden o where mo.id_orden = o.id_orden and mo.id_modeloOrden = @id)
update tb_ScanModem set SerialModem = @serial, Modelo = @modelo where id_modeloOrden = @id
update tb_ScanSim set id_sim = @id_sim
end

--STORE PROCEDURE REPORTES
go
alter procedure sp_Reports
@orden as varchar(50)
as begin
declare @id_orden as int

set @id_orden = (select id_orden from tb_Orden where orden = @orden)

select distinct mo.id_modeloOrden, m.modelo,s.sim, mo.Serialnumber, mo.scanmodem, mo.scansim, mo.fecharegistro, o.orden, sm.Modelo, o.Revision, o.RevisionFirmware ,c.caja, p.pallette, op.numeroempleado
from tb_ModeloOrden mo inner join tb_Orden o on mo.id_orden = o.id_orden left join tb_caja c on mo.id_caja = c.id_caja left join tb_Pallette p on c.id_pallette = p.id_pallette left join tb_ScanModem sm on mo.id_modeloOrden = sm.id_modeloOrden left join tb_Modelo m on m.id_modelo = o.id_modelo left join tb_SIM s on s.id_sim = o.id_sim left join tb_Operador op on op.id_operador = o.id_operador
where mo.id_orden =@id_orden order by mo.id_modeloOrden asc 

END

select distinct mo.id_modeloOrden, m.modelo,s.sim, mo.Serialnumber, mo.scanmodem, mo.scansim, mo.fecharegistro, o.orden, sm.Modelo, o.Revision, o.RevisionFirmware ,c.caja, p.pallette, op.numeroempleado
from tb_ModeloOrden mo inner join tb_Orden o on mo.id_orden = o.id_orden left join tb_caja c on mo.id_caja = c.id_caja left join tb_Pallette p on c.id_pallette = p.id_pallette left join tb_ScanModem sm on mo.id_modeloOrden = sm.id_modeloOrden left join tb_Modelo m on m.id_modelo = o.id_modelo left join tb_SIM s on s.id_sim = o.id_sim left join tb_Operador op on op.id_operador = o.id_operador
where mo.id_orden = 52 order by mo.id_modeloOrden asc 

exec sp_Reports 1.1
select id_orden from tb_Orden where orden = 1.5
select * from tb_Orden

--STORE PROCEDURE PARA SHIPPING 
go
create procedure sp_CrearTablaShipping
as begin
create table tb_Shipping(id_shipping int primary key identity(1,1), shipping_date datetime,modeloPCB varchar(255), sim varchar(255), Serialnumber varchar(255), scanmodem varchar(255), scansim varchar(255),modelo varchar(255), orden varchar(50), fecharegistro datetime, caja int, pallette int, revision varchar(20), revisonFrimware varchar(50), numeroemplado int)
END

go
create procedure sp_BorrarTabla
as begin
drop table tb_Shipping
end
-- END STORE PROCEDURE SHIPPING
go
create procedure sp_Shipping 
@id_pallette as int 
as begin 
DECLARE @modeloPCB varchar(255) -- or the appropriate type
Declare @sim varchar(255)
Declare @serialnumber varchar(255)
Declare @scanmodem varchar(255)
Declare @scansim varchar(255)
Declare @modelo varchar(255)
Declare @orden varchar(255)
Declare @fecharegistro datetime
Declare @caja varchar(255)
Declare @pallette varchar(255)
Declare @revision varchar(255)
Declare @revisionFrimware varchar(255)
Declare @numeroempleado int


DECLARE the_cursor CURSOR FAST_FORWARD
FOR select distinct m.modelo, s.sim,mo.Serialnumber, mo.scanmodem, mo.scansim, sm.Modelo,o.orden, mo.fecharegistro, c.caja, p.pallette,o.revision, o.RevisionFirmware,op.numeroempleado 
from tb_ModeloOrden mo left join tb_Orden o on o.id_orden = mo.id_orden left join tb_Modelo m on m.id_modelo = o.id_modelo left join tb_caja c on c.id_caja = mo.id_caja left join tb_Operador op on op.id_operador = o.id_operador left join tb_SIM s on s.id_sim = o.id_sim  left join tb_ScanModem sm on sm.id_modeloOrden = mo.id_modeloOrden left join tb_Pallette p on p.id_pallette = c.id_pallette
where p.id_pallette = @id_pallette order by p.pallette asc

OPEN the_cursor
FETCH NEXT FROM the_cursor INTO @modeloPCB, @sim,@serialnumber, @scanmodem, @scansim, @modelo,@orden, @fecharegistro, @caja, @pallette, @revision, @revisionfrimware,@numeroempleado

WHILE @@FETCH_STATUS = 0
BEGIN
    
	insert into tb_Shipping(modeloPCB, sim,serialnumber, scanmodem, scansim,modelo,orden,fecharegistro,shipping_date,caja,pallette,revision,revisonFrimware,numeroemplado) 
	values(@modeloPCB, @sim,@serialnumber, @scanmodem, @scansim, @modelo,@orden, @fecharegistro, GETDATE(),@caja, @pallette, @revision, @revisionfrimware,@numeroempleado)

	--update tb_orden set Restantes = (select cantidad - (select COUNT(*) from tb_ModeloOrden where id_orden = @oneid ) as Restante from tb_Orden where id_orden = @oneid) where id_orden = @oneid

    FETCH NEXT FROM the_cursor INTO @modeloPCB, @sim,@serialnumber, @scanmodem, @scansim, @modelo,@orden, @fecharegistro, @caja, @pallette, @revision, @revisionfrimware,@numeroempleado
end
END
--ESTATUS DE LAS ORDENES
go
create procedure sp_EstatusOrdenes
@id_orden as int --Borrar
as begin 
DECLARE @oneid int -- or the appropriate type

DECLARE the_cursor CURSOR FAST_FORWARD
FOR SELECT id_orden FROM tb_Orden

OPEN the_cursor
FETCH NEXT FROM the_cursor INTO @oneid

WHILE @@FETCH_STATUS = 0
BEGIN
    
	update tb_orden set Restantes = (select cantidad - (select COUNT(scanmodem) from tb_ModeloOrden where id_orden = @oneid ) as Restante from tb_Orden where id_orden = @oneid) where id_orden = @oneid

    FETCH NEXT FROM the_cursor INTO @oneid
END

CLOSE the_cursor
DEALLOCATE the_cursor
end


update tb_orden set Restantes = (select cantidad - (select COUNT(*) from tb_ModeloOrden where id_orden = @oneid ) as Restante from tb_Orden where id_orden = @oneid) where id_orden = @oneid


select COUNT(scanmodem) from tb_ModeloOrden where id_orden = 21
select * from tb_Orden
select * from tb_ModeloOrden
--Cada 6 unidades es una caja y cada 35 cajas es un pallete
--go
--create trigger CrearCaja on tb_ModeloOrden
--after update as begin
--declare @id_ModeloOrden as int
--declare @id_Caja as int
--declare @Caja as int
--declare @NumeroCaja as int 
--declare @Contador as int
--set @id_Caja = (select TOP 1 caja from tb_caja order by id_caja desc)
--set @id_ModeloOrden = (select id_modeloOrden from inserted)
--set @Caja = (select caja from tb_caja where id_caja = @id_Caja)
--update tb_ModeloOrden set id_caja = @id_Caja
--set @Contador = @Contador + 1
--if @Contador <= 6
--begin
--	set @Caja = @Caja + 1
--	insert into tb_caja (caja) values(@Caja)
--end
--end

select * from tb_ModeloOrden where fecharegistro = ''
select * from tb_Orden


select distinct COUNT(m.modelo, s.sim,mo.Serialnumber, mo.scanmodem, mo.scansim, sm.Modelo,o.orden, mo.fecharegistro, c.caja, p.pallette,o.revision, o.RevisionFirmware,op.numeroempleado )
from tb_ModeloOrden mo left join tb_Orden o on o.id_orden = mo.id_orden left join tb_Modelo m on m.id_modelo = o.id_modelo left join tb_caja c on c.id_caja = mo.id_caja left join tb_Operador op on op.id_operador = o.id_operador left join tb_SIM s on s.id_sim = o.id_sim  left join tb_ScanModem sm on sm.id_modeloOrden = mo.id_modeloOrden
left join tb_Pallette p on p.id_pallette = c.id_pallette
where p.id_pallette = 473

	select * from tb_caja where id_pallette = 473
	select * from tb_pcb
	select * from tb_Pallette where id_pallette = 473

	select COUNT(*) from tb_pallette where pallette = '2' and pallette != '' 

insert into tb_orden (orden, cantidad, fechaOrden, id_modelo, id_pcb, id_sim, id_operador, Ucaja,RevisionFirmware, Revision) values(8.6 , 100 , '09/11/2019',8,1,1,2,3,'V1.23','F')

select COUNT(mo.id_modeloOrden) 
from tb_ModeloOrden mo left join tb_Orden o on o.id_orden = mo.id_orden left join tb_Modelo m on m.id_modelo = o.id_modelo left join tb_caja c on c.id_caja = mo.id_caja left join tb_Operador op on op.id_operador = o.id_operador left join tb_SIM s on s.id_sim = o.id_sim  left join tb_ScanModem sm on sm.id_modeloOrden = mo.id_modeloOrden left join tb_Pallette p on p.id_pallette = c.id_pallette
where p.id_pallette = 472 


select distinct mo.id_modeloOrden, m.modelo,s.sim, mo.Serialnumber, mo.scanmodem, mo.scansim, mo.fecharegistro, o.orden, sm.Modelo, o.Revision, o.RevisionFirmware ,c.caja, p.pallette, op.numeroempleado
from tb_ModeloOrden mo inner join tb_Orden o on mo.id_orden = o.id_orden left join tb_caja c on mo.id_caja = c.id_caja left join tb_Pallette p on c.id_pallette = p.id_pallette left join tb_ScanModem sm on mo.id_modeloOrden = sm.id_modeloOrden left join tb_Modelo m on m.id_modelo = o.id_modelo left join tb_SIM s on s.id_sim = o.id_sim left join tb_Operador op on op.id_operador = o.id_operador
where mo.id_orden =52 order by mo.id_modeloOrden asc 

select * from tb_Orden
select cantidad from tb_Orden where id_orden = 52
select COUNT(scanmodem) from tb_ModeloOrden where id_orden = 52



select distinct mo.id_modeloOrden, mo.scanmodem, mo.scansim, mo.Serialnumber, mo.fecharegistro, o.orden, sm.Modelo,c.caja, p.pallette from tb_ModeloOrden mo inner join tb_Orden o on mo.id_orden = o.id_orden left join tb_caja c on mo.id_caja = c.id_caja left join tb_Pallette p on c.id_pallette = p.id_pallette left join tb_ScanModem sm on mo.id_modeloOrden = sm.id_modeloOrden where mo.id_orden = 52 order by mo.id_modeloOrden asc


insert into tb_orden (orden, cantidad, fechaOrden, id_modelo, id_pcb, id_sim, id_operador, RevisionFirmware, Revision) values(1.4 , 100 , '10/25/2019',2,1,1,1,'kk','l')