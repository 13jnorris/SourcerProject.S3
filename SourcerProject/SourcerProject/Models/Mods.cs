using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourcerProject.Models
{
    public class Mods : GameItem
    {
        public enum Mod
        {
            PullMod,
            PushMod,
            LiftMod,
            RiftMod
        }
        public Mod Type { get; set; }

        public Mods(int id, string name, int value, Mod type, string description, int experiencePoints) 
            : base(id, name, value, description, experiencePoints)
        {
            Type = type;
        }

    }
}
