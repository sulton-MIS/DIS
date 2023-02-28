	SELECT 
		tb_detail.id_trans as ID,
		id_produksi,
		tb_detail.dmc_code,
		id_proses,
		tb_m_kotei.name_kotei as nama_proses,
		serial_no as SERIAL,
		lot_no as LOTNO,
		berat_bundle_std as BERAT_BUNDLE_STD,
		berat_bundle_act as BERAT_BUNDLE_ACT,
		--berat_per_pcs as BERAT_PER_PCS,
		berat_pcs_std as BERAT_PCS_STD,
		avg_berat_pcs as AVG_BERAT_PCS,
		qty_std as QTY_BUNDLE_STD,
		tb_summary.qty as QTY_BUNDLE_ACT,
		id_sagyosha as NIK,
		pic as NAMA,
		tb_summary.shf as SHIFT,
		jenis_lotto as JENIS_LOTTO,
		status_lotto as STATUS_LOTTO,
		status_checker as STATUS_CHECKER,
		CASE 
			WHEN tb_summary.keterangan IS NULL THEN ''
			ELSE tb_summary.keterangan 
		END AS keterangan
	FROM
		Z_REX_Data_InOut_FG_Detail as tb_detail
		LEFT JOIN Z_REX_Data_InOut_FG_New as tb_summary ON tb_detail.id_trans = tb_summary.id_trans
		LEFT JOIN Z_RT_master_sagyosha as tb_operator ON tb_summary.opr_gaikan = tb_operator.name_sagyosha
		LEFT JOIN Z_RT_master_kotei as tb_m_kotei ON tb_detail.id_proses = tb_m_kotei.id_kotei
	WHERE 
		tb_detail.id_trans = @ID_BUNDLE
	ORDER BY SERIAL ASC