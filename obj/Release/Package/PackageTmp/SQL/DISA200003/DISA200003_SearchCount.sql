DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@DATA_ID VARCHAR(MAX) = @DATA_ID;


SET @@QUERY = '';
SET @@QUERY = '
SELECT ISNULL(max(ROW_NUM),0) FROM 
(
	SELECT 
		ROW_NUMBER() OVER (ORDER BY format(cast(A.tgl_perolehan as date),''yyyyMMdd'')) as ROW_NUM,
		A.id as [ID], 
		A.jenis_jurnal as [JENIS JURNAL], 
		A.jenis_barang as [JENIS BARANG], 
		A.register as [REGISTER], 
		format(cast(A.tgl_register as date),''yyyyMMdd'') as [TGL REGISTER], 
		A.jenis_penyusutan as [JENIS PENYUSUTAN], 
		A.jenis_asset as [JENIS ASSET], 
		A.tarif_masa_penyusutan as [TARIF/MASA PENYUSUTAN], 
		A.satuan_penyusutan as [SATUAN PENYUSUTAN], 
		A.kode_barang as [KODE BARANG], 
		A.nama_barang as [NAMA BARANG], 
		format(cast(A.tgl_perolehan as date),''yyyyMMdd'') as [TANGGAL PEROLEHAN], 
		A.no_jurnal as [NO JURNAL], 
		A.no_invoice as [NO INVOICE], 
		A.qty as [QTY], 
		A.satuan as [SATUAN], 
		A.harga_satuan as [HARGA SATUAN], 
		A.harga_perolehan as [HARGA PEROLEHAN], 
		A.akum_penyusutan_awal_tahun as [AKUM. PENYUSUTAN AWAL TAHUN], 
		A.nilai_buku_awal_tahun as [NILAI BUKU AWAL TAHUN] 
	FROM 
		[192.168.0.4].[TxDTIPRD].[dbo].[ad_tp_acc_mr_penyusutan_assets] as A
	--JOIN
	--	[192.168.0.10].[TxDTIPRD].[dbo].[ad_dis_ma_master_asset] as B
	--ON
	--	A.no_asset = B.no_asset
	WHERE 
		1=1
		AND A.register = 1 
';
IF(@jenis_penyusutan <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.jenis_penyusutan LIKE ''%'+RTRIM(@jenis_penyusutan)+'%'' ';
	END

IF(@no_jurnal <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.no_jurnal LIKE ''%'+RTRIM(@no_jurnal)+'%'' ';
	END

IF(@no_asset <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND B.no_asset LIKE ''%'+RTRIM(@no_asset)+'%'' ';
	END

IF(@nama_barang <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.nama_barang LIKE ''%'+RTRIM(@nama_barang)+'%'' ';
	END

IF(@jenis_asset <> '')
	BEGIN
		SET @@QUERY = @@QUERY + 'AND A.jenis_asset LIKE ''%'+RTRIM(@jenis_asset)+'%'' ';
	END


SET @@QUERY = @@QUERY+ ') AS TB';


EXEC(@@QUERY);

