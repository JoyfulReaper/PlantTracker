BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Activity" (
	"ActivityId"	INTEGER,
	"Name"	TEXT NOT NULL UNIQUE,
	PRIMARY KEY("ActivityId")
);
CREATE TABLE IF NOT EXISTS "Note" (
	"NoteId"	INTEGER,
	"Text"	TEXT NOT NULL,
	PRIMARY KEY("NoteId")
);
CREATE TABLE IF NOT EXISTS "Plant" (
	"PlantId"	INTEGER,
	"Name"	TEXT NOT NULL,
	"Location"	TEXT,
	"PlantPhotoId"	INTEGER,
	PRIMARY KEY("PlantId"),
	FOREIGN KEY("PlantPhotoId") REFERENCES "PlantPhoto"("PlantPhotoId")
);
CREATE TABLE IF NOT EXISTS "PlantActivity" (
	"PlantActivityId"	INTEGER,
	"PlantId"	INTEGER NOT NULL,
	"ActivityId"	INTEGER NOT NULL,
	"ActivityDate"	TEXT DEFAULT 'DATETIME()',
	FOREIGN KEY("PlantId") REFERENCES "Plant"("PlantId"),
	FOREIGN KEY("ActivityId") REFERENCES "sqlite_sequence",
	PRIMARY KEY("PlantActivityId")
);
CREATE TABLE IF NOT EXISTS "PlantNote" (
	"PlantNoteId"	INTEGER,
	"PlantId"	INTEGER NOT NULL,
	"NoteDate"  TEXT NOT NULL DEFAULT (DATETIME('now')),
	FOREIGN KEY("PlantId") REFERENCES "Plant"("PlantId"),
	PRIMARY KEY("PlantNoteId")
);
CREATE TABLE IF NOT EXISTS "PlantPhoto" (
	"PlantPhotoId"	INTEGER,
	"PlantId"	INTEGER NOT NULL,
	"Photo"	BLOB NOT NULL,
	"PhotoContentType"	TEXT NOT NULL,
	"DateAdded"	TEXT NOT NULL DEFAULT (DATETIME('now')),
	FOREIGN KEY("PlantId") REFERENCES "Plant"("PlantId"),
	PRIMARY KEY("PlantPhotoId")
);
INSERT OR IGNORE INTO "Activity" VALUES (1,'Created');
INSERT OR IGNORE INTO "Activity" VALUES (2,'Watered');
INSERT OR IGNORE INTO "Activity" VALUES (3,'Fertilized');
COMMIT;
