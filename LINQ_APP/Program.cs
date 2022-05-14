using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_APP
{
    public class Program
    {
        static void Main(string[] args)
        {
            var customers = new[]
              {
               new Customer() { Id = 2, Name ="naro",Phones = new []{
                      new Phone() {
                           Number="077 77 77 77",
                           PhoneType=PhoneType.Cell },
                      new Phone(){
                           Number="010 43 43 43",
                           PhoneType=PhoneType.Home } } },
               new Customer() { Id = 4 , Name ="rafo",Phones = new[] {
                     new Phone() {
                           Number = "010 45 87 45",
                           PhoneType = PhoneType.Home},
                     new Phone(){
                           Number="077 78 78 78",
                           PhoneType=PhoneType.Cell} } },
               new Customer() { Id = 6 , Name ="shrek",Phones = new [] {
                     new Phone(){
                           Number = "098 98 98 98 ",
                           PhoneType=PhoneType.Cell},
                     new Phone(){
                           Number = "010 45 45 45",
                           PhoneType=PhoneType.Home} }
               }
            };

            var addresses = new[]
            {
                new Addres(){Id=1,CustomerId=2,City="yerevan",Street="aresh"},
                new Addres(){Id=1,CustomerId=2,City="city_2",Street="strit_99"},
                new Addres() {Id=3,CustomerId=4,City="lennakan",Street="strit_78"},
                new Addres() {Id=5,CustomerId=6,City="city_1",Street = "strit_102"}
            };

            var resJoin = customers._Join(addresses, c => c.Id,
                                                    a => a.CustomerId,
                                                   (c, a) => new { c.Name, a.Street, a.City });

            foreach (var item in resJoin)
                Console.WriteLine($"{item.Name}--{item.Street}--{item.City}");


            var resfirstordefault = customers.AsQueryable()._FirstOrDefault(c => c.Id == 4);

            var reswhere = addresses.AsQueryable()._Where(c => c.CustomerId == 1);

            var resSelect = customers.AsQueryable()._Select(x => x.Name);
            foreach (var item in resSelect)
                Console.WriteLine(item);

            var selectMany = customers.AsQueryable()._SelectMany(x => x.Phones);
            foreach (var item in selectMany)
                Console.WriteLine($"{item.Number}--{item.PhoneType}");
        }

        private static void NewMethod()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var res = arr._Where(x => x % 2 == 0);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
        
    }
}