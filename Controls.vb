Public Class Controls
    Public GlobalRows As Integer = Console.WindowHeight
    Public GlobalCols As Integer = Console.WindowWidth

    Public Sub ProgressBar(ByVal X As Integer, ByVal Y As Integer, ByVal CurrentValue As Integer, ByVal MaxValue As Integer, ByVal BarWidth As Integer)
        Dim percentComplete As Double = (CurrentValue / MaxValue) * 100
        Dim FilledWidth As Integer = CInt(percentComplete / 100 * BarWidth)
        Dim EmptyWidth As Integer = BarWidth - FilledWidth

        Console.SetCursorPosition(X, Y)
        Console.Write(New String("█", FilledWidth) & New String("░", EmptyWidth))

    End Sub

    Public Sub Label(ByVal X As Integer, ByVal Y As Integer, ByVal Text As String, ByVal Optional fcolor As ConsoleColor = ConsoleColor.White, ByVal Optional bcolor As ConsoleColor = ConsoleColor.Black)
        Dim CurBG As ConsoleColor = Console.BackgroundColor
        Dim CurFG As ConsoleColor = Console.ForegroundColor
        System.Console.SetCursorPosition(X, Y)
        Console.ForegroundColor = fcolor
        Console.BackgroundColor = bcolor
        System.Console.Write(Text)
        Console.ForegroundColor = CurFG
        Console.BackgroundColor = CurBG
    End Sub
    Public Function TextField(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Optional bcolor As ConsoleColor = ConsoleColor.Black, ByVal Optional fcolor As ConsoleColor = ConsoleColor.White, ByVal Optional Required As Boolean = False, ByVal Optional CatchEsc As Boolean = False)
        Dim CurBG As ConsoleColor = Console.BackgroundColor
        Dim CurFG As ConsoleColor = Console.ForegroundColor
        Dim CursorVis As Boolean = Console.CursorVisible
        Console.CursorVisible = True
        Console.BackgroundColor = bcolor
        Console.ForegroundColor = fcolor
        Console.SetCursorPosition(X, Y)
        Dim retval As String = ""
        For i As Integer = 0 To Width - 1
            Console.Write(" ")
        Next
        Console.SetCursorPosition(X, Y)
        While 1
            Dim Capture As ConsoleKeyInfo = Console.ReadKey(True)
            If CatchEsc = True And Capture.Key = ConsoleKey.Escape Then
                Console.CursorVisible = CursorVis
                Console.BackgroundColor = CurBG
                Console.ForegroundColor = CurFG
                Return "ESC"
            End If
            If Capture.Key = ConsoleKey.Enter Then
                If retval.Length = 0 Then
                    If Required = False Then
                        Exit While
                    End If
                Else
                    Exit While

                End If

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
        Console.CursorVisible = CursorVis
        Console.BackgroundColor = CurBG
        Console.ForegroundColor = CurFG
        Return retval


    End Function
    Public Sub Title(ByVal Y As Integer, ByVal text As String, ByVal Optional bcolor As ConsoleColor = ConsoleColor.Black, ByVal Optional fcolor As ConsoleColor = ConsoleColor.White)
        Dim LabelColumns As Integer = text.Length
        Dim CurrentBG = Console.BackgroundColor
        Dim CurrentFG = Console.ForegroundColor
        Dim StartX As Integer = (GlobalCols / 2) - (LabelColumns / 2)
        Console.BackgroundColor = ConsoleColor.DarkBlue
        Console.ForegroundColor = ConsoleColor.White
        Label(StartX, Y, text, fcolor, bcolor)
        Console.BackgroundColor = CurrentBG
        Console.ForegroundColor = CurrentFG
    End Sub
    Public Sub SetWinSize(ByVal rows As Integer, ByVal columns As Integer)
        GlobalRows = rows
        GlobalCols = columns

        Console.SetWindowSize(columns, rows)
        Console.SetBufferSize(columns + 2, rows + 2)
    End Sub



    Public Sub DrawRectangle(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal Optional BColor As ConsoleColor = ConsoleColor.Black, ByVal Optional FColor As ConsoleColor = ConsoleColor.White)
        Dim CurrentFG = Console.ForegroundColor
        Dim CurrentBG = Console.BackgroundColor

        Dim ulCorner As String = "╔"
        Dim urCorner As String = "╗"
        Dim llCorner As String = "╚"
        Dim lrCorner As String = "╝"
        Dim vert As String = "║"
        Dim horz As String = "═"
        Dim totHorz = Width - 2
        Dim totVert = Height - 2
        Console.SetCursorPosition(X, Y)
        Console.Write(ulCorner)
        For i As Integer = 1 To totHorz
            Console.Write(horz)
        Next
        Console.Write(urCorner)
        Console.WriteLine()
        Dim curX As Integer = Console.CursorLeft
        Dim curY As Integer = Console.CursorTop

        For j As Integer = 1 To totVert
            Console.SetCursorPosition(X, curY)
            Console.Write(vert)
            For k As Integer = 1 To totHorz
                Console.Write(" ")

            Next

            Console.Write(vert)


            Console.Write(vbCrLf)


            curY += 1
        Next
        Console.SetCursorPosition(X, curY)
        Console.Write(llCorner)
        For l As Integer = 1 To totHorz
            Console.Write(horz)
        Next
        Console.Write(lrCorner)
        Console.BackgroundColor = CurrentBG
        Console.ForegroundColor = CurrentFG
    End Sub
    Public Function PasswordField(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Optional Mask As String = "*", ByVal Optional BColor As ConsoleColor = ConsoleColor.Black, Optional FColor As ConsoleColor = ConsoleColor.White, ByVal Optional CatchEscape As Boolean = False)

        Dim CurBG As ConsoleColor = Console.BackgroundColor
        Dim CurFG As ConsoleColor = Console.ForegroundColor
        Dim CursorVis As Boolean = Console.CursorVisible
        Console.CursorVisible = True
        Console.BackgroundColor = BColor
        Console.ForegroundColor = FColor
        Console.SetCursorPosition(X, Y)
        For i As Integer = 0 To Width - 1
            Console.Write(" ")
        Next
        Console.SetCursorPosition(X, Y)

        Dim pwd As String = ""

        While (1)
            Dim i As ConsoleKeyInfo = Console.ReadKey(True)
            If i.Key = ConsoleKey.Escape Then
                Console.CursorVisible = CursorVis
                Console.BackgroundColor = CurBG
                Console.ForegroundColor = CurFG
                Return "ESC"
                Exit Function

            End If
            If i.Key = ConsoleKey.Enter Then
                If pwd.Length > 0 Then
                    Exit While
                End If

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


        Console.CursorVisible = CursorVis
        Console.BackgroundColor = CurBG
        Console.ForegroundColor = CurFG
        Return pwd
    End Function

End Class
