﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvenFinder.Migrations
{
    /// <inheritdoc />
    public partial class RegistirationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Registrations_EventId",
                table: "Registrations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_UserId",
                table: "Registrations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Events_EventId",
                table: "Registrations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Users_UserId",
                table: "Registrations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Events_EventId",
                table: "Registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Users_UserId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_EventId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_UserId",
                table: "Registrations");
        }
    }
}
