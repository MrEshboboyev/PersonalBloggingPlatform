using PersonalBloggingPlatform.Domain.Events;
using PersonalBloggingPlatform.Domain.ValueObjects;
using PersonalBloggingPlatform.Shared.Abstractions.Domain;
using System;

namespace PersonalBloggingPlatform.Domain.Entities;

public class Role : AggregateRoot<Guid>
{
    private RoleName _name;
    public RoleName Name => _name;

    private Role() { }


    internal Role(RoleName name)
    {
        _name = name;

        AddEvent(new RoleCreated(this));
    }

    public void UpdateName(RoleName name)
    {
        _name = name;

        AddEvent(new RoleNameUpdated(this)); 
    }
}