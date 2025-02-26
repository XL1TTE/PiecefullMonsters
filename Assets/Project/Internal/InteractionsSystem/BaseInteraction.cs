

namespace Internal.InteractionsSystem
{


    public enum Priorities
    {
        very_low = 0,
        low = 1,
        medium = 2,
        high = 3,
        very_high = 4

    }

    public abstract class BaseInteraction
    {

        public virtual Priorities Priority()
        {
            return 0;
        }
    }
}
