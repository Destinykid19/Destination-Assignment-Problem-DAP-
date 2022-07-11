Module main

    Sub Main()
        Dim inDes As Integer = 3 '{3,5,7,25,50,75}
        Dim outDes As Integer = 7 '{3,5,7,25,50,75}
        Dim alphaa As Double = 0.3 '[0.1,0.5][0.6,0.9]
        Dim alphab As Double = 0.5 '[0.1,0.5][0.6,0.9]

        Dim instance As New instance(inDes, outDes, alphaa, alphab)

        Dim solutionGA As New Solution
        Dim N As Integer = 10
        Dim y_o(N - 1, outDes - 1) As Integer

        y_o = solutionGA.solveGA(instance, N)

    End Sub




End Module
