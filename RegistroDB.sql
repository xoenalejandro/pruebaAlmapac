ATTACH 'RegistroDB.sqlite' AS RegistroDB;

CREATE TABLE RegistroDB.User (
    Id TEXT PRIMARY KEY,
    Name TEXT,
    Email TEXT,
    Password TEXT,
    Created DATETIME,
    Modified DATETIME,
    LastLogin DATETIME,
    Token TEXT,
    IsActive INTEGER
);

CREATE TABLE RegistroDB.phones (
    Id TEXT PRIMARY KEY,
    Number TEXT,
    CityCode TEXT,
    CountryCode TEXT,
    UserId TEXT,
    FOREIGN KEY(UserId) REFERENCES User(Id)
);

DETACH RegistroDB;