using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace SourcerProject.Models
{
    public class Map
    {
        private ObservableCollection<Location> _locations;
        private Location _currentLocation;
        private List<GameItem> _standardGameItems;

        public List<GameItem> StandardGameItems
        {
            get { return _standardGameItems; }
            set { _standardGameItems = value; }
        }


        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set { _currentLocation = value; }
        }


        public ObservableCollection<Location> Locations
        {
            get { return _locations; }
            set { _locations = value; }

        }

        public GameItem GameItemById(int gameItemId)
        {
            return StandardGameItems.FirstOrDefault(i => i.Id == gameItemId);
        }

        public ObservableCollection<Location> AccessibleLocations()
        {
            ObservableCollection<Location> accessibleLocation = new ObservableCollection<Location>();

            foreach (var location in _locations)
            {
                if (location.Accessilbe == true)
                {
                    accessibleLocation.Add(location);
                }
            }
            return accessibleLocation;
        }

       
    }
}
