using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTicket.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class PasswordColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    gender = table.Column<string>( type: "nvarchar(255)", maxLength: 255, nullable: false ),
                    synopsis = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    title = table.Column<string>( type: "nvarchar(255)", maxLength: 255, nullable: false ),
                    director = table.Column<string>( type: "nvarchar(255)", maxLength: 255, nullable: false ),
                    banner_url = table.Column<string>( type: "nvarchar(200)", maxLength: 200, nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_Movies", x => x.Id );
                } );

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    email = table.Column<string>( type: "nvarchar(100)", maxLength: 100, nullable: false ),
                    password = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    is_admin = table.Column<bool>( type: "bit", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_Users", x => x.Id );
                } );

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    id = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    room = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    available_tickets = table.Column<int>( type: "int", nullable: false ),
                    date = table.Column<DateTime>( type: "datetime2", nullable: false ),
                    price = table.Column<decimal>( type: "decimal(18,2)", precision: 18, scale: 2, nullable: false ),
                    MovieId = table.Column<int>( type: "int", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_Sessions", x => x.id );
                    table.ForeignKey(
                        name: "movie_id",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade );
                } );

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    id = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    SessionId = table.Column<int>( type: "int", nullable: false ),
                    UserId = table.Column<int>( type: "int", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_Tickets", x => x.id );
                    table.ForeignKey(
                        name: "session_id",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade );
                    table.ForeignKey(
                        name: "user_id",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade );
                } );

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MovieId",
                table: "Sessions",
                column: "MovieId" );

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SessionId",
                table: "Tickets",
                column: "SessionId" );

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId" );
        }

        /// <inheritdoc />
        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DropTable(
                name: "Tickets" );

            migrationBuilder.DropTable(
                name: "Sessions" );

            migrationBuilder.DropTable(
                name: "Users" );

            migrationBuilder.DropTable(
                name: "Movies" );
        }
    }
}
