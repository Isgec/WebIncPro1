Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Script.Serialization
Imports System
Partial Class filedownload
  Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim ds As New DataSet
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "spinc_LG_DownloadFree"
        Con.Open()
        Dim da As New SqlDataAdapter
        da.SelectCommand = Cmd
        da.Fill(ds)
      End Using
    End Using
    Dim gv As New GridView
    gv.ID = "IncProvision_" & Now.Year & "_" & Now.Month.ToString.PadLeft(2, "0") & "_" & Now.Day.ToString.PadLeft(2, "0")
    gv.Style.Add(HtmlTextWriterStyle.Margin, "5px")
    gv.Style.Add(HtmlTextWriterStyle.BorderStyle, "solid")
    gv.Style.Add(HtmlTextWriterStyle.BorderWidth, "1pt")
    gv.Style.Add(HtmlTextWriterStyle.BorderColor, "gray")
    With gv
      .HeaderStyle.BackColor = Drawing.ColorTranslator.FromHtml("#3AC0F2")
      .HeaderStyle.ForeColor = Drawing.Color.White
      .RowStyle.BackColor = Drawing.ColorTranslator.FromHtml("#dcf5f5")
      .AlternatingRowStyle.BackColor = Drawing.Color.White
      .AlternatingRowStyle.ForeColor = Drawing.ColorTranslator.FromHtml("#000")
      .ShowFooter = True
    End With
    gv.DataSource = ds.Tables(0)
    gv.DataBind()

    Response.Clear()
    Response.Buffer = True
    Response.AddHeader("content-disposition", "attachment;filename=" & gv.ID & ".xls")
    Response.Charset = ""
    Response.ContentType = "application/vnd.ms-excel"
    If gv.Rows.Count > 0 Then
      Using sw As New IO.StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        gv.HeaderRow.BackColor = Drawing.Color.White
        For Each cell As TableCell In gv.HeaderRow.Cells
          cell.BackColor = gv.HeaderStyle.BackColor
        Next
        For Each row As GridViewRow In gv.Rows
          row.BackColor = Drawing.Color.White
          For Each cell As TableCell In row.Cells
            If row.RowIndex Mod 2 = 0 Then
              cell.BackColor = gv.AlternatingRowStyle.BackColor
            Else
              cell.BackColor = gv.RowStyle.BackColor
            End If
            cell.CssClass = "textmode"
          Next
        Next
        gv.RenderControl(hw)
        Dim style As String = "<style> .textmode { } </style>"
        Response.Write(style)
        Response.Output.Write(sw.ToString())
      End Using
    Else
      Response.Write("No Records.")
    End If
    Response.Flush()
    Response.End()

  End Sub

End Class
