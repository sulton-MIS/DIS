SELECT 
	dt_hist.[no_document]
    ,m_doc.[nama_document] 
    ,m_doc.[keterangan] as keterangan_dokumen
    ,dt_hist.[nm_menu]
    ,dt_hist.[nm_fitur]
    ,dt_hist.[keterangan]
    ,dt_hist.[created_by]
    ,dt_hist.[created_date]
FROM 
    ad_dis_dc_history_document as dt_hist
LEFT JOIN
    ad_dis_dc_master_document as m_doc ON dt_hist.no_document = m_doc.no_document
WHERE
    dt_hist.no_document = (SELECT no_document FROM ad_dis_dc_master_document WHERE id_tb_m_list = @ID)
ORDER BY
    dt_hist.[created_date] DESC
	