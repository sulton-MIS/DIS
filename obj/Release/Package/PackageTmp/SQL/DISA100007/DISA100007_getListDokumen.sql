SELECT 
	*
	--id_tb_m_list, no_document, nama_document
FROM 
	ad_dis_dc_master_document

WHERE
	department LIKE '%' + RTRIM(@NAMA_DEPARTMENT) + '%'
	AND flg_dispose <> 1
