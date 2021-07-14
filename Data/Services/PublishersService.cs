using Prologue.Data.Models;
using Prologue.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prologue.Data.Paging;

namespace Prologue.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }
        public void AddPublisher(PublisherViewModel publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }
        public PublisherWithBooksAndAuthorsViewModel GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthorsViewModel()
                {
                    Name = n.Name,
                    BookAuthors = n.Books.Select(n => new BookAuthorViewModel()
                    {
                        BookName = n.Title,
                        BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();
            return _publisherData;
        }

        public List<Publisher> GetAllPublishers(string sortBy, string searchString, int? pageNumber)
        {
            var _allPublishers = _context.Publishers.OrderBy(n => n.Name).ToList();

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "name_desc":
                        _allPublishers = _allPublishers.OrderByDescending(n => n.Name).ToList();
                        break;
                    default:
                        break;
                }
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                _allPublishers = _allPublishers.Where(n => n.Name.Contains(searchString , StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            int pageSize = 5;
            _allPublishers = PaginatedList<Publisher>.Create(_allPublishers.AsQueryable(), pageNumber ?? 1, pageSize);

            return _allPublishers;
        }
    public Publisher GetPublisherById(int publisherId)
        {
            var _publisherData = _context.Publishers.FirstOrDefault(n => n.Id == publisherId);
            return _publisherData;
        }

        public void DeletePublisherById(int publisherId)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == publisherId);
            if(_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
        }
    }
}
