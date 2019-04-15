using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourcerProject.Models
{
    class Credits : GameItem
    {
        public enum CreditType
        {
            Credit,
            CreditChip,
            CreditKey
        }

        public CreditType Type { get; set; }

        public Credits(int id, string name, int value, CreditType type, string description, int experiencePoints) 
            : base(id, name, value, description, experiencePoints)
        {
            Type = type;
        }
    }
}
