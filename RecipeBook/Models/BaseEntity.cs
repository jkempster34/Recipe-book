﻿namespace RecipeBook.Models
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; protected set; }
    }
}
