DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
	(
	SELECT ROW_NUMBER() OVER (ORDER BY Dmc_Type ASC) ROW_NUM,
	[Dmc_Type] as ID, 
	*
	FROM [ad_dis_pc_production_cost_material]		
	WHERE 1=1	
';

IF(@DMC_TYPE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND [Dmc_Type] LIKE ''%'+RTRIM(@DMC_TYPE)+'%'' ';
	END
SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);



--DECLARE @@QUERY VARCHAR(MAX);
--DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


--SET @@QUERY = '';
--SET @@QUERY = '
--	SELECT ISNULL(max(ROW_NUM),0) FROM 
--	(
--	SELECT ROW_NUMBER() OVER (ORDER BY Dmc_Type ASC) ROW_NUM,
--	[Dmc_Type] as ID, 
--	*
--	FROM [ad_dis_pc_production_cost_summary]		
--	WHERE 1=1	
--';

--IF(@DMC_TYPE <> '')
--	BEGIN
--		SET @@QUERY = @@QUERY + 'AND [Dmc_Type] LIKE ''%'+RTRIM(@DMC_TYPE)+'%'' ';
--	END

--IF(@CUSTOMER <> '')
--	BEGIN
--		SET @@QUERY = @@QUERY + 'AND [Customer] LIKE ''%'+RTRIM(@CUSTOMER)+'%'' ';
--	END
	
--IF(@TYPE <> '')
--	BEGIN
--		SET @@QUERY = @@QUERY + 'AND [Type] LIKE ''%'+RTRIM(@TYPE)+'%'' ';
--	END
	
--IF(@GRADE <> '')
--	BEGIN
--		SET @@QUERY = @@QUERY + 'AND [Rank] LIKE ''%'+RTRIM(@GRADE)+'%'' ';
--	END

--SET @@QUERY = @@QUERY+ ') AS TB';


--EXEC(@@QUERY);

