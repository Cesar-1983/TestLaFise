using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("conn")
        {
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;
            base.Database.Initialize(force: false);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        //public override int SaveChanges()
        //{
        //    this.ApplyStateChanges();
        //    return base.SaveChanges();
        //}

        public IEnumerable<T> SqlQuery<T>(string proc, object parameters) where T : class, new()
        {
            var arguments = PrepareArguments(proc, parameters);
            IEnumerable<T> value = this.Database.SqlQuery<T>(arguments.Item1, arguments.Item2);
            return value;
        }

        private static Tuple<string, object[]> PrepareArguments(string storedProcedure, object parameters)
        {
            var parameterNames = new List<string>();
            var parameterParameters = new List<object>();

            if (parameters != null)
            {
                foreach (PropertyInfo propertyInfo in parameters.GetType().GetProperties())
                {
                    string name = "@" + propertyInfo.Name;
                    object value = propertyInfo.GetValue(parameters, null);

                    parameterNames.Add(name);
                    if (propertyInfo.PropertyType.Name == "DataTable")
                    {
                        PropertyInfo pi = value.GetType().GetProperty("TableName");
                        String TableName = (String)(pi.GetValue(value, null));
                        parameterParameters.Add(new SqlParameter { ParameterName = name, SqlDbType = System.Data.SqlDbType.Structured, TypeName = TableName, Value = value ?? DBNull.Value });
                    }
                    else
                    {
                        parameterParameters.Add(new SqlParameter(name, value ?? DBNull.Value));
                    }
                }
            }

            if (parameterNames.Count > 0)
                storedProcedure += " " + string.Join(", ", parameterNames);

            return new Tuple<string, object[]>(storedProcedure, parameterParameters.ToArray());
        }

    }
}
