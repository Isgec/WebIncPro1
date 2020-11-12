Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Services
Imports System.IO

Partial Class LGDefault
  Inherits System.Web.UI.Page

  Private Sub F_FinanceCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles F_FinanceCompany.SelectedIndexChanged
    HttpContext.Current.Session("FinanceCompany") = F_FinanceCompany.SelectedValue
  End Sub
  Private Sub LGDefault_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    div1.Visible = False
    If HttpContext.Current.User.Identity.IsAuthenticated Then
      F_FinanceCompany.SelectedValue = HttpContext.Current.Session("FinanceCompany")
      F_SelectedCompany.InnerText = "Selected Company: " & HttpContext.Current.Session("FinanceCompany")
      div1.Visible = True
    End If
  End Sub
End Class
