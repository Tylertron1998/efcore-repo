using System;
using System.Collections.Generic;
using System.Linq;
using EfCoreRepo.Database;
using EfCoreRepo.Models;

namespace EfCoreRepo
{
    class Program
    {
        static void Main(string[] args)
        {

            var colours = new List<Colours>
            {
                Colours.Black,
                Colours.Green
            };
            
            
            using (var context = new WorkingContext())
            {

                var person = new WorkingModel
                {
                    Name = "John Skeet",
                    FavouriteColours = colours.Cast<int>().ToList()
                };

                context.People.Add(person);
                context.SaveChanges();
            }

            using (var context = new BrokenContext())
            {

                var person = new BrokenModel
                {
                    Name = "John Skeet",
                    FavouriteColours = colours
                };

                context.PeopleB.Add(person);
                context.SaveChanges();
            }

            using (var context = new BrokenContext_WithConverter())
            {

                var person = new BrokenModel
                {
                    Name = "John Skeet",
                    FavouriteColours = colours
                };

                context.PeopleC.Add(person);
                context.SaveChanges();
            }
        }
    }
}