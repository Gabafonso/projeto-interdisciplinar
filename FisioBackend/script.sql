Build started...
Build succeeded.
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Agendas] (
    [Id] int NOT NULL IDENTITY,
    [DiaDaSemana] int NOT NULL,
    [HoraInic] nvarchar(max) NULL,
    [HoraFim] nvarchar(max) NULL,
    [FuncionarioId] int NOT NULL,
    CONSTRAINT [PK_Agendas] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Pagamentos] (
    [Id] int NOT NULL IDENTITY,
    [ValorTotal] real NOT NULL,
    [ValorPag] real NOT NULL,
    [FormaPag] nvarchar(max) NULL,
    [Status] int NOT NULL,
    [DataPag] nvarchar(max) NULL,
    [DataVenc] nvarchar(max) NULL,
    CONSTRAINT [PK_Pagamentos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Pessoas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [CPF] nvarchar(max) NULL,
    [Status] int NOT NULL,
    [Telefone] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Senha] nvarchar(max) NULL,
    CONSTRAINT [PK_Pessoas] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Servicos] (
    [Id] int NOT NULL IDENTITY,
    [FormaPag] nvarchar(max) NULL,
    [ValorServ] real NOT NULL,
    [Cronograma] int NOT NULL,
    [FuncionarioId] int NOT NULL,
    [TipoServicoId] int NOT NULL,
    CONSTRAINT [PK_Servicos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TiposServico] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    CONSTRAINT [PK_TiposServico] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Clientes] (
    [Id] int NOT NULL,
    [Renda] real NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Clientes_Pessoas_Id] FOREIGN KEY ([Id]) REFERENCES [Pessoas] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Funcionarios] (
    [Id] int NOT NULL,
    [Especialidade] nvarchar(max) NULL,
    CONSTRAINT [PK_Funcionarios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Funcionarios_Pessoas_Id] FOREIGN KEY ([Id]) REFERENCES [Pessoas] ([Id]) ON DELETE CASCADE
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221127185427_Criacao_Tabelas', N'7.0.0');
GO

COMMIT;
GO


