Module SimpleConsoleControls
    Public GlobalRows As Integer = Console.WindowHeight
    Public GlobalCols As Integer = Console.WindowWidth

    Public Sub Label(ByVal X As Integer, ByVal Y As Integer, ByVal Text As String, ByVal Optional fcolor As ConsoleColor = ConsoleColor.White, ByVal Optional bcolor As ConsoleColor = ConsoleColor.Black)
        System.Console.SetCursorPosition(X, Y)
        Console.ForegroundColor = fcolor
        Console.BackgroundColor = bcolor
        System.Console.Write(Text)
        Console.ResetColor()
    End Sub
    Public Function TextField(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer)
        Console.BackgroundColor = ConsoleColor.DarkBlue
        Console.ForegroundColor = ConsoleColor.White
        Console.SetCursorPosition(X, Y)
        Dim retval As String = ""
        For i As Integer = 0 To Width - 1
            Console.Write(" ")
        Next
        Console.SetCursorPosition(X, Y)
        While 1
            Dim Capture As ConsoleKeyInfo = Console.ReadKey(True)

            If Capture.Key = ConsoleKey.Enter Then
                Exit While
            ElseIf Capture.Key = ConsoleKey.Backspace Then
                If retval.Length > 0 Then
                    retval = retval.Remove(retval.Length - 1, 1)
                    Console.Write(vbBack)
                    Console.Write(" ")
                    Console.Write(vbBack)
                End If
            Else
                If retval.Length < Width Then
                    retval += Capture.KeyChar
                    Console.SetCursorPosition(X, Y)
                    Console.Write(retval)

                End If
            End If

        End While
        Console.ResetColor()
        Return retval


    End Function
    Public Sub Title(ByVal Y As Integer, ByVal text As String)
        Dim LabelColumns As Integer = text.Length

        Dim StartX As Integer = (GlobalCols / 2) - (LabelColumns / 2)
        Console.BackgroundColor = ConsoleColor.DarkBlue
        Console.ForegroundColor = ConsoleColor.White
        Label(StartX, Y, text)
        Console.ResetColor()
    End Sub
    Public Sub SetWinSize(ByVal rows As Integer, ByVal columns As Integer)
        GlobalRows = rows
        GlobalCols = columns

        Console.SetWindowSize(columns, rows)
        Console.SetBufferSize(columns, rows)
    End Sub
    Public Function PasswordField(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Mask As String)
        Console.BackgroundColor = ConsoleColor.DarkBlue
        Console.ForegroundColor = ConsoleColor.White
        Console.SetCursorPosition(X, Y)
        For i As Integer = 0 To Width - 1
            Console.Write(" ")
        Next
        Console.SetCursorPosition(X, Y)

        Dim pwd As String = ""

        While (1)
            Dim i As ConsoleKeyInfo = Console.ReadKey(True)
            If i.Key = ConsoleKey.Enter Then
                Exit While
            ElseIf i.Key = ConsoleKey.Backspace Then
                If pwd.Length > 0 Then
                    pwd = pwd.Remove(pwd.Length - 1, 1)
                    Console.Write(vbBack)
                    Console.Write(" ")
                    Console.Write(vbBack)
                End If
            Else
                If pwd.Length < Width Then
                    pwd += i.KeyChar
                    Console.Write(Mask)
                End If
            End If





        End While



        Console.ResetColor()
        Return pwd
    End Function

End Module
