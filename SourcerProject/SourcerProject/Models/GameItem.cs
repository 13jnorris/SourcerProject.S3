﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourcerProject.Models
{
    public class GameItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public string Description { get; set; }

        public int ExperiencePoints { get; set; }
        public string  UserMessage { get; set; }


        public GameItem(int id, string name, int value, string description, int experiencePoints, string userMessage = "")
        {
            Id = id;
            Name = name;
            Value = value;
            Description = description;
            ExperiencePoints = experiencePoints;
            UserMessage = userMessage;
        }

        public virtual string InformationString()
        {
            return $"{Name}: {Description}/n";
        }
    }
}
