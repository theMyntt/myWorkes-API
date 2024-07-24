using System;
namespace myWorkes.Core
{
	public interface IMapperService<Aggregate, Entity>
	{
		Aggregate toDomain(Entity schema);
		Entity toPersistance(Aggregate schema);
	}
}

