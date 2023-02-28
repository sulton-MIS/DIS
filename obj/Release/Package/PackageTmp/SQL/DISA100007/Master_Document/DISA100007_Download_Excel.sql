DECLARE @@QUERY VARCHAR(MAX);

--flg approve
SET @STATUS_APPROVE = CASE @STATUS_APPROVE 
						 WHEN '1' THEN '1'
						 WHEN '' THEN '0'
						 ELSE 0
						 END 
--flg dispose
SET @STATUS_DISPOSE = CASE @STATUS_DISPOSE 
						 WHEN '1' THEN '1'
						 WHEN '' THEN '0'
						 ELSE 0
						 END 

SET @@QUERY = 'SELECT 
				ROW_NUMBER() OVER (ORDER BY no_document ASC) ROW_NUM,
				no_document, 
				department, 
				bagian, 
				rak, 
				(rak + ''-'' + label_rak) as label_rak, 
				nama_document, 
				(select convert(varchar, DATEADD(year, 0, tgl_register), 105)) AS tgl_register,
				(select convert(varchar, masa_simpan, 105) + '' tahun'') AS masa_simpan, 
				(select convert(varchar, estimasi_dispose, 105)) AS estimasi_dispose,
				keterangan,
				CASE
					WHEN flg_dispose = 1 THEN ''DISPOSE''
				ELSE
					''NON-DISPOSE''
				END as flg_dispose,
				dispose_by,
				--dispose_date,
				(select convert(varchar, DATEADD(year, 0, dispose_date), 105)) AS dispose_date,

				created_by,
				--created_date,
				(select convert(varchar, DATEADD(year, 0, created_date), 105)) AS created_date,

				updated_by,
				(select convert(varchar, DATEADD(year, 0, updated_date), 105)) AS updated_date
				--updated_date
			FROM
				ad_dis_dc_master_document
			WHERE
				FLG_DELETE is null OR FLG_DELETE = 0
				AND no_document LIKE ''%' +RTRIM(@NO_DOKUMEN)+ '%''
				AND nama_document LIKE ''%' +RTRIM(@NAMA_DOKUMEN)+ '%''
				AND department LIKE ''%' +RTRIM(@DEPARTMENT)+ '%''
			';
IF(@PAGE_VIEWER = 'MasterListDokumen')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND (FLG_APPROVE = 1 OR FLG_APPROVE is null )';

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
		IF(@STATUS_APPROVE <> '')
			BEGIN
				SET @@QUERY = @@QUERY + 'AND FLG_APPROVE LIKE ''%'+RTRIM(@STATUS_APPROVE)+'%'' ';
			END
		ELSE
			BEGIN
				SET @@QUERY = @@QUERY + 'AND (FLG_APPROVE = 0)';
			END
	END
	
EXEC (@@QUERY);