using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library_management_system_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    IdManager = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Birthday = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.IdManager);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    IdBook = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Author = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Genre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PublishedYear = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "double", precision: 10, scale: 2, nullable: false),
                    CoverImageUrl = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rating = table.Column<double>(type: "double", precision: 3, scale: 2, nullable: false),
                    IdManager = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.IdBook);
                    table.ForeignKey(
                        name: "FK_Books_Managers_IdManager",
                        column: x => x.IdManager,
                        principalTable: "Managers",
                        principalColumn: "IdManager",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Birthday = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdManager = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdClient);
                    table.ForeignKey(
                        name: "FK_Clients_Managers_IdManager",
                        column: x => x.IdManager,
                        principalTable: "Managers",
                        principalColumn: "IdManager",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BooksLikes",
                columns: table => new
                {
                    IdOfLikeB = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdBook = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksLikes", x => x.IdOfLikeB);
                    table.ForeignKey(
                        name: "FK_BooksLikes_Books_IdBook",
                        column: x => x.IdBook,
                        principalTable: "Books",
                        principalColumn: "IdBook",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksLikes_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BooksPurchased",
                columns: table => new
                {
                    IdOfPurchase = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdBook = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksPurchased", x => x.IdOfPurchase);
                    table.ForeignKey(
                        name: "FK_BooksPurchased_Books_IdBook",
                        column: x => x.IdBook,
                        principalTable: "Books",
                        principalColumn: "IdBook",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksPurchased_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdClient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClientLikes",
                columns: table => new
                {
                    IdOfLike = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdBook = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientLikes", x => x.IdOfLike);
                    table.ForeignKey(
                        name: "FK_ClientLikes_Books_IdBook",
                        column: x => x.IdBook,
                        principalTable: "Books",
                        principalColumn: "IdBook",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientLikes_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    IdOfReview = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReviewText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdBook = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.IdOfReview);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_IdBook",
                        column: x => x.IdBook,
                        principalTable: "Books",
                        principalColumn: "IdBook",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CartBooks",
                columns: table => new
                {
                    CartBooksId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    IdBook = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartBooks", x => x.CartBooksId);
                    table.ForeignKey(
                        name: "FK_CartBooks_Books_IdBook",
                        column: x => x.IdBook,
                        principalTable: "Books",
                        principalColumn: "IdBook",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartBooks_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "IdManager", "Birthday", "Email", "LastName", "Name", "Password", "Username" },
                values: new object[] { 1, new DateTime(1980, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "admincen311@example.com", "Cen311", "Admin", "admin123", "admin" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "IdBook", "Author", "CoverImageUrl", "Description", "Genre", "IdManager", "Price", "PublishedYear", "Rating", "Title" },
                values: new object[,]
                {
                    { 1, "F. Scott Fitzgerald", "https://th.bing.com/th/id/OIP.YY-2rOTwqOzDvIoBMaRluQHaLH?rs=1&pid=ImgDetMain", "Set in the Roaring Twenties, 'The Great Gatsby' tells the story of the enigmatic Jay Gatsby and his obsession with the beautiful Daisy Buchanan. It captures the decadence and excess of the era while exploring themes of love, wealth, and the American Dream.", "Classic", 1, 10.99, 1925, 4.5, "The Great Gatsby" },
                    { 2, "George Orwell", "https://kopp-medien.websale.net/bilder/gross/133206.jpg", "In a totalitarian future where the Party scrutinizes human actions with ever-watchful Big Brother, Winston Smith dares to express his thoughts and seeks a revolution against the oppressive regime. '1984' is a chilling vision of a dystopian future that warns against the perils of absolute power.", "Dystopian", 1, 9.9900000000000002, 1949, 4.7000000000000002, "1984" },
                    { 3, "Harper Lee", "https://cdn2.penguin.com.au/covers/original/9780434020485.jpg", "This Pulitzer Prize-winning novel is narrated by Scout Finch, a young girl in the racially charged South during the 1930s. It addresses the serious issues of race, class, and moral growth as Scout and her brother Jem learn valuable lessons about empathy and justice from their father, Atticus Finch.", "Classic", 1, 8.9900000000000002, 1960, 4.7999999999999998, "To Kill a Mockingbird" },
                    { 4, "Jane Austen", "https://th.bing.com/th/id/OIP.wcZjPkH4FZD5QYi_2kfxxAHaLS?rs=1&pid=ImgDetMain", "In this classic romantic comedy, Elizabeth Bennet navigates the complexities of love, family, and social standing in 19th-century England. Austen's wit and keen observations on human behavior make this novel a delightful exploration of relationships and societal expectations.", "Romance", 1, 7.9900000000000002, 1813, 4.5999999999999996, "Pride and Prejudice" },
                    { 5, "J.D. Salinger", "https://th.bing.com/th/id/R.1213a0ff91c94b884330e362841704a1?rik=zQDdn4XMYcbdsw&pid=ImgRaw&r=0", "The story of Holden Caulfield, a disenchanted teenager who has just been expelled from prep school. As he wanders New York City, he shares his thoughts on life, love, and the struggle of growing up. Salinger's novel remains a profound reflection of teenage angst and rebellion.", "Fiction", 1, 9.5, 1951, 4.2999999999999998, "The Catcher in the Rye" },
                    { 6, "J.R.R. Tolkien", "https://images.thenile.io/r1000/9780007487288.jpg", "Follow the adventure of Bilbo Baggins, a hobbit who is reluctantly swept into a quest to reclaim treasure from the dragon Smaug. This enchanting story is filled with memorable characters, adventure, and the timeless battle between good and evil, setting the stage for Tolkien's epic Middle-earth saga.", "Fantasy", 1, 12.99, 1937, 4.7999999999999998, "The Hobbit" },
                    { 7, "Paulo Coelho", "https://images.thenile.io/r1000/9780061233845.jpg", "A philosophical tale about Santiago, a shepherd boy who dreams of discovering a treasure in Egypt. Through his journey, he learns profound lessons about following one's dreams and listening to one's heart. 'The Alchemist' is a beautiful narrative that inspires readers to pursue their own destinies.", "Adventure", 1, 11.0, 1988, 4.5999999999999996, "The Alchemist" },
                    { 8, "Ray Bradbury", "https://i0.wp.com/www.bookishelf.com/wp-content/uploads/2020/06/Book-Review-Fahrenheit-451-by-Ray-Bradbury.jpg?resize=1332%2C2048&ssl=1", "In a future where books are banned and 'firemen' burn any that are found, Guy Montag, a fireman, begins to question the society he lives in. Bradbury's haunting narrative serves as a powerful critique of censorship and the dangers of losing individuality.", "Dystopian", 1, 8.5, 1953, 4.2999999999999998, "Fahrenheit 451" },
                    { 9, "Oscar Wilde", "https://th.bing.com/th/id/R.6b3d7883e4d845a14b9fa5449fd7b372?rik=zglji8HCqO1tkw&riu=http%3a%2f%2fwww.simbasible.com%2fwp-content%2fuploads%2f2019%2f05%2f22-2.jpg&ehk=0tVKfhqMR5v3IZQNu0TS5hdhBqsStZ4T545zodaRz3U%3d&risl=&pid=ImgRaw&r=0", "A cautionary tale about the dangers of vanity and moral decay, the story follows Dorian Gray, a young man who wishes to remain forever young while a portrait of him ages in his stead. Wilde's novel explores themes of beauty, art, and the superficial nature of society.", "Philosophical", 1, 10.0, 1890, 4.7000000000000002, "The Picture of Dorian Gray" },
                    { 10, "Charlotte Brontë", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1692725440i/197321006.jpg", "This novel follows the life of Jane Eyre, an orphaned girl who overcomes hardship and finds love with the mysterious Mr. Rochester. Brontë's exploration of themes like independence, morality, and the struggle for self-respect makes this a timeless classic.", "Romance", 1, 9.0, 1847, 4.5, "Jane Eyre" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "IdClient", "Birthday", "Email", "IdManager", "LastName", "Name", "Password", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(1995, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice.smith@example.com", 1, "Smith", "Alice", "password1", "alice95" },
                    { 2, new DateTime(1990, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.johnson@example.com", 1, "Johnson", "Bob", "password2", "bob90" },
                    { 3, new DateTime(1992, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "charlie.brown@example.com", 1, "Brown", "Charlie", "password3", "charlie92" },
                    { 4, new DateTime(1996, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "daisy.williams@example.com", 1, "Williams", "Daisy", "password4", "daisy96" },
                    { 5, new DateTime(1988, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "eve.davis@example.com", 1, "Davis", "Eve", "password5", "eve88" },
                    { 6, new DateTime(1991, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "frank.martinez@example.com", 1, "Martinez", "Frank", "password6", "frank91" },
                    { 7, new DateTime(1994, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "grace.garcia@example.com", 1, "Garcia", "Grace", "password7", "grace94" },
                    { 8, new DateTime(1993, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "hannah.anderson@example.com", 1, "Anderson", "Hannah", "password8", "hannah93" },
                    { 9, new DateTime(1989, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ian.thomas@example.com", 1, "Thomas", "Ian", "password9", "ian89" },
                    { 10, new DateTime(1990, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "jasmine.taylor@example.com", 1, "Taylor", "Jasmine", "password10", "jasmine90" }
                });

            migrationBuilder.InsertData(
                table: "BooksPurchased",
                columns: new[] { "IdOfPurchase", "IdBook", "IdClient" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "IdOfReview", "IdBook", "IdClient", "ReviewText" },
                values: new object[,]
                {
                    { 1, 1, 1, "A beautifully written tale that captures the essence of a lost era. Gatsby's tragic love story is haunting." },
                    { 2, 1, 3, "A classic that never gets old. Fitzgerald's prose is stunning, and the themes are still relevant today." },
                    { 3, 2, 4, "A thought-provoking novel that is just as relevant today as when it was published. A must-read for everyone." },
                    { 4, 3, 8, "An unforgettable story about childhood and morality. Scout and Atticus will always have a place in my heart." },
                    { 5, 7, 2, "A powerful story that encourages you to follow your dreams. Coelho's writing is poetic and inspiring." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_IdManager",
                table: "Books",
                column: "IdManager");

            migrationBuilder.CreateIndex(
                name: "IX_BooksLikes_IdBook",
                table: "BooksLikes",
                column: "IdBook");

            migrationBuilder.CreateIndex(
                name: "IX_BooksLikes_IdClient",
                table: "BooksLikes",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_BooksPurchased_IdBook",
                table: "BooksPurchased",
                column: "IdBook");

            migrationBuilder.CreateIndex(
                name: "IX_BooksPurchased_IdClient",
                table: "BooksPurchased",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_CartBooks_CartId",
                table: "CartBooks",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartBooks_IdBook",
                table: "CartBooks",
                column: "IdBook");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_IdClient",
                table: "Carts",
                column: "IdClient",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientLikes_IdBook",
                table: "ClientLikes",
                column: "IdBook");

            migrationBuilder.CreateIndex(
                name: "IX_ClientLikes_IdClient",
                table: "ClientLikes",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_IdManager",
                table: "Clients",
                column: "IdManager");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_IdBook",
                table: "Reviews",
                column: "IdBook");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_IdClient",
                table: "Reviews",
                column: "IdClient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksLikes");

            migrationBuilder.DropTable(
                name: "BooksPurchased");

            migrationBuilder.DropTable(
                name: "CartBooks");

            migrationBuilder.DropTable(
                name: "ClientLikes");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Managers");
        }
    }
}
