/*
 * @CreateTime: May 4, 2019 7:50 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 28, 2019 1:49 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;

namespace AccountingBackend.Commons.QueryHelpers {
    public class ApiQueryString {
        private int _pageNumber = 0;
        private string _searchString = "";
        public string SortBy { get; set; } = "";
        public string SortDirection { get; set; } = "Asc";
        public string SearchString {
            get {
                return _searchString;
            }
            set {
                _searchString = (value == null) ? "" : value;
            }
        }

        public int PageSize { get; set; } = 10;
        public int PageNumber {
            get {
                return _pageNumber;
            }
            set {
                _pageNumber = value - 1;
            }
        }

        public string SelectedColumns { get; set; } = "";

        public IList<Filter> Filter { get; set; } = new List<Filter> ();

    }
}