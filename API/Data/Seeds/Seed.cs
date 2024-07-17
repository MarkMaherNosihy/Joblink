using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class Seed
{
    public static async Task SeedEmployees(DataContext context){
        if( await context.Users.OfType<Employee>().AnyAsync()) return;
        var userData = await File.ReadAllTextAsync("Data/Seeds/Employee/EmployeeSeeds.json");

        var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};

        var users = JsonSerializer.Deserialize<List<Employee>>(userData, options);

        if (users == null) return;

        foreach( var user in users){
            using var hmac = new HMACSHA512();

            user.UserName = user.UserName.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("StrongPa$$word"));
            user.PasswordSalt = hmac.Key;

            context.Users.Add(user);
        }
        await context.SaveChangesAsync();
    }

    public static async Task SeedCompanies(DataContext context){

        if( await context.Users.OfType<Company>().AnyAsync()) return;

        var userData = await File.ReadAllTextAsync("Data/Seeds/Company/CompanySeeds.json");

        var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};

        var users = JsonSerializer.Deserialize<List<Company>>(userData, options);

        if (users == null) return;

        foreach( var user in users){
            using var hmac = new HMACSHA512();

            user.UserName = user.UserName.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("StrongPa$$word"));
            user.PasswordSalt = hmac.Key;

            context.Users.Add(user);
        }
        await context.SaveChangesAsync();
    }
}
