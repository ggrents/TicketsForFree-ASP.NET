using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketsForFree.Migrations
{
    /// <inheritdoc />
    public partial class fixTicketModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Tickets_TicketId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Journey");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Journey",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Journey",
                table: "Journey",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Journey_TicketId",
                table: "Reservations",
                column: "TicketId",
                principalTable: "Journey",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Journey_TicketId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Journey",
                table: "Journey");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Journey");

            migrationBuilder.RenameTable(
                name: "Journey",
                newName: "Tickets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Tickets_TicketId",
                table: "Reservations",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
