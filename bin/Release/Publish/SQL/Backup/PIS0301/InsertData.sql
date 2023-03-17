
IF @ScreenMode = 'Add'
	BEGIN
		INSERT INTO [dbo].[TB_M_TELE_PRINTER]
           ([PLANT_CD]
           ,[LOGICAL_TERMINAL]
		   ,[BC_TYPE]
		   ,[STATUS_LIVE]
		   ,[SEQ_NO_FLAG]
		   ,[SEQ_NO_PRIORITY]
		   ,[BODY_NO_FLAG]
		   ,[BODY_NO_PRIORITY]
		   ,[MODEL_FLAG]
		   ,[MODEL_PRIORITY]
		   ,[SPEC_NO_FLAG]
		   ,[SPEC_NO_PRIORITY]
		   ,[PART_NO_FLAG]
		   ,[PART_NO_PRIORITY]
		   ,[CREATED_BY]
		   ,[CREATED_DT]
		   ,[CHANGED_BY]
		   ,[CHANGED_DT]
	      )
     VALUES
           (@PlantCode
           ,@LogicalTerminal
		   ,@BcType
		   ,@StatusLive
		   ,@SeqNoFlag
		   ,@SeqNoPriority
		   ,@BodyNoFlag
		   ,@BodyNoPriority
		   ,@ModelFlag
		   ,@ModelPriority
		   ,@SpecNoFlag
		   ,@SpecNoPriority
		   ,@PartNoFlag
		   ,@PartNoPriority
		   ,@CreatedBy
		   ,GETDATE()
		   ,@ChangedBy
		   ,GETDATE()
           )
		SELECT top 1 message = replace(message_text,'{0}','Tele Printer Master insert ') from  tb_m_message where message_id='MTPS00036I'
	END
ELSE 
IF @ScreenMode = 'Edit'
	BEGIN
		UPDATE [dbo].[TB_M_TELE_PRINTER]
		SET	 [SEQ_NO_FLAG]		= @SeqNoFlag
		    ,[SEQ_NO_PRIORITY]	= @SeqNoPriority
		    ,[BODY_NO_FLAG]		= @BodyNoFlag
		    ,[BODY_NO_PRIORITY]	= @BodyNoPriority
		    ,[MODEL_FLAG]		= @ModelFlag
		    ,[MODEL_PRIORITY]	= @ModelPriority
		    ,[SPEC_NO_FLAG]		= @SpecNoFlag
		    ,[SPEC_NO_PRIORITY]	= @SpecNoPriority
		    ,[PART_NO_FLAG]		= @PartNoFlag
		    ,[PART_NO_PRIORITY]	= @PartNoPriority
			,[CHANGED_by]		= @ChangedBy
			,[CHANGED_DT]		= GETDATE()
		WHERE [PLANT_CD]			= @PlantCode
			AND [LOGICAL_TERMINAL]	= @LogicalTerminal
			AND [BC_TYPE]			= @BcType
			AND [STATUS_LIVE]		= @StatusLive
		
	SELECT top 1 message = replace(message_text,'{0}','Tele Printer Master updated ') from  tb_m_message where message_id='MTPS00036I'
	END

