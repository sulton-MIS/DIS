-- UpdateDataJson
IF(EXISTS(
	SELECT	TOP 1 *
	FROM	[dbo].[TB_R_PAGE_D]
	WHERE	[PLANT_CD] = @PlantCode
		AND	[TEMPLATE_NM] = @TemplateName
		AND	[BC_TYPE] = @BcType
		AND	[LOGICAL_TERMINAL] = @LogicalTerminal
		AND	[PAGE] = @Page
))
BEGIN
	UPDATE  [dbo].[TB_R_PAGE_D]
	SET		[OBJECT_ARGUMENT] = @JsonPages
		,	[CHANGED_by] = @ChangedBy
		,	[CHANGED_DT] = GETDATE()
	WHERE	[PLANT_CD] = @PlantCode
		AND	[TEMPLATE_NM] = @TemplateName
		AND	[BC_TYPE] = @BcType
		AND	[LOGICAL_TERMINAL] = @LogicalTerminal
		AND	[PAGE] = @Page
END
ELSE
BEGIN
	INSERT INTO [dbo].[TB_R_PAGE_D]
	(
			PLANT_CD
		,	TEMPLATE_NM
		,	BC_TYPE
		,	LOGICAL_TERMINAL
		,	[PAGE]
		,	OBJECT_ARGUMENT
		,	CREATED_BY
		,	CREATED_DT
		,	CHANGED_BY
		,	CHANGED_DT
	)
	SELECT 
			@PlantCode
		,	@TemplateName
		,	@BcType
		,	@LogicalTerminal
		,	@Page
		,	@JsonPages
		,	@ChangedBy
		,	GETDATE()
		,	@ChangedBy
		,	GETDATE()
END

SELECT TOP 1 
		MESSAGE = REPLACE(message_text,'{0}','Page Form Designer Header updated ') 
FROM	dbo.tb_m_message 
WHERE	message_id = 'MPISSTD031I'

