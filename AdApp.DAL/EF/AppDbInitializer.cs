using System.Data.Entity;
using AdApp.DAL.Entities;
using AdApp.DAL.Entities.Identity;
using AdApp.DAL.Identify;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AdApp.DAL.EF
{
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            #region add roles

            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            roleManager.Create(role1);
            roleManager.Create(role2);

            #endregion

            #region add admin

            var admin = new ApplicationUser() { Email = "fake1@mail.ru", UserName = "Peter Petrov" };
            var result = userManager.Create(admin, "123");
            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }

            var clientProfileAdmin = new ClientProfile
            {
                Id = admin.Id,
                ApplicationUser = admin,
                Name = admin.UserName
            };

            context.ClientProfiles.Add(clientProfileAdmin);

            #endregion

            #region add user

            var applicationUser1 = new ApplicationUser() { Email = "fake2@m.ru", UserName = "Ivan Ivanov" };
            var applicationUser1Result = userManager.Create(applicationUser1, "123");
            if (applicationUser1Result.Succeeded)
            {
                userManager.AddToRole(applicationUser1.Id, role2.Name);
            }

            var clientProfileUser = new ClientProfile
            {
                Id = applicationUser1.Id,
                ApplicationUser = applicationUser1,
                Name = applicationUser1.UserName
            };

            context.ClientProfiles.Add(clientProfileUser);

            #endregion

            #region add user2

            var applicationUser2 = new ApplicationUser() { Email = "fake3@m.ru", UserName = "Viktor Kirkorov" };
            var applicationUser2Result = userManager.Create(applicationUser2, "123");
            if (applicationUser2Result.Succeeded)
            {
                userManager.AddToRole(applicationUser2.Id, role2.Name);
            }

            var clientProfileUser2 = new ClientProfile
            {
                Id = applicationUser2.Id,
                ApplicationUser = applicationUser2,
                Name = applicationUser2.UserName
            };

            context.ClientProfiles.Add(clientProfileUser2);

            #endregion

            #region add advert for user

            var advert1User1 = new Advert
            {
                ApplicationUser = applicationUser1,
                Title = "Selling car",
                Content = "Selling car : LADA 2112. Very good car for young people. Price: 1000$. Phone: 8934323454"
            };

            var advert2User1 = new Advert
            {
                ApplicationUser = applicationUser1,
                Title = "Selling car",
                Content = "Selling car : MAZDA 3. Very good car for best people. Price: 5000$. Phone: 85465434656"
            };

            var advert3User1 = new Advert
            {
                ApplicationUser = applicationUser1,
                Title = "Selling house",
                Content = "Selling house : Lenina street 1. Very good house. Price: 10000$. Phone: 454645634645"
            };

            context.Adverts.Add(advert1User1);
            context.Adverts.Add(advert2User1);
            context.Adverts.Add(advert3User1);

            #endregion

            #region add advert for user2

            var advert1User2 = new Advert
            {
                ApplicationUser = applicationUser2,
                Title = "2011 BMW 3 SERIES ",
                Content = "TEL 01225 705200,30 Tax, LOVELY EXAMPLE, of the 3-series Estate, this one is the Bmw 318d SE 5-dr estate model withtheir great 2.0lt diesel engine and manual gears finished in solid red,with grey cloth seats and alloy wheels,she has covered 91,000 miles with the one owner and full Bmw service history, , 6 Months RAC Warranty., P/X WELCOME AND IF YOU NEED FINANCE WE HAVE A RANGE TO SUIT YOUR NEEDS PLEASE PHONE FOR MORE DETAILS ON ( 01225 705200 ) LOCAL RATE THANKS, This Vehicle Is Located At Our Car Sales Site Which Is At Victoria Motors Old Broughton Road Melksham Wiltshire SN128BX 01225 705200"
            };

            var advert2User2 = new Advert
            {
                ApplicationUser = applicationUser2,
                Title = "2003 BMW 320D SPORT 1 FULL YEAR MOT",
                Content = @"2003 BMW 320D SPORT FOR SALE 
MOT FOR 1 FULL YEAR SEPTEMBER 2018
144000 MILES
JUST RECENTLY SERVICED OIL FUEL FILTERS ETC
NO RUST WHATSOEVER
4 EXCELLENT TYRES
DISCS AND PADS ALL GOOD
DRIVES GREAT
NO FAULTS
FIRST TO SEE WILL BUY!!
£1695 PRICED TO SELL
CONTACT 07813010791"
            };

            var advert3User2 = new Advert
            {
                ApplicationUser = applicationUser2,
                Title = "Ford S-Max 2.0 Titanium smax, s max MOT June 2018",
                Content = "Ford S-Max 2.0 TDCi 140 Titanium 5dr Full Serv Hist, MOT June 2018. Excellent Car, only changing as we are upgrading to bigger 7 seater Galaxy, as kids have got bigger. superb mpg. Great car, sorry to let go - . 9 months tax still on car & over half a tank. Ready to go. Endless extras with Top of the range Titanium model. Keyless start, Mp3 iPhone iPod USB & Aux Music Ports, Voice Control For Media Functions, Automatic Smart Key, Front and Rear Radar Parking Sensors, Bluetooth Wireless SmartPhone Connectivity, DAB Digital Radio For A Myriad Of Stations To Suit Your Mood, Cruise Control, Rain Sensing Windscreen Wipers, Manual 6-Speed Gearbox, Ice Melting & De-misting Electric Heated Windscreen, 17In Alloy Wheels, Day Running Lights, Front Fog Lights, Tinted Glass, Anti Dazzle Rear View Mirror, Stability Control System, Electronic Brake Distribution, Hydraulic Emergency Brake Assist, Isofix, Dual-Zone Climate Control, Front And Rear Electric Windows, Radio/CD Player With MP3 Compatibility, Rear Privacy Glass, Seven Seats MPV,etc etc... 2 owners, Next MOT due 18/07/2018, Full service history, Grey, £8,295"
            };

            context.Adverts.Add(advert1User2);
            context.Adverts.Add(advert2User2);
            context.Adverts.Add(advert3User2);

            #endregion

            base.Seed(context);
        }
    }
}