DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
	SELECT ISNULL(max(ROW_NUM),0) FROM 
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
		SET @@QUERY = @@QUERY + 'AND FLG_APPROVE = 1 ';

		IF(@STATUS_DISPOSE <> '')
			BEGIN
				SET @@QUERY = @@QUERY + 'AND FLG_DISPOSE = '''+RTRIM(@STATUS_DISPOSE)+''' ';
			END
		ELSE
			BEGIN
				SET @@QUERY = @@QUERY + 'AND (FLG_DISPOSE is null OR FLG_DISPOSE=0)';
			END

	END ELSE 

IF(@PAGE_VIEWER = 'WaitingApproval')
	BEGIN

		IF(@JENIS_TRANSAKSI <> '')
			BEGIN
				SET @@QUERY = @@QUERY + 'AND jenis_transaksi LIKE ''%' + RTRIM(@JENIS_TRANSAKSI) + '%'' ';
		END

		IF(@STATUS_APPROVE <> '')
			BEGIN
				SET @@QUERY = @@QUERY + 'AND FLG_APPROVE = '''+RTRIM(@STATUS_APPROVE)+''' ';
			END
		ELSE
			BEGIN
				SET @@QUERY = @@QUERY + 'AND (FLG_APPROVE is null OR FLG_APPROVE=0)';
			END
	END

--IF(@STATUS_APPROVE <> '')
--    BEGIN
--        SET @@QUERY = @@QUERY + 'AND status_approve >= ''' + RTRIM(@STATUS_APPROVE) + ' 00:00:00'' ';
--END;

--IF(@STATUS_DISPOSE <> '')
--    BEGIN
--        SET @@QUERY = @@QUERY + 'AND created_date < ''' + RTRIM(@STATUS_DISPOSE) + ' 23:59:59'' ';
--END;

SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

