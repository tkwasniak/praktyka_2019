using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;


namespace MovieRental.Web.Models
{
    public class PaginationViewModel
    {
        
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        private readonly string _requestedURL;
        private string _sortOrder;

        public PaginationViewModel(string requestedURL, int currentPage, int totalPages, string sortOrder)
        {
            _requestedURL = requestedURL;
            _sortOrder = sortOrder;
            CurrentPage = currentPage;
            TotalPages = totalPages;
        }

        public PaginationViewModel(string requestedURL, int currentPage, int totalPages)
        {
            _requestedURL = requestedURL;
            CurrentPage = currentPage;
            TotalPages = totalPages;
        }

        public string GetPage(int page)
        {
            return String.Format(_requestedURL, page, _sortOrder);
        }
        public string GetNextPage()
        {
            return GetPage(CurrentPage + 1);
        }
        public string GetPreviousPage()
        {
            return GetPage(CurrentPage - 1);
        }


       
    }
}