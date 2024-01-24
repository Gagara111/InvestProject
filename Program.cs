using Microsoft.Data.Sqlite;
using System.Data;

var connection = new SqliteConnection("Data Source = MainDate.db");// вводим имя переменной
connection.Open();//открываем соединение

//подготовим команду которую отправляем в б/д
var comand = new SqliteCommand(); // Создали переменную для команды 
//устанавливаем связь б/д по данному соединению  для команды
comand.Connection = connection;
comand.CommandType = CommandType.Text;
comand.CommandText = @"CREATE TABLE [MainTable] (
	[id]	INTEGER NOT NULL UNIQUE,
	[UserId] INTEGER NOT NULL,
	[time]	datetime,
	[Price]	float,
	[Count]	INTEGER,
	[TypeOrderId]	INTEGER,
	PRIMARY KEY([id] AUTOINCREMENT)
);

CREATE TABLE [USER] (
	[id]	INTEGER NOT NULL UNIQUE,
	[FullName]	TEXT NOT NULL,
	[ShortName]	TEXT NOT NULL,
	PRIMARY KEY([id] AUTOINCREMENT)
);

CREATE TABLE [OrderTypes] (
	[id] INTEGER NOT NULL UNIQUE,
	[TypeOrderNow]	INTEGER,
	[OrderLimit]	INTEGER,
	PRIMARY KEY([id] AUTOINCREMENT)
);";
comand.ExecuteNonQuery();//отправляет запрос в б/д
connection.Close();//закрываем соединение в конце работы
