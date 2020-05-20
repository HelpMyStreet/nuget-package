using System;

namespace HelpMyStreet.Utils.MemDistCache
{
    public class CachedItemWrapper<T>
    {
        public CachedItemWrapper(T content, DateTimeOffset expiresAt)
        {
            Content = content;
            ExpiresAt = expiresAt;
        }

        public T Content { get; set; }

        public DateTimeOffset ExpiresAt { get; set; }

    }
}
