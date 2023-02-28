SELECT 
	[ItemCode],
    [Parts],
    [SizeProduct],
    [type],
    [BundleQty],
    [InnerQty],
    [MasterQty],
    [InnerType],
    [InnerL],
    [InnerW],
    [InnerH],
    [InnerWeight],
    [MasterType],
    [MasterL],
    [MasterW],
    [MasterH],
    [MasterWeight]

FROM 
	Y_ConvertionTablePacking
WHERE 
	ItemCode LIKE '%' +RTRIM(@ItemCode)+ '%'