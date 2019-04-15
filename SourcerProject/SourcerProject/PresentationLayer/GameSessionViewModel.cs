using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourcerProject.Models;
using System.Collections.ObjectModel;

namespace SourcerProject.PresentationLayer
{
    public class GameSessionViewModel:ObservableObject
    {
        #region ENUMS



        #endregion

        #region FIELDS

        private Player _player;
        private List<string> _messages;
        private DateTime _gameStartTime;
        private Map _gameMap;
        private Location _currentLocation;
        private ObservableCollection<Location> _accessibleLocations;
        private string _currentLocationName;
        private GameItemQuantity _currentGameItem;

        public GameItemQuantity CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
        }



        private Location _locations;

        public Location Location
        {
            get { return _locations; }
            set { _locations = value; }
        }





        public string CurrentLocationName
        {
            get { return _currentLocationName; }
            set { _currentLocationName = value;
                
                //OnPropertyChanged("CurrentLocation");
                
                }
        }


        public ObservableCollection<Location> AccessibleLocations
        {
            get { return _accessibleLocations; }
            set
            {
                _accessibleLocations = value;
                OnPropertyChanged(nameof(CurrentLocation));
            }
        }


        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                OnPlayerMove();
                OnPropertyChanged(nameof(CurrentLocation));
            }
        }
        public string MessageDisplay
        {
            get { return _currentLocation.Messages; }
        }

        public Map gameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }


        #endregion

        #region PROPERTIES

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

     

        #endregion

        #region CONSTRUCTORS

        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(
            Player player,
            List<string> initialMessages,
            
            Map gameMap,
            Location currentLocation)
        {
            
            _player = player;
            _messages = initialMessages;
            _gameMap = gameMap;
            _currentLocation = currentLocation;
            _accessibleLocations = _gameMap.AccessibleLocations();
            InitializeView();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initial setup of the game session view
        /// </summary>
        private void InitializeView()
        {
            _gameStartTime = DateTime.Now;
            _player.UpdateInventoryCatergories();
            _player.HowMuchMoneyIGot();
        }

        /// <summary>
        /// generates a sting of mission messages with time stamp with most current first
        /// </summary>
        /// <returns>string of formated mission messages</returns>
        private string FormatMessagesForViewer()
        {
            List<string> lifoMessages = new List<string>();

            for (int index = 0; index < _messages.Count; index++)
            {
                lifoMessages.Add($" <T:{GameTime().ToString(@"hh\:mm\:ss")}> " + _messages[index]);
            }

            lifoMessages.Reverse();

            return string.Join("\n\n", lifoMessages);
        }

        /// <summary>
        /// running time of game
        /// </summary>
        /// <returns></returns>
        private TimeSpan GameTime()
        {
            return DateTime.Now - _gameStartTime;
        }

        private void OnPlayerMove()
        {
            Location newLocation = new Location();
            foreach (Location location in AccessibleLocations)
            {
                if(location.Name == _currentLocationName)
                {
                    _currentLocation = location;
                }
               
            }
            if (!_player.Visited(_currentLocation))
            {
                _player.VisitedLocals.Add(_currentLocation);

                _player.ExperiencePoints += _currentLocation.AddXP;
            }

            
                    
               
        _gameMap.CurrentLocation = newLocation;
        _currentLocation = newLocation;
            
        }

        public void AddItemInventory()
        {
            if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
            {
                GameItemQuantity selectedGameItemQuantity = _currentGameItem as GameItemQuantity;
                _currentLocation.RemoveGameItemQuanityToLocation(selectedGameItemQuantity);
                _player.AddGameItemQuanityToInventory(selectedGameItemQuantity);

                OnPlayerPickUp(selectedGameItemQuantity);
            }
        }

        private void OnPlayerPickUp(GameItemQuantity gameItemQuantity)
        {
            _player.ExperiencePoints += gameItemQuantity.GameItem.ExperiencePoints;
            _player.Currency += gameItemQuantity.GameItem.Value;
        }
        private void OnPlayerPutDown(GameItemQuantity gameItemQuantity)
        {
            _player.Currency += gameItemQuantity.GameItem.Value;
        }

        public void OnUseGameItem()
        {
            switch (_currentGameItem.GameItem)
            {
                case Stims stims:
                    UseStims(stims);
                    break;
                case Mods mods:
                    //UseMods(mods);
                    break;
                default:
                    break;
            }
        }

        private void UseStims(Stims stims)
        {
            _player.Health += stims.PlusHealth;
            _player.Lives += stims.ReviveChip;
        }

       // private void UseMods(Mods mods)
        //{
            //_player.Mods += mods.
       // }

        #endregion
    }
}
