Imports System.Runtime.Serialization.Formatters
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text.RegularExpressions

Namespace NetCode

    ''' <summary>
    ''' Base Networking class. Needs to be tested still.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Net
        Implements IDisposable


#Region "Properties"

        ''' <summary>
        ''' Returns if the NetCode has been disposed.
        ''' </summary>
        ''' <value>Boolean variable based on _disposed.</value>
        ''' <returns>A True or False Boolean value.</returns>
        ''' <remarks>Use this to check to see if the class is labeled as "disposed"</remarks>
        Private ReadOnly Property Disposed As Boolean
            Get
                Return _disposed
            End Get
        End Property

        ''' <summary>
        ''' Returns if the system has an established connection or not.
        ''' </summary>
        ''' <value>Based on the internal boolean variable _connected.</value>
        ''' <returns>A True or False Boolean value.</returns>
        ''' <remarks>Always use this to check for a connection.</remarks>
        Public ReadOnly Property Connected As Boolean
            Get
                Return _connected
            End Get
        End Property

        ''' <summary>
        ''' Returns if there is a connection attempt in progress.
        ''' </summary>
        ''' <value>Based on the internal boolean variable _connecting.</value>
        ''' <returns>A True or False Boolean value.</returns>
        ''' <remarks>Use this when attempting to connect. It is called internally as well.</remarks>
        Public ReadOnly Property IsConnecting As Boolean
            Get
                Return _connecting
            End Get
        End Property

        ''' <summary>
        ''' Returns if the NetCode is waiting for an incoming connection.
        ''' </summary>
        ''' <value>A True or False Boolean Value.</value>
        ''' <returns>If the netcode is waiting or not.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsListening As Boolean
            Get
                Return _listening
            End Get
        End Property

        ''' <summary>
        ''' This returns the port that will be used for connections.
        ''' </summary>
        ''' <value>100</value>
        ''' <returns>Integer</returns>
        ''' <remarks>Probably never going to change, always should be 100.</remarks>
        Private ReadOnly Property Port As Integer
            Get
                Return 100I
            End Get
        End Property

#End Region

#Region "Overridable Subs"

        ''' <summary>
        ''' This sub is called whenever the system starts listening.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overridable Sub OnListening()
            RaiseEvent Listening(Me)
        End Sub

        ''' <summary>
        ''' The Sub is called when a connection attempt has been completed.
        ''' It is determined here if the connection attempt was completed
        ''' successfully or if there was a connection error.
        ''' </summary>
        ''' <param name="ir">The Async Result that says if the event has completed or not.</param>
        ''' <remarks></remarks>
        Protected Overridable Sub OnConnectionAttempt(ByVal ir As IAsyncResult)
            'The connection attempt has finished, check to see if there
            'is in fact a connection.
            If ir.IsCompleted AndAlso Me._connector.Connected Then
                'There is a connection, that is good.
                Me.OnConnectionEstablished()
            Else
                'There is no connection, throw an error.
                Dim Exception As New System.Net.ProtocolViolationException(String.Format("The Connection to IP Address '{0}' has failed!", _ip))
                Me.OnConnectionError(Exception)
            End If
        End Sub

        ''' <summary>
        ''' This sub is called when an incoming connection attempt succeeds. The Connection is handled accordingly and can be overridden.
        ''' </summary>
        ''' <param name="ir">The Result.</param>
        ''' <remarks></remarks>
        Protected Overridable Sub OnIncomingConnectionAttempt(ByVal ir As IAsyncResult)
            'Accept the client.
            Dim client As Sockets.TcpClient = _listener.EndAcceptTcpClient(ir)
            _connector = client
            'No longer listening
            _listener.Server.Close()
            _listening = False
            'Call the Connection Established Sub
            Me.OnConnectionEstablished()
        End Sub

        ''' <summary>
        ''' The Sub is called when a connection has been safely terminated.
        ''' </summary>
        ''' <param name="ir">The result.</param>
        ''' <remarks></remarks>
        Protected Overridable Sub OnSafeDisconnect(ByVal ir As IAsyncResult)
            'Kill the thread.
            _readerThread.Abort()

            'Raise the Connection Closed Event.
            RaiseEvent ConnectionClosed(Me)

            'We are no longer connected!
            _connected = False
            _connecting = False

            'Stop the listener if listening.
            If IsListening Then _listener.Server.Close()
            _listening = False

            'Close the connector.
            _connector.Client.Close()

        End Sub

        ''' <summary>
        ''' This sub is called to raise the ConnectionEstablished() event.
        ''' It may be overridden by another class that relies on it to perform
        ''' its own various tasks.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overridable Sub OnConnectionEstablished()

            'We are now connected.
            _connected = True

            'No longer in a connection attempt.
            _connecting = False

            'Raise the Connection Established event.
            RaiseEvent ConnectionEstablished(Me)

            'Start the reader.
            _readerThread = New Threading.Thread(AddressOf MessageListener) With {.IsBackground = True}
            _readerThread.Start()

        End Sub

        ''' <summary>
        ''' This sub is called to raise the ConnectionError() event.
        ''' It may be overridden by another class that relies on it to perform
        ''' its own various tasks.
        ''' </summary>
        ''' <param name="exception">The Exception that is passed up.</param>
        ''' <remarks></remarks>
        Protected Overridable Sub OnConnectionError(ByVal exception As Exception)

            'Stop the reader thread.
            _readerThread.Abort()

            'Raise the exception
            RaiseEvent ConnectionError(Me, exception)

            'Not connected to much of anything.
            _connected = False

            'Stop listening
            If IsListening Then _listener.Server.Close()
            _listening = False

            'Close the connector
            _connector.Client.Close()

        End Sub

        ''' <summary>
        ''' This sub is called to raise the IncomingMessage() event. It may be overridden by another class.
        ''' </summary>
        ''' <param name="message">The Object received over the stream.</param>
        ''' <remarks></remarks>
        Protected Overridable Sub OnIncomingMessage(ByVal message As Object)
            RaiseEvent IncomingMessage(Me, message)
        End Sub

#End Region

#Region "Events"

        Public Event ConnectionEstablished(ByVal sender As Object)
        Public Event ConnectionError(ByVal sender As Object, ByVal exception As Exception)
        Public Event ConnectionClosed(ByVal sender As Object)
        Public Event IncomingMessage(ByVal sender As Object, ByVal message As Object)
        Public Event Listening(ByVal sender As Object)

#End Region

#Region "Variables"

        Private _disposed As Boolean = False
        Private _listening As Boolean = False
        Private _connecting As Boolean = False
        Private _connected As Boolean = False
        Private _ip As String = String.Empty
        Private _connector As Sockets.TcpClient
        Private _listener As Sockets.TcpListener
        Private _readerThread As New System.Threading.Thread(AddressOf MessageListener) With {.IsBackground = True}

#End Region

#Region "Subs and Functions"

        ''' <summary>
        ''' Creates a new NetCode Class.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' Starts listening for an incoming connection.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub [Listen]()
            'Check to see if we're disposed
            If Disposed Then
                Throw New ObjectDisposedException("NetCode.Net", "You cannot access a disposed object!")
            End If
            'If we are not listening already, connected to someone else, or in the process of connecting.
            If Not Me.IsListening AndAlso Not Me.Connected AndAlso Not Me.IsConnecting Then
                'Set that we are listening.
                _listening = True
                'Create the Listener.
                _listener = New Sockets.TcpListener(System.Net.IPAddress.Any, Me.Port)
                'Start the Listener.
                _listener.Start()
                'Raise the event.
                Me.OnListening()
                'Create the Async acceptor.
                _listener.BeginAcceptTcpClient(New AsyncCallback(AddressOf Me.OnIncomingConnectionAttempt), _listener)
            Else
                'Debug line.
                Debug.WriteLine(String.Format("Listening: {0}, Connected: {0}, Connecting: {0}", Me.IsListening, Me.Connected, Me.IsConnecting))
            End If
        End Sub

        ''' <summary>
        ''' Stops listening for an incoming connection.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub [StopListen]()
            'Check to see if we're disposed
            If Disposed Then
                Throw New ObjectDisposedException("NetCode.Net", "You cannot access a disposed object!")
            End If
            'If the listener is active.
            If Me.IsListening Then
                'Set to false.
                _listening = False
                'Close it.
                _listener.Server.Close()
                _listener.Stop()
            End If
        End Sub

        ''' <summary>
        ''' Connects to another NetCode Library.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub [Connect](ByVal IP As String)
            'Check to see if we're disposed
            If Disposed Then
                Throw New ObjectDisposedException("NetCode.Net", "You cannot access a disposed object!")
            End If
            'If we aren't in a connection attempt, not connected, and that the IP is valid.
            If Not Me.IsConnecting AndAlso Not Me.Connected AndAlso Me.IsIPv4(IP) AndAlso Not Me.IsListening Then
                'Create a new Client
                _connector = New Sockets.TcpClient()
                'Set the internal IP
                _ip = IP
                'Set that we are connecting.
                _connecting = True
                'Begin a connection.
                _connector.BeginConnect(_ip, Me.Port, New AsyncCallback(AddressOf Me.OnConnectionAttempt), Nothing)
            ElseIf Not Me.IsIPv4(IP) Then
                Throw New NetCode.NetException(Environment.StackTrace, String.Format("The IP address provided ({0}) is not valid!", IP))
            End If
        End Sub

        ''' <summary>
        ''' Safely disconnects from another NetCode Library.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub [Disconnect](Optional ByVal SendRequest As Boolean = True)
            'Check to see if we're disposed
            If Disposed Then
                Throw New ObjectDisposedException("NetCode.Net", "You cannot access a disposed object!")
            End If
            'Make sure we are connected.
            If Me.Connected Then
                'Start a disconnection request.
                If SendRequest Then Me.ObjectSender(New InternalStructure With {.Disconnect = True})
                _connector.Client.BeginDisconnect(False, New AsyncCallback(AddressOf Me.OnSafeDisconnect), Nothing)
            End If
        End Sub

        ''' <summary>
        ''' Returns the External IP of the client.
        ''' </summary>
        ''' <returns>The IP Address of the client.</returns>
        ''' <remarks>This is used for trading and battling.</remarks>
        Public Function GetExternalIP() As String
            Try
                Return New StreamReader(HttpWebRequest.Create("http://whatismyip.com/automation/n09230945.asp").GetResponse().GetResponseStream()).ReadToEnd
            Catch
                Return String.Empty
            End Try
        End Function

        ''' <summary>
        ''' Checks to see if the given IP is a proper IP address.
        ''' </summary>
        ''' <param name="ip">The IP Address to check.</param>
        ''' <returns>A True or False Boolean Value.</returns>
        ''' <remarks>Yay for regular expressions.</remarks>
        Public Function IsIPv4(ByVal ip As String) As Boolean
            Dim rIP As Regex = New Regex("^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$")
            Return rIP.IsMatch(ip)
        End Function

        ''' <summary>
        ''' Listens for messages.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub MessageListener()
            Do While Not Disposed
                Try
                    'Read the stream.
                    Dim obj As Object = New Binary.BinaryFormatter().Deserialize(_connector.GetStream)
                    'Pass the object.
                    Dim tr As New System.Threading.Thread(New Threading.ParameterizedThreadStart(AddressOf MessageHandler))
                    'Spin off the thread.
                    tr.Start(obj)
                Catch se As Sockets.SocketException
                    'The socket has closed, raise an error.
                    Me.OnConnectionError(se)
                    'Exit Do
                Catch se As Runtime.Serialization.SerializationException
                    'Could be some bad data, raise an error.
                    Me.OnConnectionError(se)
                    'Exit Do
                Catch tae As Threading.ThreadAbortException
                    'Me.OnConnectionError(tae)
                    Exit Do
                End Try
            Loop
        End Sub

        ''' <summary>
        ''' Asynchronously called to pass an object up to the event.
        ''' </summary>
        ''' <param name="obj">The object to pass up.</param>
        ''' <remarks></remarks>
        Private Sub MessageHandler(ByVal obj As Object)
            'If we got an internal message, handle it.
            If obj.GetType Is GetType(InternalStructure) Then
                'It's a disconnect request, do the disconnect dance.
                If CType(obj, InternalStructure).Disconnect Then Me.Disconnect(False)
            Else
                'It's not internal, raise event.
                Call Me.OnIncomingMessage(obj)
            End If
        End Sub

        ''' <summary>
        ''' Sends a binary chunk across the stream.
        ''' </summary>
        ''' <param name="obj">The object to serialize and send.</param>
        ''' <remarks></remarks>
        Public Sub ObjectSender(ByVal obj As Object)
            'Lock the stream
            If Connected AndAlso Not Disposed Then
                Try
                    SyncLock _connector.GetStream
                        'Create the serializer.
                        Dim BS As New Binary.BinaryFormatter
                        'Send the data.
                        BS.Serialize(_connector.GetStream, obj)
                    End SyncLock
                Catch ex As IO.IOException
                    Me.OnConnectionError(ex)
                End Try
            ElseIf Disposed Then
                Throw New ObjectDisposedException("NetCode.Net", "You cannot access a disposed object!")
            End If
        End Sub

        ''' <summary>
        ''' Disposes of the NetCode Library and all the allotted resources.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Dispose() Implements IDisposable.Dispose
            If Not Disposed Then
                GC.SuppressFinalize(Me)
                _listening = Nothing
                _connecting = Nothing
                _connected = Nothing
                _ip = Nothing
                _connector.Client.Close()
                _connector.Close()
                _listener.Server.Close()
                _readerThread.Abort()
                _disposed = True
                GC.Collect()
            End If
        End Sub

        ''' <summary>
        ''' Returns the String Representation of the connection.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String

            'If we're connected, return that we are connected and to what IP.
            If Connected Then
                Return String.Format("Connected to IP: {0}", GetIPFromClient(Me._connector))
            End If

            'If we're listening, return that we're waiting for an incoming connection.
            If IsListening Then
                Return String.Format("Waiting for an incoming connection.")
            End If

            'If, in the rare event, we're doing a connection attempt and a .ToString() is called, I want this covered as well
            If IsConnecting Then
                Return String.Format("Attempting to connect...")
            End If

            'If none of the above conditions are satisfied, do this.
            Return "System.NetCode.Net Class, waiting for instructions."

        End Function

        ''' <summary>
        ''' Internal data struture used for the NetCode system.
        ''' </summary>
        ''' <remarks></remarks>
        <Serializable()> _
        Private Structure InternalStructure
            Public Property Disconnect As Boolean
        End Structure

        ''' <summary>
        ''' Returns the IP address of the client passed to it.
        ''' </summary>
        ''' <param name="client">The Sockets.TcpClient to retrieve the IP address from.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetIPFromClient(ByRef client As Sockets.TcpClient) As String
            Dim ipend As IPEndPoint = CType(client.Client.RemoteEndPoint, IPEndPoint)
            If Not ipend Is Nothing Then Return ipend.Address.ToString Else Return String.Empty
        End Function

#End Region

    End Class

    ''' <summary>
    ''' Exception class.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class NetException
        Inherits Exception

        Private _stackTrace As String = String.Empty
        Private _error As String = String.Empty

        ''' <summary>
        ''' Returns the StackTrace of the exception.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads ReadOnly Property StackTrace As String
            Get
                Return _stackTrace
            End Get
        End Property

        ''' <summary>
        ''' Returns any supplied error message.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ErrorMessage As String
            Get
                Return _error
            End Get
        End Property

        ''' <summary>
        ''' Creates a New Instance of the NetException Class.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' Creates a New Instance of the NetException Class.
        ''' </summary>
        ''' <param name="Stack">The StackTrace.</param>
        ''' <param name="ErrorMsg">Error Message.</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal Stack As String, ByVal ErrorMsg As String)
            _stackTrace = Stack
            _error = ErrorMsg
        End Sub

        ''' <summary>
        ''' Returns the String representation of the NetCode.NetException Class.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return String.Format("NetCode Exception: {0}{1}{2}", ErrorMessage, Environment.NewLine, StackTrace)
        End Function

    End Class

End Namespace

Namespace Systems

    ''' <summary>
    ''' The battling class!
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Battling
        Private WithEvents _opponent As New NetCode.Net()
        Private OpponentData As BattleData


#Region "Properties"

        ''' <summary>
        ''' Returns if this battle class has an active connection.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Active As Boolean
            Get
                Return _opponent.Connected
            End Get
        End Property

#End Region

        ''' <summary>
        ''' Internal Battle Data structure.
        ''' </summary>
        ''' <remarks></remarks>
        Private Structure BattleData

        End Structure

        ''' <summary>
        ''' Creates a new instance of the Battling System.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' Creates a new instance of the Battling System with an already established connection.
        ''' </summary>
        ''' <param name="Opponent"></param>
        ''' <remarks></remarks>
        Public Sub New(ByRef Opponent As NetCode.Net)
            _opponent = Opponent
        End Sub

        Private Sub ConnectionClosed(ByVal sender As Object) Handles _opponent.ConnectionClosed

        End Sub

        Private Sub ConnectionError(ByVal sender As Object, ByVal exception As System.Exception) Handles _opponent.ConnectionError

        End Sub

        Private Sub ConnectionEstablished(ByVal sender As Object) Handles _opponent.ConnectionEstablished

        End Sub

        Private Sub IncomingMessage(ByVal sender As Object, ByVal message As Object) Handles _opponent.IncomingMessage

        End Sub

    End Class

    ''' <summary>
    ''' Trading class for trading between two people.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Trading

    End Class

End Namespace