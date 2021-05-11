
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/15/2021 10:48:29
-- Generated from EDMX file: M:\Desktop\ASPnewProject\ASPcinema\Domains\ModelCinema.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FilmGenre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FilmSet] DROP CONSTRAINT [FK_FilmGenre];
GO
IF OBJECT_ID(N'[dbo].[FK_FilmAgeRating]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FilmSet] DROP CONSTRAINT [FK_FilmAgeRating];
GO
IF OBJECT_ID(N'[dbo].[FK_CinemaHallSeat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SeatSet] DROP CONSTRAINT [FK_CinemaHallSeat];
GO
IF OBJECT_ID(N'[dbo].[FK_FilmFilmSession]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FilmSessionSet] DROP CONSTRAINT [FK_FilmFilmSession];
GO
IF OBJECT_ID(N'[dbo].[FK_FilmSessionCinemaHall]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FilmSessionSet] DROP CONSTRAINT [FK_FilmSessionCinemaHall];
GO
IF OBJECT_ID(N'[dbo].[FK_SeatTicketSeat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SeatTicketSet] DROP CONSTRAINT [FK_SeatTicketSeat];
GO
IF OBJECT_ID(N'[dbo].[FK_SeatTicketFilmSession]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SeatTicketSet] DROP CONSTRAINT [FK_SeatTicketFilmSession];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FilmSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FilmSet];
GO
IF OBJECT_ID(N'[dbo].[GenreSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GenreSet];
GO
IF OBJECT_ID(N'[dbo].[AgeRatingSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AgeRatingSet];
GO
IF OBJECT_ID(N'[dbo].[CinemaHallSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CinemaHallSet];
GO
IF OBJECT_ID(N'[dbo].[SeatSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SeatSet];
GO
IF OBJECT_ID(N'[dbo].[FilmSessionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FilmSessionSet];
GO
IF OBJECT_ID(N'[dbo].[SeatTicketSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SeatTicketSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'FilmSet'
CREATE TABLE [dbo].[FilmSet] (
    [FilmID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [TimeLength] time  NOT NULL,
    [ImagePath] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [MoreGenres] nvarchar(max)  NOT NULL,
    [Actors] nvarchar(max)  NOT NULL,
    [Producer] nvarchar(max)  NOT NULL,
    [KinopoiskLink] nvarchar(max)  NOT NULL,
    [Genre_GenreID] int  NOT NULL,
    [AgeRating_AgeRatingID] int  NOT NULL
);
GO

-- Creating table 'GenreSet'
CREATE TABLE [dbo].[GenreSet] (
    [GenreID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AgeRatingSet'
CREATE TABLE [dbo].[AgeRatingSet] (
    [AgeRatingID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CinemaHallSet'
CREATE TABLE [dbo].[CinemaHallSet] (
    [CinemaHallID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [NumberOfSeats] int  NOT NULL,
    [IsVIP] bit  NOT NULL,
    [Is3D] bit  NOT NULL,
    [ImagePath] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SeatSet'
CREATE TABLE [dbo].[SeatSet] (
    [SeatID] int IDENTITY(1,1) NOT NULL,
    [SeatNumber] int  NOT NULL,
    [RowNumber] int  NOT NULL,
    [Occupied] bit  NOT NULL,
    [CinemaHall_CinemaHallID] int  NOT NULL
);
GO

-- Creating table 'FilmSessionSet'
CREATE TABLE [dbo].[FilmSessionSet] (
    [FilmSessionID] int IDENTITY(1,1) NOT NULL,
    [SessionDateTime] datetime  NOT NULL,
    [TicketPrice] int  NOT NULL,
    [Film_FilmID] int  NOT NULL,
    [CinemaHall_CinemaHallID] int  NOT NULL
);
GO

-- Creating table 'SeatTicketSet'
CREATE TABLE [dbo].[SeatTicketSet] (
    [SeatTicketID] int IDENTITY(1,1) NOT NULL,
    [Ended] bit  NOT NULL,
    [Price] int  NOT NULL,
    [Bought] bit  NOT NULL,
    [Seat_SeatID] int  NOT NULL,
    [FilmSession_FilmSessionID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [FilmID] in table 'FilmSet'
ALTER TABLE [dbo].[FilmSet]
ADD CONSTRAINT [PK_FilmSet]
    PRIMARY KEY CLUSTERED ([FilmID] ASC);
GO

-- Creating primary key on [GenreID] in table 'GenreSet'
ALTER TABLE [dbo].[GenreSet]
ADD CONSTRAINT [PK_GenreSet]
    PRIMARY KEY CLUSTERED ([GenreID] ASC);
GO

-- Creating primary key on [AgeRatingID] in table 'AgeRatingSet'
ALTER TABLE [dbo].[AgeRatingSet]
ADD CONSTRAINT [PK_AgeRatingSet]
    PRIMARY KEY CLUSTERED ([AgeRatingID] ASC);
GO

-- Creating primary key on [CinemaHallID] in table 'CinemaHallSet'
ALTER TABLE [dbo].[CinemaHallSet]
ADD CONSTRAINT [PK_CinemaHallSet]
    PRIMARY KEY CLUSTERED ([CinemaHallID] ASC);
GO

-- Creating primary key on [SeatID] in table 'SeatSet'
ALTER TABLE [dbo].[SeatSet]
ADD CONSTRAINT [PK_SeatSet]
    PRIMARY KEY CLUSTERED ([SeatID] ASC);
GO

-- Creating primary key on [FilmSessionID] in table 'FilmSessionSet'
ALTER TABLE [dbo].[FilmSessionSet]
ADD CONSTRAINT [PK_FilmSessionSet]
    PRIMARY KEY CLUSTERED ([FilmSessionID] ASC);
GO

-- Creating primary key on [SeatTicketID] in table 'SeatTicketSet'
ALTER TABLE [dbo].[SeatTicketSet]
ADD CONSTRAINT [PK_SeatTicketSet]
    PRIMARY KEY CLUSTERED ([SeatTicketID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Genre_GenreID] in table 'FilmSet'
ALTER TABLE [dbo].[FilmSet]
ADD CONSTRAINT [FK_FilmGenre]
    FOREIGN KEY ([Genre_GenreID])
    REFERENCES [dbo].[GenreSet]
        ([GenreID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilmGenre'
CREATE INDEX [IX_FK_FilmGenre]
ON [dbo].[FilmSet]
    ([Genre_GenreID]);
GO

-- Creating foreign key on [AgeRating_AgeRatingID] in table 'FilmSet'
ALTER TABLE [dbo].[FilmSet]
ADD CONSTRAINT [FK_FilmAgeRating]
    FOREIGN KEY ([AgeRating_AgeRatingID])
    REFERENCES [dbo].[AgeRatingSet]
        ([AgeRatingID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilmAgeRating'
CREATE INDEX [IX_FK_FilmAgeRating]
ON [dbo].[FilmSet]
    ([AgeRating_AgeRatingID]);
GO

-- Creating foreign key on [CinemaHall_CinemaHallID] in table 'SeatSet'
ALTER TABLE [dbo].[SeatSet]
ADD CONSTRAINT [FK_CinemaHallSeat]
    FOREIGN KEY ([CinemaHall_CinemaHallID])
    REFERENCES [dbo].[CinemaHallSet]
        ([CinemaHallID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CinemaHallSeat'
CREATE INDEX [IX_FK_CinemaHallSeat]
ON [dbo].[SeatSet]
    ([CinemaHall_CinemaHallID]);
GO

-- Creating foreign key on [Film_FilmID] in table 'FilmSessionSet'
ALTER TABLE [dbo].[FilmSessionSet]
ADD CONSTRAINT [FK_FilmFilmSession]
    FOREIGN KEY ([Film_FilmID])
    REFERENCES [dbo].[FilmSet]
        ([FilmID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilmFilmSession'
CREATE INDEX [IX_FK_FilmFilmSession]
ON [dbo].[FilmSessionSet]
    ([Film_FilmID]);
GO

-- Creating foreign key on [CinemaHall_CinemaHallID] in table 'FilmSessionSet'
ALTER TABLE [dbo].[FilmSessionSet]
ADD CONSTRAINT [FK_FilmSessionCinemaHall]
    FOREIGN KEY ([CinemaHall_CinemaHallID])
    REFERENCES [dbo].[CinemaHallSet]
        ([CinemaHallID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilmSessionCinemaHall'
CREATE INDEX [IX_FK_FilmSessionCinemaHall]
ON [dbo].[FilmSessionSet]
    ([CinemaHall_CinemaHallID]);
GO

-- Creating foreign key on [Seat_SeatID] in table 'SeatTicketSet'
ALTER TABLE [dbo].[SeatTicketSet]
ADD CONSTRAINT [FK_SeatTicketSeat]
    FOREIGN KEY ([Seat_SeatID])
    REFERENCES [dbo].[SeatSet]
        ([SeatID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SeatTicketSeat'
CREATE INDEX [IX_FK_SeatTicketSeat]
ON [dbo].[SeatTicketSet]
    ([Seat_SeatID]);
GO

-- Creating foreign key on [FilmSession_FilmSessionID] in table 'SeatTicketSet'
ALTER TABLE [dbo].[SeatTicketSet]
ADD CONSTRAINT [FK_SeatTicketFilmSession]
    FOREIGN KEY ([FilmSession_FilmSessionID])
    REFERENCES [dbo].[FilmSessionSet]
        ([FilmSessionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SeatTicketFilmSession'
CREATE INDEX [IX_FK_SeatTicketFilmSession]
ON [dbo].[SeatTicketSet]
    ([FilmSession_FilmSessionID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------