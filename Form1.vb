Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class Form1

    Dim conn As New MySqlConnection("server=localhost;userid=root;password=;database=Student_Department")

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim adapter As New MySqlDataAdapter("SELECT * FROM students", conn)
        Dim table As New DataTable()
        adapter.Fill(table)
        dgvData.DataSource = table
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        conn.Open()

        Dim cmd As New MySqlCommand("INSERT INTO students (firstName, lastName, course, department) VALUES (@fname, @lname, @course, @dept)", conn)

        cmd.Parameters.AddWithValue("@fname", txtFirstName.Text)
        cmd.Parameters.AddWithValue("@lname", txtLastName.Text)
        cmd.Parameters.AddWithValue("@course", txtCourse.Text)
        cmd.Parameters.AddWithValue("@dept", txtDepartment.Text)

        cmd.ExecuteNonQuery()
        conn.Close()

        btnLoad.PerformClick()
        MsgBox("Student record inserted!")
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        conn.Open()

        Dim cmd As New MySqlCommand("UPDATE students SET firstName = @fname, lastName = @lname, course = @course, department = @dept WHERE studentID = @id", conn)

        cmd.Parameters.AddWithValue("@fname", txtFirstName.Text)
        cmd.Parameters.AddWithValue("@lname", txtLastName.Text)
        cmd.Parameters.AddWithValue("@course", txtCourse.Text)
        cmd.Parameters.AddWithValue("@dept", txtDepartment.Text)
        cmd.Parameters.AddWithValue("@id", txtStudentID.Text)

        cmd.ExecuteNonQuery()
        conn.Close()

        btnLoad.PerformClick()
        MsgBox("Student record updated!")
    End Sub
End Class


