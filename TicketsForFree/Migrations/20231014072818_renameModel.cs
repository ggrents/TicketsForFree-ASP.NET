using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketsForFree.Migrations
{
    /// <inheritdoc />
    public partial class renameModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Journey_TicketId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Reservations",
                newName: "JourneyId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_TicketId",
                table: "Reservations",
                newName: "IX_Reservations_JourneyId");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Journey",
                newName: "JourneyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Journey_JourneyId",
                table: "Reservations",
                column: "JourneyId",
                principalTable: "Journey",
                principalColumn: "JourneyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Journey_JourneyId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "JourneyId",
                table: "Reservations",
                newName: "TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_JourneyId",
                table: "Reservations",
                newName: "IX_Reservations_TicketId");

            migrationBuilder.RenameColumn(
                name: "JourneyId",
                table: "Journey",
                newName: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Journey_TicketId",
                table: "Reservations",
                column: "TicketId",
                principalTable: "Journey",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
