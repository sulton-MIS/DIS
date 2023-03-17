
IF @ScreenMode = 'Add'
	BEGIN
		--INSERT INTO [dbo].[TB_M_LINE]
  --         ([SID]
  --         ,[LINE_CD]
		--   ,[LINE_NM]
		--   ,[CREATED_BY]
		--   ,[CREATED_DT]
		--   ,[CHANGED_BY]
		--   ,[CHANGED_DT]
	 --     )
  --   VALUES
  --         (NEWID()
  --         ,@LineCode
		--   ,@LineName
		--   ,@CreatedBy
		--   ,GETDATE()
		--   ,@ChangedBy
		--   ,GETDATE()
  --         )

		INSERT INTO [dbo].[TB_R_HARIGAMI_H]
			   ([LOGICAL_TERMINAL]
			   ,[BC_TYPE_R]
			   ,[VIN_NO]
			   ,[BODY_NO]
			   ,[ID_NO]
			   ,[PLANT_CD]
			   ,[SEQ_NO]
			   ,[KO_DATE]
			   ,[HARIGAMI_STATUS]
			   ,[STATUS_LIVE]
			   ,[CREATED_BY]
			   ,[CREATED_DT]
			   ,[CHANGED_BY]
			   ,[CHANGED_DT]
			   ,[MODEL]
			   ,[SUFFIX]
			   ,[COLOR]
			   ,[PRINTER_ID])
		 VALUES
			   (<LOGICAL_TERMINAL, varchar(20),>
			   ,<BC_TYPE_R, varchar(1),>
			   ,<VIN_NO, varchar(50),>
			   ,<BODY_NO, varchar(5),>
			   ,<ID_NO, varchar(16),>
			   ,<PLANT_CD, varchar(2),>
			   ,<SEQ_NO, varchar(10),>
			   ,<KO_DATE, datetime,>
			   ,<HARIGAMI_STATUS, varchar(1),>
			   ,<STATUS_LIVE, varchar(1),>
			   ,<CREATED_BY, varchar(50),>
			   ,<CREATED_DT, datetime,>
			   ,<CHANGED_BY, varchar(50),>
			   ,<CHANGED_DT, datetime,>
			   ,<MODEL, varchar(16),>
			   ,<SUFFIX, varchar(4),>
			   ,<COLOR, varchar(10),>
			   ,<PRINTER_ID, varchar(10),>)

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

