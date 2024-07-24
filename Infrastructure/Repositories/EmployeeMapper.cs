using System;
using myWorkes.Core;
using myWorkes.Domain.Aggregates;
using myWorkes.Infrastructure.Schema;

namespace myWorkes.Infrastructure.Repositories
{
	public class EmployeeMapper : IMapperService<EmployeeAggregate, Employee>
	{
        public EmployeeAggregate toDomain(Employee schema)
        {
            return new EmployeeAggregate(schema.Id, schema.Name, schema.Email, schema.Phone, schema.Password, schema.Type, schema.AllowedSystems, schema.CreatedAt, schema.UpdatedAt);
        }

        public Employee toPersistance(EmployeeAggregate schema)
        {
            return new Employee
            {
                Id = schema.Id,
                Name = schema.Name,
                Email = schema.Email,
                Phone = schema.Phone,
                Password = schema.Password,
                Type = schema.Type,
                AllowedSystems = schema.AllowedSystems,
                CreatedAt = schema.CreatedAt,
                UpdatedAt = schema.UpdatedAt
            };
        }
    }
}

