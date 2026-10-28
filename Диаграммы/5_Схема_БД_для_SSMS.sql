/*
  Структура базы «Ювелирная мастерская» для Microsoft SQL Server.
  Нужна только для того, чтобы SSMS построил ER-диаграмму автоматически:
  1. Откройте этот файл в SSMS и нажмите «Выполнить» (F5).
  2. В «Обозревателе объектов» раскройте Базы данных -> ЮвелирнаяМастерская.
  3. ПКМ по «Диаграммы баз данных» -> «Создать диаграмму базы данных»,
     выделите все таблицы -> «Добавить».
  Само приложение продолжает работать со своей базой SQLite, этот скрипт его не трогает.
*/

IF DB_ID(N'ЮвелирнаяМастерская') IS NULL
    CREATE DATABASE ЮвелирнаяМастерская;
GO
USE ЮвелирнаяМастерская;
GO

-- Справочники
CREATE TABLE Роли (
    id            INT IDENTITY PRIMARY KEY,
    название_роли NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Статусы_заявок (
    id               INT IDENTITY PRIMARY KEY,
    название_статуса NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Металлы (
    id               INT IDENTITY PRIMARY KEY,
    название_металла NVARCHAR(100) NOT NULL UNIQUE,
    цена_скупки      FLOAT,
    цена_работы      FLOAT
);

CREATE TABLE Камни (
    id             INT IDENTITY PRIMARY KEY,
    название_камня NVARCHAR(100) NOT NULL UNIQUE,
    цена_за_штуку  FLOAT
);

CREATE TABLE Прайс_лист_ремонта (
    id           INT IDENTITY PRIMARY KEY,
    вид_поломки  NVARCHAR(200) NOT NULL UNIQUE,
    стоимость    FLOAT,
    срок_ремонта NVARCHAR(50)
);

-- Пользователи
CREATE TABLE Пользователи (
    id      INT IDENTITY PRIMARY KEY,
    логин   NVARCHAR(100) NOT NULL UNIQUE,
    пароль  NVARCHAR(64)  NOT NULL,
    id_роли INT REFERENCES Роли(id) ON DELETE CASCADE
);

-- Заявки и сделки
CREATE TABLE Заявки_на_изготовление (
    id              INT IDENTITY PRIMARY KEY,
    id_пользователя INT REFERENCES Пользователи(id) ON DELETE CASCADE,
    id_металла      INT REFERENCES Металлы(id),
    id_камня        INT REFERENCES Камни(id),
    id_статуса      INT REFERENCES Статусы_заявок(id),
    тип_изделия     NVARCHAR(100),
    пожелания       NVARCHAR(MAX),
    дата_создания   NVARCHAR(20),
    телефон         NVARCHAR(30),
    путь_к_эскизу   NVARCHAR(500)
);

CREATE TABLE Заявки_на_ремонт (
    id                 INT IDENTITY PRIMARY KEY,
    id_пользователя    INT REFERENCES Пользователи(id) ON DELETE CASCADE,
    id_услуги          INT REFERENCES Прайс_лист_ремонта(id),
    id_статуса         INT REFERENCES Статусы_заявок(id),
    дата_создания      NVARCHAR(20),
    телефон            NVARCHAR(30),
    итоговая_стоимость FLOAT
);

CREATE TABLE Сделки_скупки (
    id              INT IDENTITY PRIMARY KEY,
    id_пользователя INT REFERENCES Пользователи(id) ON DELETE CASCADE,
    id_металла      INT REFERENCES Металлы(id),
    вес             FLOAT,
    сумма_выплаты   FLOAT,
    дата_создания   NVARCHAR(20),
    телефон         NVARCHAR(30)
);

-- Общий журнал заявок клиента
CREATE TABLE Журнал_заявок (
    id              INT IDENTITY PRIMARY KEY,
    id_пользователя INT REFERENCES Пользователи(id) ON DELETE CASCADE,
    тип_заявки      NVARCHAR(30),
    id_заявки       INT,
    дата_добавления NVARCHAR(20),
    текущий_статус  NVARCHAR(50),
    телефон         NVARCHAR(30)
);
GO
