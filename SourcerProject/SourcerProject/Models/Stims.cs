using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourcerProject.Models
{
    public class Stims : GameItem
    {
        public enum UseActionType
        {
           INCREASEBASEHEALTH,
           USEITEM


        }
        public int PlusHealth { get; set; }
        public int ReviveChip { get; set; }

        public Stims( int id, string name, int value, int plusHealth, int reviveChip, string description, int experiencePoints)
            : base(id, name, value, description, experiencePoints)
            {
            PlusHealth = plusHealth;
            ReviveChip = reviveChip;
            }
    }
}
