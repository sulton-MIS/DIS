
IF @ScreenMode = 'Add'
	BEGIN
		INSERT INTO [dbo].[TB_R_PAGE_H]
           ([PLANT_CD]
           ,[TEMPLATE_NM]
		   ,[BC_TYPE]
		   ,[LOGICAL_TERMINAL]
		   ,[PAGE_TYPE]
		   ,[STATUS_LIVE]
		   ,[ORIENTATION]
		   ,[HARIGAMI_STS]
		   ,[CREATED_BY]
		   ,[CREATED_DT]
		   ,[CHANGED_BY]
		   ,[CHANGED_DT]
	      )
     VALUES
           (@PlantCode
           ,@TemplateName
		   ,@BcType
		   ,@LogicalTerminal
		   ,@PageType
		   ,@StatusLive
		   ,@Orientation
		   ,@HarigamiStatus
		   ,@CreatedBy
		   ,GETDATE()
		   ,@ChangedBy
		   ,GETDATE()
           )
		SELECT top 1 message = replace(message_text,'{0}','Page Form Designer Header insert ') from  tb_m_message where message_id='MPISSTD031I'
	END
ELSE 
IF @ScreenMode = 'Edit'
	BEGIN
		UPDATE [dbo].[TB_R_PAGE_H]
		SET	 [PAGE_TYPE] = @PageType
			,[STATUS_LIVE] = @StatusLive
			,[ORIENTATION] = @Orientation
			,[HARIGAMI_STS] = @HarigamiStatus
			,[CHANGED_by] = @ChangedBy
			,[CHANGED_DT] = GETDATE()
		where [PLANT_CD] = @PlantCode
			and	[TEMPLATE_NM] = @TemplateName
			and	[BC_TYPE] = @BcType
			and	[LOGICAL_TERMINAL] = @LogicalTerminal

	SELECT top 1 message = replace(message_text,'{0}','Page Form Designer Header updated ') from  tb_m_message where message_id='MPISSTD031I'
	END

