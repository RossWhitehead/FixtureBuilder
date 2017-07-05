using System;

namespace FixtureBuilder.Generators
{
    public abstract class ManyGenerator
    {
        protected readonly int many;
        protected readonly int maxDepth;
        protected readonly int depth;
        protected readonly Type type;

        public ManyGenerator(int many, int maxDepth, int depth, Type type)
        {
            this.many = many;
            this.maxDepth = maxDepth;
            this.depth = depth;
            this.type = type;
        }
    }
}
