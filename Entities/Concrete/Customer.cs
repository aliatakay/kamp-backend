/* Kodların altında açıklamalar var. */
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public string CustomerId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
    }
}

/*
        Northwind veritabanında bu proplar string olarak tanımlandığı için
        biz de kod kısmında string olarak tanımlamak durumundayız.

        yoksa id özelliğini string olarak tanımlamak hatalıdır.
 */