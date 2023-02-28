SELECT 
	ROW_NUMBER() OVER (ORDER BY tb_dispose_asset.no_asset ASC) ROW_NUM,
	*,
	FORMAT(tb_dispose_asset.created_date, 'dd/MMMM/yyyy hh:mm:ss', 'id-ID') as created_date
FROM 
	ad_dis_ma_dispose_asset tb_dispose_asset
LEFT JOIN 
	ad_dis_ma_dispose_asset_detail tb_dispose_asset_detail ON tb_dispose_asset.no_dispose = tb_dispose_asset_detail.no_dispose
LEFT JOIN
	ad_dis_ma_master_asset tb_asset ON tb_dispose_asset_detail.no_asset =  tb_asset.no_asset
WHERE 
	tb_dispose_asset.no_dispose = @ID
