﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Week4.NaimaElKhattabi.CORE.Interfaces
{
    public interface IRepository<T>
    {
        List<T> FetchAll();
        T GetById(int id);
        bool Add(T item);
        bool Update(T item);
        bool Delete(T item);
    }
}
