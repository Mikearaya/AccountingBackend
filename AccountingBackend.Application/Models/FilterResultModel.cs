using System.Collections;
using System.Collections.Generic;

namespace AccountingBackend.Application.Models {
    public class FilterResultModel<T> {
        public IEnumerable<T> Items;
        public int Count;
    }
}