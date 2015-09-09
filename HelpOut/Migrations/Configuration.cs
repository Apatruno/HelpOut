namespace HelpOut.Migrations
{
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<HelpOut.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HelpOut.Models.ApplicationDbContext context)
        {

            //seeding roles
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (!context.Roles.Any(r => r.Name == "Organization"))
            {
                var role = new IdentityRole() { Name = "Organization" };
                roleManager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Volunteer"))
            {
                var role = new IdentityRole() { Name = "Volunteer" };
                roleManager.Create(role);
            }

            context.SaveChanges();
            roleStore.Dispose();
            roleManager.Dispose();



            //seeding users
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var passwordHash = new PasswordHasher();

            //habitat for humanity
            var user = new ApplicationUser()
            {
                Email = "h4h@gmail.com",
                UserName = "BobsTheBuilders",
                FullName = "Habitat for Humanity",
                PhoneNumber = "5555555555",
                Location = "270 Peachtree Street NW, Atlanta, GA 30303",
                Description = "Habitat for Humanity’s vision is a world where everyone has a decent place to live. Our mission is to put God’s love into action by bringing people together to build homes, communities and hope.",
                Website = "http://www.habitat.org/",
                PasswordHash = passwordHash.HashPassword("Password1!"),
                EventsCreated = new List<Event>()
            };

            if (!context.Users.Any(u => u.Email == "h4h@gmail.com"))
            {
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Organization");
            }
            else
                userManager.Update(user);


            //red cross
            user = new ApplicationUser()
            {
                Email = "redcross@gmail.com",
                UserName = "Switzerland",
                FullName = "American Red Cross",
                PhoneNumber = "5555555555",
                Location = "2025 E Street, NW, Washington DC 20006",
                Description = "The American Red Cross exists to provide compassionate care to those in need. Our network of generous donors, volunteers and employees share a mission of preventing and relieving suffering, here at home and around the world.",
                Website = "http://www.redcross.org/",
                PasswordHash = passwordHash.HashPassword("Password1!"),
                EventsCreated = new List<Event>()
            };

            if (!context.Users.Any(u => u.Email == "redcross@gmail.com"))
            {
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Organization");
            }
            else
                userManager.Update(user);



            //george washington
            user = new ApplicationUser()
            {
                Email = "joewash@gmail.com",
                UserName = "JoeShmoe",
                FullName = "George Washington",
                PhoneNumber = "5555555555",
                Location = "101 Callahan Dr, Alexandria, VA 22301",
                Description = "The first President of the United States(1789–1797), the commander in chief of the Continental Army during the American Revolutionary War, and one of the Founding Fathers of the United States.",
                Website = "https://simple.wikipedia.org/wiki/George_Washington",
                PasswordHash = passwordHash.HashPassword("Password1!"),
                EventsAttending = new List<Event>()
            };

            if (!context.Users.Any(u => u.Email == "joewash@gmail.com"))
            {
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Volunteer");
            }
            else
                userManager.Update(user);



            //john f kennedy
            user = new ApplicationUser()
            {
                Email = "kenjohnson@gmail.com",
                UserName = "Airport",
                FullName = "John F. Kennedy",
                PhoneNumber = "5555555555",
                Location = "646 Main St, Dallas, TX 75202",
                Description = "Commonly known as 'Jack' or by his initials JFK, was the 35th President of the United States. He was in office from 1961-1963. He was the youngest President elected to the office, at the age of 43.",
                Website = "https://simple.wikipedia.org/wiki/John_F._Kennedy",
                PasswordHash = passwordHash.HashPassword("Password1!"),
                EventsAttending = new List<Event>()
            };

            if (!context.Users.Any(u => u.Email == "kenjohnson@gmail.com"))
            {
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Volunteer");
            }
            else
                userManager.Update(user);



            //martin luther king, jr.
            user = new ApplicationUser()
            {
                Email = "mlk@gmail.com",
                UserName = "Milk",
                FullName = "Martin Luther King, Jr.",
                PhoneNumber = "5555555555",
                Location = "Independence Avenue Southwest, Washington, DC 20024",
                Description = "American pastor, activist, humanitarian, and leader in the African-American Civil Rights Movement. He is best known for his role in the advancement of civil rights using nonviolent civil disobedience based on his Christian beliefs.",
                Website = "https://simple.wikipedia.org/wiki/Martin_Luther_King,_Jr.",
                PasswordHash = passwordHash.HashPassword("Password1!"),
                EventsAttending = new List<Event>()
            };

            if (!context.Users.Any(u => u.Email == "mlk@gmail.com"))
            {
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Volunteer");
            }
            else
                userManager.Update(user);


            userStore.Dispose();
            userManager.Dispose();
            context.SaveChanges();

            //seeding events
            context.Events.AddOrUpdate(e => e.EventID,
                new Event
                {
                    EventID = 1,
                    Name = "First Ever Fundraiser to Build Seed!",
                    DateTime = DateTime.ParseExact("06/15/2015 13:45:00", "MM/dd/yyyy HH:mm:ss", null),
                    Address = "128 N Normal St",
                    City = "Ypsilanti",
                    State = "MI",
                    ZipCode = "48198",
                    Description = "Nunc cursus in purus sit amet maximus. Nam a nulla ac arcu iaculis accumsan non ac lectus. Curabitur turpis mi, pharetra pulvinar commodo vel, efficitur et lorem. Ut fermentum egestas felis, consectetur rutrum nunc molestie sit amet. Pellentesque pretium erat et mi hendrerit vehicula.",
                    OrganizationID = (from u in context.Users
                                      where u.Email == "h4h@gmail.com"
                                      select u.Id).First().ToString()
                },

                new Event
                {
                    EventID = 2,
                    Name = "George-Only Party",
                    DateTime = DateTime.ParseExact("01/15/2020 09:15:00", "MM/dd/yyyy HH:mm:ss", null),
                    Address = "1600 Pennsylvania Ave NW",
                    City = "Washington",
                    State = "DC",
                    ZipCode = "20500",
                    Description = "Vivamus eget placerat neque. In hac habitasse platea dictumst. Pellentesque sollicitudin leo eget est congue, sit amet cursus ipsum interdum. Nulla id mi ut nisi mattis vulputate in ut lacus. Sed nulla est, condimentum et vehicula ut, gravida quis dolor. Aenean quis molestie urna. ",
                    OrganizationID = (from u in context.Users
                                      where u.Email == "h4h@gmail.com"
                                      select u.Id).First().ToString()
                },

                new Event
                {
                    EventID = 3,
                    Name = "Kennedy Family Reunion",
                    DateTime = DateTime.ParseExact("11/11/2011 11:11:11", "MM/dd/yyyy HH:mm:ss", null),
                    Address = "400 E Congress St",
                    City = "Detroit",
                    State = "MI",
                    ZipCode = "48226",
                    Description = "Vivamus viverra risus tellus, at bibendum sapien venenatis nec. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Integer blandit cursus ex eu luctus. Cras interdum purus eget tempus dictum. Aenean pretium molestie urna, eu cursus lacus mattis nec.",
                    OrganizationID = (from u in context.Users
                                      where u.Email == "redcross@gmail.com"
                                      select u.Id).First().ToString()
                }
                );


        }
    }
}