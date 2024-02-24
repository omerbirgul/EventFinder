//using EvenFinder.Data;
//using Microsoft.EntityFrameworkCore;

//namespace EvenFinder.Data2.Concrate.EfCore
//{
//    public static class SeedData
//    {
//        public static void TestVerileriniDoldur(IApplicationBuilder app)
//        {
//            var context = app.ApplicationServices.CreateScope().ServiceProvider
//            .GetService<DataContext>();

//            if(context != null)
//            {
//                if(context.Database.GetPendingMigrations().Any())
//                {
//                    context.Database.Migrate();
//                }

//                //if(!context.Users.Any())
//                //{
//                //    context.Users.AddRange(
//                //        new User { Name = "omer", LastName="Birgul",UserName="omerbirgul45",PhoneNumber="15646546" }
//                //        );
//                //}

//                if (!context.Events.Any())
//                {
//                    context.Events.AddRange(
//                        new Event
//                        {
//                            EventName = "Oyun Hamuru",
//                            Description = "Oyun hamurundan şekil yapma",
//                            IsActive = true,
//                            EventLocation = "Istanbul",
//                            EventDate = DateTime.Now.AddDays(+7),
//                            EventImage = "bootcamp.png"
//                        },
//                        new Event
//                        {
//                            EventName = "Unity Game",
//                            Description = "Unity Dersleri",
//                            IsActive = true,
//                            EventLocation = "Istanbul",
//                            EventDate = DateTime.Now.AddDays(+10),
//                            EventImage = "bootcamp.png"

//                        },
//                        new Event
//                        {
//                            EventName = "Unity Game",
//                            Description = "Unity Dersleri",
//                            IsActive = true,
//                            EventLocation = "manisa",
//                            EventDate = DateTime.Now.AddDays(+100),
//                            EventImage = "bootcamp.png"

//                        },
//                        new Event
//                        {
//                            EventName = "Unity Game",
//                            Description = "Unity Dersleri",
//                            IsActive = true,
//                            EventLocation = "hakkari",
//                            EventDate = DateTime.Now.AddDays(+250),
//                            EventImage = "bootcamp.png"

//                        }
//                        );
//                }

//            }

//        }
//    }
//}
