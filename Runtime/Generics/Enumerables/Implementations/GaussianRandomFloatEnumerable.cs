using System;
using LiteNinja.Common.Extensions;
using LiteNinja.Common.Helpers;

namespace LiteNinja.Common.Generics.Enumerables
{
    public class GaussianRandomFloatEnumerable : FuncEnumerable<float>
    {
        public GaussianRandomFloatEnumerable(Random random) : base(() => ((float)random.NextGaussian(),  true))
        {
        }
        
        public GaussianRandomFloatEnumerable() : base(() => (UnityRandomHelper.NextGaussian(), true))
        {
        }

    }
}