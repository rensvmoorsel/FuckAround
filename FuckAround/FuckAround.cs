namespace FuckAroundFindOut
{
    public class FuckAround
    {
        private Dictionary<Type, Action<Exception>> findouts = new();

        private Action? defaultFindOut = null;

        private Action _action;

        public FuckAround(Action action)
        {
            _action = action;
        }

        public void Yolo()
        {
            try
            {
                _action();
            }
            catch (Exception e)
            {
                Type type = e.GetType();

                while (type != null)
                {
                    if (findouts.ContainsKey(type))
                    {
                        findouts[type](e);
                        return;
                    }
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    type = type.BaseType;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                }

                if (defaultFindOut != null)
                {
                    defaultFindOut();
                    return;
                }

                throw;
            }
        }

        public FuckAround FindOut<T>(Action<Exception> action)
        {
            findouts.Add(typeof(T), action);
            return this;
        }

        public FuckAround FindOut(Action action)
        {
            defaultFindOut = action;
            return this;
        }
    }
}
