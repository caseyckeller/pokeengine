Imports System.Runtime.Serialization.Formatters
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions

Namespace GameData

    ''' <summary>
    ''' Serialization class, need to test.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Serialization

        ''' <summary>
        ''' Saves a Trainer.
        ''' </summary>
        ''' <param name="trainer">The Trainer Data to save.</param>
        ''' <param name="location">The FOLDER where the save file is to be placed.</param>
        ''' <remarks></remarks>
        Public Sub SaveTrainer(ByVal trainer As Trainer, ByVal location As String)

            'Create Serializer, of the type Trainer.
            Dim Saver As New Binary.BinaryFormatter

            'Check the directory.
            If Directory.Exists(location) Then
                'Save the file
                Saver.Serialize(New FileStream(Path.Combine(
                                       location,
                                       String.Format("{0}.tr", trainer.TrainerName)),
                                       IO.FileMode.Create,
                                       IO.FileAccess.ReadWrite),
                                       trainer)
            End If
        End Sub

        ''' <summary>
        ''' Loads a Trainer into a Trainer Object.
        ''' </summary>
        ''' <param name="trainer">The trainer to load into.</param>
        ''' <param name="location">The location of the trainer file.</param>
        ''' <remarks></remarks>
        Public Sub LoadTrainer(ByRef trainer As Trainer, ByVal location As String)
            If File.Exists(location) Then

                Dim Loader As New Binary.BinaryFormatter
                trainer = CType(Loader.Deserialize(New FileStream(location, IO.FileMode.Open)), Trainer)

            End If
        End Sub

    End Class

    ''' <summary>
    ''' Trainer Class, still need to fill this in.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> Public Class Trainer

        Public Property TrainerName As String = String.Empty

        Public Property ID As Integer = 0I

        Public Property SID As Integer = 0I

        Public PartyPokemon As New List(Of Pokemon)

        Public Property PokemonBoxes As New List(Of Boxes) With {.Capacity = 30I}

    End Class

    ''' <summary>
    ''' PC Box class, still need to do this!
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> Public Class Boxes

        Public Property Name As String = String.Empty

        Public Property Pokemon As List(Of Pokemon)

    End Class

    ''' <summary>
    ''' Generic Pokemon class, still need to do this!
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> Public Class Pokemon
        Public Property Name As String = String.Empty
    End Class

End Namespace

Namespace NetCode

    ''' <summary>
    ''' Base Networking class. Needs to be tested still.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Net
        Implements IDisposable


#Region "Properties"

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
        Public ReadOnly Property Connecting As Boolean
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
        Public ReadOnly Property Listening As Boolean
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
            RaiseEvent ConnectionClosed()

            'We are no longer connected!
            _connected = False
            _connecting = False

            'Stop the listener if listening.
            If Listening Then _listener.Server.Close()
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
            RaiseEvent ConnectionEstablished()

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
            RaiseEvent ConnectionError(exception)

            'Not connected to much of anything.
            _connected = False

            'Stop listening
            If Listening Then _listener.Server.Close()
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
            RaiseEvent IncomingMessage(message)
        End Sub

#End Region

#Region "Events"

        Public Event ConnectionEstablished()
        Public Event ConnectionError(ByVal exception As Exception)
        Public Event ConnectionClosed()
        Public Event IncomingMessage(ByVal message As Object)

#End Region

#Region "Variables"

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
            'If we are not listening already, connected to someone else, or in the process of connecting.
            If Not Me.Listening AndAlso Not Me.Connected AndAlso Not Me.Connecting Then
                'Set that we are listening.
                _listening = True
                'Create the Listener.
                _listener = New Sockets.TcpListener(System.Net.IPAddress.Any, Me.Port)
                'Start the Listener.
                _listener.Start()
                'Create the Async acceptor.
                _listener.BeginAcceptTcpClient(New AsyncCallback(AddressOf Me.OnIncomingConnectionAttempt), _listener)
            Else
                'Debug line.
                Debug.WriteLine(String.Format("Listening: {0}, Connected: {0}, Connecting: {0}", Me.Listening, Me.Connected, Me.Connecting))
            End If
        End Sub

        ''' <summary>
        ''' Stops listening for an incoming connection.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub [StopListen]()
            'If the listener is active.
            If Me.Listening Then
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
            'If we aren't in a connection attempt, not connected, and that the IP is valid.
            If Not Me.Connecting AndAlso Not Me.Connected AndAlso Me.IsIPv4(IP) AndAlso Not Me.Listening Then
                'Create a new Client
                _connector = New Sockets.TcpClient()
                'Set the internal IP
                _ip = IP
                'Set that we are connecting.
                _connecting = True
                'Begin a connection.
                _connector.BeginConnect(_ip, Me.Port, New AsyncCallback(AddressOf Me.OnConnectionAttempt), Nothing)
            Else
                Debug.WriteLine("Connection attempt denied")
            End If
        End Sub

        ''' <summary>
        ''' Safely disconnects from another NetCode Library.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub [Disconnect](Optional ByVal SendRequest As Boolean = True)
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
            Do
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
            If Connected Then
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
            End If
        End Sub

#End Region

        ''' <summary>
        ''' Disposes of the NetCode Library and all the allotted resources.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Dispose() Implements IDisposable.Dispose
            _listening = Nothing
            _connecting = Nothing
            _connected = Nothing
            _ip = Nothing
            _connector.Client.Close()
            _connector.Close()
            _listener.Server.Close()
            _readerThread.Abort()
        End Sub

        <Serializable()> _
        Public Structure InternalStructure
            Public Property Disconnect As Boolean
        End Structure
        
    End Class

End Namespace