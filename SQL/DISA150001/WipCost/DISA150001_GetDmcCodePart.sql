DECLARE @@QUERY VARCHAR(MAX);

SET @@QUERY = '';

SET @@QUERY = '
		select 
			dmc_code as DMC_CODE,
			[dmc_code_parts] as DMC_CODE_PARTS,
			part as PART
		from
			[ad_dis_pc_production_cost_material_usage]
		where
			1=1
			AND DMC_CODE_PARTS not like ''%-S''
			AND PART NOT LIKE ''OTHERS''
		';

IF (@DMC_CODE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + '
			AND dmc_code_parts like ''%'+RTRIM(@DMC_CODE)+'%'' ';
	END

SET @@QUERY = @@QUERY + '
		group by 
			dmc_code,
			[dmc_code_parts],
			part
		order by 
			CASE when part = ''Film'' then 2 
			when part = ''Glass'' then 3
			when part = ''Tail'' then 4
			when part = ''Assembly'' then 5
			when part = ''Packing'' then 1
			END ASC
		';

EXEC(@@QUERY)