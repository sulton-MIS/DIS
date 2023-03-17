INSERT INTO [dbo].[TB_R_LEARN_EXAM_SCORE]
           ([ID_TB_M_EMPLOYEE]
           ,[ID_TB_R_LEARN_EXAM_SUBJECT]
           ,[ID_TB_M_COMPANY]
           ,[ANSWER]
           ,[CORRECT_AMOUNT]
           ,[WRONG_AMOUNT]
           ,[NOT_ANSWERED_AMOUNT]
           ,[REMEDIAL]
           ,[SCORE]
           ,[PASS_GRADUATED]
           ,[TIMER]
           ,[SUBMIT_DATE]
           ,[IS_STATUS])
     VALUES
           (@EmployeeId
           ,@SubjectId
           ,@CompanyId
           ,@Answer
           ,@CorrectAmount
           ,@WrongAmount
           ,@NotAnswerAmount
           ,(SELECT COUNT(*)
            FROM [dbo].[TB_R_LEARN_EXAM_SCORE]
            WHERE ID_TB_M_EMPLOYEE = @EmployeeId AND ID_TB_R_LEARN_EXAM_SUBJECT = @SubjectId)
           ,@Score
           ,@PassGraduate
           ,@Timer
           ,GETDATE()
           ,@Status)