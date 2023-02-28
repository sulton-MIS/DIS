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
	FROM 
        ad_dis_dc_master_document_temp
	WHERE 1=1	
	    AND jenis_transaksi = ''pinjam''
	    AND FLG_PINJAM = 1 
	    AND FLG_APPROVE = 1 
	    AND (FLG_KEMBALI is null OR FLG_KEMBALI = 0)
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

IF(@TGL_PINJAM <> '')
    BEGIN
        SET @@QUERY = @@QUERY + 'AND tgl_pinjam LIKE ''%' + RTRIM(@TGL_PINJAM) + '%'' ';
END


SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

