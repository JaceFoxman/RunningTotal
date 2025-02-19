'notes
Option Explicit On
Option Strict On

'TODO
'[x] Keep track  of transactions in a Function called RunningTotal()
'[x] get the current total as needed
'[x] provide a way to clear/zero the total
'[x] display transactions and running total formatted as currency
'[x] use optional arguments for coolness
'[] super bonus: create a method to include sales tax to the transation
Module RunningTotal

    Sub Main()
        Dim userInput As String
        Dim transactionAmount As Decimal
        Dim quit As Boolean = False

        Do
            Console.WriteLine("Enter a transaction amount")
            Console.WriteLine("Enter Q to quit")
            Console.WriteLine("Enter T to show total")
            Console.WriteLine("Enter C to clear the total")
            userInput = Console.ReadLine()
            Console.Clear()
            Try
                transactionAmount = CDec(userInput)
                RunningTotal(transactionAmount, False)
                Console.WriteLine($"The sales tax on {transactionAmount.ToString("c")} is {Tax(transactionAmount).ToString("c")}")
            Catch ex As Exception
                Select Case userInput
                    Case "q"
                        quit = True
                    Case "t"
                        Console.WriteLine($"The current total is {RunningTotal(0, False).ToString("c")}")
                    Case "c"
                        RunningTotal(0, True).ToString("c")
                    Case Else
                        Console.WriteLine($"you entered:{userInput}")
                End Select
            End Try
        Loop Until quit

        Console.Clear()
        Console.WriteLine($"The total is: {RunningTotal(0, False).ToString("c")}")
        Console.WriteLine("have a nice day")

    End Sub

    Function RunningTotal(currentNumber As Decimal, clear As Boolean) As Decimal
        Static _runningTotal As Decimal = 0
        _runningTotal += currentNumber
        If clear Then
            _runningTotal = 0
        Else

        End If

        Return _runningTotal
    End Function

    Function Tax(amount As Decimal) As Decimal
        '@ is decimal type specifier
        Const TAXRATE = 0.06@
        Return amount * TAXRATE
    End Function
End Module
