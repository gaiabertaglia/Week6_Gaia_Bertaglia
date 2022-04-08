create database ProvaAgenti

create table Agente(
Nome varchar(40) not null,
Cognome varchar(60) not null,
CodiceFiscale varchar(16) not null, 
AreaGeografica varchar(5) not null,
AnnoDiInizioAttivita int not null,
)

insert into Agente values('Gaia','Bertaglia','BRTGAI97B','BLU4',2015), ('Maria','Bianchi','BMRIA64HF78','ROSA2',2000);

select * from Agente;

--- Scelta un’area geografica, mostrare gli agenti assegnati a quell’area

select *
from Agente
where AreaGeografica = 'BLU4'

select distinct Agente.AreaGeografica
from Agente

select *
from Agente
where AnnoDiInizioAttivita <= 2000


