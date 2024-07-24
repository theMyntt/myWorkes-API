using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using myWorkes.Application.Utils;
using myWorkes.Core;
using myWorkes.Domain.Enums;

namespace myWorkes.Domain.Aggregates
{
	public class EmployeeAggregate : AggregateRoot 
	{
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public required string Password { get; set; }
        public required EEmployeerType Type { get; set; }
        public required List<string>? AllowedSystems { get; set; }

        public EmployeeAggregate(string Name, string Email, string? Phone, string Password, EEmployeerType Type, List<string>? AllowedSystems)
		{
            Id = UUID.generate();
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.Password = Password;
            this.Type = Type;
            this.AllowedSystems = AllowedSystems;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
		}

        public EmployeeAggregate(string Id, string Name, string Email, string? Phone, string Password, EEmployeerType Type, List<string>? AllowedSystems, DateTime CreatedAt)
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.Password = Password;
            this.Type = Type;
            this.AllowedSystems = AllowedSystems;
            this.CreatedAt = CreatedAt;
            UpdatedAt = DateTime.Now;
        }

        public EmployeeAggregate(string Id, string Name, string Email, string? Phone, string Password, EEmployeerType Type, List<string>? AllowedSystems, DateTime CreatedAt, DateTime UpdatedAt)
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.Password = Password;
            this.Type = Type;
            this.AllowedSystems = AllowedSystems;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
        }
	}
}

