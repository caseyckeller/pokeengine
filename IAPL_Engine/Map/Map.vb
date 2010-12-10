
''' <summary>
''' Main mapping format. The mapping format consists of a collection of layers, each having a single Tile class. The tile class contains a list
''' of individual tiles that stores the physical data that will be used in the mapping format. The format itself does not store images, those
''' are left outside the format to keep sizes down.
''' 
''' The format does store scripting paths, as well as where the script is located on the map in an X,Y coordinate fashion. This allows the map
''' format to be semi-portable and compact, storing only paths to other places instead of keeping it all internal. This is subject to change
''' at any given time.
''' </summary>
''' <remarks></remarks>
''' 
<Serializable()> _
Public Class Map
    Inherits System.Collections.ObjectModel.Collection(Of Layer)

    'Map Properties

    ''' <summary>
    ''' Gets or Sets the name of the map.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Name As String = String.Empty

    ''' <summary>
    ''' Saves a map to file.
    ''' </summary>
    ''' <param name="filepath">The filepath to save at.</param>
    ''' <remarks></remarks>
    Public Sub Save(ByVal filepath As String)

        'Create the stream.
        Dim _fs As New IO.FileStream(filepath, IO.FileMode.Create)

        'Create the saver.
        Dim _saver As New Runtime.Serialization.Formatters.Binary.BinaryFormatter

        'Save
        _saver.Serialize(_fs, Me)

        'Close filestream
        _fs.Close()

    End Sub

    ''' <summary>
    ''' Returns the number of layers this map has.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Function Count() As Integer
        Return Me.Items.Count
    End Function

    ''' <summary>
    ''' Loads a map from file.
    ''' </summary>
    ''' <param name="file">The location of the file.</param>
    ''' <remarks></remarks>
    Public Sub Load(ByVal file As String)

        Try

            'Make sure the file exists
            If IO.File.Exists(file) Then

                'Create the filestream to open it.
                Dim _fs As New IO.FileStream(file, IO.FileMode.Open)

                'Create the Loader
                Dim _loader As New Runtime.Serialization.Formatters.Binary.BinaryFormatter

                'Load the data to an object
                Dim _obj As Object = _loader.Deserialize(_fs)

                'Close the filestream
                _fs.Close()

                'Convert it
                Dim _map As Map = CType(_obj, Map)

                'Set the name
                Me.Name = _map.Name

                'Clear all the current layers.
                Me.Clear()

                'Add them back.
                For Each _layer As Layer In _map.Items
                    Me.Items.Add(_layer)
                Next

            End If

        Catch ex As Runtime.Serialization.SerializationException
            'Bad file load.
        Catch ex As Exception
            'Bad conversion probably. Not a valid file.
        End Try

    End Sub

End Class