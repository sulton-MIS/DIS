IF EXISTS(SELECT TOP 1 1
			FROM TB_R_HARIGAMI_H
			WHERE LOGICAL_TERMINAL = @LogicalTerminal
				AND BC_TYPE = @BCTypeR
				AND VIN_NO = @VINNo
				AND BODY_NO = @BodyNo
				AND ID_NO = @IDNo
				AND PLANT_CD = @PlantCd
				AND SEQ_NO = @SeqNo)
BEGIN
	SELECT TOP 1 
	Result = CAST(0 as bit),
	Message = 'MPISSTD049E',
	Param = CONCAT(@LogicalTerminal, ', ', @BCTypeR, ', ', @VINNo, ', ', @BodyNo, ', ', @IDNo, ', ', @PlantCd, ', ', @SeqNo)
END
ELSE
BEGIN
	SELECT TOP 1 
	Result = CAST(1 as bit),
	Message = null,
	Param = CONCAT(@LogicalTerminal, ', ', @BCTypeR, ', ', @VINNo, ', ', @BodyNo, ', ', @IDNo, ', ', @PlantCd, ', ', @SeqNo)
END