﻿using UserAdmin.Models.Entities;

namespace Domain.Entities.Foo;

public class FooEntity : BaseEntity
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}