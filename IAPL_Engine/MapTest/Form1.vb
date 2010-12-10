Public Class Form1

    Private _map As New Map.Map

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        _map.Name = "TEST MAP"
        For i As Integer = 0 To 4

            Dim _layer As New Map.Layer
            For j As Integer = 0 To 49

                _layer.Tiles.Add(New Map.IndividualTile With {.Location = New Point(j, 0)})

            Next
            _map.Add(_layer)

        Next

        _map.Save(IO.Path.Combine(Application.StartupPath, "test.map"))

    End Sub
End Class
