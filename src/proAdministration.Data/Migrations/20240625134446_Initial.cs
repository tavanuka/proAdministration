using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace proAdministration.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostalCode = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Currency = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "DeletedAt", "IsDeleted", "PostalCode", "State", "Street" },
                values: new object[,]
                {
                    { 1, "Bad Edgar", "Deutschland", null, false, "23966", "Rheinland-Pfalz", "Hohe Str. 64b" },
                    { 2, "Kobsdorf", "Deutschland", null, false, "00532", "Baden-Württemberg", "Bertha-von-Suttner-Str. 13c" },
                    { 3, "Bad Milo", "Deutschland", null, false, "86009", "Hessen", "Spandauer Str. 51" },
                    { 4, "Neu Thiloland", "Deutschland", null, false, "53575", "Saarland", "Karlstr. 0" },
                    { 5, "Bad Danielastadt", "Deutschland", null, false, "00419", "Thüringen", "Eidechsenweg 49a" },
                    { 6, "Thorgescheid", "Deutschland", null, false, "17517", "Mecklenburg-Vorpommern", "Werkstättenstr. 98c" },
                    { 7, "Sollerburg", "Deutschland", null, false, "41848", "Mecklenburg-Vorpommern", "Martin-Luther-Str. 360" },
                    { 8, "Süd Tarja", "Deutschland", null, false, "71650", "Brandenburg", "Gabriele-Münter-Str. 85" },
                    { 9, "Bad Susanne", "Deutschland", null, false, "94812", "Bayern", "Am Kemperstiegel 2" },
                    { 10, "Süd Jonathan", "Deutschland", null, false, "25692", "Thüringen", "Paulstr. 72b" },
                    { 11, "Wesseldorf", "Deutschland", null, false, "01169", "Hamburg", "Hermann-von-Helmholtz-Str. 11c" },
                    { 12, "Süd Jenna", "Deutschland", null, false, "87359", "Berlin", "Bensberger Str. 602" },
                    { 13, "Tamialand", "Deutschland", null, false, "65201", "Bayern", "Schulstr. 09" },
                    { 14, "Süd Joelleland", "Deutschland", null, false, "27777", "Nordrhein-Westfalen", "Kapellenstr. 57a" },
                    { 15, "Tarjaburg", "Deutschland", null, false, "19243", "Sachsen", "Dünnwalder Grenzweg 96b" },
                    { 16, "Süd Susannestadt", "Deutschland", null, false, "67105", "Bayern", "Weichselstr. 45c" },
                    { 17, "Thaliastadt", "Deutschland", null, false, "73386", "Niedersachsen", "Maria-Dresen-Str. 84" },
                    { 18, "Bad Tyron", "Deutschland", null, false, "55085", "Brandenburg", "Friedrich-Naumann-Str. 3" },
                    { 19, "Bad Matteo", "Deutschland", null, false, "36328", "Bremen", "Am Hagelkreuz 71a" },
                    { 20, "Krohnland", "Deutschland", null, false, "03895", "Rheinland-Pfalz", "Ottweilerstr. 20b" },
                    { 21, "Matulastadt", "Deutschland", null, false, "03616", "Sachsen", "Helmestr. 693" },
                    { 22, "Krugerscheid", "Deutschland", null, false, "67937", "Hessen", "Bahnhofstr. 17" },
                    { 23, "Jonaburg", "Deutschland", null, false, "24440", "Sachsen-Anhalt", "Schloßstr. 5" },
                    { 24, "Williburg", "Deutschland", null, false, "21970", "Bayern", "Kaiserplatz 05b" },
                    { 25, "Bad Collinland", "Deutschland", null, false, "84463", "Saarland", "Dönhoffstr. 44c" },
                    { 26, "Ost Medine", "Deutschland", null, false, "59127", "Mecklenburg-Vorpommern", "Von-Siebold-Str. 925" },
                    { 27, "Bad Markodorf", "Deutschland", null, false, "15882", "Berlin", "Ludwig-Girtler-Str. 31" },
                    { 28, "Süd Tammo", "Deutschland", null, false, "38055", "Nordrhein-Westfalen", "Friedensstr. 80a" },
                    { 29, "Zeyenland", "Deutschland", null, false, "15521", "Thüringen", "Am Borsberg 29b" },
                    { 30, "Süd Jana", "Deutschland", null, false, "82097", "Hamburg", "Oststr. 77c" },
                    { 31, "Zinserburg", "Deutschland", null, false, "69563", "Saarland", "Heinrich-Heine-Str. 26" },
                    { 32, "Kilianland", "Deutschland", null, false, "84613", "Schleswig-Holstein", "Auf den Reien 6" },
                    { 33, "Zoestadt", "Deutschland", null, false, "23606", "Mecklenburg-Vorpommern", "Schellingstr. 13a" },
                    { 34, "Süd Jannisburg", "Deutschland", null, false, "01721", "Hamburg", "Johannes-Dott-Str. 52b" },
                    { 35, "West Janisstadt", "Deutschland", null, false, "64856", "Sachsen", "Dhünnberg 015" },
                    { 36, "Süd Sinanland", "Deutschland", null, false, "31159", "Sachsen-Anhalt", "Virchowstr. 40" },
                    { 37, "Kuhleestadt", "Deutschland", null, false, "53078", "Niedersachsen", "Löfflerstr. 9" },
                    { 38, "Küterscheid", "Deutschland", null, false, "17257", "Bremen", "Franz-Esser-Str. 37b" },
                    { 39, "Nord Lola", "Deutschland", null, false, "94723", "Rheinland-Pfalz", "Altenberger Str. 86c" },
                    { 40, "Sabrinastadt", "Deutschland", null, false, "12906", "Sachsen", "Odenthaler Str. 258" },
                    { 41, "Nord Boris", "Deutschland", null, false, "48766", "Hessen", "Hebbelstr. 73" },
                    { 42, "Alicestadt", "Deutschland", null, false, "25332", "Sachsen", "Auf dem Blahnenhof 12a" },
                    { 43, "Nord Luisstadt", "Deutschland", null, false, "18089", "Thüringen", "Saarstr. 61b" },
                    { 44, "Alishaland", "Deutschland", null, false, "88375", "Mecklenburg-Vorpommern", "In der Wüste 00c" },
                    { 45, "Süd Melisland", "Deutschland", null, false, "84178", "Nordrhein-Westfalen", "Concordiastr. 580" },
                    { 46, "Lawsland", "Deutschland", null, false, "13241", "Rheinland-Pfalz", "Unstrutstr. 9" },
                    { 47, "Baarckscheid", "Deutschland", null, false, "19983", "Nordrhein-Westfalen", "Leipziger Str. 46a" },
                    { 48, "Süd Rania", "Deutschland", null, false, "96450", "Thüringen", "Flensburger Str. 85b" },
                    { 49, "Nord Micheldorf", "Deutschland", null, false, "92643", "Saarland", "Alfred-Kubin-Str. 338" },
                    { 50, "Süd Ian", "Deutschland", null, false, "50492", "Saarland", "Niederblecher 72" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "Currency", "CustomerId", "DeletedAt", "Email", "IsDeleted", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "EUR", "214-764391", null, "business_zender28@banse-giesche.de", false, "Banse - Giesche", "+49-779-0137173" },
                    { 2, 2, "EUR", "741-913842", null, "business.lamos@scherer-gmbh.de", false, "Scherer GmbH", "+49-270-0337886" },
                    { 3, 3, "EUR", "268-151293", null, "info90@kúhnert-schwarzmeier.de", false, "Kúhnert - Schwarzmeier", "(0874) 254094553" },
                    { 4, 4, "EUR", "895-400644", null, "hr_schneider@geissler-metzner-and-jamrozy.de", false, "Geissler, Metzner and Jamrozy", "(07838) 6400316" },
                    { 5, 5, "EUR", "322-649195", null, "business.bormann@wittl-gruppe.de", false, "Wittl Gruppe", "+49-0824-08717279" },
                    { 6, 6, "EUR", "859-898547", null, "info77@riedel-dobbrunz.de", false, "Riedel - Dobbrunz", "(07866) 3012304" },
                    { 7, 7, "EUR", "386-036098", null, "business_stuermer@koderisch-voelkel-and-knorscheidt.de", false, "Koderisch, Voelkel and Knorscheidt", "(08075) 1430904" },
                    { 8, 8, "EUR", "913-285449", null, "business.niedermeier@esenwein-gmbh-co-kg.de", false, "Esenwein GmbH & Co. KG", "(0984) 883846867" },
                    { 9, 9, "EUR", "440-424990", null, "info65@unger-kustermann.de", false, "Unger - Kustermann", "+49-597-0051536" },
                    { 10, 10, "EUR", "977-672342", null, "info6@pfersich-gröss-and-lack.de", false, "Pfersich, Gröss and Lack", "(0911) 365695831" },
                    { 11, 11, "EUR", "404-911893", null, "business_fehrig48@kaczmarek-gmbh.de", false, "Kaczmarek GmbH", "+49-9525-88763559" },
                    { 12, 12, "EUR", "931-160244", null, "info_jambor@dautzenberg-sievers-and-stürmer.de", false, "Dautzenberg, Sievers and Stürmer", "(00947) 0282218" },
                    { 13, 13, "EUR", "568-309795", null, "hr14@storl-gmbh-co-kg.de", false, "Storl GmbH & Co. KG", "(00035) 0159817" },
                    { 14, 14, "EUR", "095-557147", null, "business_sander74@moser-kahl.de", false, "Moser - Kahl", "+49-076-2390593" },
                    { 15, 15, "EUR", "522-796698", null, "business.kroeger@hirschberg-emmelmann-and-walther.de", false, "Hirschberg, Emmelmann and Walther", "(00185) 5211896" },
                    { 16, 16, "EUR", "059-945049", null, "hr2@brandt-ohg.de", false, "Brandt OHG", "+49-915-9766286" },
                    { 17, 17, "EUR", "686-184590", null, "business_heinke0@schäning-ruth.de", false, "Schäning - Ruth", "+49-180-0893452" },
                    { 18, 18, "EUR", "103-432942", null, "info42@lukoschek-leide-and-agostini.de", false, "Lukoschek, Leide and Agostini", "(0122) 203414855" },
                    { 19, 19, "EUR", "630-671493", null, "info89@hackelbusch-gruppe.de", false, "Hackelbusch Gruppe", "+49-7163-52657247" },
                    { 20, 20, "EUR", "167-820844", null, "hr_streit26@balck-brehmer.de", false, "Balck - Brehmer", "(02047) 3063100" },
                    { 21, 21, "EUR", "694-069395", null, "business.just68@schembera-ohg.de", false, "Schembera OHG", "(0246) 053709639" },
                    { 22, 22, "EUR", "221-217746", null, "info_taechl@könig-oeser.de", false, "König - Oeser", "(0628) 727786836" },
                    { 23, 23, "EUR", "758-456298", null, "hr_brehmer@gehring-kinzy-and-knorr.de", false, "Gehring, Kinzy and Knorr", "(02284) 8093798" },
                    { 24, 24, "EUR", "285-605649", null, "business.welsch95@wischer-ag.de", false, "Wischer AG", "+49-3607-04095514" },
                    { 25, 25, "EUR", "712-844190", null, "info_krohn@rheder-zahn.de", false, "Rheder - Zahn", "(04391) 9271641" },
                    { 26, 26, "EUR", "349-192541", null, "info79@kochan-schersing-and-küter.de", false, "Kochan, Schersing and Küter", "(0332) 231222770" },
                    { 27, 27, "EUR", "876-331093", null, "business_laux21@erm-kg.de", false, "Erm KG", "+49-474-4543814" },
                    { 28, 28, "EUR", "303-580444", null, "info_bayer@ullrich-hermecke.de", false, "Ullrich - Hermecke", "+49-341-5778450" },
                    { 29, 29, "EUR", "830-729895", null, "hr5@petzold-büchele-and-martel.de", false, "Petzold, Büchele and Martel", "+49-4569-81518654" },
                    { 30, 30, "EUR", "367-977346", null, "business_bozsik47@jungbluth-tasche.de", false, "Jungbluth - Tasche", "+49-498-2056872" },
                    { 31, 31, "EUR", "994-126798", null, "hr_prediger@dauer-plotzitzka-and-wallstab.de", false, "Dauer, Plotzitzka and Wallstab", "(0539) 428745810" },
                    { 32, 32, "EUR", "421-365249", null, "hr.clarius@stifel-kg.de", false, "Stifel KG", "(08570) 6428145" },
                    { 33, 33, "EUR", "958-613690", null, "business63@mordhorst-ganzmann.de", false, "Mordhorst - Ganzmann", "+49-450-2955973" },
                    { 34, 34, "EUR", "475-852141", null, "business15@hingst-alexander-and-ade.de", false, "Hingst, Alexander and Ade", "(0543) 179031794" },
                    { 35, 35, "EUR", "002-001503", null, "info_poser@bozsik-ug.de", false, "Bozsik UG", "+49-668-4492100" },
                    { 36, 36, "EUR", "539-240054", null, "hr51@schäfer-mathiszik.de", false, "Schäfer - Mathiszik", "+49-3626-60626894" },
                    { 37, 37, "EUR", "066-498405", null, "info41@loy-honz-and-bohge.de", false, "Loy, Honz and Bohge", "+49-6679-29337678" },
                    { 38, 38, "EUR", "593-637956", null, "info_geissler@haaf-gmbh.de", false, "Haaf GmbH", "+49-5708-14349620" },
                    { 39, 39, "EUR", "120-886308", null, "hr38@bahl-tächl.de", false, "Bahl - Tächl", "(01749) 4565648" },
                    { 40, 40, "EUR", "657-025859", null, "business.gutschank67@schedler-gmbh-co-kg.de", false, "Schedler GmbH & Co. KG", "+49-7816-70623452" },
                    { 41, 41, "EUR", "184-373200", null, "info_schulze9@köhrbrück-krol.de", false, "Köhrbrück - Krol", "(07129) 9378108" },
                    { 42, 42, "EUR", "611-512751", null, "business51@gebhardt-gotz-and-küsters.de", false, "Gebhardt, Gotz and Küsters", "(0853) 107850719" },
                    { 43, 43, "EUR", "148-761102", null, "business88@winkelmann-gmbh.de", false, "Winkelmann GmbH", "+49-6895-32091934" },
                    { 44, 44, "EUR", "775-900654", null, "info_hudak35@reus-schönebeck.de", false, "Reus - Schönebeck", "(08366) 4408797" },
                    { 45, 45, "EUR", "202-158005", null, "info77@knorscheidt-mohr-and-marquart.de", false, "Knorscheidt, Mohr and Marquart", "+49-8778-57146593" },
                    { 46, 46, "EUR", "739-397556", null, "business75@erdmann-gruppe.de", false, "Erdmann Gruppe", "(0591) 917121412" },
                    { 47, 47, "EUR", "266-546907", null, "info.umlauft61@uhrig-duma.de", false, "Uhrig - Duma", "(0950) 394373859" },
                    { 48, 48, "EUR", "893-885459", null, "hr3@paukner-wakan-and-newton.de", false, "Paukner, Wakan and Newton", "+49-9916-18432487" },
                    { 49, 49, "EUR", "310-033800", null, "business63@jossa-rittweg.de", false, "Jossa - Rittweg", "(03023) 8215000" },
                    { 50, 50, "EUR", "847-272351", null, "hr88@danner-kühnel-and-adam.de", false, "Danner, Kühnel and Adam", "+49-0641-44669633" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
