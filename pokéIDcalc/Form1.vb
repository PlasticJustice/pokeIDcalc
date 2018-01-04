Public Class Form1
    Dim Type As Integer 'determines what is being calculated
    Dim TID As Integer 'variable for Trainer ID
    Dim SID As Integer 'variable for Secret ID
    Dim SIDd As Double 'SID with decimals
    Dim SIDdp As Double 'Previously calculated SID
    Dim TIDd As Double 'TID with decimals
    Dim TIDdp As Double 'Previously calculated TID
    Dim G7TID As Integer 'variable for Gen 7 Trainer ID
    Dim Output As String 'Output text
    Dim Modi As Integer 'Number add to G7TID to counter the mod 1000000
    Dim TSV As Integer 'variable for Trainer Shiny Value
    Dim PossibitiesS As String 'All SID possibities when calculated with TSV
    Dim PossibitiesT As String 'All TID possibities when calculated with TSV

    Dim rings As Integer
    Dim shinyrate As Boolean
    Dim lgtyrs As Integer
    Dim rate As Double
    Dim d As Double

    'Resets all the variables
    Private Sub Reset()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
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

    'Hide/Show all textboxes
    Private Sub HideAll()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
    End Sub
    Private Sub ShowAll()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
    End Sub

    'Makes it so only numbers can be place in the textboxes:
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If

    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress

        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If

    End Sub
    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress

        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If

    End Sub
    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress

        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If

    End Sub
    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress

        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If

    End Sub

    'All the RadioButtons that select how and what is calculated:
    'G7TID
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            Reset()
            TextBox1.Enabled = False
            TextBox4.Enabled = False
            Type = 1
        Else
            Reset()
        End If
    End Sub
    'TID
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            Reset()
            GroupBox2.Show()
            HideAll()
        Else
            GroupBox2.Hide()
            Reset()
        End If
    End Sub
    'SID
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked Then
            Reset()
            GroupBox3.Show()
            HideAll()
        Else
            GroupBox3.Hide()
            Reset()
        End If
    End Sub
    'TSV
    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked Then
            TextBox1.Enabled = False
            TextBox4.Enabled = False
            Type = 4
        Else
            Reset()
        End If
    End Sub
    'G7TID & SID = TID
    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked And RadioButton2.Checked Then
            ShowAll()
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            Type = 2
        Else
            Reset()
        End If
    End Sub
    'TSV & SID = TID
    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        If RadioButton6.Checked And RadioButton2.Checked Then
            ShowAll()
            TextBox1.Enabled = False
            TextBox3.Enabled = False
            Type = 5
        Else
            Reset()
        End If
    End Sub
    'TSV & TID = SID
    Private Sub RadioButton8_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton8.CheckedChanged
        If RadioButton8.Checked And RadioButton3.Checked Then
            ShowAll()
            TextBox2.Enabled = False
            TextBox4.Enabled = False
            Type = 3
        Else
            Reset()
        End If
    End Sub
    'G7TID & TID = SID
    Private Sub RadioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton7.CheckedChanged
        If RadioButton7.Checked And RadioButton3.Checked Then
            ShowAll()
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            Type = 6
        Else
            Reset()
        End If
    End Sub

    'Form at startup
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        checkUpdate()
        RadioButton1.PerformClick()
        GroupBox2.Hide()
        GroupBox3.Hide()
        Button2.Hide()
        TabControl1.SelectedIndex += 1
        RadioButton12.PerformClick()
        RadioButton10.PerformClick()
        TabControl1.SelectedIndex -= 1
    End Sub
    Public Sub checkUpdate()
        Dim ver As String = My.Application.Info.Version.ToString
        Dim path As String = My.Application.Info.DirectoryPath
#If DEBUG Then
        System.IO.File.WriteAllText(path & "\version.txt", ver)
#Else
        Dim msgU As New UpdateCheck
#End If
    End Sub
    'Puts info from Textboxes to variables
    Private Sub updateStuff()
        If Type = 1 Then
            If TextBox3.Text = "" Or TextBox2.Text = "" Then
                MsgBox("Error")
            Else
                TID = TextBox3.Text
                SID = TextBox2.Text
            End If
        ElseIf Type = 2 Then
            If TextBox1.Text = "" Or TextBox2.Text = "" Then
                MsgBox("Error")
            Else
                G7TID = TextBox1.Text
                SID = TextBox2.Text
            End If
        ElseIf Type = 3 Then
            If TextBox3.Text = "" Or TextBox1.Text = "" Then
                MsgBox("Error")
            Else
                G7TID = TextBox1.Text
                TID = TextBox3.Text
            End If
        ElseIf Type = 4 Then
            If TextBox3.Text = "" Or TextBox2.Text = "" Then
                MsgBox("Error")
            Else
                TID = TextBox3.Text
                SID = TextBox2.Text
            End If
        ElseIf Type = 5 Then
            If TextBox4.Text = "" Or TextBox2.Text = "" Then
                MsgBox("Error")
            Else
                TSV = TextBox4.Text
                SID = TextBox2.Text
            End If
        ElseIf Type = 6 Then
            If TextBox3.Text = "" Or TextBox4.Text = "" Then
                MsgBox("Error")
            Else
                TID = TextBox3.Text
                TSV = TextBox4.Text
            End If
        End If
    End Sub

    'Calculates the amount to counter the mod 1000000
    Private Sub Modifer()
        If Modi <= 2145000000 Then
            Modi = Modi + 1000000
        Else
        End If
    End Sub

    'All SID possibities when calculated with TSV
    Private Sub possS()
        PossibitiesS = SID - 16 & " 
" & SID - 15 & " 
" & SID - 14 & " 
" & SID - 13 & " 
" & SID - 12 & " 
" & SID - 11 & " 
" & SID - 10 & " 
" & SID - 9 & " 
" & SID - 8 & " 
" & SID - 7 & " 
" & SID - 6 & " 
" & SID - 5 & " 
" & SID - 4 & " 
" & SID - 3 & " 
" & SID - 2 & " 
" & SID - 1 & " 
" & "~" & SID & "~" & " 
" & SID + 1 & " 
" & SID + 2 & " 
" & SID + 3 & " 
" & SID + 4 & " 
" & SID + 5 & " 
" & SID + 6 & " 
" & SID + 7 & " 
" & SID + 8 & " 
" & SID + 9 & " 
" & SID + 10 & " 
" & SID + 11 & " 
" & SID + 12 & " 
" & SID + 13 & " 
" & SID + 14 & " 
" & SID + 15 & " 
" & SID + 16
    End Sub
    'All TID possibities when calculated with TSV
    Private Sub possT()
        PossibitiesT = TID - 16 & " 
" & TID - 15 & " 
" & TID - 14 & " 
" & TID - 13 & " 
" & TID - 12 & " 
" & TID - 11 & " 
" & TID - 10 & " 
" & TID - 9 & " 
" & TID - 8 & " 
" & TID - 7 & " 
" & TID - 6 & " 
" & TID - 5 & " 
" & TID - 4 & " 
" & TID - 3 & " 
" & TID - 2 & " 
" & TID - 1 & " 
" & "~" & TID & "~" & " 
" & TID + 1 & " 
" & TID + 2 & " 
" & TID + 3 & " 
" & TID + 4 & " 
" & TID + 5 & " 
" & TID + 6 & " 
" & TID + 7 & " 
" & TID + 8 & " 
" & TID + 9 & " 
" & TID + 10 & " 
" & TID + 11 & " 
" & TID + 12 & " 
" & TID + 13 & " 
" & TID + 14 & " 
" & TID + 15 & " 
" & TID + 16
    End Sub

    'The calculations
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
            possT()
            Output = "TID could be one of... 

" & PossibitiesT
            RichTextBox1.Text = Output
        ElseIf Type = 6 Then
            SID = (TID Xor (TSV << 4))
            'SID = TID ^ (TSV << 4)
            possS()
            Output = "SID could be one of... 

" & PossibitiesS
            RichTextBox1.Text = Output
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog1.ShowDialog()
        OpenFileDialog1.Filter = "Main files (main)|main|All files (*.*)|*.*"
        'System.IO.File.OpenRead(OpenFileDialog1.FileName)
        Dim fileReader As Long
        fileReader = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
        MsgBox(fileReader)
        'System.IO.File.Open(OpenFileDialog1.FileName, IO.FileMode.Open)

    End Sub

    Private Sub RadioButton10_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton10.CheckedChanged
        shinyrate = True
    End Sub
    Private Sub RadioButton9_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton9.CheckedChanged
        shinyrate = False
    End Sub
    Private Sub RadioButton12_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton12.CheckedChanged
        rings = 0
    End Sub
    Private Sub RadioButton11_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton11.CheckedChanged
        rings = 1
    End Sub
    Private Sub RadioButton13_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton13.CheckedChanged
        rings = 2
    End Sub
    Private Sub RadioButton14_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton14.CheckedChanged
        rings = 3
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox5.Text = "" Then
            MsgBox("Error")
            Exit Sub
        Else
            lgtyrs = TextBox5.Text
        End If

        d = Math.Min(9, ((lgtyrs / 500) - 1))

        If (shinyrate = False) And (rings = 0) Then
            rate = 3
            Label7.Text = rate & "%"
        ElseIf (shinyrate = True) And (rings = 0) Then
            rate = 1
            Label7.Text = rate & "%"
        ElseIf (shinyrate = False) And (rings = 1) Then
            rate = 3 + d
            Label7.Text = rate & "%"
        ElseIf (shinyrate = True) And (rings = 1) Then
            rate = 1 + d
            Label7.Text = rate & "%"
        ElseIf (shinyrate = False) And (rings = 2) Then
            rate = 7 + (3 * d)
            Label7.Text = rate & "%"
        ElseIf (shinyrate = True) And (rings = 2) Then
            rate = 1 + (2 * d)
            Label7.Text = rate & "%"
        ElseIf (shinyrate = False) And (rings = 3) Then
            rate = 100
            Label7.Text = rate & "%"
        ElseIf (shinyrate = True) And (rings = 3) Then
            rate = (4 * d)
            Label7.Text = rate & "%"
        End If
    End Sub
End Class
