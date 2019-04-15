using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourcerProject.Models;
using System.Collections.ObjectModel;

namespace SourcerProject.DataLayer
{
    public class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                Name = "Deckard",
                Age = 24,
                Health = 100,
                Lives = 3,
                ExperiencePoints = 0,
                Inventory = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(0002), 1),
                        new GameItemQuantity(GameItemById(0003), 1),
                        new GameItemQuantity(GameItemById(1002), 2),
                        new GameItemQuantity(GameItemById(2001), 2)
                    },
                LocationId = 0
            };
        }

        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "\t The year is 2145 the human race has reached a level technology that allows them to shape reality itself,.....",
                "\t This event caused human beings to born with extraordinary abilites that were only achievable through technology before our story begins 24 years after that event..."
            };
        }
        public static Location StartingLocation()
        {
            return new Location()
            {
                Id = 1,
                Name = "Alpha Base",
                Description = "This is the first secret base of the Sourcer organization" +
                    "It was created by the Citium Organization which is in charge of managing, training, and monitoring all Sourcers. " +
                    "Not much is known about Citium but they managed to aquire all government contracts involved with Sourcers across the world.",
                Accessilbe = true
            };
        }

        public static Map GameMapData()
        {
            Map gameMap = new Map();
            gameMap.StandardGameItems = StandardGameItems();

            gameMap.Locations = new ObservableCollection<Location>
            {

            new Location()
               {
                       Id = 1,
                       Name = "Alpha Base",
                       Description = "This is the first secret base of the Sourcer organization" +
                    "It was created by the Citium Organization which is in charge of managing, training, and monitoring all Sourcers. " +
                    "Not much is known about Citium but they managed to aquire all government contracts involved with Sourcers across the world.",
                       Messages = "Talk to the commander for your mission briefing",
                       Accessilbe = true,
                       AddXP = 10
               },
            new Location()
                {
                    Id = 2,
                    Name = "Detroit, Michigan",
                    Description = "Detroit is quite different from what it was in the  early 21st century. The city that was  once considered a economic wasteland and crime" +
                    " running rampant. Detroit is now the economic model for cities accross the world. Detroit's turnaround can be creditied to Citium which bought large parts  of city and  " +
                    " turned it in science, technology, and research hub of the world. But don't let the glitz and glamor fool you. The old Detroit is still here and it's criminal organizitions are biding their time.",
                    Messages = "You need to find your contact for supplies. Some of the items can only be obtained from the contact other you can find along the way.",
                    Accessilbe = true,
                    GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(0001), 1),
                        new GameItemQuantity(GameItemById(1002), 2),
                        new GameItemQuantity(GameItemById(2001), 2)
                    },
                    AddXP = 12
                },
                new Location()
                {
                    Id = 3,
                    Name = "New York City, New York",
                    Description = "New York City has remained to be the best city in the world. It is the place to be if you want to become something in this world. A city that attracts that type of person tends to be a dangerous place. With all the glitz and glamor " +
                    "it attracts those who are willing to do just about anything in the world. ",
                    Messages = "Alright Deckard this is your first mission, you need to find those terrorist so the they don't disrupt the UN Summit on the Sourcer Event. If this mission goes smoothly we will be able to get a lot more contracts.",
                    Accessilbe = true,
                    AddXP = 12

                },
                new Location()
                {
                    Id = 4,
                    Name = "Los Angelos, California",
                    Description = "L.A. has seen better days, the city used to be a thriving metropolis. But now its a wasteland along with the rest of southwestern United States. LA was one of many cities that struggled with the climate shifting. " 
                    + "L.A. ran out of water towards the end of the 21st century, people still live there but not nearly as many. Living off of de-salnation plant that Citium has constructed. These plants are often targets of theft by the local population",
                    Accessilbe = true,
                    AddXP = 12

                },
                new Location()
                {
                    Id = 5,
                    Name = "Sao Paulo, Brazil",
                    Description = "Sao Paulo....",
                    Accessilbe = true,
                    GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(3001), 1),
                        new GameItemQuantity(GameItemById(0001), 1),
                        new GameItemQuantity(GameItemById(2001), 2),
                        new GameItemQuantity(GameItemById(1002), 2)

                    },
                    AddXP = 12
                },
                new Location()
                {
                    Id = 6,
                    Name = "London, England",
                    Description = "London",
                    Accessilbe = true,
                    GameItems = new ObservableCollection<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById(0004), 1),
                        new GameItemQuantity(GameItemById(2003),1),
                        new GameItemQuantity(GameItemById(3002),1)
                    },
                    AddXP = 12
                },
                new Location()
                {
                    Id = 20,
                    Name = "Citium Headquarters",
                    Description = "Final Location add description later",
                    RequiredXP = 58,
                    Accessilbe = true
                }
            };

            return gameMap; 
        }
        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
            new Weapon(0001, "Kukri", 40, 2, 5, "A weapon based on ancient design from India", 10),
            new Weapon(0002, "K-Bar", 25, 1, 3, "Standard issue U.S. Military knife", 0),
            new Weapon(0003, "M9 Beretta ", 60, 5, 9, "A normal handgun", 0),
            new Weapon(0004, "Astral Bow", 140, 5, 9, "This blends ancient technology with the cutting edge. It generates arrows out of thin air using a Sourcer's power", 50),
            new Credits(1001, "Credit Chip", 5, Credits.CreditType.Credit, "Standard credit chip", 1),
            new Credits(1002, "Credit Coin", 10, Credits.CreditType.CreditChip, "Credit Coins are based off of the crypto craze during the early 21st century, often reffered to as BitCoins to this day", 10),
            new Credits(1003, "Credit Key", 15, Credits.CreditType.CreditKey, "Used to unlock vaults at banks across the world, if find one of these you're in for a nice payday", 15),
            new Stims(2001, "Basic Stim", 5, 50, 0, "A basic medical application it wont bring back from the dead but it should help keep it away", 2),
            new Stims(2002, "Advanced Stim", 15, 100, 0, "Use when subject is near death", 4),
            new Stims(2003, "Revive Chip", 25, 0, 1,"Only issued on high risk missions", 5),
            new Mods(3001, "Lift Mod", 10, Mods.Mod.LiftMod, "This mod usually allows normal people to lift and manlipulate networked devices, for a Sourcer this allows them to lift just about anything.", 30),
            new Mods(3002, "Pull Mod", 10, Mods.Mod.PullMod, "This mod allows normal people to pull networked objects to where their focus is, Sourcers can pull anything and anyone.", 30),
            new Mods(3003, "Push Mod", 10, Mods.Mod.PushMod, "This mod allows normal people push networked objects to where their focus is, Sourcers can push anything and anyone.", 30),
            };

        }
        private static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }
    }
}

