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
    ,(select convert(varchar, estimasi_dispose, 105)) AS estimasi_dispose';
IF(@PAGE_VIEWER = 'WaitingApproval')
	BEGIN
		SET @@QUERY = @@QUERY + '   ,(select convert(varchar, DATEADD(year, 0, tgl_pinjam), 105)) AS tgl_pinjam
									,(select convert(varchar, DATEADD(year, 0, estimasi_kembali), 105)) AS estimasi_kembali';
	END
SET @@QUERY = @@QUERY + '
 FROM 
(
	SELECT 
		ROW_NUMBER() OVER (ORDER BY id_tb_m_list DESC) ROW_NUM,
		id_tb_m_list as ID, 
		*
	';
	
IF(@PAGE_VIEWER = 'MasterListDokumen')
	BEGIN
		SET @@QUERY = @@QUERY + 'FROM ad_dis_dc_master_document ';
	END
	
IF(@PAGE_VIEWER = 'WaitingApproval')
	BEGIN
		SET @@QUERY = @@QUERY + 'FROM ad_dis_dc_master_document_temp ';
	END
				
SET @@QUERY = @@QUERY + '
	WHERE 1=1	
	AND (FLG_DELETE is null OR FLG_DELETE = 0)
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

IF(@TGL_REGISTER <> '')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND tgl_register LIKE ''%' + RTRIM(@TGL_REGISTER) + '%'' ';
END


IF(@PAGE_VIEWER = 'MasterListDokumen')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND (FLG_APPROVE = 1 OR FLG_APPROVE is null )';

		IF(@STATUS_DISPOSE <> '')
			BEGIN
				SET @@QUERY = @@QUERY + 'AND FLG_DISPOSE = '''+RTRIM(@STATUS_DISPOSE)+''' ';
			END

	END ELSE 

IF(@PAGE_VIEWER = 'WaitingApproval')
	BEGIN
		IF(@JENIS_TRANSAKSI = 'taruh')
			BEGIN
				SET @@QUERY = @@QUERY + 'AND jenis_transaksi LIKE ''%' + RTRIM(@JENIS_TRANSAKSI) + '%'' ';
			END
		ELSE IF(@JENIS_TRANSAKSI = 'pinjam')
			BEGIN
				SET @@QUERY = @@QUERY + 'AND jenis_transaksi LIKE ''%' + RTRIM(@JENIS_TRANSAKSI) + '%'' ';
			END

		IF(@STATUS_APPROVE <> '')
			BEGIN
				SET @@QUERY = @@QUERY + 'AND FLG_APPROVE LIKE ''%'+RTRIM(@STATUS_APPROVE)+'%'' ';
			END
		ELSE
			BEGIN
				SET @@QUERY = @@QUERY + 'AND (FLG_APPROVE = 0)';
			END
	END

SET @@QUERY = @@QUERY + ') as TB';
IF(@@START > 0
   AND @@DISPLAY > 0)
    BEGIN
        SET @@QUERY = @@QUERY + ' WHERE ROW_NUM BETWEEN ' + @@START + ' AND ''' + @@DISPLAY + ''' ';
END;
EXEC (@@QUERY);