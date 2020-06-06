
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/06/2020 20:25:27
-- Generated from EDMX file: G:\ШАГ\Курсова\test1\isbd\Server\Data\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_RoleUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_RoleUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserRoles'
CREATE TABLE [dbo].[UserRoles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [RegistrationDate] datetime  NOT NULL,
    [ActivateLink] nvarchar(max)  NOT NULL,
    [RoleId] int  NOT NULL,
    [StatusId] int  NOT NULL
);
GO

-- Creating table 'UserStatuses'
CREATE TABLE [dbo].[UserStatuses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserFriendsSet'
CREATE TABLE [dbo].[UserFriendsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Activated] bit  NOT NULL,
    [Date] datetime  NOT NULL,
    [UserIdFrom] int  NOT NULL,
    [UserIdTo] int  NOT NULL
);
GO

-- Creating table 'UsersToChats'
CREATE TABLE [dbo].[UsersToChats] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [ChatId] int  NOT NULL
);
GO

-- Creating table 'Chats'
CREATE TABLE [dbo].[Chats] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ChatMessages'
CREATE TABLE [dbo].[ChatMessages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [ChatId] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'QuizesApproved'
CREATE TABLE [dbo].[QuizesApproved] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [QuizId] int  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'UsersQuizesResp'
CREATE TABLE [dbo].[UsersQuizesResp] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [QuizId] int  NOT NULL,
    [Rate] nvarchar(max)  NOT NULL,
    [Favourite] bit  NOT NULL
);
GO

-- Creating table 'Quizes'
CREATE TABLE [dbo].[Quizes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Image] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [StatusId] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'QuizStatuses'
CREATE TABLE [dbo].[QuizStatuses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'QuizesToCategories'
CREATE TABLE [dbo].[QuizesToCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CategoryId] int  NOT NULL,
    [QuizId] int  NOT NULL
);
GO

-- Creating table 'QuizCaetgories'
CREATE TABLE [dbo].[QuizCaetgories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Achievements'
CREATE TABLE [dbo].[Achievements] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Decription] nvarchar(max)  NOT NULL,
    [Icon] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UsersToAchievements'
CREATE TABLE [dbo].[UsersToAchievements] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AchievementId] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'Questions'
CREATE TABLE [dbo].[Questions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Points] nvarchar(max)  NOT NULL,
    [Image] nvarchar(max)  NOT NULL,
    [TypeId] int  NOT NULL,
    [QuizId] int  NOT NULL
);
GO

-- Creating table 'QuestionTypes'
CREATE TABLE [dbo].[QuestionTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SequencesTrue'
CREATE TABLE [dbo].[SequencesTrue] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Answer1] nvarchar(max)  NOT NULL,
    [Answer2] nvarchar(max)  NOT NULL,
    [Answer3] nvarchar(max)  NOT NULL,
    [Answer4] nvarchar(max)  NOT NULL,
    [QuestionId] int  NOT NULL
);
GO

-- Creating table 'BoolsTrue'
CREATE TABLE [dbo].[BoolsTrue] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Answer] bit  NOT NULL,
    [QuestionId] int  NOT NULL
);
GO

-- Creating table 'DefaultsTrue'
CREATE TABLE [dbo].[DefaultsTrue] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Answer] nvarchar(max)  NOT NULL,
    [Variant1] nvarchar(max)  NOT NULL,
    [Variant2] nvarchar(max)  NOT NULL,
    [Variant3] nvarchar(max)  NOT NULL,
    [Variant4] nvarchar(max)  NOT NULL,
    [QuestionId] int  NOT NULL
);
GO

-- Creating table 'Sessions'
CREATE TABLE [dbo].[Sessions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AccessCode] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [StatusId] int  NOT NULL,
    [QuizId] int  NOT NULL
);
GO

-- Creating table 'SessionStatuses'
CREATE TABLE [dbo].[SessionStatuses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UsersToSessions'
CREATE TABLE [dbo].[UsersToSessions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SessionId] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'UsersAnswersSequence'
CREATE TABLE [dbo].[UsersAnswersSequence] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Answer1] nvarchar(max)  NOT NULL,
    [Answer2] nvarchar(max)  NOT NULL,
    [Answer3] nvarchar(max)  NOT NULL,
    [Answer4] nvarchar(max)  NOT NULL,
    [SequenceId] int  NOT NULL,
    [UserSessionId] int  NOT NULL
);
GO

-- Creating table 'UserAnswersBool'
CREATE TABLE [dbo].[UserAnswersBool] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Answer] bit  NOT NULL,
    [BoolId] int  NOT NULL,
    [UserSessionId] int  NOT NULL
);
GO

-- Creating table 'UserAnswersDefault'
CREATE TABLE [dbo].[UserAnswersDefault] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Answer] nvarchar(max)  NOT NULL,
    [DefaultId] int  NOT NULL,
    [UserSessionId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [PK_UserRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserStatuses'
ALTER TABLE [dbo].[UserStatuses]
ADD CONSTRAINT [PK_UserStatuses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserFriendsSet'
ALTER TABLE [dbo].[UserFriendsSet]
ADD CONSTRAINT [PK_UserFriendsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersToChats'
ALTER TABLE [dbo].[UsersToChats]
ADD CONSTRAINT [PK_UsersToChats]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Chats'
ALTER TABLE [dbo].[Chats]
ADD CONSTRAINT [PK_Chats]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ChatMessages'
ALTER TABLE [dbo].[ChatMessages]
ADD CONSTRAINT [PK_ChatMessages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'QuizesApproved'
ALTER TABLE [dbo].[QuizesApproved]
ADD CONSTRAINT [PK_QuizesApproved]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersQuizesResp'
ALTER TABLE [dbo].[UsersQuizesResp]
ADD CONSTRAINT [PK_UsersQuizesResp]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Quizes'
ALTER TABLE [dbo].[Quizes]
ADD CONSTRAINT [PK_Quizes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'QuizStatuses'
ALTER TABLE [dbo].[QuizStatuses]
ADD CONSTRAINT [PK_QuizStatuses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'QuizesToCategories'
ALTER TABLE [dbo].[QuizesToCategories]
ADD CONSTRAINT [PK_QuizesToCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'QuizCaetgories'
ALTER TABLE [dbo].[QuizCaetgories]
ADD CONSTRAINT [PK_QuizCaetgories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Achievements'
ALTER TABLE [dbo].[Achievements]
ADD CONSTRAINT [PK_Achievements]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersToAchievements'
ALTER TABLE [dbo].[UsersToAchievements]
ADD CONSTRAINT [PK_UsersToAchievements]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [PK_Questions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'QuestionTypes'
ALTER TABLE [dbo].[QuestionTypes]
ADD CONSTRAINT [PK_QuestionTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SequencesTrue'
ALTER TABLE [dbo].[SequencesTrue]
ADD CONSTRAINT [PK_SequencesTrue]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BoolsTrue'
ALTER TABLE [dbo].[BoolsTrue]
ADD CONSTRAINT [PK_BoolsTrue]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DefaultsTrue'
ALTER TABLE [dbo].[DefaultsTrue]
ADD CONSTRAINT [PK_DefaultsTrue]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Sessions'
ALTER TABLE [dbo].[Sessions]
ADD CONSTRAINT [PK_Sessions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SessionStatuses'
ALTER TABLE [dbo].[SessionStatuses]
ADD CONSTRAINT [PK_SessionStatuses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersToSessions'
ALTER TABLE [dbo].[UsersToSessions]
ADD CONSTRAINT [PK_UsersToSessions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersAnswersSequence'
ALTER TABLE [dbo].[UsersAnswersSequence]
ADD CONSTRAINT [PK_UsersAnswersSequence]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserAnswersBool'
ALTER TABLE [dbo].[UserAnswersBool]
ADD CONSTRAINT [PK_UserAnswersBool]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserAnswersDefault'
ALTER TABLE [dbo].[UserAnswersDefault]
ADD CONSTRAINT [PK_UserAnswersDefault]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RoleId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_RoleUser]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[UserRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleUser'
CREATE INDEX [IX_FK_RoleUser]
ON [dbo].[Users]
    ([RoleId]);
GO

-- Creating foreign key on [StatusId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_UserStatusUser]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[UserStatuses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserStatusUser'
CREATE INDEX [IX_FK_UserStatusUser]
ON [dbo].[Users]
    ([StatusId]);
GO

-- Creating foreign key on [UserIdFrom] in table 'UserFriendsSet'
ALTER TABLE [dbo].[UserFriendsSet]
ADD CONSTRAINT [FK_UserFriendsUser]
    FOREIGN KEY ([UserIdFrom])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserFriendsUser'
CREATE INDEX [IX_FK_UserFriendsUser]
ON [dbo].[UserFriendsSet]
    ([UserIdFrom]);
GO

-- Creating foreign key on [UserIdTo] in table 'UserFriendsSet'
ALTER TABLE [dbo].[UserFriendsSet]
ADD CONSTRAINT [FK_UserFriendsUser1]
    FOREIGN KEY ([UserIdTo])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserFriendsUser1'
CREATE INDEX [IX_FK_UserFriendsUser1]
ON [dbo].[UserFriendsSet]
    ([UserIdTo]);
GO

-- Creating foreign key on [UserId] in table 'UsersToChats'
ALTER TABLE [dbo].[UsersToChats]
ADD CONSTRAINT [FK_UserToChatUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserToChatUser'
CREATE INDEX [IX_FK_UserToChatUser]
ON [dbo].[UsersToChats]
    ([UserId]);
GO

-- Creating foreign key on [ChatId] in table 'UsersToChats'
ALTER TABLE [dbo].[UsersToChats]
ADD CONSTRAINT [FK_ChatUserToChat]
    FOREIGN KEY ([ChatId])
    REFERENCES [dbo].[Chats]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChatUserToChat'
CREATE INDEX [IX_FK_ChatUserToChat]
ON [dbo].[UsersToChats]
    ([ChatId]);
GO

-- Creating foreign key on [ChatId] in table 'ChatMessages'
ALTER TABLE [dbo].[ChatMessages]
ADD CONSTRAINT [FK_ChatChatMessage]
    FOREIGN KEY ([ChatId])
    REFERENCES [dbo].[Chats]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChatChatMessage'
CREATE INDEX [IX_FK_ChatChatMessage]
ON [dbo].[ChatMessages]
    ([ChatId]);
GO

-- Creating foreign key on [UserId] in table 'ChatMessages'
ALTER TABLE [dbo].[ChatMessages]
ADD CONSTRAINT [FK_ChatMessageUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChatMessageUser'
CREATE INDEX [IX_FK_ChatMessageUser]
ON [dbo].[ChatMessages]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'QuizesApproved'
ALTER TABLE [dbo].[QuizesApproved]
ADD CONSTRAINT [FK_UserQuizApproved]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserQuizApproved'
CREATE INDEX [IX_FK_UserQuizApproved]
ON [dbo].[QuizesApproved]
    ([UserId]);
GO

-- Creating foreign key on [QuizId] in table 'QuizesApproved'
ALTER TABLE [dbo].[QuizesApproved]
ADD CONSTRAINT [FK_QuizQuizApproved]
    FOREIGN KEY ([QuizId])
    REFERENCES [dbo].[Quizes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuizQuizApproved'
CREATE INDEX [IX_FK_QuizQuizApproved]
ON [dbo].[QuizesApproved]
    ([QuizId]);
GO

-- Creating foreign key on [QuizId] in table 'UsersQuizesResp'
ALTER TABLE [dbo].[UsersQuizesResp]
ADD CONSTRAINT [FK_QuizUserQuizResp]
    FOREIGN KEY ([QuizId])
    REFERENCES [dbo].[Quizes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuizUserQuizResp'
CREATE INDEX [IX_FK_QuizUserQuizResp]
ON [dbo].[UsersQuizesResp]
    ([QuizId]);
GO

-- Creating foreign key on [UserId] in table 'UsersQuizesResp'
ALTER TABLE [dbo].[UsersQuizesResp]
ADD CONSTRAINT [FK_UserUserQuizResp]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserQuizResp'
CREATE INDEX [IX_FK_UserUserQuizResp]
ON [dbo].[UsersQuizesResp]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Quizes'
ALTER TABLE [dbo].[Quizes]
ADD CONSTRAINT [FK_UserQuiz]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserQuiz'
CREATE INDEX [IX_FK_UserQuiz]
ON [dbo].[Quizes]
    ([UserId]);
GO

-- Creating foreign key on [StatusId] in table 'Quizes'
ALTER TABLE [dbo].[Quizes]
ADD CONSTRAINT [FK_QuizStatusQuiz]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[QuizStatuses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuizStatusQuiz'
CREATE INDEX [IX_FK_QuizStatusQuiz]
ON [dbo].[Quizes]
    ([StatusId]);
GO

-- Creating foreign key on [CategoryId] in table 'QuizesToCategories'
ALTER TABLE [dbo].[QuizesToCategories]
ADD CONSTRAINT [FK_QuizCaetgoryQuizToCategory]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[QuizCaetgories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuizCaetgoryQuizToCategory'
CREATE INDEX [IX_FK_QuizCaetgoryQuizToCategory]
ON [dbo].[QuizesToCategories]
    ([CategoryId]);
GO

-- Creating foreign key on [QuizId] in table 'QuizesToCategories'
ALTER TABLE [dbo].[QuizesToCategories]
ADD CONSTRAINT [FK_QuizQuizToCategory]
    FOREIGN KEY ([QuizId])
    REFERENCES [dbo].[Quizes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuizQuizToCategory'
CREATE INDEX [IX_FK_QuizQuizToCategory]
ON [dbo].[QuizesToCategories]
    ([QuizId]);
GO

-- Creating foreign key on [AchievementId] in table 'UsersToAchievements'
ALTER TABLE [dbo].[UsersToAchievements]
ADD CONSTRAINT [FK_AchievementUserToAchievement]
    FOREIGN KEY ([AchievementId])
    REFERENCES [dbo].[Achievements]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AchievementUserToAchievement'
CREATE INDEX [IX_FK_AchievementUserToAchievement]
ON [dbo].[UsersToAchievements]
    ([AchievementId]);
GO

-- Creating foreign key on [UserId] in table 'UsersToAchievements'
ALTER TABLE [dbo].[UsersToAchievements]
ADD CONSTRAINT [FK_UserUserToAchievement]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserToAchievement'
CREATE INDEX [IX_FK_UserUserToAchievement]
ON [dbo].[UsersToAchievements]
    ([UserId]);
GO

-- Creating foreign key on [TypeId] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [FK_QuestionTypeQuestion]
    FOREIGN KEY ([TypeId])
    REFERENCES [dbo].[QuestionTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuestionTypeQuestion'
CREATE INDEX [IX_FK_QuestionTypeQuestion]
ON [dbo].[Questions]
    ([TypeId]);
GO

-- Creating foreign key on [QuizId] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [FK_QuizQuestion]
    FOREIGN KEY ([QuizId])
    REFERENCES [dbo].[Quizes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuizQuestion'
CREATE INDEX [IX_FK_QuizQuestion]
ON [dbo].[Questions]
    ([QuizId]);
GO

-- Creating foreign key on [StatusId] in table 'Sessions'
ALTER TABLE [dbo].[Sessions]
ADD CONSTRAINT [FK_SessionStatusSession]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[SessionStatuses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SessionStatusSession'
CREATE INDEX [IX_FK_SessionStatusSession]
ON [dbo].[Sessions]
    ([StatusId]);
GO

-- Creating foreign key on [QuizId] in table 'Sessions'
ALTER TABLE [dbo].[Sessions]
ADD CONSTRAINT [FK_SessionQuiz]
    FOREIGN KEY ([QuizId])
    REFERENCES [dbo].[Quizes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SessionQuiz'
CREATE INDEX [IX_FK_SessionQuiz]
ON [dbo].[Sessions]
    ([QuizId]);
GO

-- Creating foreign key on [SessionId] in table 'UsersToSessions'
ALTER TABLE [dbo].[UsersToSessions]
ADD CONSTRAINT [FK_SessionUserToSession]
    FOREIGN KEY ([SessionId])
    REFERENCES [dbo].[Sessions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SessionUserToSession'
CREATE INDEX [IX_FK_SessionUserToSession]
ON [dbo].[UsersToSessions]
    ([SessionId]);
GO

-- Creating foreign key on [UserId] in table 'UsersToSessions'
ALTER TABLE [dbo].[UsersToSessions]
ADD CONSTRAINT [FK_UserUserToSession]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserToSession'
CREATE INDEX [IX_FK_UserUserToSession]
ON [dbo].[UsersToSessions]
    ([UserId]);
GO

-- Creating foreign key on [QuestionId] in table 'SequencesTrue'
ALTER TABLE [dbo].[SequencesTrue]
ADD CONSTRAINT [FK_QuestionSequenceTrue]
    FOREIGN KEY ([QuestionId])
    REFERENCES [dbo].[Questions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuestionSequenceTrue'
CREATE INDEX [IX_FK_QuestionSequenceTrue]
ON [dbo].[SequencesTrue]
    ([QuestionId]);
GO

-- Creating foreign key on [QuestionId] in table 'BoolsTrue'
ALTER TABLE [dbo].[BoolsTrue]
ADD CONSTRAINT [FK_QuestionBoolTrue]
    FOREIGN KEY ([QuestionId])
    REFERENCES [dbo].[Questions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuestionBoolTrue'
CREATE INDEX [IX_FK_QuestionBoolTrue]
ON [dbo].[BoolsTrue]
    ([QuestionId]);
GO

-- Creating foreign key on [QuestionId] in table 'DefaultsTrue'
ALTER TABLE [dbo].[DefaultsTrue]
ADD CONSTRAINT [FK_QuestionDefaultTrue]
    FOREIGN KEY ([QuestionId])
    REFERENCES [dbo].[Questions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuestionDefaultTrue'
CREATE INDEX [IX_FK_QuestionDefaultTrue]
ON [dbo].[DefaultsTrue]
    ([QuestionId]);
GO

-- Creating foreign key on [SequenceId] in table 'UsersAnswersSequence'
ALTER TABLE [dbo].[UsersAnswersSequence]
ADD CONSTRAINT [FK_SequenceTrueUserAnswerSequence]
    FOREIGN KEY ([SequenceId])
    REFERENCES [dbo].[SequencesTrue]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SequenceTrueUserAnswerSequence'
CREATE INDEX [IX_FK_SequenceTrueUserAnswerSequence]
ON [dbo].[UsersAnswersSequence]
    ([SequenceId]);
GO

-- Creating foreign key on [BoolId] in table 'UserAnswersBool'
ALTER TABLE [dbo].[UserAnswersBool]
ADD CONSTRAINT [FK_BoolTrueUserAnswerBool]
    FOREIGN KEY ([BoolId])
    REFERENCES [dbo].[BoolsTrue]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BoolTrueUserAnswerBool'
CREATE INDEX [IX_FK_BoolTrueUserAnswerBool]
ON [dbo].[UserAnswersBool]
    ([BoolId]);
GO

-- Creating foreign key on [DefaultId] in table 'UserAnswersDefault'
ALTER TABLE [dbo].[UserAnswersDefault]
ADD CONSTRAINT [FK_DefaultTrueUserAnswerDefault]
    FOREIGN KEY ([DefaultId])
    REFERENCES [dbo].[DefaultsTrue]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DefaultTrueUserAnswerDefault'
CREATE INDEX [IX_FK_DefaultTrueUserAnswerDefault]
ON [dbo].[UserAnswersDefault]
    ([DefaultId]);
GO

-- Creating foreign key on [UserSessionId] in table 'UsersAnswersSequence'
ALTER TABLE [dbo].[UsersAnswersSequence]
ADD CONSTRAINT [FK_UserAnswerSequenceUserToSession]
    FOREIGN KEY ([UserSessionId])
    REFERENCES [dbo].[UsersToSessions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserAnswerSequenceUserToSession'
CREATE INDEX [IX_FK_UserAnswerSequenceUserToSession]
ON [dbo].[UsersAnswersSequence]
    ([UserSessionId]);
GO

-- Creating foreign key on [UserSessionId] in table 'UserAnswersBool'
ALTER TABLE [dbo].[UserAnswersBool]
ADD CONSTRAINT [FK_UserAnswerBoolUserToSession]
    FOREIGN KEY ([UserSessionId])
    REFERENCES [dbo].[UsersToSessions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserAnswerBoolUserToSession'
CREATE INDEX [IX_FK_UserAnswerBoolUserToSession]
ON [dbo].[UserAnswersBool]
    ([UserSessionId]);
GO

-- Creating foreign key on [UserSessionId] in table 'UserAnswersDefault'
ALTER TABLE [dbo].[UserAnswersDefault]
ADD CONSTRAINT [FK_UserAnswerDefaultUserToSession]
    FOREIGN KEY ([UserSessionId])
    REFERENCES [dbo].[UsersToSessions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserAnswerDefaultUserToSession'
CREATE INDEX [IX_FK_UserAnswerDefaultUserToSession]
ON [dbo].[UserAnswersDefault]
    ([UserSessionId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------