using EFitnessMonitoring.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace EFitnessMonitoring.Models
{
    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, int> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStoreIntPk(context.Get<FitnessDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 8,
                // RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser, int>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser, int>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            //manager.EmailService = new EmailService();
            //manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, int>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }

    public class ApplicationRoleManager : RoleManager<RoleIntPk, int>
    {
        public ApplicationRoleManager(IRoleStore<RoleIntPk, int> roleStore)
            : base(roleStore) { }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<RoleIntPk, int, UserRoleIntPk>(context.Get<FitnessDbContext>()));
        }
    }

    public class AppDbInitializer : CreateDatabaseIfNotExists<FitnessDbContext>
    {
        protected override void Seed(FitnessDbContext context)
        {
            ApplicationUserManager userManager = new ApplicationUserManager(new UserStoreIntPk(context));


            var roleManager = new ApplicationRoleManager(new RoleStoreIntPk(context));

            //CREEZ DOUA ROLURI
            var role1 = new RoleIntPk { Name = "admin", Id = 1 };
            var role2 = new RoleIntPk { Name = "User", Id = 2 };
            var role3 = new RoleIntPk { Name = "antrenor", Id = 3 };
            var role4 = new RoleIntPk { Name = "moderator", Id = 4 };

            //Adaugsam rolurile in DB
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);
            roleManager.Create(role4);

            // muschi
            context.ClasaMuschis.Add(new ClasaMuschi { Id_muschi = 1, Nume_Muschi = "Antebraț" });
            context.ClasaMuschis.Add(new ClasaMuschi { Id_muschi = 2, Nume_Muschi = "Spate" });
            context.ClasaMuschis.Add(new ClasaMuschi { Id_muschi = 3, Nume_Muschi = "Triceps" });
            context.ClasaMuschis.Add(new ClasaMuschi { Id_muschi = 4, Nume_Muschi = "Cvadriceps" });
            context.ClasaMuschis.Add(new ClasaMuschi { Id_muschi = 5, Nume_Muschi = "Gastrocnemius" });
            context.ClasaMuschis.Add(new ClasaMuschi { Id_muschi = 6, Nume_Muschi = "Umeri" });
            context.ClasaMuschis.Add(new ClasaMuschi { Id_muschi = 7, Nume_Muschi = "Piept" });
            context.ClasaMuschis.Add(new ClasaMuschi { Id_muschi = 8, Nume_Muschi = "Biceps" });
            context.ClasaMuschis.Add(new ClasaMuschi { Id_muschi = 9, Nume_Muschi = "Abdomen" });

            //Domeniu antrenamente
            context.DomeniuAntrenamentes.Add(new DomeniuAntrenamente { Id_antrenament = 1, Nume_antrenament = "Creștere greutate" });
            context.DomeniuAntrenamentes.Add(new DomeniuAntrenamente { Id_antrenament = 2, Nume_antrenament = "Scădere greutate" });

            //Domeniu santate
            context.DomeniuSanatates.Add(new DomeniuSanatate { Id_categorie = 1, Nume_categorie = "Sănătate" });
            context.DomeniuSanatates.Add(new DomeniuSanatate { Id_categorie = 2, Nume_categorie = "Nutriție" });

            //Categorie Produs
            context.ProduseCategories.Add(new ProduseCategory { Id_category = 1, NumeCategorie = "brățări fitness" });
            context.ProduseCategories.Add(new ProduseCategory { Id_category = 2, NumeCategorie = "proteine" });
            context.ProduseCategories.Add(new ProduseCategory { Id_category = 3, NumeCategorie = "aerobică" });
            //cream utilizator
            var admin = new ApplicationUser {Email = "mihailascu@gmail.com", UserName = "admin", Gen = "Masculin", Virsta = 21 };
            string parola = "Me-12345";
            var result = userManager.Create(admin, parola);

            //daca crearea utilizator a avut loc cu sucecs
            if (result.Succeeded)
            {
                //adauga rolul pentru utilizator
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
                userManager.AddToRole(admin.Id, role3.Name);
            }

            base.Seed(context);
        }
    }
}