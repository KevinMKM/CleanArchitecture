﻿namespace CleanArc_Kevin.Core.Abstractions.Caching;

public class FakeCacheAdapter : ICacheAdapter
{
    public void Add<TInput>(string key, TInput obj, DateTime? AbsoluteExpiration, TimeSpan? SlidingExpiration) { }

    public TOutput? Get<TOutput>(string key) => default;

    public void RemoveCache(string key) { }
}