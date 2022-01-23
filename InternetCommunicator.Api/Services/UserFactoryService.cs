﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetCommunicator.Domain.Models;
using InternetCommunicator.Infrastructure.Context;

namespace InternetCommunicator.Api.Services
{
    public abstract class UserFactoryService
    {
        protected CommunicatorDbContext _context;
        public UserFactoryService(CommunicatorDbContext context)
        {
            _context = context;
        }

        public abstract RegisterUser Create(string login, string password);
    }


    public class RegisterUserFactoryService : UserFactoryService
    {
        public RegisterUserFactoryService(CommunicatorDbContext context) : base(context)
        {
        }
        public override RegisterUser Create(string login, string password)
        {
            return null;
        }
    }
}