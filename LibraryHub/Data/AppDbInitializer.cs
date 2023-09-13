using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using LibraryHub.Data.Static;
using LibraryHub.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryHub.Data
{
    public class AppDbInitializer
    {
        
        public AppDbInitializer(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            var adminUser1 = Configuration.GetConnectionString("AdminUser");
            var adminPass1 = Configuration.GetConnectionString("AdminPass");
    }
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
           
            


            //app service scoped
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //reference to app dbcontextfile
                
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Edition
                if (!context.Editions.Any())
                {
                    context.Editions.AddRange(new List<Edition>()
                    {
                        new Edition()
                        {
                            Name = "1st Editon",
                            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSp84Db59M_m25ezDPMWNiMnJmUb2KCCNh6Ix_5Gf_g-ZPwlmqkGPZ16ODloFUWWFu7g7Y&usqp=CAU",
                            Description = "Description"
                        },
                        new Edition()
                        {
                            Name = "2nd Edition",
                            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR31MsdQ_LCvu2crr7mRbVMXBD6NWViQqFJv93fr_Kx98vRd6dc-j2gAbweUf9wkKrTNyw&usqp=CAU",
                            Description = "Description"
                        },
                        new Edition()
                        {
                            Name = "3rd Edition",
                            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQwe1oJC-5WW6Z04dt3RZPjKBI6opE2V2wzSr2ET8O-AmwfY_g55EIIK84n7ML0RHU4MlM&usqp=CAU",
                            Description = "Description"
                        },
                        new Edition()
                        {
                            Name = "4th Edition",
                            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQDaWmhyKMRWrq3eG6fOwQ-UWVg_NvM-YaEvkdC3svSkwzcNKbgo3ek_be1TikKjt1_jV4&usqp=CAU",
                            Description = "Description"
                        },
                        new Edition()
                        {
                            Name = "5th Edition",
                            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrTW21_UniBg66HmPsqJiCZ6xKNgg-CebkACriaz9us8ot38AgOAZeupj1ANO2YF31k4I&usqp=CAU",
                            Description = "Description"
                        },
                    });
                    context.SaveChanges();
                }
                //Authors
                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>()
                    {
                        new Author()
                        {
                            FullName = "George R. R. Martin",
                            Bio = "George Raymond Richard Martin (born George Raymond Martin; September 20, 1948), also known as GRRM, is an American novelist, screenwriter, television producer and short story writer. He is the author of the series of epic fantasy novels A Song of Ice and Fire, which were adapted into the Emmy Award-winning HBO series Game of Thrones (2011–2019) and its prequel series House of the Dragon (2022–present). He also helped create the Wild Cards anthology series, and contributed worldbuilding for the 2022 video game Elden Ring.\r\n\r\nIn 2005, Lev Grossman of Time called Martin \"the American Tolkien\", and in 2011, he was included on the annual Time 100 list of the most influential people in the world.",
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ed/Portrait_photoshoot_at_Worldcon_75%2C_Helsinki%2C_before_the_Hugo_Awards_%E2%80%93_George_R._R._Martin.jpg/220px-Portrait_photoshoot_at_Worldcon_75%2C_Helsinki%2C_before_the_Hugo_Awards_%E2%80%93_George_R._R._Martin.jpg"

                        },
                        new Author()
                        {
                            FullName = "Peter Thiel",
                            Bio = "Peter Andreas Thiel; born 11 October 1967) is a German-American billionaire entrepreneur, venture capitalist, and political activist. A co-founder of PayPal, Palantir Technologies, and Founders Fund, he was the first outside investor in Facebook. As of May 2022, Thiel had an estimated net worth of $7.19 billion and was ranked 297th on the Bloomberg Billionaires Index.",
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3e/Peter_Thiel_by_Gage_Skidmore.jpg/220px-Peter_Thiel_by_Gage_Skidmore.jpg"
                        },
                        new Author()
                        {
                            FullName = "Dominic O'Brien",
                            Bio = "Dominic O'Brien (10 August 1957) is a British mnemonist and an author of memory-related books. He is the eight time World Memory Champion and works as a trainer for Peak Performance Training.",
                            ProfilePictureURL = "http://dotnethow.net/images/Authors/author-3.jpeg"
                        },
                        new Author()
                        {
                            FullName = "Colleen Hoover",
                            Bio = "Joanne Rowling \"rolling\"; born 31 July 1965), also known by her pen name J. K. Rowling, is a British author and philanthropist. She wrote Harry Potter, a seven-volume children's fantasy series published from 1997 to 2007. The series has sold over 500 million copies, been translated into at least 70 languages, and spawned a global media franchise including films and video games. The Casual Vacancy (2012) was her first novel for adults. She writes Cormoran Strike, an ongoing crime fiction series, as Robert Galbraith.",
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5d/J._K._Rowling_2010.jpg/220px-J._K._Rowling_2010.jpg"
                        },
                         new Author()
                        {
                            FullName = "Actor 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Publishers
                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange(new List<Publisher>()
                    {
                        new Publisher()
                        {
                            FullName = "Publisher 1",
                            Bio = "Description",
                            ProfilePictureURL = ""

                        },
                        new Publisher()
                        {
                            FullName = "Publisher 2",
                            Bio = "Description",
                            ProfilePictureURL = ""
                        },
                        new Publisher()
                        {
                            FullName = "Publisher 3",
                            Bio = "Description",
                            ProfilePictureURL = ""
                        },
                        new Publisher()
                        {
                            FullName = "Publisher 4",
                            Bio = "Description",
                            ProfilePictureURL = ""
                        },
                        new Publisher()
                        {
                            FullName = "Publisher 5",
                            Bio = "Description",
                            ProfilePictureURL = ""
                        }
                    });
                    context.SaveChanges();
                }
                //Books
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                            Name = "Fire & Blood",
                            Description = "Fire & Blood is a fantasy book by American writer George R. R. Martin and illustrated by Doug Wheatley. It tells the history of House Targaryen, the dynasty that ruled the Seven Kingdoms of Westeros in the backstory of his series A Song of Ice and Fire.",
                            Price = 39.50,
                            ImageURL = "https://m.media-amazon.com/images/I/51sw9sAJJ3L._AC_SY780_.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            EditionId = 1,
                            PublisherId = 3,
                            BookCategory = BookCategory.Horror
                        },
                        new Book()
                        {
                            Name = "Zero to One",
                            Description = "Zero to One: Notes on Startups, or How to Build the Future is a 2014 book by the American entrepreneur and investor Peter Thiel co-written with Blake Masters.",
                            Price = 39.50,
                            ImageURL = "http://prodimage.images-bn.com/pimages/9780804139298_p0_v4_s1200x630.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            EditionId = 4,
                            PublisherId = 4,
                            BookCategory = BookCategory.Horror
                        },
                        new Book()
                        {
                            Name = "Game of Thrones: The Winds of Winter",
                            Description = "The Winds of Winter is the planned sixth novel in the epic fantasy series A Song of Ice and Fire by American writer George R. R. Martin. Martin believes the last two volumes of the series will total over 3,000 manuscript pages.",
                            Price = 29.50,
                            ImageURL = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1465341854l/12111823._SY475_.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            EditionId = 1,
                            PublisherId = 1,
                            BookCategory = BookCategory.Action
                        },
                        new Book()
                        {
                            Name = "You Can Have an Amazing Memory",
                            Description = "Dominic O'Brien's masterclass",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/Books/book-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            EditionId = 1,
                            PublisherId = 2,
                            BookCategory = BookCategory.Horror
                        },
                        new Book()
                        {
                            Name = "All Your Perfects",
                            Description = "Quinn and Graham’s perfect love is threatened by their imperfect marriage. The memories, mistakes, and secrets that they have built up over the years are now tearing them apart.",
                            Price = 39.50,
                            ImageURL = "https://m.media-amazon.com/images/I/41HxQfPYJGL.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            EditionId = 1,
                            PublisherId = 3,
                            BookCategory = BookCategory.Horror
                        },
                        new Book()
                        {
                            Name = "Game of Thrones: A Feast for Crows",
                            Description = "A Feast for Crows is the fourth of seven planned novels in the epic fantasy series A Song of Ice and Fire by American author George R. R. Martin. ",
                            Price = 39.50,
                            ImageURL = "https://awoiaf.westeros.org/images/a/a3/AFeastForCrows.jpg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            EditionId = 1,
                            PublisherId = 5,
                            BookCategory = BookCategory.Drama
                        }
                    });
                    context.SaveChanges();
                }
                //Authors & books
                if (!context.Authors_Books.Any())
                {
                    context.Authors_Books.AddRange(new List<Author_Book>()
                    {
                        new Author_Book()
                        {
                            AuthorId = 1,
                            BookId = 1
                        },
                        new Author_Book()
                        {
                            AuthorId = 3,
                            BookId = 1
                        },

                         new Author_Book()
                        {
                            AuthorId = 1,
                            BookId = 2
                        },
                         new Author_Book()
                        {
                            AuthorId = 4,
                            BookId = 2
                        },

                        new Author_Book()
                        {
                            AuthorId = 1,
                            BookId = 3
                        },
                        new Author_Book()
                        {
                            AuthorId = 2,
                            BookId = 3
                        },
                        new Author_Book()
                        {
                            AuthorId = 5,
                            BookId = 3
                        },


                        new Author_Book()
                        {
                            AuthorId = 2,
                            BookId = 4
                        },
                        new Author_Book()
                        {
                            AuthorId = 3,
                            BookId = 4
                        },
                        new Author_Book()
                        {
                            AuthorId = 4,
                            BookId = 4
                        },


                        new Author_Book()
                        {
                            AuthorId = 2,
                            BookId = 5
                        },
                        new Author_Book()
                        {
                            AuthorId = 3,
                            BookId = 5
                        },
                        new Author_Book()
                        {
                            AuthorId = 4,
                            BookId = 5
                        },
                        new Author_Book()
                        {
                            AuthorId = 5,
                            BookId = 5
                        },


                        new Author_Book()
                        {
                            AuthorId = 3,
                            BookId = 6
                        },
                        new Author_Book()
                        {
                            AuthorId = 4,
                            BookId = 6
                        },
                        new Author_Book()
                        {
                            AuthorId = 5,
                            BookId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            string keyVaultName = Environment.GetEnvironmentVariable("");
            var kvUri = "https://" + keyVaultName + ".vault.azure.net";

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
            var secret1 = await client.GetSecretAsync("AdminUser");
            var secret2 = await client.GetSecretAsync("AdminPass");

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = secret1.ToString();

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, secret2.ToString());
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
