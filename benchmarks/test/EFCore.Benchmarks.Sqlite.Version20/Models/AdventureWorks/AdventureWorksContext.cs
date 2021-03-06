// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


namespace Microsoft.EntityFrameworkCore.Benchmarks.Models.AdventureWorks
{
    public class AdventureWorksContext : AdventureWorksContextBase
    {
        private readonly string _connectionString;

        public AdventureWorksContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void ConfigureProvider(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Work around issue #9560
                entityType.Relational().Schema = null;
            }
        }
    }
}
