using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebDevCore.Data.Migrations
{
    public partial class Addorderentity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    OrderOn = table.Column<DateTime>(nullable: false),
                    EventId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    TicketCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Order_EventureEvents_EventId",
                        column: x => x.EventId,
                        principalTable: "EventureEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_EventId",
                table: "Order",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
