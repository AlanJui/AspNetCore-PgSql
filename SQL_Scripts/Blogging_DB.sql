CREATE DATABASE Blogging;


-- USE Blogging;


CREATE TABLE Blog (
    BlogId int NOT NULL IDENTITY,
    Url nvarchar(max) NOT NULL,
    CONSTRAINT PK_Blog PRIMARY KEY (BlogId)
);


CREATE TABLE Post (
    PostId int NOT NULL IDENTITY,
    BlogId int NOT NULL,
    Content nvarchar(max),
    Title nvarchar(max),
    CONSTRAINT PK_Post PRIMARY KEY (PostId),
    CONSTRAINT FK_Post_Blog_BlogId FOREIGN KEY (BlogId) REFERENCES Blog (BlogId) ON DELETE CASCADE
);


INSERT INTO Blog (Url) VALUES
('http://blogs.msdn.com/dotnet'),
('http://blogs.msdn.com/webdev'),
('http://blogs.msdn.com/visualstudio');
