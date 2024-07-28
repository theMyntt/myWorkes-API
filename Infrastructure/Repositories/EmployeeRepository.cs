using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using myWorkes.Application.Services;
using myWorkes.Core;
using myWorkes.Domain.Aggregates;
using myWorkes.Infrastructure.Schema;

namespace myWorkes.Infrastructure.Repositories
{
    public class EmployeeRepository : Controller, IRepositoryService<EmployeeAggregate>
    {
        private readonly IMongoCollection<Employee>? _collection;
        private readonly EmployeeMapper mapper;

        public EmployeeRepository(MongoDbService service)
        {
            _collection = service.Database?.GetCollection<Employee>("employees");
            mapper = new();
        }

        public async Task<ActionResult<StandardResponse>> Create(EmployeeAggregate employee)
        {
            try
            {
                if (_collection == null)
                {
                    return new ActionResult<StandardResponse>(new StandardResponse
                    {
                        StatusCode = 500,
                        Message = "Database collection is not initialized."
                    });
                }

                var entity = mapper.toPersistance(employee);

                await _collection.InsertOneAsync(entity);
                return new ActionResult<StandardResponse>(new StandardResponse
                {
                    StatusCode = 201,
                    Message = "Employee created successfully."
                });
            }
            catch (Exception ex)
            {
                return new ActionResult<StandardResponse>(new StandardResponse
                {
                    StatusCode = 500,
                    Message = $"Error creating employee: {ex.Message}"
                });
            }
        }

        public async Task<ActionResult<StandardResponse>> Delete(EmployeeAggregate employee)
        {
            try
            {
                if (_collection == null)
                {
                    return new ActionResult<StandardResponse>(new StandardResponse
                    {
                        StatusCode = 500,
                        Message = "Database collection is not initialized."
                    });
                }

                var deleteResult = await _collection.DeleteOneAsync(e => e.Id == employee.Id);

                if (deleteResult.DeletedCount == 0)
                {
                    return new ActionResult<StandardResponse>(new StandardResponse
                    {
                        StatusCode = 404,
                        Message = "Employee not found."
                    });
                }

                return new ActionResult<StandardResponse>(new StandardResponse
                {
                    StatusCode = 200,
                    Message = "Employee deleted successfully."
                });
            }
            catch (Exception ex)
            {
                return new ActionResult<StandardResponse>(new StandardResponse
                {
                    StatusCode = 500,
                    Message = $"Error deleting employee: {ex.Message}"
                });
            }
        }

        public async Task<ActionResult<StandardResponse>> Edit(EmployeeAggregate employee)
        {
            try
            {
                if (_collection == null)
                {
                    return new ActionResult<StandardResponse>(new StandardResponse
                    {
                        StatusCode = 500,
                        Message = "Database collection is not initialized."
                    });
                }

                var entity = mapper.toPersistance(employee);

                var updateResult = await _collection.ReplaceOneAsync(e => e.Id == entity.Id, entity);

                if (updateResult.MatchedCount == 0)
                {
                    return new ActionResult<StandardResponse>(new StandardResponse
                    {
                        StatusCode = 404,
                        Message = "Employee not found."
                    });
                }

                return new ActionResult<StandardResponse>(new StandardResponse
                {
                    StatusCode = 201,
                    Message = "Employee updated successfully."
                });
            }
            catch (Exception ex)
            {
                return new ActionResult<StandardResponse>(new StandardResponse
                {
                    StatusCode = 500,
                    Message = $"Error updating employee: {ex.Message}"
                });
            }
        }

        public async Task<ActionResult<IEnumerable<EmployeeAggregate>>> Filter(List<FiltersRoot> filters, int page)
        {
            try
            {
                if (_collection == null)
                {
                    return StatusCode(500, new StandardResponse("Collection is null", 500));
                }

                if (filters[0] == null)
                {
                    return BadRequest("Filters is null");
                }

                var filterDefinitionBuilder = Builders<Employee>.Filter;
                var filterList = new List<FilterDefinition<Employee>>();

                foreach (var filterRoot in filters)
                {
                    var regexFilter = filterDefinitionBuilder.Regex(filterRoot.Field, new BsonRegularExpression(filterRoot.Value, "i")); // 'i' for case-insensitive
                    filterList.Add(regexFilter);
                }

                var filter = filterDefinitionBuilder.Or(filterList);

                var pageSize = 10;
                var employees = await _collection
                    .Find(filter)
                    .Skip((page - 1) * pageSize)
                    .Limit(pageSize)
                    .ToListAsync();

                var aggregate = employees.Select(mapper.toDomain);

                return new ActionResult<IEnumerable<EmployeeAggregate>>(aggregate);
            }
            catch
            {
                return new ActionResult<IEnumerable<EmployeeAggregate>>(StatusCode(500, "An error occurred while processing the request."));
            }
        }

        public async Task<ActionResult<EmployeeAggregate>> Find(List<FiltersRoot> filters)
        {
            try
            {
                if (_collection == null)
                {
                    return StatusCode(500, new StandardResponse("Collection is null", 500));
                }

                var filterDefinitionBuilder = Builders<Employee>.Filter;
                var filter = FilterDefinition<Employee>.Empty;

                foreach (var filterRoot in filters)
                {
                    filter &= filterDefinitionBuilder.Eq(filterRoot.Field, filterRoot.Value);
                }

                var employee = await _collection.Find(filter).FirstOrDefaultAsync();

                var aggregate = mapper.toDomain(employee);

                return new ActionResult<EmployeeAggregate>(aggregate);
            }
            catch
            {
                return StatusCode(500, new StandardResponse("We cant run this operation", 500));
            }
        }

        public async Task<ActionResult<IEnumerable<EmployeeAggregate>>> Read(int page, int limit)
        {
            if (_collection == null)
            {
                return StatusCode(500, new StandardResponse("Collection is null", 500));
            }

            try
            {
                var pageSize = limit;

                var employees = await _collection
                    .Find(FilterDefinition<Employee>.Empty)
                    .Skip((page - 1) * pageSize)
                    .Limit(pageSize)
                    .ToListAsync();

                var aggregate = employees.Select(mapper.toDomain);

                return new ActionResult<IEnumerable<EmployeeAggregate>>(aggregate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new StandardResponse
                {
                    StatusCode = 500,
                    Message = $"Error retrieving employees: {ex.Message}"
                });
            }
        }
    }
}
