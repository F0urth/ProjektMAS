using System;
using System.Collections.Generic;
using System.Text;


/**
  ******************
  * @author F0urth *
  ******************
  * @date - 5/6/2020 7:45:16 PM *
  ******************
**/

namespace MP_02.Logic
{
   public class ActorAddvertisment
    {
        public static ISet<ActorAddvertisment> Extent { get; }

        static ActorAddvertisment()
        {
            Extent = new HashSet<ActorAddvertisment>();
        }

        public Actor Actor { get; set; }
        public Addvertisment Addvertisment { get; set; }
        public decimal Salary { get; set; }

        public ActorAddvertisment(Actor actor, Addvertisment addvert, decimal salary)
        {
            (Actor, Addvertisment, Salary) = (actor, addvert, salary);
            Extent.Add(this);
        }
            
        
    }
}
