/*
 * @CreateTime: May 4, 2019 7:50 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 4, 2019 7:53 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AccountingBackend.Commons.QueryHelpers {
    public static class DynamicQueryHelper {
        private static MethodInfo containsMethod = typeof (string).GetMethod ("Contains", new [] { typeof (string) });
        private static MethodInfo startsWithMethod =
            typeof (string).GetMethod ("StartsWith", new Type[] { typeof (string) });
        private static MethodInfo endsWithMethod =
            typeof (string).GetMethod ("EndsWith", new Type[] { typeof (string) });
        public static Func<T, T> GenerateSelectedColumns<T> (string Fields = "") {
            string[] EntityFields;
            if (String.IsNullOrEmpty (Fields)) {

                EntityFields = typeof (T).GetProperties ()
                    .Where (d => d.GetGetMethod ().IsStatic == false)
                    .Select (propertyInfo => propertyInfo.Name)
                    .ToArray ();

            } else {
                EntityFields = Fields.Split (',');
            }
            var xParameter = Expression.Parameter (typeof (T), "o");
            var xNew = Expression.New (typeof (T));

            var bindings = EntityFields.Select (o => o.Trim ())
                .Select (o => {
                    var mi = typeof (T).GetProperty (o);
                    var xOriginal = Expression.Property (xParameter, mi);
                    return Expression.Bind (mi, xOriginal);
                });

            var xInit = Expression.MemberInit (xNew, bindings);
            var lambda = Expression.Lambda<Func<T, T>> (xInit, xParameter);

            return lambda.Compile ();

        }

        public static string GenerateFilterString (ApiQueryString query) {
            var dict = query.SelectedColumns
                .Split (',');
            var search = "";
            uint i = 0;

            List<Object> values = new List<Object> ();
            foreach (var word in dict) {
                if (i != 0) {
                    search += " or ";
                }
                search += $"{word} Like %{0}% ";

                i++;
            }

            return search;

        }

        public static IQueryable<TEntity> OrderBy<TEntity> (this IQueryable<TEntity> source, string orderByProperty,
            bool desc) {
            string command = desc ? "OrderByDescending" : "OrderBy";
            var type = typeof (TEntity);
            var property = type.GetProperty (orderByProperty);
            var parameter = Expression.Parameter (type, "p");
            var propertyAccess = Expression.MakeMemberAccess (parameter, property);
            var orderByExpression = Expression.Lambda (propertyAccess, parameter);
            var resultExpression = Expression.Call (typeof (Queryable), command, new Type[] { type, property.PropertyType },
                source.Expression, Expression.Quote (orderByExpression));
            return source.Provider.CreateQuery<TEntity> (resultExpression);
        }

        public static Expression<Func<T, bool>> CreateWhereClause<T> (
            string propertyName, object propertyValue) {
            var parameter = Expression.Parameter (typeof (T));
            return Expression.Lambda<Func<T, bool>> (
                Expression.Equal (
                    Expression.Property (parameter, propertyName),
                    Expression.Constant (propertyValue)),
                parameter);
        }

        public static Expression<Func<T, bool>> BuildWhere<T> (IList<Filter> filters) {
            if (filters.Count == 0)
                return null;

            ParameterExpression param = Expression.Parameter (typeof (T), "t");
            Expression exp = null;

            if (filters.Count == 1)
                exp = GetExpression<T> (param, filters[0]);
            else if (filters.Count == 2)
                exp = GetExpression<T> (param, filters[0], filters[1]);
            else {
                while (filters.Count > 0) {
                    var f1 = filters[0];
                    var f2 = filters[1];

                    if (exp == null)
                        exp = GetExpression<T> (param, filters[0], filters[1]);
                    else
                        exp = Expression.AndAlso (exp, GetExpression<T> (param, filters[0], filters[1]));

                    filters.Remove (f1);
                    filters.Remove (f2);

                    if (filters.Count == 1) {
                        exp = Expression.AndAlso (exp, GetExpression<T> (param, filters[0]));
                        filters.RemoveAt (0);
                    }
                }
            }

            return Expression.Lambda<Func<T, bool>> (exp, param);
        }

        private static Expression GetExpression<T> (ParameterExpression param, Filter filter) {
            MemberExpression member = Expression.Property (param, filter.PropertyName);
            ConstantExpression constant = Expression.Constant (filter.Value);
            UnaryExpression converted = Expression.Convert (constant, member.Type);

            switch (filter.Operation) {
                case Op.Equals:
                    return Expression.Equal (member, converted);

                case Op.GreaterThan:
                    return Expression.GreaterThan (member, converted);

                case Op.GreaterThanOrEqual:
                    return Expression.GreaterThanOrEqual (member, converted);

                case Op.LessThan:
                    return Expression.LessThan (member, converted);

                case Op.LessThanOrEqual:
                    return Expression.LessThanOrEqual (member, converted);

                case Op.Contains:
                    return Expression.Call (member, containsMethod, converted);

                case Op.StartsWith:
                    return Expression.Call (member, startsWithMethod, converted);

                case Op.EndsWith:
                    return Expression.Call (member, endsWithMethod, converted);
            }

            return null;
        }

        private static BinaryExpression GetExpression<T> (ParameterExpression param, Filter filter1, Filter filter2) {
            Expression bin1 = GetExpression<T> (param, filter1);
            Expression bin2 = GetExpression<T> (param, filter2);

            return Expression.AndAlso (bin1, bin2);
        }

    }

    public class Filter {
        public string PropertyName { get; set; }
        public Op Operation { get; set; }
        public object Value { get; set; }
    }

    public enum Op {
        Equals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqual,
        LessThanOrEqual,
        Contains,
        StartsWith,
        EndsWith
    }
}