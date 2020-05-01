using Its.Games.Core.Commons;

namespace Its.Games.Othello.Commons
{
    public abstract class OthelloMarker : IMarker, IOthelloMarker
    {
        private string name = "";
        private int id = -1;

        protected abstract string GetName();
        protected abstract int GetId();

        public OthelloMarker()
        {
            id = GetId();
            name = GetName();
        }

        public bool IsSameSide(IMarker marker)
        {
            bool same = Name.Equals(marker.Name);
            return same;
        }

        public int Id 
        { 
            get 
            { 
                return id;
            }

            set 
            {
                id = value;
            } 
        }

        //For example "Black" or "White"
        public string Name 
        { 
            get
            {
                return name;
            } 

            set
            {
                name = value;
            }
        }
    }
}