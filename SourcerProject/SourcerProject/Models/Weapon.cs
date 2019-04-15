using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourcerProject.Models
{
    public class Weapon : GameItem
    {
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        

        public Weapon(int id, string name, int value, int minDamage, int maxDamage, string description, int experiencePoints)
            : base(id, name, value, description, experiencePoints)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
           
        }
    }
}
