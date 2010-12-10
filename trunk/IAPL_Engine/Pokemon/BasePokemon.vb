''' <summary>
''' The Base Pokemon class is what the Pokemon class will
''' inherit upon the creation of a Pokemon. The Base Pokemon
''' class stores the basic information, such as base stats,
''' possible abilities, and the moves that the Pokemon can
''' learn. This information is passed on to the Pokemon class
''' and used throughout the game.
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Public Class BasePokemon

    ''' <summary>
    ''' Gets or Sets the Base Stats for this Pokemon.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BaseStats As New Stats



End Class

''' <summary>
''' Stores general stat information about a pokemon.
''' </summary>
''' <remarks></remarks>
''' 
<Serializable()> _
Public Class Stats

    Public Property Attack As Integer
    Public Property Defense As Integer
    Public Property Speed As Integer
    Public Property SpAtk As Integer
    Public Property SpDef As Integer
    Public Property HP As Integer

End Class