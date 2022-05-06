﻿using Microsoft.EntityFrameworkCore;

namespace AddressBookWebAiWithEntityFrameWork.Model
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
