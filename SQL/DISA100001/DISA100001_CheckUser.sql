SELECT
	*
FROM
	ad_dis_sc_master_user as m_user
	left join ad_dis_sc_master_user_akses as m_user_akses on m_user.nik = m_user_akses.nik
	left join ad_dis_sc_master_form as m_form on m_user_akses.kode_form = m_form.kode_form
WHERE
	m_user.username like '%' + (@USERNAME) + '%'
	and m_form.nama_form like '%' + (@NAMA_FORM) + '%'
