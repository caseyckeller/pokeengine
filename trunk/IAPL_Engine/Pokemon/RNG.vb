Public Class RNG
    Implements IDisposable

    'Variables
    Private _rand As Random
    Private _rand2 As Random
    Private _seeds As List(Of Double)
    Private _dispose As Boolean = False
    Private _regen As System.Threading.Thread

    ''' <summary>
    ''' Gets or Sets the seeds that the RNG uses.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Seeds As List(Of Double)
        Get
            Return _seeds
        End Get
        Set(ByVal value As List(Of Double))
            _seeds = value
        End Set
    End Property

    ''' <summary>
    ''' Seeds the RNG's
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SeedGenerators()

        'Take a few random variables from the array list
        Dim _tempRNG As New Random(Date.Now.Millisecond)

        'Reseed the initial generator.
        _tempRNG = New Random(Date.Now.Millisecond + _tempRNG.Next(1, 500) + Date.Now.Second * _tempRNG.Next(0, 400))

        'Grab a random value
        Dim _randomVal As Double = GetRandomSeed(_tempRNG)

        'Seed one of the RNG's
        _rand = New Random(CInt(Math.Abs(Math.Pow(_tempRNG.Next(1, 5), Math.Log(_randomVal)) + GetRandomSeed(_tempRNG))))

        'RNG seeded, seed the next one.
        _rand2 = New Random(CInt(Factoral(_rand.Next(0, 5)) + GetRandomSeed(_tempRNG)))

    End Sub

    ''' <summary>
    ''' Seeds the RNG's
    ''' </summary>
    ''' <param name="randomNumber">Pass in a number that will be used in seeding the initial generator.</param>
    ''' <remarks></remarks>
    Private Sub SeedGenerators(ByVal randomNumber As Integer)

        'Create the initial Random Number Generator.
        Dim _iRNG As New Random(Date.Now.Millisecond + randomNumber)

        'Create a temporary array to hold some other numbers.
        Dim _list As New List(Of Integer)

        'Grab a random number
        Dim _randomVal As Double = GetRandomSeed(_iRNG)

        'Combine the two numbers
        Dim _newNumber As Double = randomNumber * Math.Pow(randomNumber / 2, Math.E ^ (Math.Round((_randomVal / 16) + 1, 0)))

        'Reseed the initial RNG
        _iRNG = New Random(CInt(Date.Now.Millisecond + _iRNG.Next(1, 501)))

    End Sub

    ''' <summary>
    ''' Seeds the RNG's
    ''' </summary>
    ''' <param name="seedList">A list of random numbers to use.</param>
    ''' <remarks></remarks>
    Private Sub SeedGenerators(ByVal seedList As List(Of Integer))

        'Seed the initial generator
        Dim _iRNG As New Random(Date.Now.Second * seedList(If(seedList(_rand.Next(0, seedList.Count - 1)) > 1000, _rand.Next(0, seedList.Count), _rand2.Next(0, seedList.Count))))

        'Remove a few seeds from the seed list.
        _seeds.RemoveRange(0, _iRNG.Next(1, _seeds.Count - 1))

        'Add a few seeds to the global seed list.
        For i As Integer = 0 To _iRNG.Next(5, 11)

            'Add them to the list
            _seeds.Add(_iRNG.Next(1, _iRNG.Next(2, 80)))

        Next

        'Reseed the main generators? Flip a coin to find out.
        Dim _coin As Integer = _iRNG.Next(1)

        'See if it's 'heads'
        If _coin.Equals(0I) Then

            'Reseed them.
            _rand = New Random(CInt(Math.Pow(2, _iRNG.Next(4, _rand.Next(5, 11))) / 2))
            _rand2 = New Random(CInt(GetRandomSeed(_rand2) * Math.Exp(_iRNG.Next(0, _rand.Next(3, _rand2.Next(5, 14))))))

        End If

    End Sub

    ''' <summary>
    ''' Generates a new RNG
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        'We are not disposed
        _dispose = False

        'We don't have our own list to start out with. We're gonna have to make our own. >.<
        Dim _rnd As New Random(Date.Now.Millisecond * Math.Abs((Date.Now.Year - (Date.Now.Month + Date.Now.Hour))))

        'OK, now should I reseed myself? Fuck it I don't care. Give me 100 numbers randomly.
        For i As Integer = 1 To 100
            Dim _num As Integer = _rnd.Next(3, 100I)
            _seeds.Add(If(_num < 30, Factoral(_num), _num))
        Next

        'Get the Generators ready.
        Me.SeedGenerators()

        'Everything seeded, start the thread that reseeds everything.
        _regen = New System.Threading.Thread(AddressOf Me.ConstantRNG) With {.IsBackground = True}
        _regen.Start()

    End Sub

    ''' <summary>
    ''' Generates a new RNG
    ''' </summary>
    ''' <param name="_arr">The List(Of Double) to use in the seed determination.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _arr As List(Of Double))

        'We are not disposed
        _dispose = False

        'Take a few random variables from the array list
        Dim _tempRNG As New Random(Date.Now.Millisecond)

        'See if the List is empty.
        If _arr.Count.Equals(0) Then

            'Well that's freaking lovely. We need some bullshit data.
            For i As Integer = 1 To 50
                _arr.Add(_tempRNG.Next(1, 900))
            Next

        End If

        'Assign the seeds to use for later
        _seeds = _arr

        'Get the Generators ready.
        Me.SeedGenerators()

        'Everything seeded, start the thread that reseeds everything.
        _regen = New System.Threading.Thread(AddressOf Me.ConstantRNG) With {.IsBackground = True}
        _regen.Start()

    End Sub

    ''' <summary>
    ''' Gets the next number.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Advance() As Double

        'Throw an ObjectDisposedException if we have been disposed.
        If _dispose Then Throw New ObjectDisposedException("RNG")

        'Get another Random object.
        Dim _rand3 As New Random(_rand.Next(1, 16) * _rand.Next(1, 5) + _rand2.Next(32, 100))

        'Determine a number.
        Dim _number As Double = (Math.E ^ _rand3.Next(0, 13)) / Math.Round(Math.Sqrt(GetRandomSeed(_rand3)) * 100)

        'DEBUG
        Debug.WriteLine(String.Format("Number 1: {0}", _number))

        'Get another number.
        Dim _number2 As Double = Math.Round(Math.Log(GetRandomSeed(_rand2)) + _rand3.Next(0, CInt(GetRandomSeed(_rand) + 1)), 0)

        'DEBUG
        Debug.WriteLine(String.Format("Number 2: {0}", _number2))

        'Perform modifications.
        _number = Math.Pow(_number, _rand.Next(_rand3.Next(1, 4), _rand2.Next(3, 5)) / _rand.Next(1, 5))

        'DEBUG
        Debug.WriteLine(String.Format("Number 1: {0}", _number))

        'Return
        Return Math.Abs(Math.Round(_number, 0) * _rand.Next(2, _rand3.Next(4, 8)) - _number2)

    End Function

    ''' <summary>
    ''' Gets the next number with the specified bounds.
    ''' </summary>
    ''' <param name="min">The minimum value that the number can be.</param>
    ''' <param name="max">The maximum value that the number can be.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Advance(ByVal min As Integer, ByVal max As Integer) As Double

        'Throw an ObjectDisposedException if we have been disposed.
        If _dispose Then Throw New ObjectDisposedException("RNG")

        'If the minimum is lower then the maximum.
        If min < max Then

            'Get another Random object.
            Dim _rand3 As New Random(CInt((_rand.Next(1, 16) + _rand2.Next(32, 52)) / (GetRandomSeed(_rand) / 2)))

            'Seed it again
            _rand3 = New Random(CInt(_rand.Next(15, 300) / _rand3.Next(2, 9)))
            _rand3 = New Random(CInt(GetRandomSeed(_rand3) + Math.E ^ _rand3.Next(1, _rand.Next(1, 20))))

            'Return a new value.
            Return _rand3.Next(min, max + 1)

        Else

            'Throw an error
            Throw New ArgumentException(String.Format("{0} is not less then {1}!", min, max), min.ToString)

        End If

    End Function

    ''' <summary>
    ''' Gets a List of random numbers with the specified bounds.
    ''' </summary>
    ''' <param name="min">The minimum value that the number can be.</param>
    ''' <param name="max">The maximum value that the number can be.</param>
    ''' <param name="count">The length of the list of numbers.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AdvanceRange(ByVal min As Integer, ByVal max As Integer, ByVal count As Integer) As List(Of Double)

        'Create the return list
        Dim _list As New List(Of Double)

        'Setup a loop to generate the numbers!
        For i As Integer = 1 To count
            _list.Add(Me.Advance(min, max))
        Next

        'Return the list
        Return _list

    End Function

    ''' <summary>
    ''' Returns a Random object.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetRandom() As Random

        'Create a new random.
        Dim _random As New Random(CInt(Date.Now.Ticks / (Date.Now.Millisecond / 8)))

        'Find out what number was selected.
        Select Case _random.Next(1, 4)
            Case 1
                Return _rand
            Case 2
                Return _rand2
            Case Else
                Return _random
        End Select

    End Function

    ''' <summary>
    ''' Gets a random seed.
    ''' </summary>
    ''' <param name="rnd">The Random Number Generator to use.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetRandomSeed(ByVal rnd As Random) As Double

        Try

            'Return a Random value from the seed list.
            Return _seeds(rnd.Next(0, _seeds.Count - 1))

        Catch ex As ArgumentOutOfRangeException

            'ERROR
            Return rnd.Next(0, 5000)

        End Try

    End Function

    ''' <summary>
    ''' Performs a factoral operation on a number.
    ''' </summary>
    ''' <param name="start">The beginning number.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Factoral(ByVal start As Integer) As Double

        'Create the return value.
        Dim _retVal As Double = 1

        'Setup the for loop
        For i As Integer = start To 1 Step -1

            'Multiply the return value by the term.
            _retVal *= i

        Next

        'Return it.
        Return _retVal

    End Function

    ''' <summary>
    ''' Runs on a background thread to constantly reseed the Random Number Generators.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ConstantRNG()

        'Infinitely loop this.
        Do
            'Rest anywhere from 10 to 52 seconds before doing this.
            System.Threading.Thread.Sleep(_rand.Next(10000, 52001))

            'Debug
            Debug.WriteLine("Beginning to re-seed the RNG. Method being selected.")

            'Setup a try to catch any thread exceptions.
            Try

                'Generate a number between 1 and 3
                Dim _number As Integer = CInt(Me.Advance(1, 3))

                'Figure out what method to use.
                Select Case _number

                    Case 1I
                        Debug.WriteLine("Method 1 was selected.")
                        'Method one; same method used when the system is initialized.
                        Me.SeedGenerators()

                    Case 2I
                        Debug.WriteLine("Method 2 was selected.")
                        'Method two; alternate method.
                        Me.SeedGenerators(_rand.Next(501))

                    Case 3
                        'Method three; generates new seeders and RNG's
                        Debug.WriteLine("Method 3 was selected.")
                        'Create a new List of random values.
                        Dim _seeds As New List(Of Integer)
                        For i As Integer = 0 To _rand.Next(8, 50)
                            _seeds.Add(_rand.Next(1, 2000))
                        Next

                        'Call method three.
                        Me.SeedGenerators(_seeds)

                End Select

                Debug.WriteLine("The RNG has been re-seeded!")

                'Catch that exception!
            Catch tae As Threading.ThreadAbortException

                'Write out the debug information.
                Debug.WriteLine(tae.ExceptionState.ToString)

                'Exit the Do Loop
                Exit Do

            End Try

        Loop

    End Sub

    ''' <summary>
    ''' Disposes the RNG
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Dispose() Implements IDisposable.Dispose

        'Set the internal flag to true
        _dispose = True

        'Abort the thread.
        _regen.Abort("Disposing the Thread")

        'Set the generators to nothing.
        _rand = Nothing
        _rand2 = Nothing

        'Clear the seeds list
        _seeds.Clear()

        'Force a garbage collection
        GC.Collect()

    End Sub

End Class