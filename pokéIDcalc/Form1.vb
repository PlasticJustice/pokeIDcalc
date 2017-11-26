Public Class Form1
    Dim Type As Integer
    Dim TID As Integer
    Dim SID As Integer
    Dim SIDd As Double
    Dim SIDdp As Double
    Dim TIDd As Double
    Dim TIDdp As Double
    Dim G7TID As Integer
    Dim Output As String
    Dim Modi As Integer
    Dim TSV As Integer
    Private Sub Reset()
        Type = 0
        TID = 0
        SID = 0
        SIDd = 0
        SIDdp = 0
        TIDd = 0
        TIDdp = 0
        G7TID = 0
        Modi = 0
        TSV = 0
    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            TextBox1.Enabled = False
            TextBox4.Enabled = False
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            Type = 1
        Else
            TextBox1.Enabled = True
            TextBox4.Enabled = True
            Type = 0
            Reset()
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            RadioButton5.PerformClick()
            GroupBox2.Enabled = True
            Type = 2
        Else

            GroupBox2.Enabled = False
            Type = 0
            Reset()
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked Then
            TextBox2.Enabled = False
            TextBox4.Enabled = False
            RadioButton8.PerformClick()
            GroupBox3.Enabled = True
            Type = 3
        Else

            GroupBox3.Enabled = False
            Type = 0
            Reset()
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked Then
            TextBox1.Enabled = False
            TextBox4.Enabled = False
            Type = 4
        Else
            TextBox1.Enabled = True
            TextBox4.Enabled = True
            Type = 0
            Reset()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadioButton1.PerformClick()
        RadioButton5.PerformClick()
        RadioButton8.PerformClick()
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
    End Sub
    Private Sub updateStuff()
        If Type = 1 Then
            TID = TextBox3.Text
            SID = TextBox2.Text
        ElseIf Type = 2 Then
            G7TID = TextBox1.Text
            SID = TextBox2.Text
        ElseIf Type = 3 Then
            G7TID = TextBox1.Text
            TID = TextBox3.Text
        ElseIf Type = 4 Then
            TID = TextBox3.Text
            SID = TextBox2.Text
        ElseIf Type = 5 Then
            TSV = TextBox4.Text
            SID = TextBox2.Text
        ElseIf Type = 6 Then
            TID = TextBox3.Text
            TSV = TextBox4.Text

        End If
    End Sub
    Private Sub Modifer()
        If Modi <= 2145000000 Then
            Modi = Modi + 1000000
        Else
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        updateStuff()
        If Type = 1 Then
            G7TID = (TID + (SID * 65536)) Mod 1000000
            Output = "G7TID is " & G7TID
            RichTextBox1.Text = Output
        ElseIf Type = 3 Then
            Output = "SID could be one of... 
"
1:
            SIDd = ((G7TID + Modi) - TID) / 65536
            If SIDd = SIDdp Then
                GoTo 2
            End If
            If SIDd >= 100000 Then
                GoTo 2
            Else
                SIDdp = SIDd
                If SIDd Mod 1 = 0 Then
                    SID = SIDd
                    Output = Output & "
" & SID
                    Modifer()
                    GoTo 1
                Else
                    Modifer()
                    GoTo 1
                End If
            End If
2:
            RichTextBox1.Text = Output
        ElseIf Type = 2 Then
            Output = "TID could be one of... 
"
3:
            TIDd = ((G7TID + Modi) - (SID * 65536))
            'If TIDd < 0 Then
            'Modifer()
            'GoTo 3
            'End If
            If TIDd = TIDdp Then
                GoTo 4
            End If
            If TIDd >= 100000 Then
                GoTo 4
            Else
                TIDdp = TIDd
                If TIDd Mod 1 = 0 Then
                    TID = TIDd
                    Output = "TID could be one of... 

" & TID
                    Modifer()
                    GoTo 3
                Else
                    Modifer()
                    GoTo 3
                End If
            End If
4:
            RichTextBox1.Text = Output
        ElseIf Type = 4 Then
            TSV = (TID Xor SID) >> 4
            Output = "TSV is " & TSV
            RichTextBox1.Text = Output
        ElseIf Type = 5 Then
            TID = (SID Xor (TSV << 4))
            'TID = SID ^ (TSV << 4)
            Output = "TID is " & TID + 1
            RichTextBox1.Text = Output
        ElseIf Type = 6 Then
            SID = (TID Xor (TSV << 4))
            'SID = TID ^ (TSV << 4)
            Output = "SID is " & SID - 1
            RichTextBox1.Text = Output
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked And RadioButton2.Checked Then
            TextBox3.Enabled = False
            TextBox4.Enabled = False
        Else
            TextBox3.Enabled = True
            TextBox4.Enabled = True
        End If
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        If RadioButton6.Checked And RadioButton2.Checked Then
            TextBox1.Enabled = False
            TextBox3.Enabled = False
            Type = 5
        Else
            TextBox3.Enabled = True
            TextBox1.Enabled = True
            Type = 0
        End If
    End Sub

    Private Sub RadioButton8_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton8.CheckedChanged
        If RadioButton8.Checked And RadioButton3.Checked Then
            TextBox2.Enabled = False
            TextBox4.Enabled = False
        Else
            TextBox2.Enabled = True
            TextBox4.Enabled = True
        End If
    End Sub

    Private Sub RadioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton7.CheckedChanged
        If RadioButton7.Checked And RadioButton3.Checked Then
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            Type = 6
        Else
            TextBox2.Enabled = True
            TextBox1.Enabled = True
            Type = 0
        End If
    End Sub
End Class
