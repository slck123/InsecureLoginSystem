
Imports System.Data.OleDb





Public Class Form1


    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=your source;"
    Dim connection As New OleDbConnection(connectionString)






    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text

        ' Veritabanı bağlantısı
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=your source;"
        Dim query As String = $"SELECT * FROM users WHERE username = '{username}' AND password = '{password}'"

        Try
            Using connection As New OleDbConnection(connectionString)
                Dim command As New OleDbCommand(query, connection)
                connection.Open()
                Dim reader As OleDbDataReader = command.ExecuteReader()

                If reader.HasRows Then
                    lblResult.Text = "Giriş başarılı!"
                Else
                    lblResult.Text = "Giriş başarısız!"
                End If
            End Using
        Catch ex As Exception
            lblResult.Text = "Hata: " & ex.Message
        End Try


        Try
            Using connection As New OleDbConnection(connectionString)
                Dim command As New OleDbCommand(query, connection)
                connection.Open()
                Dim reader As OleDbDataReader = command.ExecuteReader()

                If reader.HasRows Then
                    lblResult.Text = "Giriş başarılı!"
                Else
                    lblResult.Text = "Giriş başarısız!"
                End If
            End Using
        Catch ex As Exception
            lblResult.Text = "Hata: " & ex.Message & " - Query: " & query
        End Try

    End Sub











End Class
