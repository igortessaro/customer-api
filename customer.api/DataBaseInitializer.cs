using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace customer.api
{
    public static class DataBaseInitializer
    {
        public static void Fill<TEntity>(string fileName, DbSet<TEntity> dbSet) where TEntity : class
        {
            string text = File.ReadAllText(Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JsonData"), fileName));
            IList<TEntity> entities = JsonConvert.DeserializeObject<IList<TEntity>>(text);
            dbSet.AddRange(entities);
        }
    }
}
