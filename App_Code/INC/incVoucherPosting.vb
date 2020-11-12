Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Xml
Namespace SIS.TA
  Public Class taPostVoucherResult
    Public Property IsError As Boolean = False
    Public Property Message As String = ""
    Public Property BatchNo As String = ""
    Public Property DocumentNo As String = ""
    Public Property LineNo As String = ""
    Public Property VoucherType As String = ""
    Public Property VoucherCompany As String = ""
  End Class
  Public Class prjCmpActERP
    Public Property ProjectID As String = ""
    Public Property Company As String = ""
    Public Property Activity As String = ""
    Public Property Element As String = "99080500"
    Public Property SubContracting As String = "DPOH"
  End Class
  Public Class taVoucher
    Private Shared Sub UpdateBatchUser(ByVal BatchNo As String, ByVal UserID As String, ByVal VchDate As String, ByVal VchType As String)
      Dim rYear As String = ""
      Dim Sql As String = ""
      Sql = " Select "
      Sql &= " t_year As BatchYear "
      Sql &= " From ttfgld100200 "
      Sql &= " Where t_btno = " & BatchNo
      Sql &= " and t_user = '0340'"
      Sql &= " and t_tedt = convert(datetime,'" & VchDate & "',103)"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          rYear = Cmd.ExecuteScalar
        End Using
        Sql = " update "
        Sql &= " ttfgld100200 "
        Sql &= " set t_user = '" & UserID & "'"
        Sql &= " Where t_btno = " & BatchNo
        Sql &= " and t_user = '0340'"
        Sql &= " and t_tedt = convert(datetime,'" & VchDate & "',103)"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.ExecuteNonQuery()
        End Using
        Sql = " update "
        Sql &= " ttfgld101200 "
        Sql &= " set t_user = '" & UserID & "'"
        Sql &= " Where t_btno = " & BatchNo
        Sql &= " and t_user = '0340'"
        Sql &= " and t_year = " & rYear
        Sql &= " and t_ttyp = '" & VchType & "'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.ExecuteNonQuery()
        End Using
      End Using
    End Sub

    Private Shared Function GetProjectCompanyFromERP(ByVal ProjectID As String) As prjCmpActERP
      Dim mRet As SIS.TA.prjCmpActERP = Nothing
      Dim Sql As String = ""
      Sql = " Select "
      Sql &= " t_ncmp As Company "
      Sql &= " ,t_rsac As Activity "
      Sql &= " From ttppdm600200 "
      Sql &= " Where t_cprj = '" & ProjectID & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          If rd.Read Then
            mRet = New prjCmpActERP
            mRet.ProjectID = ProjectID
            mRet.Company = rd("Company")
            mRet.Activity = rd("Activity")
          End If
        End Using
      End Using
      Return mRet
    End Function

    Public Shared Function CreatePostVoucherData(xData As List(Of SIS.INC.vchData), ByVal VCHOn As String, vchBatch As Integer) As List(Of taPostVoucherResult)
      Dim mRet As New List(Of taPostVoucherResult)
      Dim dbkR As taPostVoucherResult = PostVoucher(xData, VCHOn, vchBatch, True)
      If Not dbkR.IsError Then
        mRet.Add(dbkR)
        Dim meisR As taPostVoucherResult = PostVoucher(xData, VCHOn, vchBatch, False)
        If Not meisR.IsError Then
          mRet.Add(meisR)
        End If
      End If
      Return mRet
    End Function

    Private Shared Function PostVoucher(ByVal xData As List(Of SIS.INC.vchData), ByVal VCHOn As String, vchBatch As Integer, IsDBK As Boolean) As taPostVoucherResult
      Dim UserId As String = HttpContext.Current.Session("LoginID")
      Dim mRet As New taPostVoucherResult
      Dim VoucherDate As String = ""
      Dim VoucherType As String = ""
      Dim CreditGL As String = ""
      Dim DebitGL As String = ""
      Dim Company As String = "200"
      Dim LineCount As Integer = 0
      Dim Remarks As String = ""
      Try
        Dim CardNo As String = Convert.ToInt32(HttpContext.Current.Session("LoginID"))
        Dim mFileName As String = CardNo & "_" & Now.ToString.Replace("/", "").Replace(":", "").Replace(" ", "") & ".xml"
        Dim tmpDir As String = HttpContext.Current.Server.MapPath("~/..") & "App_Temp\TABill"
        Dim oTW As IO.StreamWriter = New IO.StreamWriter(tmpDir & "\s\" & mFileName)
        oTW.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")

        VoucherDate = IIf(VCHOn = "", Now.Date, VCHOn)
        VoucherType = "JVN"
        If IsDBK Then
          DebitGL = "1550248"
          CreditGL = "5622110"
          Remarks = "DBK Provision " & Convert.ToDateTime(VoucherDate).ToString("MMM") & " " & Convert.ToDateTime(VoucherDate).Year
        Else
          DebitGL = "1550247"
          CreditGL = "5622110"
          Remarks = "MEIS Provision " & Convert.ToDateTime(VoucherDate).ToString("MMM") & " " & Convert.ToDateTime(VoucherDate).Year
        End If
        oTW.WriteLine("<Companies>")
        oTW.WriteLine("  <Company name=""" & Company & """>")
        oTW.WriteLine("    <Lines>")
        For Each tmp As SIS.INC.vchData In xData
          'insert Debit 
          oTW.WriteLine("      <Line PrkLedgerID=""" & vchBatch & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & DebitGL & "," & tmp.ProjectCode & "," & "" & "," & "" & "," & "" & "," & "UP" & "," & "INR" & "," & tmp.DAmt & "," & "1" & "," & Remarks & "," & CardNo & "," & "1.00" & "</Line>")
          LineCount += 1
          'Insert Credit
          oTW.WriteLine("      <CreditLine>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & CreditGL & "," & tmp.ProjectCode & "," & "" & "," & "" & "," & "" & "," & "UP" & "," & "INR" & "," & tmp.DAmt & "," & "2" & "," & Remarks & "," & CardNo & "," & "1.00" & "</CreditLine>")
          LineCount += 1
        Next
        oTW.WriteLine("    </Lines>")
        oTW.WriteLine("    <Batch>" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & VoucherType & "</Batch>")
        oTW.WriteLine("    <Errors><Error></Error></Errors>")
        oTW.WriteLine("  </Company>")
        oTW.WriteLine("</Companies>")
        oTW.Close()
        '============End VCH Posting=================
        mRet.VoucherType = VoucherType
        mRet.VoucherCompany = "200"
        '================Read===================
        Dim oTR As XmlDocument = New XmlDocument
        Dim TryCount As Integer = 0
        Dim ErrFound As Boolean = False
        Dim TryLimit As Integer = 150
        Do While True
          Try
            oTR.Load(tmpDir & "\t\P_" & mFileName)
            Exit Do
          Catch ex As Exception
            TryCount += 1
            Threading.Thread.Sleep(2000)
          End Try
          If TryCount >= TryLimit Then
            Exit Do
          End If
        Loop
        If TryCount < TryLimit Then
          'First check no error in xml
          For Each cmp As XmlNode In oTR.ChildNodes(1)
            Dim oErr As XmlNode = cmp.ChildNodes(2)
            For Each errchild As XmlNode In oErr.ChildNodes
              If errchild.InnerText <> String.Empty Then
                mRet.IsError = True
                mRet.Message = errchild.InnerText
                ErrFound = True
                Exit For
              End If
            Next
          Next
          If Not ErrFound Then
            For Each cmp As XmlNode In oTR.ChildNodes(1)
              Dim oLines As XmlNode = cmp.ChildNodes(0)
              Dim oBatch As XmlNode = cmp.ChildNodes(1)
              Dim oErr As XmlNode = cmp.ChildNodes(2)
              For Each cmpChild As XmlNode In cmp.ChildNodes
                If cmpChild.Name.ToLower = "lines" Then
                  For Each line As XmlNode In cmpChild.ChildNodes
                    If line.Name.ToLower <> "creditline" Then
                      Dim PrkLedgerID As String = line.Attributes("PrkLedgerID").Value
                      If vchBatch.ToString = PrkLedgerID Then
                        mRet.BatchNo = line.Attributes("BatchNo").Value
                        mRet.DocumentNo = line.Attributes("DocumentNo").Value
                        mRet.LineNo = line.Attributes("LineNo").Value
                      End If
                    End If
                  Next
                  Exit For
                End If
              Next
            Next
          End If
        Else
          mRet.IsError = True
          mRet.Message = "XML Not Processed"
        End If
      Catch ex As Exception
        mRet.IsError = True
        mRet.Message = ex.Message
      End Try
      If Not mRet.IsError Then
        Try
          UpdateBatchUser(mRet.BatchNo, UserId, VoucherDate, VoucherType)
        Catch ex As Exception
        End Try
      End If
      Return mRet
    End Function
    Public Shared Function CreateAndPostDBKRealization(xData As List(Of SIS.INC.vchData), ByVal VCHOn As String, vchBatch As Integer) As taPostVoucherResult
      Dim mRet As taPostVoucherResult = PostDBKRealization(xData, VCHOn, vchBatch)
      If Not mRet.IsError Then
        Return mRet
      End If
      Return Nothing
    End Function
    Private Shared Function PostDBKRealization(ByVal xData As List(Of SIS.INC.vchData), ByVal VCHOn As String, vchBatch As Integer) As taPostVoucherResult
      Dim UserId As String = HttpContext.Current.Session("LoginID")
      Dim mRet As New taPostVoucherResult
      Dim VoucherDate As String = ""
      Dim VoucherType As String = ""
      Dim CreditGL As String = ""
      Dim DebitGL As String = ""
      Dim Company As String = "200"
      Dim LineCount As Integer = 0
      Dim Remarks As String = ""
      Try
        Dim CardNo As String = Convert.ToInt32(HttpContext.Current.Session("LoginID"))
        Dim mFileName As String = ""
        mFileName = CardNo & "_DBK_" & Now.ToString.Replace("/", "").Replace(":", "").Replace(" ", "") & ".xml"
        Dim tmpDir As String = HttpContext.Current.Server.MapPath("~/..") & "App_Temp\TABill"
          Dim oTW As IO.StreamWriter = New IO.StreamWriter(tmpDir & "\s\" & mFileName)
        oTW.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")

        VoucherDate = IIf(VCHOn = "", Now.Date, VCHOn)
        VoucherType = "JVN"

        oTW.WriteLine("<Companies>")
        oTW.WriteLine("  <Company name=""" & Company & """>")
        oTW.WriteLine("    <Lines>")
        For Each tmp As SIS.INC.vchData In xData
          '1. Realization
          DebitGL = tmp.GLCode
          CreditGL = "5622110"
          Remarks = "DBK Received " & Convert.ToDateTime(VoucherDate).ToString("MMM") & " " & Convert.ToDateTime(VoucherDate).Year & ", " & tmp.BankName
          'insert Debit 
          oTW.WriteLine("      <Line PrkLedgerID=""" & vchBatch & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & DebitGL & "," & tmp.ProjectCode & "," & "" & "," & "" & "," & "" & "," & "UP" & "," & "INR" & "," & tmp.DAmt & "," & "1" & "," & Remarks & "," & CardNo & "," & "1.00" & "</Line>")
          LineCount += 1
          'Insert Credit
          oTW.WriteLine("      <CreditLine>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & CreditGL & "," & tmp.ProjectCode & "," & "" & "," & "" & "," & "" & "," & "UP" & "," & "INR" & "," & tmp.DAmt & "," & "2" & "," & Remarks & "," & CardNo & "," & "1.00" & "</CreditLine>")
          LineCount += 1
          '2. Provision Revert
          CreditGL = "1550248"
          DebitGL = "5622110"
          Remarks = "DBK Provision Rev " & Convert.ToDateTime(VoucherDate).ToString("MMM") & " " & Convert.ToDateTime(VoucherDate).Year
          'insert Debit 
          oTW.WriteLine("      <Line PrkLedgerID=""" & vchBatch & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & DebitGL & "," & tmp.ProjectCode & "," & "" & "," & "" & "," & "" & "," & "UP" & "," & "INR" & "," & tmp.MAmt & "," & "1" & "," & Remarks & "," & CardNo & "," & "1.00" & "</Line>")
          LineCount += 1
          'Insert Credit
          oTW.WriteLine("      <CreditLine>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & CreditGL & "," & tmp.ProjectCode & "," & "" & "," & "" & "," & "" & "," & "UP" & "," & "INR" & "," & tmp.MAmt & "," & "2" & "," & Remarks & "," & CardNo & "," & "1.00" & "</CreditLine>")
          LineCount += 1
        Next
        oTW.WriteLine("    </Lines>")
        oTW.WriteLine("    <Batch>" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & VoucherType & "</Batch>")
        oTW.WriteLine("    <Errors><Error></Error></Errors>")
        oTW.WriteLine("  </Company>")
        oTW.WriteLine("</Companies>")
        oTW.Close()
        '============End VCH Posting=================
        mRet.VoucherType = VoucherType
        mRet.VoucherCompany = "200"
        '================Read===================
        Dim oTR As XmlDocument = New XmlDocument
        Dim TryCount As Integer = 0
        Dim ErrFound As Boolean = False
        Dim TryLimit As Integer = 150
        Do While True
          Try
            oTR.Load(tmpDir & "\t\P_" & mFileName)
            Exit Do
          Catch ex As Exception
            TryCount += 1
            Threading.Thread.Sleep(2000)
          End Try
          If TryCount >= TryLimit Then
            Exit Do
          End If
        Loop
        If TryCount < TryLimit Then
          'First check no error in xml
          For Each cmp As XmlNode In oTR.ChildNodes(1)
            Dim oErr As XmlNode = cmp.ChildNodes(2)
            For Each errchild As XmlNode In oErr.ChildNodes
              If errchild.InnerText <> String.Empty Then
                mRet.IsError = True
                mRet.Message = errchild.InnerText
                ErrFound = True
                Exit For
              End If
            Next
          Next
          If Not ErrFound Then
            For Each cmp As XmlNode In oTR.ChildNodes(1)
              Dim oLines As XmlNode = cmp.ChildNodes(0)
              Dim oBatch As XmlNode = cmp.ChildNodes(1)
              Dim oErr As XmlNode = cmp.ChildNodes(2)
              For Each cmpChild As XmlNode In cmp.ChildNodes
                If cmpChild.Name.ToLower = "lines" Then
                  For Each line As XmlNode In cmpChild.ChildNodes
                    If line.Name.ToLower <> "creditline" Then
                      Dim PrkLedgerID As String = line.Attributes("PrkLedgerID").Value
                      If vchBatch.ToString = PrkLedgerID Then
                        mRet.BatchNo = line.Attributes("BatchNo").Value
                        mRet.DocumentNo = line.Attributes("DocumentNo").Value
                        mRet.LineNo = line.Attributes("LineNo").Value
                      End If
                    End If
                  Next
                  Exit For
                End If
              Next
            Next
          End If
        Else
          mRet.IsError = True
          mRet.Message = "XML Not Processed"
        End If
      Catch ex As Exception
        mRet.IsError = True
        mRet.Message = ex.Message
      End Try
      If Not mRet.IsError Then
        Try
          UpdateBatchUser(mRet.BatchNo, UserId, VoucherDate, VoucherType)
        Catch ex As Exception
        End Try
      End If
      Return mRet
    End Function

    Public Shared Function CreateAndPostMEISRealization(xData As List(Of SIS.INC.vchData), ByVal VCHOn As String, vchBatch As Integer) As taPostVoucherResult
      Dim mRet As taPostVoucherResult = PostMEISRealization(xData, VCHOn, vchBatch)
      If Not mRet.IsError Then
        Return mRet
      End If
      Return Nothing
    End Function
    Private Shared Function PostMEISRealization(ByVal xData As List(Of SIS.INC.vchData), ByVal VCHOn As String, vchBatch As Integer) As taPostVoucherResult
      Dim UserId As String = HttpContext.Current.Session("LoginID")
      Dim mRet As New taPostVoucherResult
      Dim VoucherDate As String = ""
      Dim VoucherType As String = ""
      Dim CreditGL As String = ""
      Dim DebitGL As String = ""
      Dim Company As String = "200"
      Dim LineCount As Integer = 0
      Dim Remarks As String = ""
      Try
        Dim CardNo As String = Convert.ToInt32(HttpContext.Current.Session("LoginID"))
        Dim mFileName As String = ""
        mFileName = CardNo & "_DBK_" & Now.ToString.Replace("/", "").Replace(":", "").Replace(" ", "") & ".xml"
        Dim tmpDir As String = HttpContext.Current.Server.MapPath("~/..") & "App_Temp\TABill"
        Dim oTW As IO.StreamWriter = New IO.StreamWriter(tmpDir & "\s\" & mFileName)
        oTW.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")

        VoucherDate = IIf(VCHOn = "", Now.Date, VCHOn)
        VoucherType = "JVN"

        oTW.WriteLine("<Companies>")
        oTW.WriteLine("  <Company name=""" & Company & """>")
        oTW.WriteLine("    <Lines>")
        For Each tmp As SIS.INC.vchData In xData
          '1. Realization
          DebitGL = tmp.GLCode
          CreditGL = "1550247"
          Remarks = "MEIS Received " & Convert.ToDateTime(VoucherDate).ToString("MMM") & " " & Convert.ToDateTime(VoucherDate).Year & ", " & tmp.BankName
          'insert Debit 
          oTW.WriteLine("      <Line PrkLedgerID=""" & vchBatch & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & DebitGL & "," & tmp.ProjectCode & "," & "" & "," & "" & "," & "" & "," & "UP" & "," & "INR" & "," & tmp.DAmt & "," & "1" & "," & Remarks & "," & CardNo & "," & "1.00" & "</Line>")
          LineCount += 1
          'Insert Credit
          oTW.WriteLine("      <CreditLine>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & CreditGL & "," & tmp.ProjectCode & "," & "" & "," & "" & "," & "" & "," & "UP" & "," & "INR" & "," & tmp.DAmt & "," & "2" & "," & Remarks & "," & CardNo & "," & "1.00" & "</CreditLine>")
          LineCount += 1
          '2. Provision Revert
          CreditGL = "1550247"
          DebitGL = "5622110"
          Remarks = "MEIS Provision Rev " & Convert.ToDateTime(VoucherDate).ToString("MMM") & " " & Convert.ToDateTime(VoucherDate).Year
          'insert Debit 
          oTW.WriteLine("      <Line PrkLedgerID=""" & vchBatch & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & DebitGL & "," & tmp.ProjectCode & "," & "" & "," & "" & "," & "" & "," & "UP" & "," & "INR" & "," & tmp.MAmt & "," & "1" & "," & Remarks & "," & CardNo & "," & "1.00" & "</Line>")
          LineCount += 1
          'Insert Credit
          oTW.WriteLine("      <CreditLine>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & CreditGL & "," & tmp.ProjectCode & "," & "" & "," & "" & "," & "" & "," & "UP" & "," & "INR" & "," & tmp.MAmt & "," & "2" & "," & Remarks & "," & CardNo & "," & "1.00" & "</CreditLine>")
          LineCount += 1
        Next
        oTW.WriteLine("    </Lines>")
        oTW.WriteLine("    <Batch>" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & VoucherType & "</Batch>")
        oTW.WriteLine("    <Errors><Error></Error></Errors>")
        oTW.WriteLine("  </Company>")
        oTW.WriteLine("</Companies>")
        oTW.Close()
        '============End VCH Posting=================
        mRet.VoucherType = VoucherType
        mRet.VoucherCompany = "200"
        '================Read===================
        Dim oTR As XmlDocument = New XmlDocument
        Dim TryCount As Integer = 0
        Dim ErrFound As Boolean = False
        Dim TryLimit As Integer = 150
        Do While True
          Try
            oTR.Load(tmpDir & "\t\P_" & mFileName)
            Exit Do
          Catch ex As Exception
            TryCount += 1
            Threading.Thread.Sleep(2000)
          End Try
          If TryCount >= TryLimit Then
            Exit Do
          End If
        Loop
        If TryCount < TryLimit Then
          'First check no error in xml
          For Each cmp As XmlNode In oTR.ChildNodes(1)
            Dim oErr As XmlNode = cmp.ChildNodes(2)
            For Each errchild As XmlNode In oErr.ChildNodes
              If errchild.InnerText <> String.Empty Then
                mRet.IsError = True
                mRet.Message = errchild.InnerText
                ErrFound = True
                Exit For
              End If
            Next
          Next
          If Not ErrFound Then
            For Each cmp As XmlNode In oTR.ChildNodes(1)
              Dim oLines As XmlNode = cmp.ChildNodes(0)
              Dim oBatch As XmlNode = cmp.ChildNodes(1)
              Dim oErr As XmlNode = cmp.ChildNodes(2)
              For Each cmpChild As XmlNode In cmp.ChildNodes
                If cmpChild.Name.ToLower = "lines" Then
                  For Each line As XmlNode In cmpChild.ChildNodes
                    If line.Name.ToLower <> "creditline" Then
                      Dim PrkLedgerID As String = line.Attributes("PrkLedgerID").Value
                      If vchBatch.ToString = PrkLedgerID Then
                        mRet.BatchNo = line.Attributes("BatchNo").Value
                        mRet.DocumentNo = line.Attributes("DocumentNo").Value
                        mRet.LineNo = line.Attributes("LineNo").Value
                      End If
                    End If
                  Next
                  Exit For
                End If
              Next
            Next
          End If
        Else
          mRet.IsError = True
          mRet.Message = "XML Not Processed"
        End If
      Catch ex As Exception
        mRet.IsError = True
        mRet.Message = ex.Message
      End Try
      If Not mRet.IsError Then
        Try
          UpdateBatchUser(mRet.BatchNo, UserId, VoucherDate, VoucherType)
        Catch ex As Exception
        End Try
      End If
      Return mRet
    End Function
  End Class
End Namespace
