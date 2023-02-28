
DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;

SET @@QUERY = '';
SET @@QUERY = '
SELECT 
	*
 FROM 
(
	SELECT 
		ROW_NUMBER() OVER (
		ORDER BY
        CASE when RIGHT(DMC_TYPE, 2) = ''-F'' then 2 
			when RIGHT(DMC_TYPE, 2) = ''-G'' then 3
			when RIGHT(DMC_TYPE, 3) = ''-FG'' then 4
			when RIGHT(DMC_TYPE, 4) = ''-FGT'' then 5
			when RIGHT(DMC_TYPE, 7) = ''-FGT-GK'' then 6
		END ASC) ROW_NUM
		,DMC_TYPE as ID
        ,DMC_TYPE as DMC_CODE_PARTS
		,[MATERIAL_COST]
        ,[FINISH_GOODS]
        ,[PRINTING]
        ,[LAMINATING_AKHIR]
        ,[WASHING_GLASS]
        ,[SCRIBE]
        ,[HOGOSIRU]
        ,[PUNCHING]
        ,[SUDAH_PRESS]
        ,[SUDAH_KAPTONTAPE]
        ,[SUDAH_CHUKAN]
        ,[SUDAH_FPC]
        ,[SUDAH_HEATSEAL]
        ,[SUDAH_HARIAWASE]
        ,[SUDAH_AGING]
        ,[SUDAH_OVEN]
        ,[SUDAH_HOKYOTAPE]
        ,[SUDAH_DOUBLETAPE]
        ,[SUDAH_FUREKENSA]
        ,[SUDAH_CEK_KELENGKAPAN]
        ,[SUDAH_DENKI]
        ,[SUDAH_GAIKAN]
        ,[LABOR_COST]
        ,[ORIGINAL_LABOR_COST]
        ,[INDIRECT]
        ,[MANUFACTURING_COST]
        ,[FLG_STATUS_PROD]
        FROM [ad_dis_pc_wip_cost]
	WHERE 1=1
';

IF(@DMC_CODE_PARTS <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND DMC_TYPE LIKE ''%'+RTRIM(@DMC_CODE_PARTS)+'%'' ';
	END



SET @@QUERY = @@QUERY +') as TB';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+'''  ';
END

EXEC(@@QUERY)

