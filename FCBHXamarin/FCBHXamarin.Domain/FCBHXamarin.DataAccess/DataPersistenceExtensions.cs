using System;
using System.Linq;
using Couchbase.Lite.Query;
using FCBHXamarin.Models.Kernel;

namespace FCBHXamarin.DataAccess
{
	public static class DataPersistenceExtensions
	{
		public static IDataPersistence<T> GetDataPersistence<T>() where T: DomainEntity
		{
			return new CouchbaseLocal<T>();
		}
		/// <summary>
		/// Withes the arguments.
		/// </summary>
		/// <param name="expression">The expression.</param>
		/// <param name="param">The parameter.</param>
		/// <returns>
		/// IExpression
		/// </returns>
		public static IExpression WithArgs(this IExpression expression, Tuple<string, object>[] param)
		{
			var isFirst = true;
			foreach (var (item1, item2) in param.ToList())
			{
				if (isFirst)
				{
					expression.And(Expression.Property(item1).Like(Expression.String(item2.ToString())));
					isFirst = false;
					continue;
				}

				expression.Or(Expression.Property(item1).Like(Expression.String(item2.ToString())));
			}

			return expression;
		}
	}
}
