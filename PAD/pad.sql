create database pad
go
use pad

create table loging
(
id_login int identity(1,1) primary key ,
usuario nvarchar(50),
passwordd nvarchar(50),
cargo nvarchar(50)
)

create table tramite_bachiller
(
id_bachiller int identity(1,1) primary key ,
revisado date,
remitodo_observado nvarchar(50),
observacion_corregida nvarchar(50),
segunda_observacion nvarchar(50),
ok_numero char(8),
fecha_ok nvarchar(50) ,
id_persona int
foreign key (id_persona) references persona (id_persona),
)
create table tramite_titulado
(
id_titulado int identity(1,1) primary key ,
revisado date,
remitodo_observado nvarchar(50),

observacion_corregida nvarchar(50),

segunda_observacion nvarchar(50),

ok_numero char(8),
fecha_ok nvarchar(50),
id_persona int
foreign key (id_persona) references persona (id_persona),

)

create table tramite
(
id_tramite int identity(1,1) primary key ,
nomtr_tramitante nvarchar(50),
)
create table persona
(
id_persona int identity(1,1) primary key ,
nombre nvarchar(50),
apellidos nvarchar(50),
id_tramite int,
foreign key (id_tramite) references tramite (id_tramite)
)
insert into loging values ('admin','root','administrador')
insert into loging values ('admin','123','usuarios')
insert into loging values ('grado','andy','administrador')
select*from loging
insert into tramite_titulado values('','','','',1,'')

insert into tramite_bachiller values ('','','','',1,'')
insert  into  tramite values (''),('BACHILLER'),('TITULADO')
create proc listaregresado
as
select id_tramite , nomtr_tramitante from tramite order by nomtr_tramitante asc
go
exec listaregresado

							
							select*from  loging
							select *from loging where usuario='admin'  and passwordd='root'
							select *from loging where usuario='admin' and passwordd='root'
							
							create proc admin
							@usuario nvarchar(50),
							@passowrd nvarchar(50)
							as
							select *from loging
							where usuario=@usuario and passwordd=@passowrd
							go
							 exec admin 'admin','root'
						 
						 create proc buscar_bachiller
						 @filtro nvarchar(50)
						 as
						 select p.id_persona as numero ,apellidos,nombre,nomtr_tramitante AS TRAMITANTE,revisado,remitodo_observado,observacion_corregida,segunda_observacion,ok_numero,fecha_OK						
							 from persona p inner join tramite tr
							 on p.id_tramite=tr.id_tramite
							 inner join tramite_bachiller t
							 on p.id_persona=t.id_persona      
							 where apellidos like  @filtro +'%'
							 go


							 select id_persona as numero ,apellidos,nombre,nomtr_tramitante AS TRAMITANTE from persona p   inner join tramite t on p.id_tramite = t.id_tramite

							create proc motrarpersona_titulado
							as 
							select id_persona as numero ,apellidos,nombre,nomtr_tramitante AS TRAMITANTE
							 from persona  p   inner join    tramite t
							 on p.id_tramite=t.id_tramite  
							 where nomtr_tramitante='TITULADO'                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
							go

							create proc motrarpersona_bachiller
							as 
							select id_persona as numero ,apellidos,nombre,nomtr_tramitante AS TRAMITANTE
							 from persona  p   inner join    tramite t
							 on p.id_tramite=t.id_tramite  
							 where nomtr_tramitante='BACHILLER'                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
							go
							exec  motrarpersona_bachiller
							select *from persona
							create proc insertarpersona
							
							@nombre nvarchar(50),
							@apellidos nvarchar(50),	
							@tramitante int
							as
							insert into persona values (@nombre,@apellidos,@tramitante )
							go
							exec  insertarpersona 'andy','cuellar quino',1

							create proc editarpersona
							@nombre nvarchar(50),
							@apellidos nvarchar(50),
							@tramitante int,
							@id int
							as
							update persona set nombre=@nombre,apellidos=@apellidos,id_tramite=@tramitante
							where id_persona=@id
							go
							exec editarpersona 'jose','marsiso loc',3,1
							select*from persona

							create proc eliminar
							@idpro int
							as
							delete from persona where id_persona=@idpro
							go

							exec eliminar 1
							----------------------------------------------------------------------------------------------------------------------------------------------------------------

							create proc motrar_tr_titulado
							as 
							select id_titulado as Nr_titulado, p.id_persona as numero ,apellidos,nombre,nomtr_tramitante AS TRAMITANTE,revisado,remitodo_observado,observacion_corregida,segunda_observacion,ok_numero,fecha_OK						
							 from persona p inner join tramite tr
							 on p.id_tramite=tr.id_tramite
							 inner join tramite_titulado t
							 on p.id_persona=t.id_persona                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
							go
							 	exec insertartitulado
								
							create proc insertartitulado
							
							@revisado date,
							@remitido_revisado nvarchar(50),
							
							@observacion_corregida nvarchar(50),
							
							@segunda_observacion nvarchar(50),
						
							@ok_numero char(8),
					
							@fecha_ok nvarchar(50),
							@numero_persona int
							as
							insert into tramite_titulado values (@revisado,@remitido_revisado,@observacion_corregida,@segunda_observacion,@ok_numero,@fecha_ok,@numero_persona )
							go
							exec insertartitulado '26-02-2018','26-02-2018','26-02-2018','26-02-2018','' ,'26-02-2018',1


							 create proc editartitulado
								
							@revisado date,
							@remitido_revisado nvarchar(50),
							@observacion_corregida nvarchar(50),
							@segunda_observacion nvarchar(50),
							@ok_numero char(8),				
							@fecha_ok nvarchar(50),
							@numero_persona int,
							@id int
							as
							update tramite_titulado set revisado=@revisado,remitodo_observado=@remitido_revisado,observacion_corregida=@observacion_corregida,
							segunda_observacion=@segunda_observacion,ok_numero=@ok_numero,fecha_ok=@fecha_ok,id_persona=@numero_persona
							where id_titulado=@id
							go

				        	exec editartitulado '2018-07-01','2018-07-01','2018-07-01','2018-07-01',100,'2018-07-01',2,8
							select*from tramite_titulado
							insert  into  tramite_titulado values ('26-02-2018','26-02-2018','26-02-2018',2)	
								
								select*from tramite
								select*from persona
									select*from tramite_titulado

									
						create proc eliminar_titulado
							@idpro int
							as
							delete from tramite_titulado where id_titulado=@idpro
							go

							exec eliminar_titulado 8

						-----------------------------------------------------------------------------------------------------------------------------------------------------------
							create proc motrar_tr_bachiller
							as 
							select id_bachiller as Nr_bachillar ,p.id_persona as numero ,apellidos,nombre,nomtr_tramitante AS TRAMITANTE,revisado,remitodo_observado,observacion_corregida,segunda_observacion,ok_numero,fecha_OK						
							 from persona p inner join tramite tr
							 on p.id_tramite=tr.id_tramite
							 inner join  tramite_bachiller b
							 on p.id_persona=b.id_persona                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
							go
							select*from tramite_bachiller
							
							
							create proc insertarbachillar
							
							@revisado date,
							@remitido_revisado nvarchar(50),
							@observacion_corregida nvarchar(50),
							@segunda_observacion nvarchar(50),
							@ok_numero char(8),
							@fecha_ok nvarchar(50),
							@numero_persona int
							as
							insert into tramite_bachiller values (@revisado,@remitido_revisado,@observacion_corregida,@segunda_observacion,@ok_numero,@fecha_ok,@numero_persona )
							go
                           
						    create proc editarbachiller
								
							@revisado date,
							@remitido_revisado nvarchar(50),
							@observacion_corregida nvarchar(50),
							@segunda_observacion nvarchar(50),
							@ok_numero char(8),				
							@fecha_ok nvarchar(50),
							@numero_persona int,
							@id int
							as
							update tramite_bachiller set revisado=@revisado,remitodo_observado=@remitido_revisado,observacion_corregida=@observacion_corregida,
							segunda_observacion=@segunda_observacion,ok_numero=@ok_numero,fecha_ok=@fecha_ok,id_persona=@numero_persona
							where id_bachiller=@id
							go
							exec editarbachiller
							create proc eliminar_bachiller
							@idpro int
							as
							delete from tramite_bachiller where id_bachiller=@idpro
							go










-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

use pad
select *from persona
select count (id_persona )from persona p inner join
tramite t on t.id_tramite=p.id_tramite
where nomtr_tramitante='TITULADO'

select count (id_persona )from persona p inner join
tramite t on t.id_tramite=p.id_tramite
where nomtr_tramitante='BACHILLER'

select count (id_persona )from persona p inner join
tramite t on t.id_tramite=p.id_tramite

create proc numero
@numer_titualados int out ,
@umero_bachiler int out,
@numero_tramitante int out
as
set @numer_titualados=(select count (id_persona )from persona p inner join
tramite t on t.id_tramite=p.id_tramite
where nomtr_tramitante='TITULADO')
set @umero_bachiler=(select count (id_persona )from persona p inner join
tramite t on t.id_tramite=p.id_tramite
where nomtr_tramitante='BACHILLER')
set @numero_tramitante=(select count (id_persona )from persona p inner join
tramite t on t.id_tramite=p.id_tramite)
go


create proc fecha_bachiller
@fecha date
as
select p.id_persona as numero ,apellidos,nombre,t.nomtr_tramitante AS TRAMITANTE from persona p inner join tramite_bachiller b
on p.id_persona =b.id_persona
inner join tramite t
on p.id_tramite=t.id_tramite
where revisado=@fecha
go

create proc fecha_titulado
@fecha date
as
select p.id_persona as numero ,apellidos,nombre,t.nomtr_tramitante AS TRAMITANTE from persona p inner join tramite_titulado ti
on p.id_persona =ti.id_persona
inner join tramite t
on p.id_tramite=t.id_tramite
where revisado=@fecha
go


