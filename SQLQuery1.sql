﻿create table IMMUNISATION(
[RECORD ID] int not null primary key,
[PATIENT ID] varchar(25) NOT NULL,
VACCINE VARCHAR(20) NOT NULL,
[DOSE NUMBER] INT NOT NULL,
[BATCH NUMBER] VARCHAR(10),
[DATE IMMUNISED] DATETIME,
[DOCTOR OR NURSE ID] VARCHAR(20)
);

CREATE TABLE TREATMENTS(
[TREATMENT ID] INT NOT NULL PRIMARY KEY,
[PATIENT ID] VARCHAR(20) NOT NULL,
DISEASE VARCHAR(100) NOT NULL,
MEDICINE VARCHAR(100),
DOSAGE VARCHAR(500),
[DOCTOR OR NURSE ID] VARCHAR(20),
[DATE ADMINISTERED] DATETIME,
);

CREATE TABLE APPOINTMENTS(
[APPOINTMENT ID] INT NOT NULL PRIMARY KEY,
[DOCTOR OR NURSE ID] VARCHAR(20),
[PATIENT ID] VARCHAR(20) NOT NULL,
[DATE FOR APPOINTMENT] DATETIME,
[TIME FOR APPOINTMENT] DATETIME,
REASON VARCHAR(500)
);

CREATE TABLE [GROWTH TABLE](
[RECORD ID] INT NOT NULL PRIMARY KEY,
[PATIENT ID] VARCHAR(20) NOT NULL,
[AGE IN MONTHS] INT NOT NULL,
WEIGHT INT NULL,
HEIGHT INT NULL
);
