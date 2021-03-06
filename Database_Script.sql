USE [master]
GO
/****** Object:  Database [School]    Script Date: 5/25/2021 7:35:01 PM ******/
CREATE DATABASE [School]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'test', FILENAME = N'D:\SQL server Microsoft\MSSQL15.MSSQLSERVER\MSSQL\DATA\test.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'test_log', FILENAME = N'D:\SQL server Microsoft\MSSQL15.MSSQLSERVER\MSSQL\DATA\test_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [School] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [School].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [School] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [School] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [School] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [School] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [School] SET ARITHABORT OFF 
GO
ALTER DATABASE [School] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [School] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [School] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [School] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [School] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [School] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [School] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [School] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [School] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [School] SET  DISABLE_BROKER 
GO
ALTER DATABASE [School] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [School] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [School] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [School] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [School] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [School] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [School] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [School] SET RECOVERY FULL 
GO
ALTER DATABASE [School] SET  MULTI_USER 
GO
ALTER DATABASE [School] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [School] SET DB_CHAINING OFF 
GO
ALTER DATABASE [School] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [School] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [School] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [School] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'School', N'ON'
GO
ALTER DATABASE [School] SET QUERY_STORE = OFF
GO
USE [School]
GO
/****** Object:  Table [dbo].[Absenta]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Absenta](
	[id_absenta] [int] IDENTITY(1,1) NOT NULL,
	[descriere_tip_absenta] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Absenta] PRIMARY KEY CLUSTERED 
(
	[id_absenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrator](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nume] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Administrator] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clasa]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clasa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numar_clasa] [int] NOT NULL,
	[litera] [varchar](2) NOT NULL,
	[specializare] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Clasa] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuplaj_Clasa]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuplaj_Clasa](
	[id_cuplaj] [int] NOT NULL,
	[id_clasa] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diriginte_Clasa]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diriginte_Clasa](
	[id_profesor] [int] NOT NULL,
	[id_clasa] [int] NOT NULL,
	[id_diriginte] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Diriginte_Clasa_1] PRIMARY KEY CLUSTERED 
(
	[id_diriginte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentClasa]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentClasa](
	[id_document] [int] NOT NULL,
	[id_clasa] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documents](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Data] [varbinary](max) NULL,
	[Extension] [varchar](4) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Elev]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Elev](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nume] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Elev] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Elev_Absenta]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Elev_Absenta](
	[id_absenta] [int] NOT NULL,
	[id_elev] [int] NOT NULL,
	[id_cuplaj] [int] NOT NULL,
	[data] [date] NOT NULL,
 CONSTRAINT [PK_Elev_Absenta] PRIMARY KEY CLUSTERED 
(
	[id_absenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Elev_Clasa]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Elev_Clasa](
	[id_elev] [int] NOT NULL,
	[id_clasa] [int] NOT NULL,
 CONSTRAINT [PK_Elev_Clasa] PRIMARY KEY CLUSTERED 
(
	[id_elev] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Elev_Nota]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Elev_Nota](
	[id_elev] [int] NOT NULL,
	[id_cuplaj] [int] NOT NULL,
	[data] [date] NOT NULL,
	[id_nota] [int] NOT NULL,
	[semestru] [int] NOT NULL,
 CONSTRAINT [PK_Elev_Nota] PRIMARY KEY CLUSTERED 
(
	[id_nota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ElevAbsenta]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ElevAbsenta](
	[id_absenta] [int] IDENTITY(1,1) NOT NULL,
	[tip_absenta] [varchar](50) NOT NULL,
	[data] [varchar](50) NOT NULL,
	[id_cuplaj] [int] NOT NULL,
	[id_elev] [int] NOT NULL,
 CONSTRAINT [PK_ElevAbsenta] PRIMARY KEY CLUSTERED 
(
	[id_absenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ElevNota]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ElevNota](
	[id_nota] [int] IDENTITY(1,1) NOT NULL,
	[nota] [int] NOT NULL,
	[id_elev] [int] NOT NULL,
	[id_cuplaj] [int] NOT NULL,
	[tip_nota] [varchar](50) NOT NULL,
	[semestru] [int] NOT NULL,
	[data] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login_Admin]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login_Admin](
	[id_administrator] [int] NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login_Elev]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login_Elev](
	[id_elev] [int] NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login_Profesor]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login_Profesor](
	[id_profesor] [int] NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materie]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materie](
	[id_materie] [int] IDENTITY(1,1) NOT NULL,
	[denumire] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Materie] PRIMARY KEY CLUSTERED 
(
	[id_materie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nota]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nota](
	[id_nota] [int] IDENTITY(1,1) NOT NULL,
	[descriere_tip_nota] [varchar](50) NOT NULL,
	[nota] [int] NOT NULL,
 CONSTRAINT [PK_Nota] PRIMARY KEY CLUSTERED 
(
	[id_nota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nume] [varchar](50) NOT NULL,
	[numar_telefon] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesor_Materie]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor_Materie](
	[id_profesor] [int] NOT NULL,
	[id_materie] [int] NOT NULL,
	[id_cuplaj] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Profesor_Materie] PRIMARY KEY CLUSTERED 
(
	[id_cuplaj] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Diriginte_Clasa]  WITH CHECK ADD  CONSTRAINT [FK_Diriginte_Clasa_Clasa] FOREIGN KEY([id_clasa])
REFERENCES [dbo].[Clasa] ([id])
GO
ALTER TABLE [dbo].[Diriginte_Clasa] CHECK CONSTRAINT [FK_Diriginte_Clasa_Clasa]
GO
ALTER TABLE [dbo].[Diriginte_Clasa]  WITH CHECK ADD  CONSTRAINT [FK_Diriginte_Clasa_Profesor] FOREIGN KEY([id_profesor])
REFERENCES [dbo].[Profesor] ([id])
GO
ALTER TABLE [dbo].[Diriginte_Clasa] CHECK CONSTRAINT [FK_Diriginte_Clasa_Profesor]
GO
ALTER TABLE [dbo].[DocumentClasa]  WITH CHECK ADD  CONSTRAINT [FK_DocumentClasa_Clasa] FOREIGN KEY([id_clasa])
REFERENCES [dbo].[Clasa] ([id])
GO
ALTER TABLE [dbo].[DocumentClasa] CHECK CONSTRAINT [FK_DocumentClasa_Clasa]
GO
ALTER TABLE [dbo].[DocumentClasa]  WITH CHECK ADD  CONSTRAINT [FK_DocumentClasa_Documents] FOREIGN KEY([id_document])
REFERENCES [dbo].[Documents] ([ID])
GO
ALTER TABLE [dbo].[DocumentClasa] CHECK CONSTRAINT [FK_DocumentClasa_Documents]
GO
ALTER TABLE [dbo].[Elev_Absenta]  WITH CHECK ADD  CONSTRAINT [FK_Elev_Absenta_Absenta] FOREIGN KEY([id_absenta])
REFERENCES [dbo].[Absenta] ([id_absenta])
GO
ALTER TABLE [dbo].[Elev_Absenta] CHECK CONSTRAINT [FK_Elev_Absenta_Absenta]
GO
ALTER TABLE [dbo].[Elev_Absenta]  WITH CHECK ADD  CONSTRAINT [FK_Elev_Absenta_Elev] FOREIGN KEY([id_elev])
REFERENCES [dbo].[Elev] ([id])
GO
ALTER TABLE [dbo].[Elev_Absenta] CHECK CONSTRAINT [FK_Elev_Absenta_Elev]
GO
ALTER TABLE [dbo].[Elev_Absenta]  WITH CHECK ADD  CONSTRAINT [FK_Elev_Absenta_Profesor_Materie] FOREIGN KEY([id_cuplaj])
REFERENCES [dbo].[Profesor_Materie] ([id_cuplaj])
GO
ALTER TABLE [dbo].[Elev_Absenta] CHECK CONSTRAINT [FK_Elev_Absenta_Profesor_Materie]
GO
ALTER TABLE [dbo].[Elev_Clasa]  WITH CHECK ADD  CONSTRAINT [FK_Elev_Clasa_Clasa] FOREIGN KEY([id_clasa])
REFERENCES [dbo].[Clasa] ([id])
GO
ALTER TABLE [dbo].[Elev_Clasa] CHECK CONSTRAINT [FK_Elev_Clasa_Clasa]
GO
ALTER TABLE [dbo].[Elev_Clasa]  WITH CHECK ADD  CONSTRAINT [FK_Elev_Clasa_Elev] FOREIGN KEY([id_elev])
REFERENCES [dbo].[Elev] ([id])
GO
ALTER TABLE [dbo].[Elev_Clasa] CHECK CONSTRAINT [FK_Elev_Clasa_Elev]
GO
ALTER TABLE [dbo].[Elev_Nota]  WITH CHECK ADD  CONSTRAINT [FK_Elev_Nota_Elev] FOREIGN KEY([id_elev])
REFERENCES [dbo].[Elev] ([id])
GO
ALTER TABLE [dbo].[Elev_Nota] CHECK CONSTRAINT [FK_Elev_Nota_Elev]
GO
ALTER TABLE [dbo].[Elev_Nota]  WITH CHECK ADD  CONSTRAINT [FK_Elev_Nota_Nota] FOREIGN KEY([id_nota])
REFERENCES [dbo].[Nota] ([id_nota])
GO
ALTER TABLE [dbo].[Elev_Nota] CHECK CONSTRAINT [FK_Elev_Nota_Nota]
GO
ALTER TABLE [dbo].[Elev_Nota]  WITH CHECK ADD  CONSTRAINT [FK_Elev_Nota_Profesor_Materie] FOREIGN KEY([id_cuplaj])
REFERENCES [dbo].[Profesor_Materie] ([id_cuplaj])
GO
ALTER TABLE [dbo].[Elev_Nota] CHECK CONSTRAINT [FK_Elev_Nota_Profesor_Materie]
GO
ALTER TABLE [dbo].[ElevNota]  WITH CHECK ADD  CONSTRAINT [FK_ElevNota_Elev] FOREIGN KEY([id_elev])
REFERENCES [dbo].[Elev] ([id])
GO
ALTER TABLE [dbo].[ElevNota] CHECK CONSTRAINT [FK_ElevNota_Elev]
GO
ALTER TABLE [dbo].[ElevNota]  WITH CHECK ADD  CONSTRAINT [FK_ElevNota_Profesor_Materie] FOREIGN KEY([id_cuplaj])
REFERENCES [dbo].[Profesor_Materie] ([id_cuplaj])
GO
ALTER TABLE [dbo].[ElevNota] CHECK CONSTRAINT [FK_ElevNota_Profesor_Materie]
GO
ALTER TABLE [dbo].[Login_Admin]  WITH CHECK ADD  CONSTRAINT [FK_Login_Admin_Administrator] FOREIGN KEY([id_administrator])
REFERENCES [dbo].[Administrator] ([id])
GO
ALTER TABLE [dbo].[Login_Admin] CHECK CONSTRAINT [FK_Login_Admin_Administrator]
GO
ALTER TABLE [dbo].[Login_Elev]  WITH CHECK ADD  CONSTRAINT [FK_Login_Elev_Elev] FOREIGN KEY([id_elev])
REFERENCES [dbo].[Elev] ([id])
GO
ALTER TABLE [dbo].[Login_Elev] CHECK CONSTRAINT [FK_Login_Elev_Elev]
GO
ALTER TABLE [dbo].[Login_Profesor]  WITH CHECK ADD  CONSTRAINT [FK_Login_Profesor_Profesor] FOREIGN KEY([id_profesor])
REFERENCES [dbo].[Profesor] ([id])
GO
ALTER TABLE [dbo].[Login_Profesor] CHECK CONSTRAINT [FK_Login_Profesor_Profesor]
GO
ALTER TABLE [dbo].[Profesor_Materie]  WITH CHECK ADD  CONSTRAINT [FK_Profesor_Materie_Materie] FOREIGN KEY([id_materie])
REFERENCES [dbo].[Materie] ([id_materie])
GO
ALTER TABLE [dbo].[Profesor_Materie] CHECK CONSTRAINT [FK_Profesor_Materie_Materie]
GO
ALTER TABLE [dbo].[Profesor_Materie]  WITH CHECK ADD  CONSTRAINT [FK_Profesor_Materie_Profesor] FOREIGN KEY([id_profesor])
REFERENCES [dbo].[Profesor] ([id])
GO
ALTER TABLE [dbo].[Profesor_Materie] CHECK CONSTRAINT [FK_Profesor_Materie_Profesor]
GO
/****** Object:  StoredProcedure [dbo].[AdminLoginDetails]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AdminLoginDetails]
AS
BEGIN
	select * from Login_Admin
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteAbsence]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
CREATE PROCEDURE [dbo].[DeleteAbsence]
	@idAbsenta int
AS
BEGIN
	delete from ElevAbsenta where id_absenta=@idAbsenta
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteAndAddMasterToClass]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteAndAddMasterToClass]
	@idProfesor int, @idClasa int
AS
BEGIN
	delete from Diriginte_Clasa where id_clasa=@idClasa
	delete from Diriginte_Clasa where id_profesor=@idProfesor
	insert into Diriginte_Clasa values(@idProfesor, @idClasa)
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteClass]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteClass]
	@idClasa int
AS
BEGIN
	delete from Clasa where id=@idClasa
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteGradeStudent]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteGradeStudent] 
	@idNota int
AS
BEGIN
	delete from ElevNota where id_nota=@idNota
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteMaster]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteMaster]
	@idDiriginte int
AS
BEGIN
	delete from Diriginte_Clasa where id_diriginte=@idDiriginte
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteStudentFromAbsences]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStudentFromAbsences]
	@idElev int
AS
BEGIN
	delete from Elev_Absenta where id_elev=@idElev
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteStudentFromClass]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStudentFromClass]
	@idElev int
AS
BEGIN
	delete from Elev_Clasa where id_elev=@idElev
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteStudentFromLogin]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStudentFromLogin]
	@idElev int
AS
BEGIN
	delete from Login_Elev where id_elev=@idElev
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteStudentFromMarks]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStudentFromMarks]
	@idElev int
AS
BEGIN
	delete from Elev_Nota where id_elev=@idElev
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteStudentFromStudents]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStudentFromStudents]
	@idElev int
AS
BEGIN
	delete from Elev where id=@idElev
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteSubject]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteSubject]
	@idMaterie int
AS
BEGIN
	delete from Materie where id_materie=@idMaterie
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteTeacherFromClasses]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteTeacherFromClasses]
	@idProfesor int
AS
BEGIN
	delete Cuplaj_Clasa from Cuplaj_Clasa inner join Profesor_Materie on Cuplaj_Clasa.id_cuplaj=Profesor_Materie.id_cuplaj inner join Profesor on Profesor_Materie.id_profesor=Profesor.id where Profesor.id=@idProfesor
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteTeacherFromLogin]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteTeacherFromLogin]
	@idProfesor int
AS
BEGIN
	delete from Login_Profesor where id_profesor=@idProfesor
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteTeacherFromMasters]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteTeacherFromMasters]
	@idProfesor int
AS
BEGIN
	delete from Diriginte_Clasa where id_profesor=@idProfesor
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteTeacherFromSubjects]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteTeacherFromSubjects]
	@idProfesor int
AS
BEGIN
	delete from Profesor_Materie where id_profesor=@idProfesor
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteTeacherFromTeachers]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteTeacherFromTeachers]
	@idProfesor int
AS
BEGIN
	delete from Profesor where id=@idProfesor
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteTeacherSubjectToClass]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteTeacherSubjectToClass]
	@idCuplaj int, @idClasa int
AS
BEGIN
	delete from Cuplaj_Clasa where id_cuplaj=@idCuplaj and id_clasa=@idClasa
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteTeacherToSubject]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteTeacherToSubject]
	@idCuplaj int
AS
BEGIN
	delete from Profesor_Materie where id_cuplaj=@idCuplaj
END
GO
/****** Object:  StoredProcedure [dbo].[GetAbsences]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAbsences]

AS
BEGIN
	select * from ElevAbsenta
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllAbsencesStudent]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllAbsencesStudent]
	
AS
BEGIN
	select * from ElevAbsenta inner join Elev on ElevAbsenta.id_elev=Elev.id inner join Profesor_Materie on ElevAbsenta.id_cuplaj=Profesor_Materie.id_cuplaj
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllClasses]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllClasses]

AS
BEGIN
	select * from Clasa
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllClassesToStudents]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllClassesToStudents]

AS
BEGIN
	select * from Elev_Clasa inner join Elev on Elev_Clasa.id_elev=Elev.id inner join Clasa on Elev_Clasa.id_clasa=Clasa.id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllDocuments]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllDocuments]

AS
BEGIN
	select * from Documents
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllGradeStudentsListed]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllGradeStudentsListed]

AS
BEGIN
	select * from ElevNota inner join Elev on ElevNota.id_elev=Elev.id inner join Profesor_Materie on ElevNota.id_cuplaj=Profesor_Materie.id_cuplaj
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllStudents]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllStudents] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	select * from Elev
END


GO
/****** Object:  StoredProcedure [dbo].[GetAllStudentsToClasses]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllStudentsToClasses]
AS
BEGIN
	select * from Elev_Clasa inner join Elev on Elev_Clasa.id_elev=Elev.id inner join Clasa on Elev_Clasa.id_clasa=Clasa.id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllStudentsToGrades]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllStudentsToGrades]

AS
BEGIN
	select * from Elev_Nota inner join Elev on Elev_Nota.id_elev=Elev.id inner join Nota on Elev_Nota.id_nota=Nota.id_nota
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllStudentToClass]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllStudentToClass]

AS
BEGIN
	select * from Elev_Clasa
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllSubjects]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllSubjects]

AS
BEGIN
	select * from Materie
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllTeachers]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllTeachers]
AS
BEGIN
	select * from Profesor
END
GO
/****** Object:  StoredProcedure [dbo].[GetALLTeachersToSubjects]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetALLTeachersToSubjects]

AS
BEGIN
	select * from Profesor_Materie inner join Profesor on Profesor_Materie.id_profesor=Profesor.id inner join Materie on Materie.id_materie=Profesor_Materie.id_materie
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllTeacherToSubject]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllTeacherToSubject]

AS
BEGIN
	select * from Profesor_Materie
END
GO
/****** Object:  StoredProcedure [dbo].[GetGrades]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetGrades]

AS
BEGIN
	select * from Nota
END
GO
/****** Object:  StoredProcedure [dbo].[GetGradeStudent]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetGradeStudent] 
	
AS
BEGIN
	select * from ElevNota
END
GO
/****** Object:  StoredProcedure [dbo].[GetMastersList]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMastersList]

AS
BEGIN
	select nume, Clasa.numar_clasa, Clasa.litera, Clasa.specializare from Diriginte_Clasa inner join Profesor on Diriginte_Clasa.id_profesor=Profesor.id inner join Clasa on Clasa.id=Diriginte_Clasa.id_clasa inner join Profesor_Materie on Profesor.id=Profesor_Materie.id_profesor inner join Materie on Materie.id_materie=Profesor_Materie.id_materie
END
GO
/****** Object:  StoredProcedure [dbo].[GetMastersToClass]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMastersToClass]

AS
BEGIN
	select * from Diriginte_Clasa inner join Profesor on Diriginte_Clasa.id_profesor=Profesor.id inner join Clasa on Clasa.id=Diriginte_Clasa.id_clasa inner join Profesor_Materie on Profesor.id=Profesor_Materie.id_profesor inner join Materie on Materie.id_materie=Profesor_Materie.id_materie
END
GO
/****** Object:  StoredProcedure [dbo].[GetStudentToGrade]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStudentToGrade]

AS
BEGIN
	select * from Elev_Nota
END
GO
/****** Object:  StoredProcedure [dbo].[GetTeachersToClass]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTeachersToClass]
AS
BEGIN
	select * from Cuplaj_Clasa inner join Profesor_Materie on Cuplaj_Clasa.id_cuplaj=Profesor_Materie.id_cuplaj inner join Materie on Materie.id_materie=Profesor_Materie.id_materie inner join Profesor on Profesor.id=Profesor_Materie.id_profesor inner join Clasa on Cuplaj_Clasa.id_clasa=Clasa.id
END
GO
/****** Object:  StoredProcedure [dbo].[GetTotalListStudents]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTotalListStudents]
	-- Add the parameters for the stored procedure here
AS
BEGIN

	select nume, specializare, numar_clasa, litera from Elev inner join Elev_Clasa on Elev.id=Elev_Clasa.id_elev inner join Clasa on Elev_Clasa.id_clasa=Clasa.id
END
GO
/****** Object:  StoredProcedure [dbo].[InsertAbsence]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertAbsence] 
	@tipAbsenta varchar(50), @data varchar(50), @idCuplaj int, @idElev int
AS
BEGIN
	insert into ElevAbsenta(tip_absenta, [data], id_cuplaj, id_elev) values(@tipAbsenta, @data, @idCuplaj, @idElev)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertClass]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertClass]
	@class_number int, @letter varchar(2), @specialization varchar(50)
AS
BEGIN
	insert into Clasa(numar_clasa, litera, specializare) values(@class_number, @letter, @specialization)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertDocument]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertDocument] 
	@Data varbinary(max), @Extension varchar(4)
AS
BEGIN
	insert into Documents([Data], Extension) values(@Data, @Extension)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertDocumentClasa]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertDocumentClasa] 
	@DocumentID int, @ClasaID int
AS
BEGIN
	insert into DocumentClasa(id_clasa, id_document) values(@ClasaID, @DocumentID)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertIntoGradeStudent]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertIntoGradeStudent]
	@nota int, @idElev int, @idCuplaj int, @tipNota varchar(50), @semestru int, @data varchar(50)
AS
BEGIN
	insert into ElevNota(nota, id_elev, id_cuplaj, tip_nota, semestru, [data]) values(@nota, @idElev, @idCuplaj, @tipNota, @semestru, @data)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertMasterToClass]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertMasterToClass]
	@idProfesor int, @idClasa int
AS
BEGIN
	insert into Diriginte_Clasa values(@idProfesor, @idClasa)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertNota]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
CREATE PROCEDURE [dbo].[InsertNota]
	@descriere varchar(50), @nota int
AS
BEGIN
	insert into Nota(descriere_tip_nota, nota) values(@descriere, @nota)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertStudent]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertStudent]
	@name varchar(50)
AS
BEGIN
	insert into Elev(nume) values(@name)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertStudentGrade]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertStudentGrade]
	@idElev int, @idCuplaj int, @data date, @idNota int, @semestru int
AS
BEGIN
	insert into Elev_Nota(id_elev, id_cuplaj, [data], id_nota, semestru) values(@idElev, @idCuplaj, @data, @idNota, @semestru)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertStudentLoginDetails]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertStudentLoginDetails]
	@idElev int, @email varchar(50), @password varchar(50)
AS
BEGIN
	insert into Login_Elev(id_elev, email, [password]) values(@idElev, @email, @password)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertStudentToClass]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertStudentToClass]
	@idElev int, @idClasa int
AS
BEGIN
	insert into Elev_Clasa(id_elev, id_clasa) values(@idElev, @idClasa)
END
GO
/****** Object:  StoredProcedure [dbo].[Insertsubject]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Insertsubject]
	@denumire varchar(50)
AS
BEGIN
	insert into Materie(denumire) values(@denumire)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertTeacher]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertTeacher]
	@name varchar(50), @phone varchar(15)
AS
BEGIN
	insert into Profesor(nume, numar_telefon) values(@name, @phone)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertTeacherLoginDetails]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertTeacherLoginDetails]
	@idProfesor int, @email varchar(50), @password varchar(50)
AS
BEGIN
	insert into Login_Profesor(id_profesor, email, [password]) values(@idProfesor, @email, @password)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertTeacherSubjectToClass]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertTeacherSubjectToClass]
	@idCuplaj int, @idClasa int
AS
BEGIN
	insert into Cuplaj_Clasa values(@idCuplaj, @idClasa)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertTeacherToSubject]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertTeacherToSubject]
	@idProfesor int, @idMaterie int
AS
BEGIN
	insert into Profesor_Materie(id_profesor, id_materie) values(@idProfesor, @idMaterie)
END
GO
/****** Object:  StoredProcedure [dbo].[StudentLoginDetails]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StudentLoginDetails]
AS
BEGIN
	select * from Login_Elev
END
GO
/****** Object:  StoredProcedure [dbo].[TeacherLoginDetails]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TeacherLoginDetails]
AS
BEGIN
	select * from Login_Profesor
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateMasterToClass]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateMasterToClass]
	@idProfesor int, @idClasa int, @idDiriginte int
AS
BEGIN
	update Diriginte_Clasa set id_clasa=@idClasa, id_profesor=@idProfesor where id_diriginte=@idDiriginte
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStudentName]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStudentName]
	@idElev int, @nume varchar(50)
AS
BEGIN
	update Elev set nume=@nume where id=@idElev
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStudentToClass]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStudentToClass]
	@idElev int, @idClasa int
AS
BEGIN
	update Elev_Clasa set id_clasa=@idClasa where id_elev=@idElev
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTeacher]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
CREATE PROCEDURE [dbo].[UpdateTeacher]
	@idProfesor int, @nume varchar(50), @telefon varchar(15)
AS
BEGIN
	update Profesor set nume=@nume, numar_telefon=@telefon where id=@idProfesor
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTeacherToSubject]    Script Date: 5/25/2021 7:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateTeacherToSubject]
	@idCuplaj int, @idProfesor int, @idMaterie int
AS
BEGIN
	update Profesor_Materie set id_materie=@idMaterie, id_profesor=@idProfesor where id_cuplaj=@idCuplaj 
END
GO
USE [master]
GO
ALTER DATABASE [School] SET  READ_WRITE 
GO
