DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@START VARCHAR(50) = @START;
DECLARE @@DISPLAY VARCHAR(50) = @DISPLAY;

SET @@QUERY = '';
SET @@QUERY = 'SELECT 
	*
 FROM 
(
	SELECT 
		ROW_NUMBER() OVER (ORDER BY format(cast(A.tgl_perolehan as date),''yyyyMMdd'')) as ROW_NUM,
		A.id, 
		A.jenis_jurnal, 
		format(cast(A.tgl_register as date),''yyyyMMdd'') as tgl_register, 
		B.tahun, 
		A.jenis_penyusutan, 
		A.jenis_asset, 
		B.no_asset,
		A.kode_barang, 
		A.nama_barang, 
		format(cast(A.tgl_perolehan as date),''yyyyMMdd'') as tgl_perolehan, 
		A.no_jurnal, 
		A.no_invoice, 
		A.qty, 
		A.satuan, 
		A.harga_satuan, 
		A.tarif_masa_penyusutan, 
		A.satuan_penyusutan, 
		A.harga_perolehan, 
		A.akum_penyusutan_awal_tahun, 
		(A.harga_perolehan - A.akum_penyusutan_awal_tahun) as nilai_buku_awal_tahun, 
		cast(((A.harga_perolehan / A.tarif_masa_penyusutan) / 12) as decimal(18, 2)) as nilai_penyusutan_perbulan, 
		cast(((A.harga_perolehan / A.tarif_masa_penyusutan) / 12) as decimal(18, 2)) as jan, 
		cast(((A.harga_perolehan / A.tarif_masa_penyusutan) / 12) as decimal(18, 2)) as feb, 
		cast(((A.harga_perolehan / A.tarif_masa_penyusutan) / 12) as decimal(18, 2)) as mar, 
		cast(((A.harga_perolehan / A.tarif_masa_penyusutan) / 12) as decimal(18, 2)) as apr, 
		cast(((A.harga_perolehan / A.tarif_masa_penyusutan) / 12) as decimal(18, 2)) as may, 
		cast(((A.harga_perolehan / A.tarif_masa_penyusutan) / 12) as decimal(18, 2)) as jun, 
		cast(((A.harga_perolehan / A.tarif_masa_penyusutan) / 12) as decimal(18, 2)) as jul, 
		cast(((A.harga_perolehan / A.tarif_masa_penyusutan) / 12) as decimal(18, 2)) as aug, 
		cast(((A.harga_perolehan / A.tarif_masa_penyusutan) / 12) as decimal(18, 2)) as sep, 
		cast(((A.harga_perolehan / A.tarif_masa_penyusutan) / 12) as decimal(18, 2)) as oct, 
		cast(((A.harga_perolehan / A.tarif_masa_penyusutan) / 12) as decimal(18, 2)) as nov, 
		cast(((A.harga_perolehan / A.tarif_masa_penyusutan) / 12) as decimal(18, 2)) as dec, 
		cast((A.harga_perolehan / A.tarif_masa_penyusutan) as decimal(18, 2)) as total, 
		A.harga_perolehan - A.akum_penyusutan_awal_tahun - cast((A.harga_perolehan / A.tarif_masa_penyusutan) as decimal(18, 2)) as nilai_buku_nbv_tahun_berjalan 
	FROM 
		[192.168.0.4].[TxDTIPRD].[dbo].[ad_tp_acc_mr_penyusutan_assets] as A
	JOIN
		[192.168.0.10].[TxDTIPRD].[dbo].[ad_dis_ma_master_asset] as B
	ON
		A.no_asset = B.no_asset
	WHERE 
		1=1
		AND A.jenis_penyusutan = ''Straight Line''
		AND A.jenis_asset like ''%%''
';
IF(@no_jurnal <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND no_jurnal LIKE ''%'+RTRIM(@no_jurnal)+'%'' ';
	END

IF(@no_asset <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND no_asset LIKE ''%'+RTRIM(@no_asset)+'%'' ';
	END

IF(@nama_barang <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND nama_barang LIKE ''%'+RTRIM(@nama_barang)+'%'' ';
	END

IF(@jenis_asset <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND jenis_asset LIKE ''%'+RTRIM(@jenis_asset)+'%'' ';
	END




SET @@QUERY = @@QUERY +') as TB

';

IF(@@START > 0 AND @@DISPLAY > 0)
BEGIN	
	SET @@QUERY = @@QUERY +' WHERE ROW_NUM BETWEEN '+@@START+' AND '''+@@DISPLAY+''' ';
END

EXEC(@@QUERY)