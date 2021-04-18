/****** Todo lists ******/
CREATE TABLE MicroSungero_Planning_TodoList (
  Id integer NOT NULL,
  TypeGuid uuid NOT NULL,
  Title varchar(100) NOT NULL,
  Description varchar(250) NULL,
  AuthorId integer NOT NULL,
  CreatedDate timestamp without time zone NOT NULL,
  Deadline timestamp without time zone NULL,
  IsCompleted boolean NULL,
  CompletedDate timestamp without time zone NULL,
CONSTRAINT MicroSungero_Planning_TodoList_PK PRIMARY KEY (Id));

CREATE SEQUENCE MicroSungero_Planning_TodoList_Id
 START WITH 1
 INCREMENT BY 10
 MINVALUE 1
 MAXVALUE 9223372036854775807;


/****** Todo items ******/
CREATE TABLE MicroSungero_Planning_Todo (
  Id integer NOT NULL,
  TypeGuid uuid NOT NULL,
  Title varchar(100) NOT NULL,
  Description varchar(250) NULL,
  Note varchar(250) NULL,
  PerformerId integer NULL,
  Priority varchar(20) NULL,
  CreatedDate timestamp without time zone NOT NULL,
  Deadline timestamp without time zone NULL,
  IsCompleted boolean NULL,
  CompletedDate timestamp without time zone NULL,
  TodoListId integer NOT NULL,
CONSTRAINT MicroSungero_Planning_Todo_PK PRIMARY KEY (Id),
CONSTRAINT FK_TodoList_Id FOREIGN KEY (TodoListId) REFERENCES MicroSungero_Planning_TodoList (Id) ON DELETE CASCADE);

CREATE SEQUENCE MicroSungero_Planning_Todo_Id
 START WITH 1
 INCREMENT BY 10
 MINVALUE 1
 MAXVALUE 9223372036854775807;


 /****** Todo tags ******/
CREATE TABLE MicroSungero_Planning_TodoTag (
  Id integer NOT NULL,
  TypeGuid uuid NOT NULL,
  Tag_Name varchar(100) null,
  Tag_Color varchar(20) null,
  TodoId integer NOT NULL,
CONSTRAINT MicroSungero_Planning_TodoTag_PK PRIMARY KEY (Id),
CONSTRAINT FK_Todo_Id FOREIGN KEY (TodoId) REFERENCES MicroSungero_Planning_Todo (Id) ON DELETE CASCADE);

CREATE SEQUENCE MicroSungero_Planning_TodoTag_Id
 START WITH 1
 INCREMENT BY 10
 MINVALUE 1
 MAXVALUE 9223372036854775807;