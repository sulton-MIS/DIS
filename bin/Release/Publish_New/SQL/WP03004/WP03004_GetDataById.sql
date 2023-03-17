SELECT [ID_TB_M_LEARN_MOD_TRAINING] AS [Id]
      ,[TITLE] AS [Title]
      ,[TRAINING_FOR] AS [Training_for]
      ,[DESCRIPTION] AS [Description]
      ,[FILE_PATH] AS [FilePath]
      ,[FILE_NAME] AS [FileName]
	  ,[CONTENT_TRAINING] AS [Content]
  FROM [dbo].[TB_M_LEARN_MODULE_TRAINING]
  WHERE [ID_TB_M_LEARN_MOD_TRAINING] = @id