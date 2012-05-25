namespace Fluency.Framework
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Fluent<TContext, TConfiguration>
        where TConfiguration : IConfiguration<TConfiguration>, new()
    {
        private readonly IList<TConfiguration> _configData;

        protected Fluent(TContext context)
        {
            this._configData = new List<TConfiguration>();
            this.Context = context;
        }

        protected virtual TConfiguration Configure()
        {
            return this._configData
                .Aggregate(new TConfiguration(), (a, b) => a.Update(b));
        }

        protected void Append(TConfiguration next)
        {
            this._configData.Add(next);
        }

        protected TContext Context { get; private set; }
    }
}