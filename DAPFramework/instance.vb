Public Class instance
    Public InbDes As Integer 'number inbound
    Public OutDes As Integer 'number outbound

    Public alphaA As Double 'startinterval alpha 'umso höher umso voller ??
    Public alphaB As Double 'endinterval alpha

    Public NumberOfSegments As Integer
    Public DsIN As Integer 'number of inboutDes per Segment
    Public DsOut As Integer 'number of inboutDes per Segment
    Private OutPerIn() As Integer
    Private rnd As Random

    Public bio(,) As Integer

    Sub New(ByVal inbDes As Integer, ByVal outDes As Integer, ByVal alphaa As Double, ByVal alphab As Double)
        Me.rnd = New Random
        Me.InbDes = inbDes - 1 '0 basierter Index bei arrays
        Me.OutDes = outDes - 1
        Me.alphaA = alphaa
        Me.alphaB = alphab
        ReDim Me.OutPerIn(Me.InbDes) 'Outbound destination pro inbound (normalerweise mehr outbounds als unbounds)
        ReDim Me.bio(Me.InbDes, Me.OutDes) 'transportmatrix

        NumberOfSegments = CInt((2 / 3) * Math.Min(inbDes + 1, outDes + 1)) 'festgelegte anazhl an segmenten

        'symmetrische Verteileung der Türen auf Segmente
        DsIN = Math.Round(inbDes / NumberOfSegments)
        DsOut = Math.Round(outDes / NumberOfSegments)

        OutPerIn = getOutPerIn(OutPerIn)
        getBio()

    End Sub


    Function getOutPerIn(array() As Integer)
        Dim zValue(UBound(array)) As Integer

        For i = 0 To UBound(zValue)
            zValue(i) = CInt(getRND() * OutDes)
        Next

        Return zValue
    End Function

    Sub getBio() 'erstellung bio
        For i = 0 To InbDes
            Dim RndSeq() As Integer
            RndSeq = getRndOutSeq()
            For j = 0 To OutPerIn(i) - 1
                Dim RndAlpha As Double = CInt(getRND() * OutDes)
                Dim Muy As Double = CInt(5000 / RndAlpha)
                Dim sigma As Double = CInt(0.2 * 5000 / RndAlpha)
                bio(i, RndSeq(j)) = rnd.Next(Muy - sigma, Muy + sigma)
            Next
        Next
    End Sub

    Function getRND()
        Dim zRnd As Double
        Do
            zRnd = rnd.NextDouble
        Loop Until zRnd >= alphaA And zRnd <= alphaB
        Return zRnd
    End Function

    Function getRndOutSeq()
        Dim outSeq(OutDes) As Integer
        Dim zList As New List(Of Integer)
        For i = 0 To OutDes
            zList.Add(i)
        Next
        For i = 0 To OutDes
            Dim zRnd As Integer = rnd.Next(0, zList.Count)
            outSeq(i) = zList(zRnd)
            zList.RemoveAt(zRnd)
        Next
        Return outSeq
    End Function
End Class
