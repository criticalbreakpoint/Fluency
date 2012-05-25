namespace Fluency.Framework
{
    public interface IConfiguration<TConfiguration>
        where TConfiguration : IConfiguration<TConfiguration>, new()
    {
        TConfiguration Update(TConfiguration next);
    }
}