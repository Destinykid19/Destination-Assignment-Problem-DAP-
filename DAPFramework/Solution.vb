Public Class Solution
    Public pi_i() As Integer
    Public mü_o(,) As Integer

    Private rnd As New Random

    Public Function solveGA(ByRef instance As instance, ByVal N As Integer) As Integer(,)
        ReDim pi_i(instance.InbDes)
        ReDim mü_o(N - 1, instance.OutDes)

        Dim list_inb_segmente As New List(Of Integer)
        Dim list_outb_segmente As New List(Of Integer)

        For i = 1 To instance.NumberOfSegments
            For j = 1 To instance.DsIN
                list_inb_segmente.Add(i)
            Next
            For j = 1 To instance.DsOut
                list_outb_segmente.Add(i)
            Next
        Next


        Dim templistin As List(Of Integer) = list_inb_segmente
        For i = 0 To instance.InbDes
            Dim zRnd As Integer = rnd.Next(0, templistin.Count)
            pi_i(i) = list_inb_segmente(zRnd)
            templistin.RemoveAt(zRnd)
        Next

        'Startlösung generieren 
        For i = 0 To N - 1
            Dim templistout As List(Of Integer) = list_outb_segmente
            For j = 0 To instance.OutDes
                Dim zRnd As Integer = rnd.Next(0, templistout.Count)
                mü_o(i, j) = list_outb_segmente(zRnd)
                templistout.RemoveAt(zRnd)
            Next
        Next

        Return mü_o

    End Function
End Class
