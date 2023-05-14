create table mpilalao(
    idMpilalao INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    anaranaMpilalao VARCHAR(40) NOT NULL CHECK (anaranaMpilalao <> '' AND anaranaMpilalao <> ' '),
    vola NUMERIC
);

create table lalao(
    idLalao INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    idMpilalao1 INTEGER NOT NULL REFERENCES mpilalao(idMpilalao),
    idMpilalao2 INTEGER NOT NULL REFERENCES mpilalao(idMpilalao),
    isaMpilalao1 INTEGER DEFAULT 0,
    isaMpilalao2 INTEGER DEFAULT 0,
    -- Efa niala ny prix Jeton
    fanamby INTEGER NOT NULL
    -- Impiry manao, izany hoe baolina firy
    manche INTEGER NOT NULL
);

create table statLalao(
    idStatLalao INTEGER PRIMARY KEY NOT NULL,
    idLalao INTEGER REFERENCES lalao(idLalao),
    idMpilalao INTEGER REFERENCES mpilalao(idMpilalao),
    isaMaty INTEGER NOT NULL
);

create table Babyfoot(
    idBabyfoot INTEGER NOT NULL PRIMARY KEY,
    vidinaJeton INTEGER NOT NULL,
    isaBaolina INTEGER NOT NULL
);

--NB : To make it more readable (sqlite) use '.mode column'

--Fampidirana andrana
insert into mpilalao (anaranaMpilalao, vola) values('RaKilabo', 30000);
insert into mpilalao (anaranaMpilalao, vola) values('Ilemafybe', 40000);

insert into Babyfoot (vidinaJeton, isaBaolina) values(50, 5);