namespace WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class PartType
    {
        public int PartTypeId { get; }
        public string Name { get; }
        public string Description { get; }
        public string Category { get;  }
        public Characteristics[] Characteristics { get; }

        public PartType()
        {

        }
        public PartType(int partId, string name, string category, string description, Characteristics[] characteristics)
        {
            PartTypeId = partId;
            Name = name;
            Category = category;
            Description = description;
        }
    }
    internal class Characteristics
    {
        public Characteristics(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; }
        public string Value { get; }
    }
}