using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context){
           if(context.Activities.Any()) return;
            var data=new List<Activity>{
                new Activity(){Titel="Test",Venue="Venue",Date=DateTime.Now.AddDays(-5),Description="Description",Category="Category",City="City"},
             new Activity(){Titel="Test1",Venue="Venue1",Date=DateTime.Now.AddDays(-8),Description="Description1",Category="Category1",City="City1"}
             };
             await context.Activities.AddRangeAsync(data);
             await context.SaveChangesAsync();
           }
           
             

        }
    }
