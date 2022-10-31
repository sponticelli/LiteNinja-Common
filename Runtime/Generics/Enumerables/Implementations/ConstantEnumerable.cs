using System.Collections.Generic;

namespace LiteNinja.Common.Generics.Enumerables
{
    public class ConstantEnumerable<T> : FuncEnumerable<T>
    {
        private readonly IEnumerator<T> _enumerator;

        public ConstantEnumerable(T value) : base(() => (value,  true))
        {

        }
    }
}