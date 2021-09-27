﻿using System;
using System.Linq;
using AutoMapper;

using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;
using BookstoreAppWebAPI.Operations.BookOperations.Create;
using BookStoreAppWebAPI.UnitTests.TestSetup;
using FluentAssertions;
using Xunit;

namespace BookStoreAppWebAPI.UnitTests.Operations.BookOperations.CreateBookCommands
{
    public class CreateBookCommandsTests : IClassFixture<CommonTextFixture>
    {

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandsTests(CommonTextFixture textFixture)
        {
            _mapper = textFixture.Mapper;
            _context = textFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistBootTitleGiven_InvalidExporationException_ShouldBeReturn()
        {
            var book = new Book()
            {
                Description = "Güzel kitap",
                Title = "Lean Startup",
                GenreId = 1,
                WriterId = 1,
                PublishDate = new DateTime(2000, 02, 11)
            };

            BookstoreAppWebAPI.Operations.BookOperations.Create.CreateBookCommands commands = new BookstoreAppWebAPI.Operations.BookOperations.Create.CreateBookCommands(_context, _mapper);

            commands.Model = new CreateBookViewModel()
            {
                Title = book.Title,
                Description = book.Description,
                GenreId = book.GenreId,
                PublishDate = book.PublishDate,
                WriterId = book.WriterId
            };

            FluentActions.Invoking(() =>
            {
                commands.AddBook();
            }).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");


        }


        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
            BookstoreAppWebAPI.Operations.BookOperations.Create.CreateBookCommands commands =
                new BookstoreAppWebAPI.Operations.BookOperations.Create.CreateBookCommands(_context, _mapper);

            CreateBookViewModel model = new CreateBookViewModel()
            {
                Title = "Cerrah",
                Description = "Güzel kitap",
                GenreId = 1,
                PublishDate = new DateTime(2000, 02, 11),
                WriterId = 1
            };

            commands.Model = model;

            //act
            FluentActions.Invoking(() =>
            {
                commands.AddBook();
            }).Invoke();

            //assert

            var searchedBook = _context.Books.ToList().Find(x => x.Title == model.Title);

            searchedBook.Should().NotBeNull();
            searchedBook.Title.Should().Be(model.Title);
            searchedBook.PublishDate.Should().Be(model.PublishDate);
            searchedBook.WriterId.Should().Be(model.WriterId);
            searchedBook.GenreId.Should().Be(model.GenreId);
        }

    }
}