SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

/****** TodoList ******/
create table dbo.MicroSungero_Planning_TodoList
(
  [Id] int not null,
  [TypeGuid] uniqueidentifier not null,
  [Title] nvarchar(100) not null,
  [Description] nvarchar(250) null,
  [AuthorId] int not null,
  [CreatedDate] datetime2 not null,
  [Deadline] datetime2 null,
  [IsCompleted] bit null,
  [CompletedDate] datetime2 null,
  PRIMARY KEY CLUSTERED
  (
	[Id] ASC
  ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) on [PRIMARY]
GO

CREATE SEQUENCE [dbo].[MicroSungero_Planning_TodoList_Id] 
 AS [bigint]
 START WITH 1
 INCREMENT BY 10
 MINVALUE 1
 MAXVALUE 9223372036854775807
 CACHE 
GO

/****** Todo item ******/
create table dbo.MicroSungero_Planning_Todo
(
  [Id] int not null,
  [TypeGuid] uniqueidentifier not null,
  [Title] nvarchar(100) not null,
  [Description] nvarchar(250) null,
  [PerformerId] int null,
  [Priority] nvarchar(20) null,
  [CreatedDate] datetime2 not null,
  [Deadline] datetime2 null,
  [IsCompleted] bit null,
  [CompletedDate] datetime2 null,
  [Tag_Name] nvarchar(100) null,
  [Tag_Color] nvarchar(20) null,
  [TodoListId] int not null,
  PRIMARY KEY CLUSTERED
  (
	[Id] ASC
  ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) on [PRIMARY]
GO

ALTER TABLE [dbo].MicroSungero_Planning_Todo  WITH CHECK ADD CONSTRAINT [FK_TodoItem_TodoList] FOREIGN KEY([TodoListId])
REFERENCES [dbo].[MicroSungero_Planning_TodoList] ([Id])
GO

CREATE SEQUENCE [dbo].[MicroSungero_Planning_Todo_Id] 
 AS [bigint]
 START WITH 1
 INCREMENT BY 10
 MINVALUE 1
 MAXVALUE 9223372036854775807
 CACHE 
GO
