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

    }
}