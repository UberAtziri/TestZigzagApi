using System;
using MongoDB.Bson.Serialization.Attributes;

namespace TestZigzagApi.Data.Entities
{
    public class BaseEntity
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}