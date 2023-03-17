
IF @ScreenMode = 'Add'
	BEGIN
		INSERT INTO [dbo].[TB_M_LINE]
           ([SID]
           ,[LINE_CD]
		   ,[LINE_NM]
		   ,[CREATED_BY]
		   ,[CREATED_DT]
		   ,[CHANGED_BY]
		   ,[CHANGED_DT]
	      )
     VALUES
           (NEWID()
           ,@LineCode
		   ,@LineName
		   ,@CreatedBy
		   ,GETDATE()
		   ,@ChangedBy
		   ,GETDATE()
           )
		SELECT top 1 message = replace(message_text,'{0}','Line Master insert ') from  tb_m_message where message_id='MTPS00036I'
	END
ELSE 
IF @ScreenMode = 'Edit'
	BEGIN
		UPDATE [dbo].[TB_M_LINE]
		SET	[LINE_NM] = @LineName
			,[CHANGED_by] = @ChangedBy
			,[CHANGED_DT] = GETDATE()
		where SID = @SID
	SELECT top 1 message = replace(message_text,'{0}','Direct Delivery Master updated ') from  tb_m_message where message_id='MTPS00036I'
	END

