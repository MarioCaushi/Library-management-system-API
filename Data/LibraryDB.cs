using Microsoft.EntityFrameworkCore;
using Library_management_system_API.Models;

namespace Library_management_system_API.Data
{
    public class LibraryDB : DbContext
    {
        public LibraryDB(DbContextOptions<LibraryDB> options) : base(options)
        {
        }

        // Define DbSet properties for each table
        public DbSet<Book> Books { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ClientLiked> ClientLikes { get; set; }
        public DbSet<BooksPurchased> BooksPurchased { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartBooks> CartBooks { get; set; }
        public DbSet<BooksLikes> BooksLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Client)
                .WithOne(c => c.Cart)
                .HasForeignKey<Cart>(c => c.IdClient)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Book Configuration
    modelBuilder.Entity<Book>(entity =>
    {
        // Primary Key
        entity.HasKey(book => book.IdBook);

        // Properties Configuration
        entity.Property(book => book.Title)
            .IsRequired()
            .HasMaxLength(200);
        
        entity.Property(book => book.Author)
            .IsRequired()
            .HasMaxLength(100);
        
        entity.Property(book => book.Genre)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(book => book.PublishedYear)
            .IsRequired();

        entity.Property(book => book.Description)
            .IsRequired();

        entity.Property(book => book.Price)
            .HasPrecision(10, 2);

        entity.Property(book => book.CoverImageUrl)
            .HasMaxLength(500);

        entity.Property(book => book.Rating)
            .HasPrecision(3, 2);

        // Relationships

        // One-to-Many: Manager to Books
        entity.HasOne(book => book.Manager)
            .WithMany(manager => manager.Books)
            .HasForeignKey(book => book.IdManager)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many: Book to Reviews
        entity.HasMany(book => book.Reviews)
            .WithOne(review => review.Book)
            .HasForeignKey(review => review.IdBook)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many: Book to BooksPurchased
        entity.HasMany(book => book.BooksPurchased)
            .WithOne(purchase => purchase.Book)
            .HasForeignKey(purchase => purchase.IdBook)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many: Book to ClientLikes
        entity.HasMany(book => book.ClientLikes)
            .WithOne(like => like.Book)
            .HasForeignKey(like => like.IdBook)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many: Book to BooksLikes
        entity.HasMany(book => book.BooksLikes)
            .WithOne(like => like.Book)
            .HasForeignKey(like => like.IdBook)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many: Book to CartBooks
        entity.HasMany(book => book.CartBooks)
            .WithOne(cartBook => cartBook.Book)
            .HasForeignKey(cartBook => cartBook.IdBook)
            .OnDelete(DeleteBehavior.Cascade);
    });
    
    // Configure the BooksLikes entity
    modelBuilder.Entity<BooksLikes>(entity =>
    {
        entity.HasKey(bl => bl.IdOfLikeB); // Primary key

        // Configure the relationship with Client
        entity.HasOne(bl => bl.Client)
            .WithMany(c => c.BooksLikes)
            .HasForeignKey(bl => bl.IdClient)
            .OnDelete(DeleteBehavior.Cascade); // Define delete behavior

        // Configure the relationship with Book
        entity.HasOne(bl => bl.Book)
            .WithMany(b => b.BooksLikes)
            .HasForeignKey(bl => bl.IdBook)
            .OnDelete(DeleteBehavior.Cascade); // Define delete behavior
    });
    
    modelBuilder.Entity<BooksPurchased>(entity =>
    {
        entity.HasKey(bp => bp.IdOfPurchase); // Primary key

        entity.HasOne(bp => bp.Client)
            .WithMany(c => c.BooksPurchased)
            .HasForeignKey(bp => bp.IdClient)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete

        entity.HasOne(bp => bp.Book)
            .WithMany(b => b.BooksPurchased)
            .HasForeignKey(bp => bp.IdBook)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete
    });

    modelBuilder.Entity<CartBooks>(entity =>
    {
        entity.HasKey(cb => cb.CartBooksId); // Primary key

        entity.HasOne(cb => cb.Cart)
            .WithMany(c => c.CartBooks)
            .HasForeignKey(cb => cb.CartId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete

        entity.HasOne(cb => cb.Book)
            .WithMany(b => b.CartBooks)
            .HasForeignKey(cb => cb.IdBook)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete
    });

    modelBuilder.Entity<Client>(entity =>
    {
        entity.HasKey(c => c.IdClient); // Primary key

        entity.HasOne(c => c.Manager)
            .WithMany(m => m.Clients)
            .HasForeignKey(c => c.IdManager)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete

        // Relationships for navigation properties are implicitly defined through other configurations
    });

    modelBuilder.Entity<ClientLiked>(entity =>
    {
        entity.HasKey(cl => cl.IdOfLike); // Primary key

        entity.HasOne(cl => cl.Client)
            .WithMany(c => c.ClientLikes)
            .HasForeignKey(cl => cl.IdClient)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete

        entity.HasOne(cl => cl.Book)
            .WithMany(b => b.ClientLikes)
            .HasForeignKey(cl => cl.IdBook)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete
    });

    modelBuilder.Entity<Manager>(entity =>
    {
        entity.HasKey(m => m.IdManager); // Primary key

        // Navigation properties for Books and Clients are implicitly handled through relationships
    });

    modelBuilder.Entity<Review>(entity =>
    {
        entity.HasKey(r => r.IdOfReview); // Primary key

        entity.HasOne(r => r.Client)
            .WithMany(c => c.Reviews)
            .HasForeignKey(r => r.IdClient)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete

        entity.HasOne(r => r.Book)
            .WithMany(b => b.Reviews)
            .HasForeignKey(r => r.IdBook)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete
    });

    
            
            // Seed data for Manager
            modelBuilder.Entity<Manager>().HasData(
                new Manager
                {
                    IdManager = 1,
                    Name = "Admin",
                    LastName = "Cen311",
                    Email = "admincen311@example.com",
                    Birthday = new DateTime(1980, 1, 15),
                    Username = "admin",
                    Password = "admin123"
                }
            );

            // Seed data for Clients
            modelBuilder.Entity<Client>().HasData(
                new Client { IdClient = 1, Name = "Alice", LastName = "Smith", Email = "alice.smith@example.com", Birthday = new DateTime(1995, 3, 20), Username = "alice95", Password = "password1" , IdManager = 1},
                new Client { IdClient = 2, Name = "Bob", LastName = "Johnson", Email = "bob.johnson@example.com", Birthday = new DateTime(1990, 7, 30), Username = "bob90", Password = "password2", IdManager = 1 },
                new Client { IdClient = 3, Name = "Charlie", LastName = "Brown", Email = "charlie.brown@example.com", Birthday = new DateTime(1992, 11, 5), Username = "charlie92", Password = "password3" , IdManager = 1 },
                new Client { IdClient = 4, Name = "Daisy", LastName = "Williams", Email = "daisy.williams@example.com", Birthday = new DateTime(1996, 2, 14), Username = "daisy96", Password = "password4" , IdManager = 1},
                new Client { IdClient = 5, Name = "Eve", LastName = "Davis", Email = "eve.davis@example.com", Birthday = new DateTime(1988, 5, 22), Username = "eve88", Password = "password5" , IdManager = 1},
                new Client { IdClient = 6, Name = "Frank", LastName = "Martinez", Email = "frank.martinez@example.com", Birthday = new DateTime(1991, 9, 10), Username = "frank91", Password = "password6" , IdManager = 1},
                new Client { IdClient = 7, Name = "Grace", LastName = "Garcia", Email = "grace.garcia@example.com", Birthday = new DateTime(1994, 12, 25), Username = "grace94", Password = "password7" , IdManager = 1},
                new Client { IdClient = 8, Name = "Hannah", LastName = "Anderson", Email = "hannah.anderson@example.com", Birthday = new DateTime(1993, 4, 2), Username = "hannah93", Password = "password8" , IdManager = 1},
                new Client { IdClient = 9, Name = "Ian", LastName = "Thomas", Email = "ian.thomas@example.com", Birthday = new DateTime(1989, 6, 15), Username = "ian89", Password = "password9" , IdManager = 1},
                new Client { IdClient = 10, Name = "Jasmine", LastName = "Taylor", Email = "jasmine.taylor@example.com", Birthday = new DateTime(1990, 8, 28), Username = "jasmine90", Password = "password10" , IdManager = 1 }
            );

            // Seed data for Books
modelBuilder.Entity<Book>().HasData(
    new Book
    {
        IdBook = 1,
        Title = "The Great Gatsby",
        Author = "F. Scott Fitzgerald",
        Genre = "Classic",
        PublishedYear = 1925,
        Description = "Set in the Roaring Twenties, 'The Great Gatsby' tells the story of the enigmatic Jay Gatsby and his obsession with the beautiful Daisy Buchanan. It captures the decadence and excess of the era while exploring themes of love, wealth, and the American Dream.",
        Price = 10.99,
        CoverImageUrl = "https://th.bing.com/th/id/OIP.YY-2rOTwqOzDvIoBMaRluQHaLH?rs=1&pid=ImgDetMain",
        Rating = 4.5, 
        IdManager = 1
    },
    new Book
    {
        IdBook = 2,
        Title = "1984",
        Author = "George Orwell",
        Genre = "Dystopian",
        PublishedYear = 1949,
        Description = "In a totalitarian future where the Party scrutinizes human actions with ever-watchful Big Brother, Winston Smith dares to express his thoughts and seeks a revolution against the oppressive regime. '1984' is a chilling vision of a dystopian future that warns against the perils of absolute power.",
        Price = 9.99,
        CoverImageUrl = "https://kopp-medien.websale.net/bilder/gross/133206.jpg",
        Rating = 4.7, 
        IdManager = 1
    },
    new Book
    {
        IdBook = 3,
        Title = "To Kill a Mockingbird",
        Author = "Harper Lee",
        Genre = "Classic",
        PublishedYear = 1960,
        Description = "This Pulitzer Prize-winning novel is narrated by Scout Finch, a young girl in the racially charged South during the 1930s. It addresses the serious issues of race, class, and moral growth as Scout and her brother Jem learn valuable lessons about empathy and justice from their father, Atticus Finch.",
        Price = 8.99,
        CoverImageUrl = "https://cdn2.penguin.com.au/covers/original/9780434020485.jpg",
        Rating = 4.8, 
        IdManager = 1
    },
    new Book
    {
        IdBook = 4,
        Title = "Pride and Prejudice",
        Author = "Jane Austen",
        Genre = "Romance",
        PublishedYear = 1813,
        Description = "In this classic romantic comedy, Elizabeth Bennet navigates the complexities of love, family, and social standing in 19th-century England. Austen's wit and keen observations on human behavior make this novel a delightful exploration of relationships and societal expectations.",
        Price = 7.99,
        CoverImageUrl = "https://th.bing.com/th/id/OIP.wcZjPkH4FZD5QYi_2kfxxAHaLS?rs=1&pid=ImgDetMain",
        Rating = 4.6, 
        IdManager = 1
    },
    new Book
    {
        IdBook = 5,
        Title = "The Catcher in the Rye",
        Author = "J.D. Salinger",
        Genre = "Fiction",
        PublishedYear = 1951,
        Description = "The story of Holden Caulfield, a disenchanted teenager who has just been expelled from prep school. As he wanders New York City, he shares his thoughts on life, love, and the struggle of growing up. Salinger's novel remains a profound reflection of teenage angst and rebellion.",
        Price = 9.50,
        CoverImageUrl = "https://th.bing.com/th/id/R.1213a0ff91c94b884330e362841704a1?rik=zQDdn4XMYcbdsw&pid=ImgRaw&r=0",
        Rating = 4.3, 
        IdManager = 1
    },
    new Book
    {
        IdBook = 6,
        Title = "The Hobbit",
        Author = "J.R.R. Tolkien",
        Genre = "Fantasy",
        PublishedYear = 1937,
        Description = "Follow the adventure of Bilbo Baggins, a hobbit who is reluctantly swept into a quest to reclaim treasure from the dragon Smaug. This enchanting story is filled with memorable characters, adventure, and the timeless battle between good and evil, setting the stage for Tolkien's epic Middle-earth saga.",
        Price = 12.99,
        CoverImageUrl = "https://images.thenile.io/r1000/9780007487288.jpg",
        Rating = 4.8, 
        IdManager = 1
    },
    new Book
    {
        IdBook = 7,
        Title = "The Alchemist",
        Author = "Paulo Coelho",
        Genre = "Adventure",
        PublishedYear = 1988,
        Description = "A philosophical tale about Santiago, a shepherd boy who dreams of discovering a treasure in Egypt. Through his journey, he learns profound lessons about following one's dreams and listening to one's heart. 'The Alchemist' is a beautiful narrative that inspires readers to pursue their own destinies.",
        Price = 11.00,
        CoverImageUrl = "https://images.thenile.io/r1000/9780061233845.jpg",
        Rating = 4.6, 
        IdManager = 1
    },
    new Book
    {
        IdBook = 8,
        Title = "Fahrenheit 451",
        Author = "Ray Bradbury",
        Genre = "Dystopian",
        PublishedYear = 1953,
        Description = "In a future where books are banned and 'firemen' burn any that are found, Guy Montag, a fireman, begins to question the society he lives in. Bradbury's haunting narrative serves as a powerful critique of censorship and the dangers of losing individuality.",
        Price = 8.50,
        CoverImageUrl = "https://i0.wp.com/www.bookishelf.com/wp-content/uploads/2020/06/Book-Review-Fahrenheit-451-by-Ray-Bradbury.jpg?resize=1332%2C2048&ssl=1",
        Rating = 4.3, 
        IdManager = 1
    },
    new Book
    {
        IdBook = 9,
        Title = "The Picture of Dorian Gray",
        Author = "Oscar Wilde",
        Genre = "Philosophical",
        PublishedYear = 1890,
        Description = "A cautionary tale about the dangers of vanity and moral decay, the story follows Dorian Gray, a young man who wishes to remain forever young while a portrait of him ages in his stead. Wilde's novel explores themes of beauty, art, and the superficial nature of society.",
        Price = 10.00,
        CoverImageUrl = "https://th.bing.com/th/id/R.6b3d7883e4d845a14b9fa5449fd7b372?rik=zglji8HCqO1tkw&riu=http%3a%2f%2fwww.simbasible.com%2fwp-content%2fuploads%2f2019%2f05%2f22-2.jpg&ehk=0tVKfhqMR5v3IZQNu0TS5hdhBqsStZ4T545zodaRz3U%3d&risl=&pid=ImgRaw&r=0",
        Rating = 4.7, 
        IdManager = 1
    },
    new Book
    {
        IdBook = 10,
        Title = "Jane Eyre",
        Author = "Charlotte Brontë",
        Genre = "Romance",
        PublishedYear = 1847,
        Description = "This novel follows the life of Jane Eyre, an orphaned girl who overcomes hardship and finds love with the mysterious Mr. Rochester. Brontë's exploration of themes like independence, morality, and the struggle for self-respect makes this a timeless classic.",
        Price = 9.00,
        CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1692725440i/197321006.jpg",
        Rating = 4.5, 
        IdManager = 1
    }
);


modelBuilder.Entity<Review>().HasData(
    new Review
    {
        IdOfReview = 1,
        ReviewText = "A beautifully written tale that captures the essence of a lost era. Gatsby's tragic love story is haunting.",
        IdClient = 1,
        IdBook = 1
    },
    new Review
    {
        IdOfReview = 2,
        ReviewText = "A classic that never gets old. Fitzgerald's prose is stunning, and the themes are still relevant today.",
        IdClient = 3,
        IdBook = 1
    },
    new Review
    {
        IdOfReview = 3,
        ReviewText = "A thought-provoking novel that is just as relevant today as when it was published. A must-read for everyone.",
        IdClient = 4,
        IdBook = 2
    },
    new Review
    {
        IdOfReview = 4,
        ReviewText = "An unforgettable story about childhood and morality. Scout and Atticus will always have a place in my heart.",
        IdClient = 8,
        IdBook = 3
    },
    new Review
    {
        IdOfReview = 5,
        ReviewText = "A powerful story that encourages you to follow your dreams. Coelho's writing is poetic and inspiring.",
        IdClient = 2,
        IdBook = 7
    }
);

            // Seed data for BooksPurchased
            modelBuilder.Entity<BooksPurchased>().HasData(
                new BooksPurchased { IdOfPurchase = 1, IdClient = 1, IdBook = 2 },
                new BooksPurchased { IdOfPurchase = 2, IdClient = 2, IdBook = 1 }
            );
        }
    }
}
