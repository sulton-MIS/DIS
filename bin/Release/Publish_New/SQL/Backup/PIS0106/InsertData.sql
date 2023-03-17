
IF @ScreenMode = 'Add'
	BEGIN
		INSERT INTO [dbo].[TB_M_STYLE]
            ([STYLE_CD]
		   ,[STYLE_NM]
		   ,[CREATED_BY]
		   ,[CREATED_DT]
		   ,[CHANGED_BY]
		   ,[CHANGED_DT]
	      )
     VALUES
           (@StyleCode
		   ,@StyleName
		   ,@CreatedBy
		   ,GETDATE()
		   ,@ChangedBy
		   ,GETDATE()
           )
		SELECT top 1 message = replace(message_text,'{0}','Style Master insert ') from  tb_m_message where message_id='MTPS00036I'
	END
ELSE 
IF @ScreenMode = 'Edit'
	BEGIN
		UPDATE [dbo].[TB_M_STYLE]
		SET	[STYLE_NM] = @StyleName
			,[CHANGED_by] = @ChangedBy
			,[CHANGED_DT] = GETDATE()
		where [STYLE_CD] = @StyleCode
	SELECT top 1 message = replace(message_text,'{0}','Style Master updated ') from  tb_m_message where message_id='MTPS00036I'
	END

