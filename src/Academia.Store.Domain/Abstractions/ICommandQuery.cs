﻿namespace Academia.Store.Domain.Abstractions
{
    public interface ICommand
    {
        bool IsValid();
    }

    public interface IQuery
    {
        bool IsValid();
    }
}
