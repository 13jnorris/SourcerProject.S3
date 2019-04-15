using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SourcerProject.Models
{
    public class Player:Character
    {

        #region FIELDS

        private int _lives;
        private int _health;
        private int _experiencePoints;
        private int _currency;
        private List<Location> _locationVisited;
        private ObservableCollection<GameItemQuantity> _inventory;
        private ObservableCollection<GameItemQuantity> _stims;
        private ObservableCollection<GameItemQuantity> _mods;
        private ObservableCollection<GameItemQuantity> _weapon;
        private ObservableCollection<GameItemQuantity> _credits;













        #endregion

        #region PROPERTIES

        public int Lives
        {
            get { return _lives; }
            set {
                _lives = value;
                OnPropertyChanged(nameof(Lives));
            }
        }
        public int Currency
        {
            get { return _currency; }
            set {
                _currency = value;
                OnPropertyChanged(nameof(Currency));
            }
        }

        public int Health
        {
            get { return _health; }
            set {
                _health = value;

                if (_health > 100)
                {
                    _health = 100;
                }
                else if (_health <= 0)
                {
                    _health = 100;
                    _lives--;
                }
            }
        }
        public ObservableCollection<GameItemQuantity> Credits
        {
            get { return _credits; }
            set { _credits = value; }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                _experiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints));
            }
        }


        public List<Location> VisitedLocals
        {
            get { return _locationVisited; }
            set { _locationVisited = value; }
        }

        public ObservableCollection<GameItemQuantity> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        public ObservableCollection<GameItemQuantity> Stims
        {
            get { return _stims; }
            set { _stims = value; }
        }
        public ObservableCollection<GameItemQuantity> Mods
        {
            get { return _mods; }
            set { _mods = value; }
        }
        public ObservableCollection<GameItemQuantity> Weapon
        {
            get { return _weapon; }
            set { _weapon = value; }
        }

        #endregion
        #region Constructors
        public Player()
        {
            _locationVisited = new List<Location>();
            _weapon = new ObservableCollection<GameItemQuantity>();
            _stims = new ObservableCollection<GameItemQuantity>();
            _mods = new ObservableCollection<GameItemQuantity>();
            _credits = new ObservableCollection<GameItemQuantity>();
        }
        #endregion
        #region METHODS

        /// <summary>
        /// override the default greeting in the Character class to include the job title
        /// set the proper article based on the job title
        /// </summary>
        /// <returns>default greeting</returns>
        public override string DefaultGreeting()
        {
            string article = "a";

            List<string> vowels = new List<string>() { "A", "E", "I", "O", "U" };

            if (vowels.Contains(ToString().Substring(0, 1))) ;
            {
                article = "an";
            }

            return $"Hello, my name is {_name} and I am Sourcer and this where my story begins.";
        }

        public void UpdateInventoryCatergories()
        {
            Mods.Clear();
            Stims.Clear();
            Weapon.Clear();
            Credits.Clear();
            foreach (var gameItemQuantity in _inventory)
            {
                if (gameItemQuantity.GameItem is Stims) Stims.Add(gameItemQuantity);
                if (gameItemQuantity.GameItem is Credits) Credits.Add(gameItemQuantity);
                if (gameItemQuantity.GameItem is Weapon) Weapon.Add(gameItemQuantity);
                if (gameItemQuantity.GameItem is Mods) Mods.Add(gameItemQuantity);
            }

        }
        public void HowMuchMoneyIGot()
        {
            Currency = _inventory.Sum(i => i.GameItem.Value * i.Quantity);
        }

        public void AddGameItemQuanityToInventory(GameItemQuantity selectedGameItemQuantity)
        {
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);
            if(gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = selectedGameItemQuantity.GameItem;
                newGameItemQuantity.Quantity = 1;

                _inventory.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity++;
            }
            UpdateInventoryCatergories();
        }
        public void RemoveGameItemQuanitityFromInventory(GameItemQuantity selectedGameItemQuanity)
        {
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuanity.GameItem.Id);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuanity.Quantity == 1)
                {
                    _inventory.Remove(gameItemQuantity);
                }
                else
                {
                    gameItemQuantity.Quantity--;
                }
            }
            UpdateInventoryCatergories();
        }
        public bool Visited(Location location)
        {
            return _locationVisited.Contains(location);
        }

        #endregion
    }
}
