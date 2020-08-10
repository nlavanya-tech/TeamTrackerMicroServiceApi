using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamsMicroservice.Entities
{
    public class Teams
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TeamName { get; set; }
        public string TeamManager { get; set; }
        public string DomainOfWork { get; set; }
        public string TeamMembers { get; set; }
    }
}
