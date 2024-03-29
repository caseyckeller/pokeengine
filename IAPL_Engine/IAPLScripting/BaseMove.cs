﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//These are for scripting
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace IAPL.Moves
{
    /// <summary>
    /// This is a base move, it stores basic information for a move. PP will be stored in an ActiveMove class and will be aggregated by the pokemon
    /// </summary>
    [Serializable]
    public class BaseMove
    {
        public String name;
        public String description;
        public int power;
        public int accuracy;
        public String moveType; //Move type - Fire, Fighting, etc, also used for STAB
        public String moveKind; //Physical, Special, or Status
        public int basePP;

        //TODO find out if this class needs a way to track volatile status effects (confustion, perish song, etc)

        /// <summary>
        /// Creates an instance of a move given all the parameters
        /// </summary>
        /// <param name="name">Name of the move</param>
        /// <param name="description">Short description of the move</param>
        /// <param name="power">power of the move (ususally multiples of 5)</param>
        /// <param name="accuracy">accuracy of the move (between 30 and 100 usually), -1 for NA</param>
        /// <param name="moveType">Type of move - Fire, Water, Ghost etc</param>
        /// <param name="moveKind">Kind of move - Physical, Special, or Status</param>
        /// <param name="basePP">Base PP of the move</param>
        public BaseMove(String name, String description, int power, int accuracy, String moveType, String moveKind, int basePP)
        {
            this.name = name;
            this.description = description;
            this.power = power;
            this.accuracy = accuracy;
            if (accuracy > 100) this.accuracy = 100;

            this.moveType = moveType;
            this.moveKind = moveKind;
            this.basePP = basePP;
        }

        /// <summary>
        /// Creates an instance of a move given all parameters except accuracy
        /// </summary>
        /// <param name="name">Name of the move</param>
        /// <param name="description">Short description of the move</param>
        /// <param name="power">power of the move (ususally multiples of 5)</param>
        /// <param name="moveType">Type of move - Fire, Water, Ghost etc</param>
        /// <param name="moveKind">Kind of move - Physical, Special, or Status</param>
        /// <param name="basePP">Base PP of the move</param>
        public BaseMove(String name, String description, int power, String moveType, String moveKind, int basePP)
        {
            this.name = name;
            this.description = description;
            this.power = power;
            this.accuracy = -1;
            if (accuracy > 100) this.accuracy = 100;

            this.moveType = moveType;
            this.moveKind = moveKind;
            this.basePP = basePP;
        }
    }
}
