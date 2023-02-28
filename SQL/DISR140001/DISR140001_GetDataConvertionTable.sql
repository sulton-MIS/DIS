SELECT	
	ItemCode,
	PcsWeight,
	BundleWeight,
	BundleQty

FROM
	Y_ConvertionTablePacking
WHERE 
	ItemCode = @id_seihin