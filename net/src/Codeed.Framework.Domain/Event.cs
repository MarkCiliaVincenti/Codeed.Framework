﻿using System;
using System.Text.Json.Serialization;

namespace Codeed.Framework.Domain
{
    public abstract class Event : Message
    {
        public DateTime Timestamp { get; private set; }

        public Guid Id { get; private set; }

        protected Event()
        {
            Id = Guid.NewGuid();
            Timestamp = DateTime.Now;
        }

        [JsonConstructor]
        protected Event(Guid id, DateTime timestamp)
        {
            Id = id;
            Timestamp = timestamp;
        }
    }
}