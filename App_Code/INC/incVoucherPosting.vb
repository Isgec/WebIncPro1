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
  Public Class taVoucher
    Private Shared Sub UpdateBatchUser(ByVal BatchNo As String, ByVal UserID As String, ByVal VchDate As String, ByVal VchType As String)
      Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
      Dim rYear As String = ""
      Dim Sql As String = ""
      Sql = " Select "
      Sql &= " t_year As BatchYear "
      Sql &= " From ttfgld100" & Comp
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
        Sql &= " ttfgld100" & Comp
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
        Sql &= " ttfgld101" & Comp
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

    Public Shared Function CreatePostVoucherData(xData As List(Of SIS.TA.vchData), ByVal VCHOn As String, vchBatch As Integer) As List(Of taPostVoucherResult)
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

    Private Shared Function PostVoucher(ByVal xData As List(Of SIS.TA.vchData), ByVal VCHOn As String, vchBatch As Integer, IsDBK As Boolean) As taPostVoucherResult
      Dim UserId As String = HttpContext.Current.Session("LoginID")
      Dim mRet As New taPostVoucherResult
      Dim VoucherDate As String = ""
      Dim VoucherType As String = ""
      Dim CreditGL As String = ""
      Dim DebitGL As String = ""
      Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
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
        oTW.WriteLine("  <Company name=""" & Comp & """>")
        oTW.WriteLine("    <Lines>")
        For Each tmp As SIS.TA.vchData In xData
          'insert Debit 
          oTW.WriteLine("      <Line PrkLedgerID=""" & vchBatch & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Comp & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Comp & "," & tmp.DivisionID & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & DebitGL & "," & tmp.ProjectCode & "," & "" & "," & "" & "," & "" & "," & "UP" & "," & "INR" & "," & tmp.DAmt & "," & "1" & "," & Remarks & "," & CardNo & "," & "1.00" & "</Line>")
          LineCount += 1
          'Insert Credit
          oTW.WriteLine("      <CreditLine>" & Comp & "," & tmp.DivisionID & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & CreditGL & "," & tmp.ProjectCode & "," & "" & "," & "" & "," & "" & "," & "UP" & "," & "INR" & "," & tmp.DAmt & "," & "2" & "," & Remarks & "," & CardNo & "," & "1.00" & "</CreditLine>")
          LineCount += 1
        Next
        oTW.WriteLine("    </Lines>")
        oTW.WriteLine("    <Batch>" & Comp & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & VoucherType & "</Batch>")
        oTW.WriteLine("    <Errors><Error></Error></Errors>")
        oTW.WriteLine("  </Company>")
        oTW.WriteLine("</Companies>")
        oTW.Close()
        '============End VCH Posting=================
        mRet.VoucherType = VoucherType
        mRet.VoucherCompany = Comp
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
    Public Shared Function CreateAndPostDBKRealization(xData As List(Of SIS.TA.vchData), ByVal VCHOn As String, vchBatch As Integer) As taPostVoucherResult
      Dim mRet As taPostVoucherResult = PostDBKRealization(xData, VCHOn, vchBatch)
      If Not mRet.IsError Then
        Return mRet
      End If
      Return Nothing
    End Function
    Private Shared Function PostDBKRealization(ByVal xData As List(Of SIS.TA.vchData), ByVal VCHOn As String, vchBatch As Integer) As taPostVoucherResult
      Dim UserId As String = HttpContext.Current.Session("LoginID")
      Dim mRet As New taPostVoucherResult
      Dim VoucherDate As String = ""
      Dim VoucherType As String = ""
      Dim CreditGL As String = ""
      Dim DebitGL As String = ""
      Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
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
        oTW.WriteLine("  <Company name=""" & Comp & """>")
        oTW.WriteLine("    <Lines>")
        For Each tmp As SIS.TA.vchData In xData
          '1. Realization
          DebitGL = tmp.GLCode
          CreditGL = "5622110"
          Remarks = "DBK Received " & Convert.ToDateTime(VoucherDate).ToString("MMM") & " " & Convert.ToDateTime(VoucherDate).Year & ", " & tmp.BankName
          'insert Debit 
          oTW.WriteLine("      <Line PrkLedgerID=""" & vchBatch & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Comp & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Comp & "," & tmp.BankComp & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & DebitGL & "," & "" & "," & "" & "," & "" & "," & "" & "," & "" & "," & "INR" & "," & tmp.DAmt & "," & "1" & "," & Remarks & "," & CardNo & "," & "1.00" & "</Line>")
          LineCount += 1
          'Insert Credit
          oTW.WriteLine("      <CreditLine>" & Comp & "," & tmp.DivisionID & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & CreditGL & "," & tmp.ProjectCode & "," & "" & "," & "" & "," & "" & "," & "UP" & "," & "INR" & "," & tmp.DAmt & "," & "2" & "," & Remarks & "," & CardNo & "," & "1.00" & "</CreditLine>")
          LineCount += 1
          '2. Provision Revert
          CreditGL = "1550248"
          DebitGL = "5622110"
          Remarks = "DBK Provision Rev " & Convert.ToDateTime(VoucherDate).ToString("MMM") & " " & Convert.ToDateTime(VoucherDate).Year
          'insert Debit 
          oTW.WriteLine("      <Line PrkLedgerID=""" & vchBatch & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Comp & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Comp & "," & tmp.DivisionID & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & DebitGL & "," & tmp.ProjectCode & "," & "" & "," & "" & "," & "" & "," & "UP" & "," & "INR" & "," & tmp.MAmt & "," & "1" & "," & Remarks & "," & CardNo & "," & "1.00" & "</Line>")
          LineCount += 1
          'Insert Credit
          oTW.WriteLine("      <CreditLine>" & Comp & "," & tmp.DivisionID & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & CreditGL & "," & tmp.ProjectCode & "," & "" & "," & "" & "," & "" & "," & "UP" & "," & "INR" & "," & tmp.MAmt & "," & "2" & "," & Remarks & "," & CardNo & "," & "1.00" & "</CreditLine>")
          LineCount += 1
        Next
        oTW.WriteLine("    </Lines>")
        oTW.WriteLine("    <Batch>" & Comp & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & VoucherType & "</Batch>")
        oTW.WriteLine("    <Errors><Error></Error></Errors>")
        oTW.WriteLine("  </Company>")
        oTW.WriteLine("</Companies>")
        oTW.Close()
        '============End VCH Posting=================
        mRet.VoucherType = VoucherType
        mRet.VoucherCompany = Comp
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

    Public Shared Function CreateAndPostMEISRealization(xData As List(Of SIS.TA.vchData), ByVal VCHOn As String, vchBatch As Integer) As taPostVoucherResult
      Dim mRet As taPostVoucherResult = PostMEISRealization(xData, VCHOn, vchBatch)
      If Not mRet.IsError Then
        Return mRet
      End If
      Return Nothing
    End Function
    Private Shared Function PostMEISRealization(ByVal xData As List(Of SIS.TA.vchData), ByVal VCHOn As String, vchBatch As Integer) As taPostVoucherResult
      Dim UserId As String = HttpContext.Current.Session("LoginID")
      Dim mRet As New taPostVoucherResult
      Dim VoucherDate As String = ""
      Dim VoucherType As String = ""
      Dim CreditGL As String = ""
      Dim DebitGL As String = ""
      Dim Comp As String = HttpContext.Current.Session("FinanceCompany")


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
        oTW.WriteLine("  <Company name=""" & Comp & """>")
        oTW.WriteLine("    <Lines>")
        For Each tmp As SIS.TA.vchData In xData
          ''1. Realization
          'DebitGL = tmp.GLCode
          'CreditGL = "1550247"
          'Remarks = "MEIS Received " & Convert.ToDateTime(VoucherDate).ToString("MMM") & " " & Convert.ToDateTime(VoucherDate).Year & ", " & tmp.BankName
          ''insert Debit 
          'oTW.WriteLine("      <Line PrkLedgerID=""" & vchBatch & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Comp & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Comp & "," & tmp.DivisionID & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & DebitGL & "," & tmp.ProjectCode & "," & "" & "," & "" & "," & "" & "," & "UP" & "," & "INR" & "," & tmp.DAmt & "," & "1" & "," & Remarks & "," & CardNo & "," & "1.00" & "</Line>")
          'LineCount += 1
          ''Insert Credit
          'oTW.WriteLine("      <CreditLine>" & Comp & "," & tmp.DivisionID & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & CreditGL & "," & tmp.ProjectCode & "," & "" & "," & "" & "," & "" & "," & "UP" & "," & "INR" & "," & tmp.DAmt & "," & "2" & "," & Remarks & "," & CardNo & "," & "1.00" & "</CreditLine>")
          'LineCount += 1
          '2. Provision Revert
          CreditGL = "1550247"
          DebitGL = "5622110"
          Remarks = "MEIS Provision Rev " & Convert.ToDateTime(VoucherDate).ToString("MMM") & " " & Convert.ToDateTime(VoucherDate).Year
          'insert Debit 
          oTW.WriteLine("      <Line PrkLedgerID=""" & vchBatch & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Comp & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Comp & "," & tmp.DivisionID & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & DebitGL & "," & tmp.ProjectCode & "," & "" & "," & "" & "," & "" & "," & "UP" & "," & "INR" & "," & tmp.MAmt & "," & "1" & "," & Remarks & "," & CardNo & "," & "1.00" & "</Line>")
          LineCount += 1
          'Insert Credit
          oTW.WriteLine("      <CreditLine>" & Comp & "," & tmp.DivisionID & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & CreditGL & "," & tmp.ProjectCode & "," & "" & "," & "" & "," & "" & "," & "UP" & "," & "INR" & "," & tmp.MAmt & "," & "2" & "," & Remarks & "," & CardNo & "," & "1.00" & "</CreditLine>")
          LineCount += 1
        Next
        oTW.WriteLine("    </Lines>")
        oTW.WriteLine("    <Batch>" & Comp & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & VoucherType & "</Batch>")
        oTW.WriteLine("    <Errors><Error></Error></Errors>")
        oTW.WriteLine("  </Company>")
        oTW.WriteLine("</Companies>")
        oTW.Close()
        '============End VCH Posting=================
        mRet.VoucherType = VoucherType
        mRet.VoucherCompany = Comp
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
  Public Class vchData
    Public Property Seq As Integer = 0
    Public Property DivisionID As String = ""
    Public Property GLCode As String = ""
    Public Property BankName As String = ""
    Public Property BankComp As String = ""
    Public Property ProjectCode As String = ""
    Public Property State As String = "UP"
    Public Property Amt As String = ""
    Public Property DAmt As String = ""
    Public Property MAmt As String = ""
    Public Property DrCr As String = ""
    Public Property Remarks As String = ""
    Public Shared Function GetHTML(xData As List(Of SIS.TA.vchData), IsDBK As Boolean) As String
      Dim mRet As String = ""
      mRet &= "<div class='x-div'>"
      mRet &= "<table class='x-tbl'>"
      mRet &= "<tr class='x-h-tbl'>"
      mRet &= "<td>Company</td><td>GL Code</td><td>Dim-1</td><td>Dim-5</td><td>Amount</td><td>Dr/Cr</td><td>Remarks</td></tr>"
      For Each xd As SIS.TA.vchData In xData
        '1. Debit Row
        mRet &= "<tr class='x-d1-tbl'>"
        mRet &= "<td>" & xd.DivisionID & "</td>"
        If IsDBK Then
          mRet &= "<td>1550248</td>"
        Else
          mRet &= "<td>1550247</td>"
        End If
        mRet &= "<td>" & xd.ProjectCode & "</td>"
        mRet &= "<td>UP</td>"
        If IsDBK Then
          mRet &= "<td>" & xd.DAmt & "</td>"
        Else
          mRet &= "<td>" & xd.MAmt & "</td>"
        End If
        mRet &= "<td>Debit</td>"
        If IsDBK Then
          mRet &= "<td>" & "DBK Provision " & Now.ToString("MMM") & " " & Now.Year & "</td>"
        Else
          mRet &= "<td>" & "MRIS Provision " & Now.ToString("MMM") & " " & Now.Year & "</td>"
        End If
        mRet &= "</tr>"
        '2 Credit Row
        mRet &= "<tr class='x-d2-tbl'>"
        mRet &= "<td>" & xd.DivisionID & "</td>"
        If IsDBK Then
          mRet &= "<td>5622110</td>"
        Else
          mRet &= "<td>5622110</td>"
        End If
        mRet &= "<td>" & xd.ProjectCode & "</td>"
        mRet &= "<td>UP</td>"
        If IsDBK Then
          mRet &= "<td>" & xd.DAmt & "</td>"
        Else
          mRet &= "<td>" & xd.MAmt & "</td>"
        End If
        mRet &= "<td>Credit</td>"
        If IsDBK Then
          mRet &= "<td>" & "DBK Provision " & Now.ToString("MMM") & " " & Now.Year & "</td>"
        Else
          mRet &= "<td>" & "MRIS Provision " & Now.ToString("MMM") & " " & Now.Year & "</td>"
        End If
        mRet &= "</tr>"
      Next
      mRet &= "</table></div>"
      Return mRet
    End Function

    Public Shared Function GetHTMLDBK(xData As List(Of SIS.TA.vchData)) As String
      Dim mRet As String = ""
      mRet &= "<div class='x-div'>"
      mRet &= "<table class='x-tbl'>"
      mRet &= "<tr class='x-h-tbl'>"
      mRet &= "<td>Company</td><td>GL Code</td><td>Dim-1</td><td>Dim-5</td><td>Amount</td><td>Dr/Cr</td><td>Remarks</td></tr>"
      For Each xd As SIS.TA.vchData In xData
        'A Realization
        '1. Debit Row
        mRet &= "<tr class='x-d1-tbl'>"
        mRet &= "<td>" & xd.BankComp & "</td>"
        mRet &= "<td>" & xd.GLCode & "</td>"
        mRet &= "<td>" & "" & "</td>"
        mRet &= "<td></td>"
        mRet &= "<td>" & xd.DAmt & "</td>"
        mRet &= "<td>Debit</td>"
        mRet &= "<td>" & "DBK Provision " & Now.ToString("MMM") & " " & Now.Year & ", " & xd.BankName & "</td>"
        mRet &= "</tr>"
        '2 Credit Row
        mRet &= "<tr class='x-d2-tbl'>"
        mRet &= "<td>" & xd.DivisionID & "</td>"
        mRet &= "<td>5622110</td>"
        mRet &= "<td>" & xd.ProjectCode & "</td>"
        mRet &= "<td>UP</td>"
        mRet &= "<td>" & xd.DAmt & "</td>"
        mRet &= "<td>Credit</td>"
        mRet &= "<td>" & "DBK Provision " & Now.ToString("MMM") & " " & Now.Year & ", " & xd.BankName & "</td>"
        mRet &= "</tr>"
        'B Provision Reversal
        '1. Debit Row
        mRet &= "<tr class='x-d1-tbl'>"
        mRet &= "<td>" & xd.DivisionID & "</td>"
        mRet &= "<td>5622110</td>"
        mRet &= "<td>" & xd.ProjectCode & "</td>"
        mRet &= "<td>UP</td>"
        mRet &= "<td>" & xd.MAmt & "</td>"
        mRet &= "<td>Debit</td>"
        mRet &= "<td>" & "DBK Provision " & Now.ToString("MMM") & " " & Now.Year & "</td>"
        mRet &= "</tr>"
        '2 Credit Row
        mRet &= "<tr class='x-d2-tbl'>"
        mRet &= "<td>" & xd.DivisionID & "</td>"
        mRet &= "<td>1550248</td>"
        mRet &= "<td>" & xd.ProjectCode & "</td>"
        mRet &= "<td>UP</td>"
        mRet &= "<td>" & xd.MAmt & "</td>"
        mRet &= "<td>Credit</td>"
        mRet &= "<td>" & "DBK Provision " & Now.ToString("MMM") & " " & Now.Year & "</td>"
        mRet &= "</tr>"
      Next
      mRet &= "</table></div>"
      Return mRet
    End Function

    Public Shared Function GetHTMLMEIS(xData As List(Of SIS.TA.vchData)) As String
      Dim mRet As String = ""
      mRet &= "<div class='x-div'>"
      mRet &= "<table class='x-tbl'>"
      mRet &= "<tr class='x-h-tbl'>"
      mRet &= "<td>Company</td><td>GL Code</td><td>Dim-1</td><td>Dim-5</td><td>Amount</td><td>Dr/Cr</td><td>Remarks</td></tr>"
      For Each xd As SIS.TA.vchData In xData
        ''A Realization
        ''1. Debit Row
        'mRet &= "<tr class='x-d1-tbl'>"
        'mRet &= "<td>" & xd.DivisionID & "</td>"
        'mRet &= "<td>" & xd.GLCode & "</td>"
        'mRet &= "<td>" & xd.ProjectCode & "</td>"
        'mRet &= "<td>UP</td>"
        'mRet &= "<td>" & xd.DAmt & "</td>"
        'mRet &= "<td>Debit</td>"
        'mRet &= "<td>" & "DBK Provision " & Now.ToString("MMM") & " " & Now.Year & ", " & xd.BankName & "</td>"
        'mRet &= "</tr>"
        ''2 Credit Row
        'mRet &= "<tr class='x-d2-tbl'>"
        'mRet &= "<td>" & xd.DivisionID & "</td>"
        'mRet &= "<td>1550247</td>"
        'mRet &= "<td>" & xd.ProjectCode & "</td>"
        'mRet &= "<td>UP</td>"
        'mRet &= "<td>" & xd.DAmt & "</td>"
        'mRet &= "<td>Credit</td>"
        'mRet &= "<td>" & "DBK Provision " & Now.ToString("MMM") & " " & Now.Year & ", " & xd.BankName & "</td>"
        'mRet &= "</tr>"
        'B Provision Reversal
        '1. Debit Row
        mRet &= "<tr class='x-d1-tbl'>"
        mRet &= "<td>" & xd.DivisionID & "</td>"
        mRet &= "<td>1550247</td>"
        mRet &= "<td>" & xd.ProjectCode & "</td>"
        mRet &= "<td>UP</td>"
        mRet &= "<td>" & xd.MAmt & "</td>"
        mRet &= "<td>Debit</td>"
        mRet &= "<td>" & "DBK Provision " & Now.ToString("MMM") & " " & Now.Year & "</td>"
        mRet &= "</tr>"
        '2 Credit Row
        mRet &= "<tr class='x-d2-tbl'>"
        mRet &= "<td>" & xd.DivisionID & "</td>"
        mRet &= "<td>1550248</td>"
        mRet &= "<td>" & xd.ProjectCode & "</td>"
        mRet &= "<td>UP</td>"
        mRet &= "<td>" & xd.MAmt & "</td>"
        mRet &= "<td>Credit</td>"
        mRet &= "<td>" & "DBK Provision " & Now.ToString("MMM") & " " & Now.Year & "</td>"
        mRet &= "</tr>"
      Next
      mRet &= "</table></div>"
      Return mRet
    End Function

    Public Sub New(rd As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, rd)
    End Sub
    Public Sub New()

    End Sub
  End Class

End Namespace
