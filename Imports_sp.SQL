SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spincDBKRealizationProcessSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spincDBKRealizationProcessSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spincDBKRealizationProcessSelectListSearch]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @KeyWord VarChar(250),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
    DECLARE @KeyWord1 VarChar(260)
    SET @KeyWord1 = '%' + LOWER(@KeyWord) + '%'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,SerialNo Int NOT NULL
  )
  INSERT INTO #PageIndex (SerialNo)
  SELECT [INC_DBKRealization].[SerialNo] FROM [INC_DBKRealization]
  INNER JOIN [IJTPerks].[dbo].[aspnet_users] AS [aspnet_users1]
    ON [INC_DBKRealization].[CreatedBy] = [aspnet_users1].[LoginID]
  LEFT OUTER JOIN [INC_Banks] AS [INC_Banks2]
    ON [INC_DBKRealization].[BankID] = [INC_Banks2].[BankID]
 WHERE  
   ( 
         STR(ISNULL([INC_DBKRealization].[SerialNo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([INC_DBKRealization].[FwdBatchNo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([INC_DBKRealization].[RtnBatchNo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([INC_DBKRealization].[VchBatchNo], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([INC_DBKRealization].[ProcessedBy],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([INC_DBKRealization].[CustomInvoiceNo],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([INC_DBKRealization].[Description],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([INC_DBKRealization].[ScrollNo],'')) LIKE @KeyWord1
     OR STR(ISNULL([INC_DBKRealization].[DBKAmount], 0)) LIKE @KeyWord1
     OR STR(ISNULL([INC_DBKRealization].[BankID], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([INC_DBKRealization].[DBK_DocumentNo],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([INC_DBKRealization].[DBK_LineNo],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([INC_DBKRealization].[CreatedBy],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([INC_DBKRealization].[DBK_BatchNo],'')) LIKE @KeyWord1
     OR STR(ISNULL([INC_DBKRealization].[StatusID], 0)) LIKE @KeyWord1
     OR STR(ISNULL([INC_DBKRealization].[BatchNo], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 'SerialNo' THEN [INC_DBKRealization].[SerialNo] END,
     CASE @OrderBy WHEN 'SerialNo DESC' THEN [INC_DBKRealization].[SerialNo] END DESC,
     CASE @OrderBy WHEN 'FwdBatchNo' THEN [INC_DBKRealization].[FwdBatchNo] END,
     CASE @OrderBy WHEN 'FwdBatchNo DESC' THEN [INC_DBKRealization].[FwdBatchNo] END DESC,
     CASE @OrderBy WHEN 'RtnBatchNo' THEN [INC_DBKRealization].[RtnBatchNo] END,
     CASE @OrderBy WHEN 'RtnBatchNo DESC' THEN [INC_DBKRealization].[RtnBatchNo] END DESC,
     CASE @OrderBy WHEN 'VchBatchNo' THEN [INC_DBKRealization].[VchBatchNo] END,
     CASE @OrderBy WHEN 'VchBatchNo DESC' THEN [INC_DBKRealization].[VchBatchNo] END DESC,
     CASE @OrderBy WHEN 'IsReturned' THEN [INC_DBKRealization].[IsReturned] END,
     CASE @OrderBy WHEN 'IsReturned DESC' THEN [INC_DBKRealization].[IsReturned] END DESC,
     CASE @OrderBy WHEN 'ProcessedBy' THEN [INC_DBKRealization].[ProcessedBy] END,
     CASE @OrderBy WHEN 'ProcessedBy DESC' THEN [INC_DBKRealization].[ProcessedBy] END DESC,
     CASE @OrderBy WHEN 'ProcessedOn' THEN [INC_DBKRealization].[ProcessedOn] END,
     CASE @OrderBy WHEN 'ProcessedOn DESC' THEN [INC_DBKRealization].[ProcessedOn] END DESC,
     CASE @OrderBy WHEN 'CustomInvoiceNo' THEN [INC_DBKRealization].[CustomInvoiceNo] END,
     CASE @OrderBy WHEN 'CustomInvoiceNo DESC' THEN [INC_DBKRealization].[CustomInvoiceNo] END DESC,
     CASE @OrderBy WHEN 'ValueDate' THEN [INC_DBKRealization].[ValueDate] END,
     CASE @OrderBy WHEN 'ValueDate DESC' THEN [INC_DBKRealization].[ValueDate] END DESC,
     CASE @OrderBy WHEN 'Description' THEN [INC_DBKRealization].[Description] END,
     CASE @OrderBy WHEN 'Description DESC' THEN [INC_DBKRealization].[Description] END DESC,
     CASE @OrderBy WHEN 'ScrollNo' THEN [INC_DBKRealization].[ScrollNo] END,
     CASE @OrderBy WHEN 'ScrollNo DESC' THEN [INC_DBKRealization].[ScrollNo] END DESC,
     CASE @OrderBy WHEN 'ScrollDate' THEN [INC_DBKRealization].[ScrollDate] END,
     CASE @OrderBy WHEN 'ScrollDate DESC' THEN [INC_DBKRealization].[ScrollDate] END DESC,
     CASE @OrderBy WHEN 'DBKAmount' THEN [INC_DBKRealization].[DBKAmount] END,
     CASE @OrderBy WHEN 'DBKAmount DESC' THEN [INC_DBKRealization].[DBKAmount] END DESC,
     CASE @OrderBy WHEN 'BankID' THEN [INC_DBKRealization].[BankID] END,
     CASE @OrderBy WHEN 'BankID DESC' THEN [INC_DBKRealization].[BankID] END DESC,
     CASE @OrderBy WHEN 'DBK_DocumentNo' THEN [INC_DBKRealization].[DBK_DocumentNo] END,
     CASE @OrderBy WHEN 'DBK_DocumentNo DESC' THEN [INC_DBKRealization].[DBK_DocumentNo] END DESC,
     CASE @OrderBy WHEN 'DBK_LineNo' THEN [INC_DBKRealization].[DBK_LineNo] END,
     CASE @OrderBy WHEN 'DBK_LineNo DESC' THEN [INC_DBKRealization].[DBK_LineNo] END DESC,
     CASE @OrderBy WHEN 'CreatedBy' THEN [INC_DBKRealization].[CreatedBy] END,
     CASE @OrderBy WHEN 'CreatedBy DESC' THEN [INC_DBKRealization].[CreatedBy] END DESC,
     CASE @OrderBy WHEN 'DBK_BatchNo' THEN [INC_DBKRealization].[DBK_BatchNo] END,
     CASE @OrderBy WHEN 'DBK_BatchNo DESC' THEN [INC_DBKRealization].[DBK_BatchNo] END DESC,
     CASE @OrderBy WHEN 'StatusID' THEN [INC_DBKRealization].[StatusID] END,
     CASE @OrderBy WHEN 'StatusID DESC' THEN [INC_DBKRealization].[StatusID] END DESC,
     CASE @OrderBy WHEN 'CreatedOn' THEN [INC_DBKRealization].[CreatedOn] END,
     CASE @OrderBy WHEN 'CreatedOn DESC' THEN [INC_DBKRealization].[CreatedOn] END DESC,
     CASE @OrderBy WHEN 'BatchNo' THEN [INC_DBKRealization].[BatchNo] END,
     CASE @OrderBy WHEN 'BatchNo DESC' THEN [INC_DBKRealization].[BatchNo] END DESC,
     CASE @OrderBy WHEN 'aspnet_Users1_UserFullName' THEN [aspnet_Users1].[UserFullName] END,
     CASE @OrderBy WHEN 'aspnet_Users1_UserFullName DESC' THEN [aspnet_Users1].[UserFullName] END DESC,
     CASE @OrderBy WHEN 'INC_Banks2_BankName' THEN [INC_Banks2].[BankName] END,
     CASE @OrderBy WHEN 'INC_Banks2_BankName DESC' THEN [INC_Banks2].[BankName] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [INC_DBKRealization].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,
    [INC_Banks2].[BankName] AS INC_Banks2_BankName 
  FROM [INC_DBKRealization] 
      INNER JOIN #PageIndex
          ON [INC_DBKRealization].[SerialNo] = #PageIndex.SerialNo
  INNER JOIN [IJTPerks].[dbo].[aspnet_users] AS [aspnet_users1]
    ON [INC_DBKRealization].[CreatedBy] = [aspnet_users1].[LoginID]
  LEFT OUTER JOIN [INC_Banks] AS [INC_Banks2]
    ON [INC_DBKRealization].[BankID] = [INC_Banks2].[BankID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spincDBKRealizationProcessSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spincDBKRealizationProcessSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spincDBKRealizationProcessSelectListFilteres]
  @Filter_FwdBatchNo Int,
  @Filter_RtnBatchNo Int,
  @Filter_VchBatchNo Int,
  @Filter_CustomInvoiceNo NVarChar(9),
  @Filter_StatusID Int,
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,SerialNo Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 'SerialNo'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[INC_DBKRealization].[SerialNo]'
  SET @LGSQL = @LGSQL + ' FROM [INC_DBKRealization] '
  SET @LGSQL = @LGSQL + '  INNER JOIN [IJTPerks].[dbo].[aspnet_users] AS [aspnet_users1]'
  SET @LGSQL = @LGSQL + '    ON [INC_DBKRealization].[CreatedBy] = [aspnet_users1].[LoginID]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [INC_Banks] AS [INC_Banks2]'
  SET @LGSQL = @LGSQL + '    ON [INC_DBKRealization].[BankID] = [INC_Banks2].[BankID]'
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_FwdBatchNo > 0) 
    SET @LGSQL = @LGSQL + ' AND [INC_DBKRealization].[FwdBatchNo] = ' + STR(@Filter_FwdBatchNo)
  IF (@Filter_RtnBatchNo > 0) 
    SET @LGSQL = @LGSQL + ' AND [INC_DBKRealization].[RtnBatchNo] = ' + STR(@Filter_RtnBatchNo)
  IF (@Filter_VchBatchNo > 0) 
    SET @LGSQL = @LGSQL + ' AND [INC_DBKRealization].[VchBatchNo] = ' + STR(@Filter_VchBatchNo)
  IF (@Filter_CustomInvoiceNo > '') 
    SET @LGSQL = @LGSQL + ' AND [INC_DBKRealization].[CustomInvoiceNo] = ''' + @Filter_CustomInvoiceNo + ''''
  IF (@Filter_StatusID > 0) 
    SET @LGSQL = @LGSQL + ' AND [INC_DBKRealization].[StatusID] = ' + STR(@Filter_StatusID)
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 'SerialNo' THEN '[INC_DBKRealization].[SerialNo]'
                        WHEN 'SerialNo DESC' THEN '[INC_DBKRealization].[SerialNo] DESC'
                        WHEN 'FwdBatchNo' THEN '[INC_DBKRealization].[FwdBatchNo]'
                        WHEN 'FwdBatchNo DESC' THEN '[INC_DBKRealization].[FwdBatchNo] DESC'
                        WHEN 'RtnBatchNo' THEN '[INC_DBKRealization].[RtnBatchNo]'
                        WHEN 'RtnBatchNo DESC' THEN '[INC_DBKRealization].[RtnBatchNo] DESC'
                        WHEN 'VchBatchNo' THEN '[INC_DBKRealization].[VchBatchNo]'
                        WHEN 'VchBatchNo DESC' THEN '[INC_DBKRealization].[VchBatchNo] DESC'
                        WHEN 'IsReturned' THEN '[INC_DBKRealization].[IsReturned]'
                        WHEN 'IsReturned DESC' THEN '[INC_DBKRealization].[IsReturned] DESC'
                        WHEN 'ProcessedBy' THEN '[INC_DBKRealization].[ProcessedBy]'
                        WHEN 'ProcessedBy DESC' THEN '[INC_DBKRealization].[ProcessedBy] DESC'
                        WHEN 'ProcessedOn' THEN '[INC_DBKRealization].[ProcessedOn]'
                        WHEN 'ProcessedOn DESC' THEN '[INC_DBKRealization].[ProcessedOn] DESC'
                        WHEN 'CustomInvoiceNo' THEN '[INC_DBKRealization].[CustomInvoiceNo]'
                        WHEN 'CustomInvoiceNo DESC' THEN '[INC_DBKRealization].[CustomInvoiceNo] DESC'
                        WHEN 'ValueDate' THEN '[INC_DBKRealization].[ValueDate]'
                        WHEN 'ValueDate DESC' THEN '[INC_DBKRealization].[ValueDate] DESC'
                        WHEN 'Description' THEN '[INC_DBKRealization].[Description]'
                        WHEN 'Description DESC' THEN '[INC_DBKRealization].[Description] DESC'
                        WHEN 'ScrollNo' THEN '[INC_DBKRealization].[ScrollNo]'
                        WHEN 'ScrollNo DESC' THEN '[INC_DBKRealization].[ScrollNo] DESC'
                        WHEN 'ScrollDate' THEN '[INC_DBKRealization].[ScrollDate]'
                        WHEN 'ScrollDate DESC' THEN '[INC_DBKRealization].[ScrollDate] DESC'
                        WHEN 'DBKAmount' THEN '[INC_DBKRealization].[DBKAmount]'
                        WHEN 'DBKAmount DESC' THEN '[INC_DBKRealization].[DBKAmount] DESC'
                        WHEN 'BankID' THEN '[INC_DBKRealization].[BankID]'
                        WHEN 'BankID DESC' THEN '[INC_DBKRealization].[BankID] DESC'
                        WHEN 'DBK_DocumentNo' THEN '[INC_DBKRealization].[DBK_DocumentNo]'
                        WHEN 'DBK_DocumentNo DESC' THEN '[INC_DBKRealization].[DBK_DocumentNo] DESC'
                        WHEN 'DBK_LineNo' THEN '[INC_DBKRealization].[DBK_LineNo]'
                        WHEN 'DBK_LineNo DESC' THEN '[INC_DBKRealization].[DBK_LineNo] DESC'
                        WHEN 'CreatedBy' THEN '[INC_DBKRealization].[CreatedBy]'
                        WHEN 'CreatedBy DESC' THEN '[INC_DBKRealization].[CreatedBy] DESC'
                        WHEN 'DBK_BatchNo' THEN '[INC_DBKRealization].[DBK_BatchNo]'
                        WHEN 'DBK_BatchNo DESC' THEN '[INC_DBKRealization].[DBK_BatchNo] DESC'
                        WHEN 'StatusID' THEN '[INC_DBKRealization].[StatusID]'
                        WHEN 'StatusID DESC' THEN '[INC_DBKRealization].[StatusID] DESC'
                        WHEN 'CreatedOn' THEN '[INC_DBKRealization].[CreatedOn]'
                        WHEN 'CreatedOn DESC' THEN '[INC_DBKRealization].[CreatedOn] DESC'
                        WHEN 'BatchNo' THEN '[INC_DBKRealization].[BatchNo]'
                        WHEN 'BatchNo DESC' THEN '[INC_DBKRealization].[BatchNo] DESC'
                        WHEN 'aspnet_Users1_UserFullName' THEN '[aspnet_Users1].[UserFullName]'
                        WHEN 'aspnet_Users1_UserFullName DESC' THEN '[aspnet_Users1].[UserFullName] DESC'
                        WHEN 'INC_Banks2_BankName' THEN '[INC_Banks2].[BankName]'
                        WHEN 'INC_Banks2_BankName DESC' THEN '[INC_Banks2].[BankName] DESC'
                        ELSE '[INC_DBKRealization].[SerialNo]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [INC_DBKRealization].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,
    [INC_Banks2].[BankName] AS INC_Banks2_BankName 
  FROM [INC_DBKRealization] 
      INNER JOIN #PageIndex
          ON [INC_DBKRealization].[SerialNo] = #PageIndex.SerialNo
  INNER JOIN [IJTPerks].[dbo].[aspnet_users] AS [aspnet_users1]
    ON [INC_DBKRealization].[CreatedBy] = [aspnet_users1].[LoginID]
  LEFT OUTER JOIN [INC_Banks] AS [INC_Banks2]
    ON [INC_DBKRealization].[BankID] = [INC_Banks2].[BankID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spincMEISRealizationProcessSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spincMEISRealizationProcessSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spincMEISRealizationProcessSelectListSearch]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @KeyWord VarChar(250),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
    DECLARE @KeyWord1 VarChar(260)
    SET @KeyWord1 = '%' + LOWER(@KeyWord) + '%'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,SerialNo Int NOT NULL
  )
  INSERT INTO #PageIndex (SerialNo)
  SELECT [INC_MEISRealization].[SerialNo] FROM [INC_MEISRealization]
  INNER JOIN [IJTPerks].[dbo].[aspnet_users] AS [aspnet_users1]
    ON [INC_MEISRealization].[CreatedBy] = [aspnet_users1].[LoginID]
  LEFT OUTER JOIN [INC_Banks] AS [INC_Banks2]
    ON [INC_MEISRealization].[BankID] = [INC_Banks2].[BankID]
 WHERE  
   ( 
         STR(ISNULL([INC_MEISRealization].[SerialNo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([INC_MEISRealization].[FwdBatchNo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([INC_MEISRealization].[RtnBatchNo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([INC_MEISRealization].[VchBatchNo], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([INC_MEISRealization].[ProcessedBy],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([INC_MEISRealization].[CustomInvoiceNo],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([INC_MEISRealization].[SBillNo],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([INC_MEISRealization].[FileNo],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([INC_MEISRealization].[MEISNo],'')) LIKE @KeyWord1
     OR STR(ISNULL([INC_MEISRealization].[MEISAmount], 0)) LIKE @KeyWord1
     OR STR(ISNULL([INC_MEISRealization].[OtherTax], 0)) LIKE @KeyWord1
     OR STR(ISNULL([INC_MEISRealization].[SaleAmount], 0)) LIKE @KeyWord1
     OR STR(ISNULL([INC_MEISRealization].[RealisedAmount], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([INC_MEISRealization].[SoldTo],'')) LIKE @KeyWord1
     OR STR(ISNULL([INC_MEISRealization].[BankID], 0)) LIKE @KeyWord1
     OR STR(ISNULL([INC_MEISRealization].[BatchNo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([INC_MEISRealization].[StatusID], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([INC_MEISRealization].[MEIS_DocumentNo],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([INC_MEISRealization].[MEIS_LineNo],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([INC_MEISRealization].[MEIS_BatchNo],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([INC_MEISRealization].[CreatedBy],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 'SerialNo' THEN [INC_MEISRealization].[SerialNo] END,
     CASE @OrderBy WHEN 'SerialNo DESC' THEN [INC_MEISRealization].[SerialNo] END DESC,
     CASE @OrderBy WHEN 'FwdBatchNo' THEN [INC_MEISRealization].[FwdBatchNo] END,
     CASE @OrderBy WHEN 'FwdBatchNo DESC' THEN [INC_MEISRealization].[FwdBatchNo] END DESC,
     CASE @OrderBy WHEN 'RtnBatchNo' THEN [INC_MEISRealization].[RtnBatchNo] END,
     CASE @OrderBy WHEN 'RtnBatchNo DESC' THEN [INC_MEISRealization].[RtnBatchNo] END DESC,
     CASE @OrderBy WHEN 'VchBatchNo' THEN [INC_MEISRealization].[VchBatchNo] END,
     CASE @OrderBy WHEN 'VchBatchNo DESC' THEN [INC_MEISRealization].[VchBatchNo] END DESC,
     CASE @OrderBy WHEN 'IsReturned' THEN [INC_MEISRealization].[IsReturned] END,
     CASE @OrderBy WHEN 'IsReturned DESC' THEN [INC_MEISRealization].[IsReturned] END DESC,
     CASE @OrderBy WHEN 'ProcessedBy' THEN [INC_MEISRealization].[ProcessedBy] END,
     CASE @OrderBy WHEN 'ProcessedBy DESC' THEN [INC_MEISRealization].[ProcessedBy] END DESC,
     CASE @OrderBy WHEN 'ProcessedOn' THEN [INC_MEISRealization].[ProcessedOn] END,
     CASE @OrderBy WHEN 'ProcessedOn DESC' THEN [INC_MEISRealization].[ProcessedOn] END DESC,
     CASE @OrderBy WHEN 'CustomInvoiceNo' THEN [INC_MEISRealization].[CustomInvoiceNo] END,
     CASE @OrderBy WHEN 'CustomInvoiceNo DESC' THEN [INC_MEISRealization].[CustomInvoiceNo] END DESC,
     CASE @OrderBy WHEN 'SBillNo' THEN [INC_MEISRealization].[SBillNo] END,
     CASE @OrderBy WHEN 'SBillNo DESC' THEN [INC_MEISRealization].[SBillNo] END DESC,
     CASE @OrderBy WHEN 'SBillDate' THEN [INC_MEISRealization].[SBillDate] END,
     CASE @OrderBy WHEN 'SBillDate DESC' THEN [INC_MEISRealization].[SBillDate] END DESC,
     CASE @OrderBy WHEN 'FileNo' THEN [INC_MEISRealization].[FileNo] END,
     CASE @OrderBy WHEN 'FileNo DESC' THEN [INC_MEISRealization].[FileNo] END DESC,
     CASE @OrderBy WHEN 'FileDate' THEN [INC_MEISRealization].[FileDate] END,
     CASE @OrderBy WHEN 'FileDate DESC' THEN [INC_MEISRealization].[FileDate] END DESC,
     CASE @OrderBy WHEN 'MEISNo' THEN [INC_MEISRealization].[MEISNo] END,
     CASE @OrderBy WHEN 'MEISNo DESC' THEN [INC_MEISRealization].[MEISNo] END DESC,
     CASE @OrderBy WHEN 'MEISDate' THEN [INC_MEISRealization].[MEISDate] END,
     CASE @OrderBy WHEN 'MEISDate DESC' THEN [INC_MEISRealization].[MEISDate] END DESC,
     CASE @OrderBy WHEN 'MEISAmount' THEN [INC_MEISRealization].[MEISAmount] END,
     CASE @OrderBy WHEN 'MEISAmount DESC' THEN [INC_MEISRealization].[MEISAmount] END DESC,
     CASE @OrderBy WHEN 'OtherTax' THEN [INC_MEISRealization].[OtherTax] END,
     CASE @OrderBy WHEN 'OtherTax DESC' THEN [INC_MEISRealization].[OtherTax] END DESC,
     CASE @OrderBy WHEN 'SaleAmount' THEN [INC_MEISRealization].[SaleAmount] END,
     CASE @OrderBy WHEN 'SaleAmount DESC' THEN [INC_MEISRealization].[SaleAmount] END DESC,
     CASE @OrderBy WHEN 'RealisedAmount' THEN [INC_MEISRealization].[RealisedAmount] END,
     CASE @OrderBy WHEN 'RealisedAmount DESC' THEN [INC_MEISRealization].[RealisedAmount] END DESC,
     CASE @OrderBy WHEN 'SoldTo' THEN [INC_MEISRealization].[SoldTo] END,
     CASE @OrderBy WHEN 'SoldTo DESC' THEN [INC_MEISRealization].[SoldTo] END DESC,
     CASE @OrderBy WHEN 'BankID' THEN [INC_MEISRealization].[BankID] END,
     CASE @OrderBy WHEN 'BankID DESC' THEN [INC_MEISRealization].[BankID] END DESC,
     CASE @OrderBy WHEN 'BatchNo' THEN [INC_MEISRealization].[BatchNo] END,
     CASE @OrderBy WHEN 'BatchNo DESC' THEN [INC_MEISRealization].[BatchNo] END DESC,
     CASE @OrderBy WHEN 'StatusID' THEN [INC_MEISRealization].[StatusID] END,
     CASE @OrderBy WHEN 'StatusID DESC' THEN [INC_MEISRealization].[StatusID] END DESC,
     CASE @OrderBy WHEN 'MEIS_DocumentNo' THEN [INC_MEISRealization].[MEIS_DocumentNo] END,
     CASE @OrderBy WHEN 'MEIS_DocumentNo DESC' THEN [INC_MEISRealization].[MEIS_DocumentNo] END DESC,
     CASE @OrderBy WHEN 'MEIS_LineNo' THEN [INC_MEISRealization].[MEIS_LineNo] END,
     CASE @OrderBy WHEN 'MEIS_LineNo DESC' THEN [INC_MEISRealization].[MEIS_LineNo] END DESC,
     CASE @OrderBy WHEN 'MEIS_BatchNo' THEN [INC_MEISRealization].[MEIS_BatchNo] END,
     CASE @OrderBy WHEN 'MEIS_BatchNo DESC' THEN [INC_MEISRealization].[MEIS_BatchNo] END DESC,
     CASE @OrderBy WHEN 'CreatedBy' THEN [INC_MEISRealization].[CreatedBy] END,
     CASE @OrderBy WHEN 'CreatedBy DESC' THEN [INC_MEISRealization].[CreatedBy] END DESC,
     CASE @OrderBy WHEN 'CreatedOn' THEN [INC_MEISRealization].[CreatedOn] END,
     CASE @OrderBy WHEN 'CreatedOn DESC' THEN [INC_MEISRealization].[CreatedOn] END DESC,
     CASE @OrderBy WHEN 'aspnet_Users1_UserFullName' THEN [aspnet_Users1].[UserFullName] END,
     CASE @OrderBy WHEN 'aspnet_Users1_UserFullName DESC' THEN [aspnet_Users1].[UserFullName] END DESC,
     CASE @OrderBy WHEN 'INC_Banks2_BankName' THEN [INC_Banks2].[BankName] END,
     CASE @OrderBy WHEN 'INC_Banks2_BankName DESC' THEN [INC_Banks2].[BankName] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [INC_MEISRealization].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,
    [INC_Banks2].[BankName] AS INC_Banks2_BankName 
  FROM [INC_MEISRealization] 
      INNER JOIN #PageIndex
          ON [INC_MEISRealization].[SerialNo] = #PageIndex.SerialNo
  INNER JOIN [IJTPerks].[dbo].[aspnet_users] AS [aspnet_users1]
    ON [INC_MEISRealization].[CreatedBy] = [aspnet_users1].[LoginID]
  LEFT OUTER JOIN [INC_Banks] AS [INC_Banks2]
    ON [INC_MEISRealization].[BankID] = [INC_Banks2].[BankID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spincMEISRealizationProcessSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spincMEISRealizationProcessSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spincMEISRealizationProcessSelectListFilteres]
  @Filter_FwdBatchNo Int,
  @Filter_RtnBatchNo Int,
  @Filter_VchBatchNo Int,
  @Filter_CustomInvoiceNo NVarChar(9),
  @Filter_BankID Int,
  @Filter_StatusID Int,
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,SerialNo Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 'SerialNo'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[INC_MEISRealization].[SerialNo]'
  SET @LGSQL = @LGSQL + ' FROM [INC_MEISRealization] '
  SET @LGSQL = @LGSQL + '  INNER JOIN [IJTPerks].[dbo].[aspnet_users] AS [aspnet_users1]'
  SET @LGSQL = @LGSQL + '    ON [INC_MEISRealization].[CreatedBy] = [aspnet_users1].[LoginID]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [INC_Banks] AS [INC_Banks2]'
  SET @LGSQL = @LGSQL + '    ON [INC_MEISRealization].[BankID] = [INC_Banks2].[BankID]'
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_FwdBatchNo > 0) 
    SET @LGSQL = @LGSQL + ' AND [INC_MEISRealization].[FwdBatchNo] = ' + STR(@Filter_FwdBatchNo)
  IF (@Filter_RtnBatchNo > 0) 
    SET @LGSQL = @LGSQL + ' AND [INC_MEISRealization].[RtnBatchNo] = ' + STR(@Filter_RtnBatchNo)
  IF (@Filter_VchBatchNo > 0) 
    SET @LGSQL = @LGSQL + ' AND [INC_MEISRealization].[VchBatchNo] = ' + STR(@Filter_VchBatchNo)
  IF (@Filter_CustomInvoiceNo > '') 
    SET @LGSQL = @LGSQL + ' AND [INC_MEISRealization].[CustomInvoiceNo] = ''' + @Filter_CustomInvoiceNo + ''''
  IF (@Filter_BankID > 0) 
    SET @LGSQL = @LGSQL + ' AND [INC_MEISRealization].[BankID] = ' + STR(@Filter_BankID)
  IF (@Filter_StatusID > 0) 
    SET @LGSQL = @LGSQL + ' AND [INC_MEISRealization].[StatusID] = ' + STR(@Filter_StatusID)
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 'SerialNo' THEN '[INC_MEISRealization].[SerialNo]'
                        WHEN 'SerialNo DESC' THEN '[INC_MEISRealization].[SerialNo] DESC'
                        WHEN 'FwdBatchNo' THEN '[INC_MEISRealization].[FwdBatchNo]'
                        WHEN 'FwdBatchNo DESC' THEN '[INC_MEISRealization].[FwdBatchNo] DESC'
                        WHEN 'RtnBatchNo' THEN '[INC_MEISRealization].[RtnBatchNo]'
                        WHEN 'RtnBatchNo DESC' THEN '[INC_MEISRealization].[RtnBatchNo] DESC'
                        WHEN 'VchBatchNo' THEN '[INC_MEISRealization].[VchBatchNo]'
                        WHEN 'VchBatchNo DESC' THEN '[INC_MEISRealization].[VchBatchNo] DESC'
                        WHEN 'IsReturned' THEN '[INC_MEISRealization].[IsReturned]'
                        WHEN 'IsReturned DESC' THEN '[INC_MEISRealization].[IsReturned] DESC'
                        WHEN 'ProcessedBy' THEN '[INC_MEISRealization].[ProcessedBy]'
                        WHEN 'ProcessedBy DESC' THEN '[INC_MEISRealization].[ProcessedBy] DESC'
                        WHEN 'ProcessedOn' THEN '[INC_MEISRealization].[ProcessedOn]'
                        WHEN 'ProcessedOn DESC' THEN '[INC_MEISRealization].[ProcessedOn] DESC'
                        WHEN 'CustomInvoiceNo' THEN '[INC_MEISRealization].[CustomInvoiceNo]'
                        WHEN 'CustomInvoiceNo DESC' THEN '[INC_MEISRealization].[CustomInvoiceNo] DESC'
                        WHEN 'SBillNo' THEN '[INC_MEISRealization].[SBillNo]'
                        WHEN 'SBillNo DESC' THEN '[INC_MEISRealization].[SBillNo] DESC'
                        WHEN 'SBillDate' THEN '[INC_MEISRealization].[SBillDate]'
                        WHEN 'SBillDate DESC' THEN '[INC_MEISRealization].[SBillDate] DESC'
                        WHEN 'FileNo' THEN '[INC_MEISRealization].[FileNo]'
                        WHEN 'FileNo DESC' THEN '[INC_MEISRealization].[FileNo] DESC'
                        WHEN 'FileDate' THEN '[INC_MEISRealization].[FileDate]'
                        WHEN 'FileDate DESC' THEN '[INC_MEISRealization].[FileDate] DESC'
                        WHEN 'MEISNo' THEN '[INC_MEISRealization].[MEISNo]'
                        WHEN 'MEISNo DESC' THEN '[INC_MEISRealization].[MEISNo] DESC'
                        WHEN 'MEISDate' THEN '[INC_MEISRealization].[MEISDate]'
                        WHEN 'MEISDate DESC' THEN '[INC_MEISRealization].[MEISDate] DESC'
                        WHEN 'MEISAmount' THEN '[INC_MEISRealization].[MEISAmount]'
                        WHEN 'MEISAmount DESC' THEN '[INC_MEISRealization].[MEISAmount] DESC'
                        WHEN 'OtherTax' THEN '[INC_MEISRealization].[OtherTax]'
                        WHEN 'OtherTax DESC' THEN '[INC_MEISRealization].[OtherTax] DESC'
                        WHEN 'SaleAmount' THEN '[INC_MEISRealization].[SaleAmount]'
                        WHEN 'SaleAmount DESC' THEN '[INC_MEISRealization].[SaleAmount] DESC'
                        WHEN 'RealisedAmount' THEN '[INC_MEISRealization].[RealisedAmount]'
                        WHEN 'RealisedAmount DESC' THEN '[INC_MEISRealization].[RealisedAmount] DESC'
                        WHEN 'SoldTo' THEN '[INC_MEISRealization].[SoldTo]'
                        WHEN 'SoldTo DESC' THEN '[INC_MEISRealization].[SoldTo] DESC'
                        WHEN 'BankID' THEN '[INC_MEISRealization].[BankID]'
                        WHEN 'BankID DESC' THEN '[INC_MEISRealization].[BankID] DESC'
                        WHEN 'BatchNo' THEN '[INC_MEISRealization].[BatchNo]'
                        WHEN 'BatchNo DESC' THEN '[INC_MEISRealization].[BatchNo] DESC'
                        WHEN 'StatusID' THEN '[INC_MEISRealization].[StatusID]'
                        WHEN 'StatusID DESC' THEN '[INC_MEISRealization].[StatusID] DESC'
                        WHEN 'MEIS_DocumentNo' THEN '[INC_MEISRealization].[MEIS_DocumentNo]'
                        WHEN 'MEIS_DocumentNo DESC' THEN '[INC_MEISRealization].[MEIS_DocumentNo] DESC'
                        WHEN 'MEIS_LineNo' THEN '[INC_MEISRealization].[MEIS_LineNo]'
                        WHEN 'MEIS_LineNo DESC' THEN '[INC_MEISRealization].[MEIS_LineNo] DESC'
                        WHEN 'MEIS_BatchNo' THEN '[INC_MEISRealization].[MEIS_BatchNo]'
                        WHEN 'MEIS_BatchNo DESC' THEN '[INC_MEISRealization].[MEIS_BatchNo] DESC'
                        WHEN 'CreatedBy' THEN '[INC_MEISRealization].[CreatedBy]'
                        WHEN 'CreatedBy DESC' THEN '[INC_MEISRealization].[CreatedBy] DESC'
                        WHEN 'CreatedOn' THEN '[INC_MEISRealization].[CreatedOn]'
                        WHEN 'CreatedOn DESC' THEN '[INC_MEISRealization].[CreatedOn] DESC'
                        WHEN 'aspnet_Users1_UserFullName' THEN '[aspnet_Users1].[UserFullName]'
                        WHEN 'aspnet_Users1_UserFullName DESC' THEN '[aspnet_Users1].[UserFullName] DESC'
                        WHEN 'INC_Banks2_BankName' THEN '[INC_Banks2].[BankName]'
                        WHEN 'INC_Banks2_BankName DESC' THEN '[INC_Banks2].[BankName] DESC'
                        ELSE '[INC_MEISRealization].[SerialNo]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [INC_MEISRealization].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,
    [INC_Banks2].[BankName] AS INC_Banks2_BankName 
  FROM [INC_MEISRealization] 
      INNER JOIN #PageIndex
          ON [INC_MEISRealization].[SerialNo] = #PageIndex.SerialNo
  INNER JOIN [IJTPerks].[dbo].[aspnet_users] AS [aspnet_users1]
    ON [INC_MEISRealization].[CreatedBy] = [aspnet_users1].[LoginID]
  LEFT OUTER JOIN [INC_Banks] AS [INC_Banks2]
    ON [INC_MEISRealization].[BankID] = [INC_Banks2].[BankID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
