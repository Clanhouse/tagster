namespace Tagster.Redis.Builders
{
    internal sealed class RedisOptionsBuilder : IRedisOptionsBuilder
    {
        private readonly RedisOptions _options = new();

        public IRedisOptionsBuilder WithConnectionString(string connectionString)
        {
            _options.ConnectionString = connectionString;
            return this;
        }

        public IRedisOptionsBuilder WithInstance(string instance)
        {
            _options.Instance = instance;
            return this;
        }

        public RedisOptions Build()
        {
            return _options;
        }
    }
}