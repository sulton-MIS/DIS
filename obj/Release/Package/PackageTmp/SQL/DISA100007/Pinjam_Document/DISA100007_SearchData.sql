DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50)= @START;
DECLARE @@DISPLAY VARCHAR(50)= @DISPLAY;

SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
	,(select convert(varchar, created_date, 113)) as CREATED_DATE
	,(select convert(varchar, updated_date, 113)) as UPDATED_DATE
	,(select convert(varchar, dispose_date, 113)) as DISPOSE_DATE
	,(select convert(varchar, DATEADD(year, 0, tgl_register), 105)) AS TGL_REGISTER
    ,(select convert(varchar, estimasi_dispose, 105)) AS estimasi_dispose
	,(select convert(varchar, DATEADD(year, 0, tgl_pinjam), 105)) AS tgl_pinjam
	,(select convert(varchar, DATEADD(year, 0, estimasi_kembali), 105)) AS estimasi_kembali
	,(select convert(varchar, DATEADD(year, 0, tgl_kembali), 105)) AS tgl_kembali
 FROM 
(
	SELECT 
		ROW_NUMBER() OVER (ORDER BY id_tb_m_list DESC) ROW_NUM,
		id_tb_m_list as ID, 
		*
	FROM 
		ad_dis_dc_master_document_temp ';
	
SET @@QUERY = @@QUERY + '
	WHERE 1=1	
	AND jenis_transaksi = ''pinjam''
	AND FLG_APPROVE = 1 
';

IF(@NO_DOKUMEN <> '')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND no_document LIKE ''%' + RTRIM(@NO_DOKUMEN) + '%'' ';
END

IF(@NAMA_DOKUMEN <> '')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND nama_document LIKE ''%' + RTRIM(@NAMA_DOKUMEN) + '%'' ';
END

IF(@DEPARTMENT <> '')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND department LIKE ''%' + RTRIM(@DEPARTMENT) + '%'' ';
END

IF(@NOMOR_RAK <> '')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND rak LIKE ''%' + RTRIM(@NOMOR_RAK) + '%'' ';
END

IF(@LABEL_RAK <> '')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND label_rak LIKE ''%' + RTRIM(@LABEL_RAK) + '%'' ';
END

IF(@TGL_PINJAM <> '')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND tgl_pinjam LIKE ''%' + RTRIM(@TGL_PINJAM) + '%'' ';
END

IF(@STATUS_PENGEMBALIAN = '0')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND flg_kembali is null AND flg_pinjam = 1 ';
END ELSE
IF(@STATUS_PENGEMBALIAN = '1')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND flg_kembali = 1 AND flg_pinjam = 0 ';
END


SET @@QUERY = @@QUERY + ') as TB';
IF(@@START > 0
   AND @@DISPLAY > 0)
    BEGIN
        SET @@QUERY = @@QUERY + ' WHERE ROW_NUM BETWEEN ' + @@START + ' AND ''' + @@DISPLAY + ''' ';
END;
EXEC (@@QUERY);