using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourcerProject.Models
{
    public class Character : ObservableObject
    {
        protected int _id;
        protected string _name;
        protected int _locationId;
        protected int _age;




        #region PROPERTIES

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }



        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, int locationId)
        {
            _name = name;

            _locationId = locationId;
        }

        #endregion

        #region METHODS

        public virtual string DefaultGreeting()
        {
            return $"Hello, my name is {_name}.";
        }
        #endregion
    }
}
