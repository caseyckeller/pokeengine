''' <summary>
''' The data that each tile holds
''' </summary>
''' <remarks></remarks>
''' 
<Serializable()> _
Public Structure IndividualTile

    ''' <summary>
    ''' Gets or Sets the location of the 32 x 32 tile image of the Tile.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImagePath As String

    ''' <summary>
    ''' Gets or Sets if the tile is passable.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Passable As Boolean

    ''' <summary>
    ''' Gets or Sets the location of the tile on the map.
    ''' Note: These points should be divisible by 32!
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Location As System.Drawing.Point

    ''' <summary>
    ''' Gets or Sets if the tile is occupied by the player or NPC.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Occupied As Boolean

    ''' <summary>
    ''' Gets or Sets if the tile is jumpable.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Jumpable As Boolean

    ''' <summary>
    ''' Gets or Sets if the tile is a bike only tile.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Bike As Boolean

    ''' <summary>
    ''' Gets or Sets the direction(s) the tile can be passable from.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property aDirection As aFrom

    ''' <summary>
    ''' Compares this tile with the passed one to see if they are the same.
    ''' </summary>
    ''' <param name="obj">The object to compare it to</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function Equals(ByVal obj As Object) As Boolean

        If TypeOf obj Is IndividualTile Then

            Dim _tile As IndividualTile = CType(obj, IndividualTile)

            With _tile
                Return .aDirection.Equals(Me.aDirection) AndAlso
                    .Bike.Equals(Me.Bike) AndAlso
                    .ImagePath.Equals(Me.ImagePath) AndAlso
                    .Jumpable.Equals(Me.Jumpable) AndAlso
                    .Location.Equals(Me.Location) AndAlso
                    .Occupied.Equals(Me.Occupied) AndAlso
                    .Passable.Equals(Me.Passable)
            End With


        End If
        Return False
    End Function

    ''' <summary>
    ''' Creates a new Individual Tile.
    ''' </summary>
    ''' <param name="IC">Discarded dummy data</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal IC As Boolean)

        ImagePath = String.Empty
        Passable = False
        Location = New Drawing.Point
        Occupied = False
        Jumpable = False
        Bike = False
        aDirection = New aFrom(True, True, True, True)

    End Sub

End Structure

''' <summary>
''' Allows greater customization of which direction a tile is passable from.
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Public Structure aFrom

    Public Property North As Boolean
    Public Property South As Boolean
    Public Property East As Boolean
    Public Property West As Boolean

    Public Sub New(ByVal n As Boolean, ByVal s As Boolean, ByVal e As Boolean, ByVal w As Boolean)
        North = n
        South = s
        East = e
        West = w
    End Sub

    Public Overrides Function Equals(ByVal obj As Object) As Boolean

        If TypeOf obj Is aFrom Then

            Dim _obj As aFrom = CType(obj, aFrom)
            With _obj
                Return .North.Equals(Me.North) AndAlso .South.Equals(Me.South) AndAlso .East.Equals(Me.East) AndAlso .West = Me.West
            End With

        End If

        Return False

    End Function

End Structure

''' <summary>
''' The individual tiles of each map.
''' </summary>
''' <remarks></remarks>
''' 
<Serializable()> _
Public Class Tiles
    Inherits System.Collections.ObjectModel.Collection(Of IndividualTile)

    ''' <summary>
    ''' Returns a List of Tiles that lie within the specified X coordinate.
    ''' </summary>
    ''' <param name="x_coordinate">The X coordinate to look for.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTilesByX(ByVal x_coordinate As Integer) As List(Of IndividualTile)

        'Create the return list.
        Dim _tileList As New List(Of IndividualTile)

        'Setup a For Loop to get all the points
        For Each tile As IndividualTile In Me.Items

            'If the x coordinate is equal, add it.
            If tile.Location.X.Equals(x_coordinate) Then _tileList.Add(tile)

        Next

        'Return the list
        Return _tileList

    End Function

    ''' <summary>
    ''' Returns a List of Tiles that lie within the specified X coordinate.
    ''' </summary>
    ''' <param name="y_coordinate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTilesByY(ByVal y_coordinate As Integer) As List(Of IndividualTile)

        'Create the return list.
        Dim _tileList As New List(Of IndividualTile)

        'Setup a For Loop to get all the points
        For Each tile As IndividualTile In Me.Items

            'If the x coordinate is equal, add it.
            If tile.Location.Y.Equals(y_coordinate) Then _tileList.Add(tile)

        Next

        'Return the list
        Return _tileList

    End Function

    ''' <summary>
    ''' Returns a list of tiles that have the specified coordinate.
    ''' </summary>
    ''' <param name="coordinates">The coordinate to find.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTiles(ByVal coordinates As Drawing.Point) As List(Of IndividualTile)

        'Create the return list.
        Dim _tileList As New List(Of IndividualTile)

        'Setup a For Loop to get all the points
        For Each tile As IndividualTile In Me.Items

            'If the x coordinate is equal, add it.
            If tile.Location.Equals(coordinates) Then _tileList.Add(tile)

        Next

        'Return the list
        Return _tileList

    End Function

    ''' <summary>
    ''' Adds a new Tile to the system if it doesn't already exist.
    ''' </summary>
    ''' <param name="tile">The new tile to add.</param>
    ''' <remarks></remarks>
    Public Overloads Sub Add(ByVal tile As IndividualTile)

        'Make sure the tile location isn't already taken.
        If Me.GetTiles(tile.Location).Count.Equals(0I) Then

            'Add it
            Me.Items.Add(tile)

        End If


    End Sub

    ''' <summary>
    ''' Removes a tile based on it's coordinate.
    ''' </summary>
    ''' <param name="coordinate">The coordinate to remove.</param>
    ''' <remarks></remarks>
    Public Overloads Sub Remove(ByVal coordinate As Drawing.Point)

        'Since we should only have one, we can use the GetTiles() method
        'to get the actual tile rather then searching ourselves.
        Dim _tiles As List(Of IndividualTile) = Me.GetTiles(coordinate)

        'Now remove it.
        For Each tile As IndividualTile In _tiles

            'Remove!
            Me.Items.Remove(tile)

        Next

    End Sub

    ''' <summary>
    ''' Checks to see if a tile is passable from all directions
    ''' and has nobody inside it.
    ''' </summary>
    ''' <param name="tile">The tile to check.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TileClear(ByVal tile As IndividualTile) As Boolean

        Return Not tile.Occupied AndAlso tile.aDirection.Equals(New aFrom(True, True, True, True))

    End Function

    ''' <summary>
    ''' Returns the number of tiles the layer has.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Function Count() As Integer
        Return Me.Items.Count
    End Function

End Class

Public Enum TType
    Black = 0
    Grass
    Dirt
    Sand
    Brick
End Enum

Public Enum Direction
    North
    South
    East
    West
End Enum