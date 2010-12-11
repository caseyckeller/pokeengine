using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IAPL.Moves;


namespace IAPL.Moves
{
    /// <summary>
    /// This is a list which holds every move
    /// There is an add method which allows more moves to be created
    /// NOTE: SortedList IS AWESOMESAUCE!!!
    /// </summary>
    [Serializable]
    class MoveList
    {
        public SortedList<string, BaseMove> move;
        public int numberOfMoves
        {
            get { return move.Count; }
        }

        public MoveList()
        {
            //Keys for moves are always in upper case, this is automatic
            move = new SortedList<string, BaseMove>();
        }

        /// <summary>
        /// Adds the specified base more to the move list
        /// NOTE: Will overwrite any move with the same name
        /// </summary>
        /// <param name="newMove">instance of base move</param>
        public void addMove( BaseMove newMove)
        {
            
            try
            {
                move.Add(newMove.name.ToUpper(), newMove);
            }
            catch (ArgumentException)
            {
                move.Remove(newMove.name.ToUpper());
                move.Add(newMove.name.ToUpper(), newMove);
            }
        }

        /// <summary>
        /// returns a BaseMove object from the list with the given name
        /// </summary>
        /// <param name="moveName">string containing move name you wish to find</param>
        /// <returns>BaseMove OR null if unsuccessful</returns>
        public BaseMove getMove( String moveName)
        {
            BaseMove temp = null;
            if (move.ContainsKey(moveName.ToUpper()))
            {
                temp = move[moveName.ToUpper()];
            }
            return temp;
        }

        /// <summary>
        /// Removes a move with the specified name
        /// </summary>
        /// <param name="moveName">string of the move's name</param>
        public void removeMove(String moveName)
        {
            if(move.ContainsKey(moveName.ToUpper()))
                move.Remove(moveName.ToUpper());
        }

        /// <summary>
        /// Removes the specified Base move
        /// </summary>
        /// <param name="moveName">Basemove you wish to remove</param>
        public void removeMove(BaseMove inMove)
        {
            if (move.ContainsKey(inMove.name.ToUpper()))
                move.Remove(inMove.name.ToUpper());
        }
    }
}
