﻿using System;
using System.Linq;
using AutoMapper;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;

namespace BookstoreAppWebAPI.Operations.BookOperations.Create
{
    public class CreateBookCommands
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommands(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CreateBookViewModel Model { get; set; }

        public void AddBook()
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == Model.Title);

            if (book != null) throw new InvalidOperationException("Kitap zaten mevcut");

            book = _mapper.Map<Book>(Model);


            _context.Books.Add(book);
            _context.SaveChanges();
        }
    }

    public class CreateBookViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int GenreId { get; set; }
        public int WriterId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}