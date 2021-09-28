using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;
using FluentValidation.Results;

namespace BookstoreAppWebAPI.Operations.BookOperations.Read
{
    public class ReadBookCommand
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public ReadBookCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadBookViewModel Model { get; set; }

        public List<ReadBookViewModel> GetBooksWithDetails()
        {
            var books = from book in _context.Books
                join writer in _context.Writers on book.WriterId equals writer.Id
                join genre in _context.Genres on book.GenreId equals genre.Id
                select new ReadBookViewModel
                {
                    Id = book.Id,
                    Description = book.Description,
                    PublishDate = book.PublishDate,
                    Title = book.Title,
                    Genre = genre,
                    Writer = writer
                };

            return books.ToList();
        }

        public List<ReadBookViewModel> GetBooks()
        {
            var books = _context.Books.ToList();

            List<ReadBookViewModel> models = new List<ReadBookViewModel>();

            models = _mapper.Map(books, models);

            return models;
        }

        public ReadBookViewModel GetBookByBookId()
        {
            ReadBookValidator validator = new ReadBookValidator();
            ValidationResult result =  validator.Validate(Model);

            if (!result.IsValid)
            {
                throw new NullReferenceException("Id vermeniz gerekiyor");
            }
                
            var searchedBook =  _context.Books.Single(x => x.Id == Model.Id);

             Model = _mapper.Map(searchedBook, Model);

             return Model;
        }

        public ReadBookViewModel GetBookWithDetailsByBookId()
        {
            ReadBookValidator validator = new ReadBookValidator();
            ValidationResult result =  validator.Validate(Model);

            if (!result.IsValid)
            {
                throw new NullReferenceException("Id vermeniz gerekiyor");
            }
            
            var searchedBook = from book in _context.Books
                join writer in _context.Writers on book.WriterId equals writer.Id
                join genre in _context.Genres on book.GenreId equals genre.Id
                select new ReadBookViewModel
                {
                    Id = book.Id,
                    Description = book.Description,
                    PublishDate = book.PublishDate,
                    Title = book.Title,
                    Genre = genre,
                    Writer = writer
                };

            return searchedBook.Single(x => x.Id == Model.Id);
        }

    }


    public class ReadBookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }

        public Genre Genre { get; set; }
        public Writer Writer { get; set; }
    }
}