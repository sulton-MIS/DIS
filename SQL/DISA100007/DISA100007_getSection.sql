SELECT 
	m_section.kode_dept,
	kode_section, 
	nama_section, 
	m_section.nama_alias as nama_section_alias
FROM 
	ad_dis_sc_master_section as m_section
INNER JOIN 
	ad_dis_sc_master_departement m_dept ON m_section.kode_dept = m_dept.kode_dept