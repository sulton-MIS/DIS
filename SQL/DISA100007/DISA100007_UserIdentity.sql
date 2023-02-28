SELECT
	--*,
	m_user.nik as NIK,
	m_user.nama as NAMA_USER,
	m_user.nama_alias as NAMA_USER_ALIAS,
	m_section.KODE_SECTION as KODE_SECTION,
	m_section.NAMA_SECTION as NAMA_SECTION,
	m_section.NAMA_ALIAS as NAMA_SECTION_ALIAS,
	m_dept.KODE_DEPT as KODE_DEPT,
	m_dept.NAMA_DEPT as NAMA_DEPT,
	m_dept.NAMA_ALIAS as NAMA_DEPT_ALIAS

FROM
	ad_dis_sc_master_user as m_user
	left join ad_dis_sc_master_section as m_section on m_user.kode_section = m_section.kode_section
	left join ad_dis_sc_master_departement as m_dept on m_section.kode_dept = m_dept.kode_dept
WHERE
	m_user.username like '%' + (@USERNAME) + '%'
