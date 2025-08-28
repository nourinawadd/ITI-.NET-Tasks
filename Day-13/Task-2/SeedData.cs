using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Task_2.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

            // 1) Ensure roles
            string[] roles = { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    var created = await roleManager.CreateAsync(new IdentityRole(role));
                    if (!created.Succeeded)
                        throw new Exception($"Failed to create role '{role}': " +
                                            string.Join(", ", created.Errors.Select(e => e.Description)));
                }
            }

            // 2) Admin user
            var adminEmail = "admin@hotmail.com";
            var admin = await userManager.FindByEmailAsync(adminEmail);
            if (admin == null)
            {
                admin = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                var createAdmin = await userManager.CreateAsync(admin, "Admin@123");
                if (!createAdmin.Succeeded)
                    throw new Exception("Failed to create admin: " +
                        string.Join(", ", createAdmin.Errors.Select(e => e.Description)));

                var addAdminRole = await userManager.AddToRoleAsync(admin, "Admin");
                if (!addAdminRole.Succeeded)
                    throw new Exception("Failed to add Admin role: " +
                        string.Join(", ", addAdminRole.Errors.Select(e => e.Description)));
            }

            // 3) Normal user
            var userEmail = "user@hotmail.com";
            var user = await userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = userEmail,
                    Email = userEmail,
                    EmailConfirmed = true
                };
                var createUser = await userManager.CreateAsync(user, "User@123");
                if (!createUser.Succeeded)
                    throw new Exception("Failed to create user: " +
                        string.Join(", ", createUser.Errors.Select(e => e.Description)));

                var addUserRole = await userManager.AddToRoleAsync(user, "User");
                if (!addUserRole.Succeeded)
                    throw new Exception("Failed to add User role: " +
                        string.Join(", ", addUserRole.Errors.Select(e => e.Description)));
            }
        }
    }
}
