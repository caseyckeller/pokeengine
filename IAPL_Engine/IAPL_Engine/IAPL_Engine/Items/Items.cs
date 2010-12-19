//Let's try this again
//12/18/2010
//-bigplrbear
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAPL.itemlib
{
    public class items
    {
        /*
         * Contains global variables and functions.
         * All classes inherit this class.
         */
        public bool did_it_work(byte a)
        {
            if (a == 1)
            {
                return false;
            }

            if (a == 0)
            {
                return true;
            }

            if (a == null)
            {
                return true;
            }

            return false;
        }

        public class heal : items
        {
            public class potion : items
            {


                public int potion(int max_hp, int current_hp)
                {
                    while (current_hp != 0 && current_hp != max_hp)
                    {
                        current_hp = current_hp + 20;

                        if (current_hp >= max_hp)
                        {
                            current_hp = max_hp;
                        }

                        did_it_work(0);
                        return current_hp;
                    }

                    did_it_work(1);
                    return current_hp;
                }

                public int superpotion(int max_hp, int current_hp)
                {
                    while (current_hp != 0 && current_hp != max_hp)
                    {
                        current_hp = current_hp + 50;

                        if (current_hp >= max_hp)
                        {
                            current_hp = max_hp;
                        }

                        did_it_work(0);
                        return current_hp;
                    }

                    did_it_work(1);
                    return current_hp;
                }

            }


        }

        public class hold : items
        {
            public class battleitems : items
            {
            }

            public class overworlditems : items
            {
            }
        }

        public class keyitems : items
        {
        }

        public class berries : items
        {
            public class statusheal : items
            {
            }

            public class hpheal : items
            {
            }
        }

        public class balls : items
        {
            public class apricorns : items
            {
            }
        }

        public class stones : items
        {
        }

        public class otheritems : items
        {
            public class statenhancers : items
            {
            }

            public class repel : items
            {
            }

            public class legendaryitems : items
            {
            }
        }


    }
}