Public Class Form1
    Dim WithEvents c1 As New NetCode.Net
    Dim WithEvents c2 As New NetCode.Net

    Private Delegate Sub dAddToListBox(ByRef LB As ListBox, ByVal data As String)
    Private Sub AddToListBox(ByRef LB As ListBox, ByVal data As String)
        If LB.InvokeRequired Then
            LB.Invoke(New dAddToListBox(AddressOf AddToListBox), LB, data)
        Else
            LB.Items.Add(data)
            LB.SelectedIndex = LB.Items.Count - 1
        End If
    End Sub


#Region "c1 code"
    Private Sub c1_ConnectionClosed() Handles c1.ConnectionClosed
        AddToListBox(ListBox1, "connection closed")
    End Sub

    Private Sub c1_ConnectionError(ByVal sender As Object, ByVal exception As System.Exception) Handles c1.ConnectionError
        AddToListBox(ListBox1, "connection error")
        AddToListBox(ListBox1, exception.ToString)
    End Sub

    Private Sub c1_ConnectionEstablished() Handles c1.ConnectionEstablished
        AddToListBox(ListBox1, "connection established")
    End Sub

    Private Sub c1_IncomingMessage(ByVal sender As Object, ByVal message As Object) Handles c1.IncomingMessage
        AddToListBox(ListBox1, "message")
    End Sub
#End Region

#Region "c2 code"
    Private Sub c2_ConnectionClosed() Handles c2.ConnectionClosed
        AddToListBox(ListBox2, "connection closed")
    End Sub

    Private Sub c2_ConnectionError(ByVal sender As Object, ByVal exception As System.Exception) Handles c2.ConnectionError
        AddToListBox(ListBox2, "connection error")
        AddToListBox(ListBox2, exception.ToString)
    End Sub

    Private Sub c2_ConnectionEstablished() Handles c2.ConnectionEstablished
        AddToListBox(ListBox2, "connection established")
    End Sub

    Private Sub c2_IncomingMessage(ByVal sender As Object, ByVal message As Object) Handles c2.IncomingMessage
        AddToListBox(ListBox2, "message")
    End Sub
#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        c1 = New NetCode.Net
        c1.Listen()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        c2 = New NetCode.Net
        c2.Connect(TextBox1.Text)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'c2.ObjectSender(New Object)
        c2.Disconnect()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        c1.ObjectSender("hi")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        c2.ObjectSender("hlelo")
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        c1.Disconnect()
    End Sub

End Class