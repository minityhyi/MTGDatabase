
IF NOT EXISTS (select * from sysobjects where name='Decks')
	CREATE TABLE Decks(
	Id INTEGER PRIMARY KEY IDENTITY(1,1),
	DeckName VARCHAR(255)
)
go

IF NOT EXISTS (select * from sysobjects where name='Cards')
	CREATE TABLE Cards(
	Id INTEGER PRIMARY KEY IDENTITY(1,1),
	DeckId INTEGER,
	CardName VARCHAR(255),
	ManaValue VARCHAR(255),
	Colors VARCHAR(255),
	CardType VARCHAR(255),
	CreaturePower VARCHAR(255),
	CreatureToughness VARCHAR(255),
	PlaneswalkerLoyalty VARCHAR(255),
	IsSideBoard BIT DEFAULT 'False',
	FOREIGN KEY (DeckId) references Decks(Id)
)
go