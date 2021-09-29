using System;
using AutoMapper;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Operations.BookOperations.Read;
using BookStoreAppWebAPI.UnitTests.TestSetup;
using FluentAssertions;
using Xunit;

namespace BookStoreAppWebAPI.UnitTests.Operations.BookOperations.ReadBook
{
    public class ReadBookCommandTests:IClassFixture<CommonTextFixture>
    {
        private readonly IMapper _mapper;
        private readonly BookStoreDbContext _context;
        
        public ReadBookCommandTests(CommonTextFixture textFixture)
        {
            _context = textFixture.Context;
            _mapper = textFixture.Mapper;
        }
        

    }
}