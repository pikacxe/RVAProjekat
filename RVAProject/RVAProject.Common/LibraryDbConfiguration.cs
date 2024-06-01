using Npgsql;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;

namespace RVAProject.Common
{
    public class LibraryDbConfiguration : DbConfiguration
    {
        public LibraryDbConfiguration()
        {
            var name = "Npgsql";

            SetProviderFactory(providerInvariantName: name,
                               providerFactory: NpgsqlFactory.Instance);

            SetProviderServices(providerInvariantName: name,
                                provider: NpgsqlServices.Instance);

            SetDefaultConnectionFactory(connectionFactory: new NpgsqlConnectionFactory());

            SetMigrationSqlGenerator("Npgsql", () => new SqlGenerator());
        }
    }
    public class SqlGenerator : NpgsqlMigrationSqlGenerator
    {
        private readonly string[] systemColumnNames = { "oid", "tableoid", "xmin", "cmin", "xmax", "cmax", "ctid" };

        protected override void Convert(CreateTableOperation createTableOperation)
        {
            var systemColumns = createTableOperation.Columns.Where(x => systemColumnNames.Contains(x.Name)).ToArray();
            foreach (var systemColumn in systemColumns)
                createTableOperation.Columns.Remove(systemColumn);
            base.Convert(createTableOperation);
        }
    }
}
