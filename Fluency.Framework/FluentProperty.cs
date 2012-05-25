namespace Fluency.Framework
{
    using System;

    public struct FluentProperty<T>
    {
        public bool PropertySet { get; private set; }

        private T _value;
        public T Value
        {
            get
            {
                if (PropertySet == false)
                {
                    throw new InvalidOperationException(
                        "The property value is not set.");
                }

                return this._value;
            }
            set
            {
                this.PropertySet = true;
                this._value = value;
            }
        }

        public FluentProperty<T> Or(FluentProperty<T> current)
        {
            return PropertySet ? this : current;
        }

        public static implicit operator T(FluentProperty<T> obj)
        {
            return obj.Value;
        }

        public static implicit operator FluentProperty<T>(T obj)
        {
            return new FluentProperty<T> { Value = obj };
        }
    }
}