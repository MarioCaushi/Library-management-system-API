﻿// <auto-generated />
using System;
using Library_management_system_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library_management_system_API.Migrations
{
    [DbContext(typeof(LibraryDB))]
    partial class LibraryDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Library_management_system_API.Models.Book", b =>
                {
                    b.Property<int>("IdBook")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdBook"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CoverImageUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("IdManager")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("double");

                    b.Property<int>("PublishedYear")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasPrecision(3, 2)
                        .HasColumnType("double");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("IdBook");

                    b.HasIndex("IdManager");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            IdBook = 1,
                            Author = "F. Scott Fitzgerald",
                            CoverImageUrl = "https://th.bing.com/th/id/OIP.YY-2rOTwqOzDvIoBMaRluQHaLH?rs=1&pid=ImgDetMain",
                            Description = "Set in the Roaring Twenties, 'The Great Gatsby' tells the story of the enigmatic Jay Gatsby and his obsession with the beautiful Daisy Buchanan. It captures the decadence and excess of the era while exploring themes of love, wealth, and the American Dream.",
                            Genre = "Classic",
                            IdManager = 1,
                            Price = 10.99,
                            PublishedYear = 1925,
                            Rating = 4.5,
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            IdBook = 2,
                            Author = "George Orwell",
                            CoverImageUrl = "https://kopp-medien.websale.net/bilder/gross/133206.jpg",
                            Description = "In a totalitarian future where the Party scrutinizes human actions with ever-watchful Big Brother, Winston Smith dares to express his thoughts and seeks a revolution against the oppressive regime. '1984' is a chilling vision of a dystopian future that warns against the perils of absolute power.",
                            Genre = "Dystopian",
                            IdManager = 1,
                            Price = 9.9900000000000002,
                            PublishedYear = 1949,
                            Rating = 4.7000000000000002,
                            Title = "1984"
                        },
                        new
                        {
                            IdBook = 3,
                            Author = "Harper Lee",
                            CoverImageUrl = "https://cdn2.penguin.com.au/covers/original/9780434020485.jpg",
                            Description = "This Pulitzer Prize-winning novel is narrated by Scout Finch, a young girl in the racially charged South during the 1930s. It addresses the serious issues of race, class, and moral growth as Scout and her brother Jem learn valuable lessons about empathy and justice from their father, Atticus Finch.",
                            Genre = "Classic",
                            IdManager = 1,
                            Price = 8.9900000000000002,
                            PublishedYear = 1960,
                            Rating = 4.7999999999999998,
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            IdBook = 4,
                            Author = "Jane Austen",
                            CoverImageUrl = "https://th.bing.com/th/id/OIP.wcZjPkH4FZD5QYi_2kfxxAHaLS?rs=1&pid=ImgDetMain",
                            Description = "In this classic romantic comedy, Elizabeth Bennet navigates the complexities of love, family, and social standing in 19th-century England. Austen's wit and keen observations on human behavior make this novel a delightful exploration of relationships and societal expectations.",
                            Genre = "Romance",
                            IdManager = 1,
                            Price = 7.9900000000000002,
                            PublishedYear = 1813,
                            Rating = 4.5999999999999996,
                            Title = "Pride and Prejudice"
                        },
                        new
                        {
                            IdBook = 5,
                            Author = "J.D. Salinger",
                            CoverImageUrl = "https://th.bing.com/th/id/R.1213a0ff91c94b884330e362841704a1?rik=zQDdn4XMYcbdsw&pid=ImgRaw&r=0",
                            Description = "The story of Holden Caulfield, a disenchanted teenager who has just been expelled from prep school. As he wanders New York City, he shares his thoughts on life, love, and the struggle of growing up. Salinger's novel remains a profound reflection of teenage angst and rebellion.",
                            Genre = "Fiction",
                            IdManager = 1,
                            Price = 9.5,
                            PublishedYear = 1951,
                            Rating = 4.2999999999999998,
                            Title = "The Catcher in the Rye"
                        },
                        new
                        {
                            IdBook = 6,
                            Author = "J.R.R. Tolkien",
                            CoverImageUrl = "https://images.thenile.io/r1000/9780007487288.jpg",
                            Description = "Follow the adventure of Bilbo Baggins, a hobbit who is reluctantly swept into a quest to reclaim treasure from the dragon Smaug. This enchanting story is filled with memorable characters, adventure, and the timeless battle between good and evil, setting the stage for Tolkien's epic Middle-earth saga.",
                            Genre = "Fantasy",
                            IdManager = 1,
                            Price = 12.99,
                            PublishedYear = 1937,
                            Rating = 4.7999999999999998,
                            Title = "The Hobbit"
                        },
                        new
                        {
                            IdBook = 7,
                            Author = "Paulo Coelho",
                            CoverImageUrl = "https://images.thenile.io/r1000/9780061233845.jpg",
                            Description = "A philosophical tale about Santiago, a shepherd boy who dreams of discovering a treasure in Egypt. Through his journey, he learns profound lessons about following one's dreams and listening to one's heart. 'The Alchemist' is a beautiful narrative that inspires readers to pursue their own destinies.",
                            Genre = "Adventure",
                            IdManager = 1,
                            Price = 11.0,
                            PublishedYear = 1988,
                            Rating = 4.5999999999999996,
                            Title = "The Alchemist"
                        },
                        new
                        {
                            IdBook = 8,
                            Author = "Ray Bradbury",
                            CoverImageUrl = "https://i0.wp.com/www.bookishelf.com/wp-content/uploads/2020/06/Book-Review-Fahrenheit-451-by-Ray-Bradbury.jpg?resize=1332%2C2048&ssl=1",
                            Description = "In a future where books are banned and 'firemen' burn any that are found, Guy Montag, a fireman, begins to question the society he lives in. Bradbury's haunting narrative serves as a powerful critique of censorship and the dangers of losing individuality.",
                            Genre = "Dystopian",
                            IdManager = 1,
                            Price = 8.5,
                            PublishedYear = 1953,
                            Rating = 4.2999999999999998,
                            Title = "Fahrenheit 451"
                        },
                        new
                        {
                            IdBook = 9,
                            Author = "Oscar Wilde",
                            CoverImageUrl = "https://th.bing.com/th/id/R.6b3d7883e4d845a14b9fa5449fd7b372?rik=zglji8HCqO1tkw&riu=http%3a%2f%2fwww.simbasible.com%2fwp-content%2fuploads%2f2019%2f05%2f22-2.jpg&ehk=0tVKfhqMR5v3IZQNu0TS5hdhBqsStZ4T545zodaRz3U%3d&risl=&pid=ImgRaw&r=0",
                            Description = "A cautionary tale about the dangers of vanity and moral decay, the story follows Dorian Gray, a young man who wishes to remain forever young while a portrait of him ages in his stead. Wilde's novel explores themes of beauty, art, and the superficial nature of society.",
                            Genre = "Philosophical",
                            IdManager = 1,
                            Price = 10.0,
                            PublishedYear = 1890,
                            Rating = 4.7000000000000002,
                            Title = "The Picture of Dorian Gray"
                        },
                        new
                        {
                            IdBook = 10,
                            Author = "Charlotte Brontë",
                            CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1692725440i/197321006.jpg",
                            Description = "This novel follows the life of Jane Eyre, an orphaned girl who overcomes hardship and finds love with the mysterious Mr. Rochester. Brontë's exploration of themes like independence, morality, and the struggle for self-respect makes this a timeless classic.",
                            Genre = "Romance",
                            IdManager = 1,
                            Price = 9.0,
                            PublishedYear = 1847,
                            Rating = 4.5,
                            Title = "Jane Eyre"
                        });
                });

            modelBuilder.Entity("Library_management_system_API.Models.BooksLikes", b =>
                {
                    b.Property<int>("IdOfLikeB")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdOfLikeB"));

                    b.Property<int>("IdBook")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.HasKey("IdOfLikeB");

                    b.HasIndex("IdBook");

                    b.HasIndex("IdClient");

                    b.ToTable("BooksLikes");
                });

            modelBuilder.Entity("Library_management_system_API.Models.BooksPurchased", b =>
                {
                    b.Property<int>("IdOfPurchase")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdOfPurchase"));

                    b.Property<int>("IdBook")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.HasKey("IdOfPurchase");

                    b.HasIndex("IdBook");

                    b.HasIndex("IdClient");

                    b.ToTable("BooksPurchased");

                    b.HasData(
                        new
                        {
                            IdOfPurchase = 1,
                            IdBook = 2,
                            IdClient = 1
                        },
                        new
                        {
                            IdOfPurchase = 2,
                            IdBook = 1,
                            IdClient = 2
                        });
                });

            modelBuilder.Entity("Library_management_system_API.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CartId"));

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("IdClient")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Library_management_system_API.Models.CartBooks", b =>
                {
                    b.Property<int>("CartBooksId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CartBooksId"));

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("IdBook")
                        .HasColumnType("int");

                    b.HasKey("CartBooksId");

                    b.HasIndex("CartId");

                    b.HasIndex("IdBook");

                    b.ToTable("CartBooks");
                });

            modelBuilder.Entity("Library_management_system_API.Models.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdClient"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IdManager")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdClient");

                    b.HasIndex("IdManager");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            IdClient = 1,
                            Birthday = new DateTime(1995, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "alice.smith@example.com",
                            IdManager = 1,
                            LastName = "Smith",
                            Name = "Alice",
                            Password = "password1",
                            Username = "alice95"
                        },
                        new
                        {
                            IdClient = 2,
                            Birthday = new DateTime(1990, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "bob.johnson@example.com",
                            IdManager = 1,
                            LastName = "Johnson",
                            Name = "Bob",
                            Password = "password2",
                            Username = "bob90"
                        },
                        new
                        {
                            IdClient = 3,
                            Birthday = new DateTime(1992, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "charlie.brown@example.com",
                            IdManager = 1,
                            LastName = "Brown",
                            Name = "Charlie",
                            Password = "password3",
                            Username = "charlie92"
                        },
                        new
                        {
                            IdClient = 4,
                            Birthday = new DateTime(1996, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "daisy.williams@example.com",
                            IdManager = 1,
                            LastName = "Williams",
                            Name = "Daisy",
                            Password = "password4",
                            Username = "daisy96"
                        },
                        new
                        {
                            IdClient = 5,
                            Birthday = new DateTime(1988, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "eve.davis@example.com",
                            IdManager = 1,
                            LastName = "Davis",
                            Name = "Eve",
                            Password = "password5",
                            Username = "eve88"
                        },
                        new
                        {
                            IdClient = 6,
                            Birthday = new DateTime(1991, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "frank.martinez@example.com",
                            IdManager = 1,
                            LastName = "Martinez",
                            Name = "Frank",
                            Password = "password6",
                            Username = "frank91"
                        },
                        new
                        {
                            IdClient = 7,
                            Birthday = new DateTime(1994, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "grace.garcia@example.com",
                            IdManager = 1,
                            LastName = "Garcia",
                            Name = "Grace",
                            Password = "password7",
                            Username = "grace94"
                        },
                        new
                        {
                            IdClient = 8,
                            Birthday = new DateTime(1993, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "hannah.anderson@example.com",
                            IdManager = 1,
                            LastName = "Anderson",
                            Name = "Hannah",
                            Password = "password8",
                            Username = "hannah93"
                        },
                        new
                        {
                            IdClient = 9,
                            Birthday = new DateTime(1989, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ian.thomas@example.com",
                            IdManager = 1,
                            LastName = "Thomas",
                            Name = "Ian",
                            Password = "password9",
                            Username = "ian89"
                        },
                        new
                        {
                            IdClient = 10,
                            Birthday = new DateTime(1990, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jasmine.taylor@example.com",
                            IdManager = 1,
                            LastName = "Taylor",
                            Name = "Jasmine",
                            Password = "password10",
                            Username = "jasmine90"
                        });
                });

            modelBuilder.Entity("Library_management_system_API.Models.ClientLiked", b =>
                {
                    b.Property<int>("IdOfLike")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdOfLike"));

                    b.Property<int>("IdBook")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.HasKey("IdOfLike");

                    b.HasIndex("IdBook");

                    b.HasIndex("IdClient");

                    b.ToTable("ClientLikes");
                });

            modelBuilder.Entity("Library_management_system_API.Models.Manager", b =>
                {
                    b.Property<int>("IdManager")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdManager"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdManager");

                    b.ToTable("Managers");

                    b.HasData(
                        new
                        {
                            IdManager = 1,
                            Birthday = new DateTime(1980, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admincen311@example.com",
                            LastName = "Cen311",
                            Name = "Admin",
                            Password = "admin123",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("Library_management_system_API.Models.Review", b =>
                {
                    b.Property<int>("IdOfReview")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdOfReview"));

                    b.Property<int>("IdBook")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdOfReview");

                    b.HasIndex("IdBook");

                    b.HasIndex("IdClient");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            IdOfReview = 1,
                            IdBook = 1,
                            IdClient = 1,
                            ReviewText = "A beautifully written tale that captures the essence of a lost era. Gatsby's tragic love story is haunting."
                        },
                        new
                        {
                            IdOfReview = 2,
                            IdBook = 1,
                            IdClient = 3,
                            ReviewText = "A classic that never gets old. Fitzgerald's prose is stunning, and the themes are still relevant today."
                        },
                        new
                        {
                            IdOfReview = 3,
                            IdBook = 2,
                            IdClient = 4,
                            ReviewText = "A thought-provoking novel that is just as relevant today as when it was published. A must-read for everyone."
                        },
                        new
                        {
                            IdOfReview = 4,
                            IdBook = 3,
                            IdClient = 8,
                            ReviewText = "An unforgettable story about childhood and morality. Scout and Atticus will always have a place in my heart."
                        },
                        new
                        {
                            IdOfReview = 5,
                            IdBook = 7,
                            IdClient = 2,
                            ReviewText = "A powerful story that encourages you to follow your dreams. Coelho's writing is poetic and inspiring."
                        });
                });

            modelBuilder.Entity("Library_management_system_API.Models.Book", b =>
                {
                    b.HasOne("Library_management_system_API.Models.Manager", "Manager")
                        .WithMany("Books")
                        .HasForeignKey("IdManager")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Library_management_system_API.Models.BooksLikes", b =>
                {
                    b.HasOne("Library_management_system_API.Models.Book", "Book")
                        .WithMany("BooksLikes")
                        .HasForeignKey("IdBook")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_management_system_API.Models.Client", "Client")
                        .WithMany("BooksLikes")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Library_management_system_API.Models.BooksPurchased", b =>
                {
                    b.HasOne("Library_management_system_API.Models.Book", "Book")
                        .WithMany("BooksPurchased")
                        .HasForeignKey("IdBook")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_management_system_API.Models.Client", "Client")
                        .WithMany("BooksPurchased")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Library_management_system_API.Models.Cart", b =>
                {
                    b.HasOne("Library_management_system_API.Models.Client", "Client")
                        .WithOne("Cart")
                        .HasForeignKey("Library_management_system_API.Models.Cart", "IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Library_management_system_API.Models.CartBooks", b =>
                {
                    b.HasOne("Library_management_system_API.Models.Cart", "Cart")
                        .WithMany("CartBooks")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_management_system_API.Models.Book", "Book")
                        .WithMany("CartBooks")
                        .HasForeignKey("IdBook")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("Library_management_system_API.Models.Client", b =>
                {
                    b.HasOne("Library_management_system_API.Models.Manager", "Manager")
                        .WithMany("Clients")
                        .HasForeignKey("IdManager")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Library_management_system_API.Models.ClientLiked", b =>
                {
                    b.HasOne("Library_management_system_API.Models.Book", "Book")
                        .WithMany("ClientLikes")
                        .HasForeignKey("IdBook")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_management_system_API.Models.Client", "Client")
                        .WithMany("ClientLikes")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Library_management_system_API.Models.Review", b =>
                {
                    b.HasOne("Library_management_system_API.Models.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("IdBook")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_management_system_API.Models.Client", "Client")
                        .WithMany("Reviews")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Library_management_system_API.Models.Book", b =>
                {
                    b.Navigation("BooksLikes");

                    b.Navigation("BooksPurchased");

                    b.Navigation("CartBooks");

                    b.Navigation("ClientLikes");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Library_management_system_API.Models.Cart", b =>
                {
                    b.Navigation("CartBooks");
                });

            modelBuilder.Entity("Library_management_system_API.Models.Client", b =>
                {
                    b.Navigation("BooksLikes");

                    b.Navigation("BooksPurchased");

                    b.Navigation("Cart")
                        .IsRequired();

                    b.Navigation("ClientLikes");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Library_management_system_API.Models.Manager", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Clients");
                });
#pragma warning restore 612, 618
        }
    }
}
