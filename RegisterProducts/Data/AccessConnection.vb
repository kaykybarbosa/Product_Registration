Imports System.Data.SqlClient

Public Class AccessConnection
    Private ReadOnly strStringConnection As String
    Private ReadOnly connection As SqlConnection
    Private ReadOnly command As SqlCommand

    Public Sub AccessConnection()

    End Sub
    Public Sub New()
        strStringConnection = ConfigurationManager.ConnectionStrings("StringConectionRegisterProduct").ToString
        connection = New SqlConnection(strStringConnection)
        command = New SqlCommand()
    End Sub

    Public Function ExecuteSqlCommand(ByVal strSql As String) As Integer
        Dim rowsAffected As Integer

        connection.Open()

        command.Connection = connection
        command.CommandText = strSql

        Try

            rowsAffected = command.ExecuteNonQuery()

        Catch ex As Exception

            rowsAffected = -1

        End Try

        connection.Close()

        Return rowsAffected

    End Function

    Public Function ExecuteDataTable(ByVal strSql As String) As DataTable
        Dim sd As New SqlDataAdapter
        Dim dt As New DataTable

        connection.Open()

        command.Connection = connection
        command.CommandText = strSql
        sd.SelectCommand = command

        Try
            sd.Fill(dt)

        Catch ex As Exception

            dt = Nothing

        End Try

        connection.Close()

        Return dt

    End Function

    Public Function ExecuteSqlCommandReader(ByVal strSql As String)

        connection.Open()

        command.Connection = connection
        command.CommandText = strSql

        Return command.ExecuteReader()

    End Function

End Class
