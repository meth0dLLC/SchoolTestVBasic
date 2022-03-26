Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Visible = False
        Button2.Visible = True
        Label1.Visible = True
        Label1.Text = "Фамилия: " & vbCrLf & vbCrLf & "Имя: " & vbCrLf & vbCrLf & "Итоговая оценка: "
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fam As String
        Dim name As String
        If (Button2.Visible = True) Then
            fam = InputBox("Введите фамилию", "Регистрация")
            While fam.Length <= 2 And fam <> "" ' try detect click on exit or cancel
                MsgBox("Введите корректную фамилию", vbCritical + vbRetryCancel)
                If vbRetry Then
                    fam = InputBox("Введите фамилию", "Регистрация")
                End If
            End While
            If (fam.Length() > 2) Then
                name = InputBox("Введите имя", "Регистрация")
                While name.Length <= 2 And name <> "" ' try detect click on exit or cancel
                    MsgBox("Введите корректное имя", vbCritical + vbRetryCancel)
                    If vbRetry Then
                        name = InputBox("Введите имя", "Регистрация")
                    End If
                End While
                If (name.Length() > 2) Then
                    Button2.Visible = False
                    Button3.Visible = True
                End If
            End If
            base(0) = fam 'record data in massive
            base(1) = name
        End If
        If fam <> "" And Name <> "" Then
            Label1.Text = "Фамилия: " + fam & vbCrLf & vbCrLf & "Имя: " + name & vbCrLf & vbCrLf & "Итоговая оценка: -"
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Timer1.Enabled = True
        Timer1.Start()
        Label1.Visible = False
        Button3.Visible = False
        Button4.Visible = True
        Label2.Visible = True
        Label4.Visible = True
        CheckBox1.Visible = True
        CheckBox2.Visible = True
        CheckBox3.Visible = True
        CheckBox4.Visible = True
        ProgressBar1.Visible = True
        Label3.Visible = True
        Button5.Visible = True
        Button6.Visible = True
        Label3.Text = "Осталось времени: 10:00"
        Label2.Text = "Вопрос 1 из 10"
        Label4.Text = "Какая функция преобразовывает численный тип данных в строковый?"
        CheckBox1.Text = "Val"
        CheckBox2.Text = "Integer"
        CheckBox3.Text = "CStr"
        CheckBox4.Text = "Pow"
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim time As Integer
        Dim range As Byte
        Dim sec As Byte = 60
        sync += 1
        If sync = 60 Then
            sync = 1
        End If
        If sec = 0 Then
            sec = 60
        End If
        time += 1
        timeT -= time
        Select Case timeT
            Case <= 999 And timeT >= 941
                range = 9
            Case <= 941 And timeT >= 881
                range = 8
            Case <= 881 And timeT >= 821
                range = 7
            Case <= 821 And timeT >= 761
                range = 6
            Case <= 761 And timeT >= 701
                range = 5
            Case <= 701 And timeT >= 641
                range = 4
            Case <= 641 And timeT >= 581
                range = 3
            Case <= 581 And timeT >= 521
                range = 2
            Case <= 521 And timeT >= 461
                range = 1
            Case <= 461 And timeT >= 401
                range = 0
        End Select
        If (timeT = 401) Then
            Timer1.Stop()
            MsgBox("Время вышло!", vbInformation)
            If (vbOK) Then
                End
            End If
        End If
        sec -= sync
        If sec <= 9 Then
            Label3.Text = "Осталось времени: " + CStr(range) + ":" + "0" + CStr(sec)
        Else
            Label3.Text = "Осталось времени: " + CStr(range) + ":" + CStr(sec)
        End If
    End Sub

    Sub Aesthic()
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
    End Sub

    Sub UpdateData() ' mg i fix main bug with update data
        Select Case que ' check on right answer
            Case 1
                If (CheckBox3.CheckState = 1 And asyncD = 1) Then
                    data += 1
                End If
            Case 2
                If (CheckBox3.CheckState = 1 And asyncD = 2) Then
                    data += 1
                End If
            Case 3
                If (CheckBox2.CheckState = 1 And asyncD = 3) Then
                    data += 1
                End If
            Case 4
                If (CheckBox2.CheckState = 1 And asyncD = 4) Then
                    data += 1
                End If
            Case 5
                If (CheckBox2.CheckState = 1 And asyncD = 5) Then
                    data += 1
                End If
            Case 6
                If (CheckBox3.CheckState = 1 And asyncD = 6) Then
                    data += 1
                End If
            Case 7
                If (CheckBox2.CheckState = 1 And asyncD = 7) Then
                    data += 1
                End If
            Case 8
                If (CheckBox1.CheckState = 1 And asyncD = 8) Then
                    data += 1
                End If
            Case 9
                If (CheckBox3.CheckState = 1 And asyncD = 9) Then
                    data += 1
                End If
            Case 10
                If (CheckBox3.CheckState = 1 And asyncD = 10) Then
                    data += 1
                End If
        End Select

        If data >= 3 And data <= 5 Then ' calculate estimation
            lxc = 3
        ElseIf data >= 6 And data <= 8 Then
            lxc = 4
        ElseIf data >= 9 And data <= 11 Then
            lxc = 5
        Else
            lxc = 2
        End If
        base(2) = CStr(lxc) ' record data in massive
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim stopT As Boolean
        CheckBox1.Enabled = True
        CheckBox2.Enabled = True
        CheckBox3.Enabled = True
        CheckBox4.Enabled = True
        Button6.Enabled = False
        Button4.Enabled = False
        If CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = False Then
            MsgBox("Выберите хотя бы 1 вариант ответа", vbExclamation + vbOK)
            If vbOK Then
                stopT = True
            End If
        End If
        If stopT = False Then
            ProgressBar1.Value = que * 10 ' * 10 cuz max value bar - 100
            que += 1
        End If
        If (que <> 11) Then
            Label2.Text = "Вопрос " + CStr(que) + " из 10"
            Select Case que
                Case 2
                    Aesthic()
                    Label4.Text = "Какая функция преобразовывает строковый тип данных в численный?"
                    CheckBox1.Text = "Str"
                    CheckBox2.Text = "Float"
                    CheckBox3.Text = "Val"
                    CheckBox4.Text = "Auto"
                Case 3
                    Aesthic()
                    Label4.Text = "Функция для вызова окна ввода"
                    CheckBox1.Text = "MsgBox"
                    CheckBox2.Text = "InputBox"
                    CheckBox3.Text = "MessageBox"
                    CheckBox4.Text = "Writeln"
                Case 4
                    Aesthic()
                    Label4.Text = "Функция для вызова окна вывода"
                    CheckBox1.Text = "InputBox"
                    CheckBox2.Text = "MsgBox"
                    CheckBox3.Text = "Readln"
                    CheckBox4.Text = "Writeln"
                Case 5
                    Aesthic()
                    Label4.Text = "Какая библиотека используется в ЯП Паскаль для работы с графикой?"
                    CheckBox1.Text = "system"
                    CheckBox2.Text = "graphabc"
                    CheckBox3.Text = "Graphica"
                    CheckBox4.Text = "init_dx9"
                Case 6
                    Aesthic()
                    Label4.Text = "Каким способом можно инициализировать переменные глобально?"
                    CheckBox1.Text = "Private"
                    CheckBox2.Text = "Component"
                    CheckBox3.Text = "Module"
                    CheckBox4.Text = "Public"
                Case 7
                    Aesthic()
                    Label4.Text = "Какой язык программирования более востребован на 2022 год?"
                    CheckBox1.Text = "Scratch"
                    CheckBox2.Text = "C++"
                    CheckBox3.Text = "PHP"
                    CheckBox4.Text = "Basic"
                Case 8
                    Aesthic()
                    Label4.Text = "Функция перевода иного типа данных в строку"
                    CheckBox1.Text = "*.ToString"
                    CheckBox2.Text = "CStr"
                    CheckBox3.Text = "std::string"
                    CheckBox4.Text = "array"
                Case 9
                    Aesthic()
                    Label4.Text = "Популярный шифратор текста"
                    CheckBox1.Text = "XorString"
                    CheckBox2.Text = "FN1VA"
                    CheckBox3.Text = "Base64"
                    CheckBox4.Text = "VMP"
                Case 10
                    Aesthic()
                    Label4.Text = "Численный тип вместимостью от 0 до 255"
                    CheckBox1.Text = "Integer"
                    CheckBox2.Text = "LongLong"
                    CheckBox3.Text = "Byte"
                    CheckBox4.Text = "Str"
            End Select
            If (que = 10) Then
                Button4.Text = "Завершить"
                Timer1.Stop()
            End If
        Else
            Label2.Visible = True
            Label2.Left() = Label2.Left() + 325
            Label2.Text = "Тест завершен"
            Label1.Top() = Label1.Top() + 20
            Label1.Text = "Фамилия: " + base(0) & vbCrLf & vbCrLf & "Имя: " + base(1) & vbCrLf & vbCrLf & "Итоговая оценка: " + base(2) & vbCrLf & vbCrLf &
            "Правильных ответов: " + CStr(data) + " из 10"
            Button4.Visible = False
            Label4.Visible = False
            CheckBox1.Visible = False
            CheckBox2.Visible = False
            CheckBox3.Visible = False
            CheckBox4.Visible = False
            ProgressBar1.Visible = False
            Label1.Visible = True
            Label3.Visible = False
            Button5.Visible = False
            Button6.Visible = False
            que = 0
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Button5.Enabled = True
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Button5.Enabled = True
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        Button5.Enabled = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        asyncD += 1 ' again iqless fix data base
        CheckBox1.Enabled = False
        CheckBox2.Enabled = False
        CheckBox3.Enabled = False
        CheckBox4.Enabled = False
        Button4.Enabled = True
        Button6.Enabled = True
        Button5.Enabled = False
        UpdateData() ' again iqless fix data base
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        CheckBox1.Enabled = True
        CheckBox2.Enabled = True
        CheckBox3.Enabled = True
        CheckBox4.Enabled = True
        Aesthic()
        Button5.Enabled = False
        Button4.Enabled = False
        Button6.Enabled = False
        asyncD -= 1
        data -= 1
        UpdateData()
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        Button5.Enabled = True
    End Sub
End Class
