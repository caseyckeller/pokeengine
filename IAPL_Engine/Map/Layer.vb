
''' <summary>
''' Individul Layers of each map.
''' </summary>
''' <remarks></remarks>
''' 
<Serializable()> _
Public Class Layer

    'We just need one tile variable since the tile class inherits 
    'the collection of IndividualTiles that serves as our ground
    'layer for maps
    Private _tiles As New Tiles

    ''' <summary>
    ''' Returns the Tiles of this layer.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Tiles As Tiles
        Get
            Return _tiles
        End Get
    End Property

End Class