using PersonalBloggingPlatform.Domain.Events;
using PersonalBloggingPlatform.Domain.ValueObjects;
using PersonalBloggingPlatform.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;

namespace PersonalBloggingPlatform.Domain.Entities;

public class Role : AggregateRoot<Guid>
{
    private RoleName _name;
    private readonly List<User> _users = [];

    public RoleName Name => _name;
    public IReadOnlyCollection<User> Users => _users.AsReadOnly();

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

    public void AddUser(User user)
    {
        if (!_users.Contains(user))
        {
            _users.Add(user);
        }
    }
}