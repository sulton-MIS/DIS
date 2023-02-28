DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;

SET @@QUERY = '';
SET @@QUERY = 'SELECT * FROM ( 
	SELECT 
	   ROW_NUMBER() OVER (ORDER BY B.TRANS_DATE DESC) ROW_NUM,
	   A.ID_TRANS as ID,
       A.ID_TRANS as ID_BUNDLE,
	   A.ID_PRODUKSI,
	   A.ID_PROSES,
	   E.NAME_KOTEI AS NAMA_PROSES,
       A.DMC_CODE,
	   A.LOT_NO,
	   A.SERIAL_NO as SERIAL,
	   A.BERAT_PER_PCS,
	   C.id_sagyosha as NIK_GAIKAN, 
	   A.pic as OPR_GAIKAN,
	   B.KETERANGAN,
	   A.SHF as SHIFT,
	   B.KALI_PRINT as JML_PRINT,
	   FORMAT(A.TRANS_DATE, ''dd-MM-yyyy HH:mm:ss'') as TRANS_DATE,
	   STATUS_CHECKER,
	   D.name_sagyosha as Checker,
	   FORMAT(B.CHECKER_DATE, ''dd-MM-yyyy HH:mm:ss'') as CHECKER_DATE
    FROM dbo.Z_REX_Data_InOut_FG_Detail A
		LEFT JOIN Z_REX_Data_InOut_FG_New B ON B.id_trans = A.id_trans
		LEFT JOIN Z_RT_master_sagyosha C ON B.nik_gaikan = C.id_sagyosha
		LEFT JOIN Z_RT_master_sagyosha D ON B.checker = D.id_sagyosha
		LEFT JOIN Z_RT_master_kotei E ON A.id_proses = E.id_kotei
    WHERE 1=1 and A.id_trans like ''B%''';

IF(@ID_BUNDLE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.ID_TRANS LIKE ''%'+@ID_BUNDLE+'%'' ';
	END
IF(@DMC_CODE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.DMC_CODE LIKE ''%'+@DMC_CODE+'%'' ';
	END

IF(@NIK_GAIKAN <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND D.ID_SAGYOSHA LIKE ''%'+@NIK_GAIKAN+'%'' ';
	END
	
IF(@OPR_GAIKAN <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND B.OPR_GAIKAN LIKE ''%'+@OPR_GAIKAN+'%'' ';
	END

IF(@TRANS_DATE <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.TRANS_DATE >= '''+@TRANS_DATE+' 00:00:00'' ';
	END

IF(@TRANS_DATETO <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.TRANS_DATE <= '''+@TRANS_DATETO+' 23:59:59'' ';
	END

SET @@QUERY = @@QUERY +') as TB';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)