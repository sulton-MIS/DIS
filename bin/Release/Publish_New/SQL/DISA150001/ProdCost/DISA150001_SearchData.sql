
DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;

SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT ROW_NUMBER() OVER (ORDER BY [Dmc_Type] ASC) ROW_NUM
	,[dmc_type] as ID 
	,[dmc_type]
    ,[customer]
    ,[touch_panel_type]
    ,[rank]
    ,[touch_panel_dimension]
    ,[touch_panel_size]
    ,[versi_wis]
    ,[lot_size]
    ,[indirect]
    ,[sga]
    ,[cavity_film]
    ,[cavity_glass]
    ,[cavity_tail]
    ,[yield_printing_film]
    ,[yield_printing_glass]
    ,[yield_printing_tail]
    ,[yield_film_midle_inspection]
    ,[yield_glass_midle_inspection]
    ,[yield_tail_electrical]
    ,[yield_tail_cosmetic]
    ,[yield_assembly]
    ,[yield_final_assembly]
    ,[yield_electrical_inspection]
    ,[yield_final_inspection]
    ,[yield_total_film]
    ,[yield_total_glass]
    ,[yield_total_tail]
    ,[lot_size_film]
    ,[max_lot_size_film]
    ,[lot_size_glass]
    ,[max_lot_size_glass]
    ,[lot_size_tail]
    ,[max_lot_size_tail]
    ,[labour_charge_printing]
    ,[labour_charge_assembly]
    ,[labour_charge_etching]
    ,[labour_charge_press]
    ,[labour_charge_non_printing]
    ,[labour_charge_kompo]
    ,[air_cif_sales_price]
    ,[air_cif_material_cost]
    ,[air_cif_labour_cost]
    ,[air_cif_indirect]
    ,[air_cif_sga]
    ,[air_cif_transportation_cost]
    ,[air_cif_grand_total]
    ,[air_cif_marginal_profit_ratio]
    ,[air_cif_profit_ratio]
    ,[fob_sales_price]
    ,[fob_material_cost]
    ,[fob_labour_cost]
    ,[fob_indirect]
    ,[fob_sga]
    ,[fob_transportation_cost]
    ,[fob_grand_total]
    ,[fob_marginal_profit_ratio]
    ,[fob_profit_ratio]
    ,[labour_cost_printing]
    ,[labour_cost_assembly]
    ,[labour_cost_etching]
    ,[labour_cost_press]
    ,[labour_cost_non_printing]
    ,[labour_cost_kompo]
    ,[material_cost_after_gaikan]
    ,[material_cost_after_gaikan_printing]
    ,[material_cost_after_gaikan_assembly]
    ,[material_cost_after_gaikan_etching]
    ,[material_cost_after_gaikan_press]
    ,[material_cost_after_gaikan_non_printing] 
FROM 
	ad_dis_pc_production_cost	
	WHERE 1=1	
';

IF(@DMC_TYPE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND [Dmc_Type] LIKE ''%'+RTRIM(@DMC_TYPE)+'%'' ';
	END

IF(@CUSTOMER <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND [Customer] LIKE ''%'+RTRIM(@CUSTOMER)+'%'' ';
	END
	
IF(@TYPE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND [Type] LIKE ''%'+RTRIM(@TYPE)+'%'' ';
	END
	
IF(@GRADE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND [Rank] LIKE ''%'+RTRIM(@GRADE)+'%'' ';
	END

SET @@QUERY = @@QUERY +') as TB';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+'''  ';
END

EXEC(@@QUERY)


--DECLARE @@QUERY VARCHAR(MAX);
--DECLARE @@START VARCHAR(50) = @START;
--DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;

--SET @@QUERY = '';
--SET @@QUERY = 'SELECT 
--	*
-- FROM 
--(
--	SELECT ROW_NUMBER() OVER (ORDER BY Dmc_Type ASC) ROW_NUM,
--	[Dmc_Type] as ID 
--	,[Dmc_Type]
--	,[Customer]
--	,[Lot_Size]
--	,SUBSTRING(format([MassProAirCifJpn], ''C'',''id-ID''), 1, 100) as [MassProAirCifJpn]
--	,SUBSTRING(format([MassProSeaCifJpn], ''C'',''id-ID''), 1, 100) as [MassProSeaCifJpn]
--	,SUBSTRING(format([MassProAirCifSha], ''C'',''id-ID''), 1, 100) as [MassProAirCifSha]
--	,SUBSTRING(format([MassProSeaCifSha], ''C'',''id-ID''), 1, 100) as [MassProSeaCifSha]
--	,SUBSTRING(format([MassProAirCifHkg], ''C'',''id-ID''), 1, 100) as [MassProAirCifHkg]
--	,SUBSTRING(format([MassProSeaCifHkg], ''C'',''id-ID''), 1, 100) as [MassProSeaCifHkg]
--	,SUBSTRING(format([MassProFob], ''C'',''id-ID''), 1, 100) as [MassProFob]
--	,SUBSTRING(format([EngineeringSample], ''C'',''id-ID''), 1, 100) as [EngineeringSample]
--	,[WIS]
--	,[Cavity_Film]
--    ,[Cavity_Glass]
--    ,[Cavity_Tail]
--	,[Type]
--    ,[Rank]
--    ,[Inch]
--	,SUBSTRING(format([Material_Cost], ''C'',''id-ID''), 1, 100) as [Material_Cost]
--	,SUBSTRING(format([Cost_Printing], ''C'',''id-ID''), 1, 100) as [Cost_Printing]
--	,SUBSTRING(format([Cost_Etching], ''C'',''id-ID''), 1, 100) as [Cost_Etching]
--	,SUBSTRING(format([Cost_Press], ''C'',''id-ID''), 1, 100) as [Cost_Press]
--	,SUBSTRING(format([Cost_Assy], ''C'',''id-ID''), 1, 100) as [Cost_Assy]
--	,SUBSTRING(format([Cost_Konpo], ''C'',''id-ID''), 1, 100) as [Cost_Konpo]
--	,SUBSTRING(format([Total_Labour], ''C'',''id-ID''), 1, 100) as [Total_Labour]
--	,SUBSTRING(format([InDirect_Labour], ''C'',''id-ID''), 1, 100) as [InDirect_Labour]
--	,SUBSTRING(format([SGA], ''C'',''id-ID''), 1, 100) as [SGA]
--	,SUBSTRING(format([Trans_AirCifJpn], ''C'',''id-ID''), 1, 100) as [Trans_AirCifJpn]
--	,SUBSTRING(format([Trans_SeaCifTokyo], ''C'',''id-ID''), 1, 100) as [Trans_SeaCifTokyo]
--	,SUBSTRING(format([Trans_AirCifSha], ''C'',''id-ID''), 1, 100) as [Trans_AirCifSha]
--	,SUBSTRING(format([Trans_SeaCifSha], ''C'',''id-ID''), 1, 100) as [Trans_SeaCifSha]
--	,SUBSTRING(format([Trans_AirCifHkg], ''C'',''id-ID''), 1, 100) as [Trans_AirCifHkg]
--	,SUBSTRING(format([Trans_SeaCifHkg], ''C'',''id-ID''), 1, 100) as [Trans_SeaCifHkg]
--	,SUBSTRING(format([Total_Cost_AirCifJpn], ''C'',''id-ID''), 1, 100) as [Total_Cost_AirCifJpn]
--	,SUBSTRING(format([Total_Cost_SeaCifTokyo], ''C'',''id-ID''), 1, 100) as [Total_Cost_SeaCifTokyo]
--	,SUBSTRING(format([Total_Cost_AirCifSha], ''C'',''id-ID''), 1, 100) as [Total_Cost_AirCifSha]
--	,SUBSTRING(format([Total_Cost_SeaCifSha], ''C'',''id-ID''), 1, 100) as [Total_Cost_SeaCifSha]
--	,SUBSTRING(format([Total_Cost_AirCifHkg], ''C'',''id-ID''), 1, 100) as [Total_Cost_AirCifHkg]
--	,SUBSTRING(format([Total_Cost_SeaCifHkg], ''C'',''id-ID''), 1, 100) as [Total_Cost_SeaCifHkg]
--	,SUBSTRING(format([Total_Cost_FOB], ''C'',''id-ID''), 1, 100) as [Total_Cost_FOB]
--	,SUBSTRING(format([Prod_Yield_Film], ''C'',''id-ID''), 1, 100) as [Prod_Yield_Film]
--    ,[CT_Printing]
--    ,[CT_NonPrinting]
--    ,[CT_Etching]
--    ,[CT_Press]
--    ,[CT_Assembly]
--    ,[CT_Konpo]
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

--SET @@QUERY = @@QUERY +') as TB';

--IF(@@START > 0 AND @@DISPLAY > 0)
--BEGIN	
--	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+'''  ';
--END

--EXEC(@@QUERY)