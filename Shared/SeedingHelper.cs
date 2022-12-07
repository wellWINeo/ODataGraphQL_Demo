using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Shared;

public static class SeedingHelper
{
    public static async Task SeedDataAsync(IServiceProvider provider)
    {
        await using var scope = provider.CreateAsyncScope();
        var context = scope.ServiceProvider.GetService<LibraryDbContext>();

        var locations = new Location[]
        {
            new() { Country = "Russia", City = "Moscow" },
            new() { Country = "Russia", City = "Saint-Petersburg" },
            new() { Country = "Russia", City = "Yekaterinburg" },
            new() { Country = "Belarus", City = "Minsk" },
            new() { Country = "Kazakhstan", City = "Almaty" },
            new() { Country = "Turkey", City = "Istanbul" },
            new() { Country = "Turkey", City = "Izmir" },
            new() { Country = "Serbia", City = "Belgrade" },
        };
        await context.AddRangeAsync(locations);
        await context.SaveChangesAsync();

        var genres = new Genre[]
        {
            new() { Name = "Fantasy" },
            new() { Name = "Science Fiction" },
            new() { Name = "Adventure" },
            new() { Name = "Romance" },
            new() { Name = "Horror" },
        };
        await context.AddRangeAsync(genres);
        await context.SaveChangesAsync();

        var authors = new Author[]
        {
            new()
            {
                FirstName = "Федор",
                MiddleName = "Михайлович",
                LastName = "Достоевский",
                BirthData = new DateOnly(1821, 10, 30),
                BirthLocation = locations[0],
                LiveLocation = locations[1],
            },
            new()
            {
                FirstName = "Михаил",
                MiddleName = "Афанасьевич",
                LastName = "Булгаков",
                BirthData = new DateOnly(1891, 5, 3),
                BirthLocation = locations[2],
                LiveLocation = locations[3],
            },
            new()
            {
                FirstName = "Александр",
                MiddleName = "Сергеевич",
                LastName = "Пушкин",
                BirthData = new DateOnly(1799, 5, 26),
                BirthLocation = locations[4],
                LiveLocation = locations[5],
            },
            new()
            {
                FirstName = "Николай",
                MiddleName = "Васильевич",
                LastName = "Гоголь",
                BirthData = new DateOnly(1809, 3, 20),
                BirthLocation = locations[6],
                LiveLocation = locations[7],
            },
        };
        await context.AddRangeAsync(authors);
        await context.SaveChangesAsync();

        var books = new Book[]
        {
            new()
            {
                Title = "Мертвые души",
                Description =
                    "Говоря о „Мертвых душах“, можно вдоволь наговориться о России», – это суждение поэта и критика П. А. Вяземского объясняет особое место поэмы Гоголя в истории русской литературы: и огромный успех у читателей, и необычайную остроту полемики вокруг главной гоголевской книги, и многообразие высказанных мнений, каждое из которых так или иначе вовлекает в размышления о природе национального мышления и культурного сознания, о настоящем и будущем России.",
                PublishedYear = 1842,
                Author = authors[3],
                Genres = new List<Genre>()
                {
                    genres[2],
                    genres[3],
                },
            },
            new()
            {
                Title = "Ревизор",
                Description =
                    "«Ревизор» — одна из лучших русских комедий. Н.В. Гоголь заставил современников смеяться над тем, к чему они привыкли и что перестали замечать. И сегодня комедия, созданная великим русским писателем, продолжая звучать современно, указывает путь к нравственному возрождению.",
                PublishedYear = 1836,
                Author = authors[3],
                Genres = new List<Genre>()
                {
                    genres[0],
                    genres[2],
                },
            },
            new()
            {
                Title = "Евгений Онегин",
                Description =
                    "Говоря о „Мертвых душах“, можно вдоволь наговориться о России», – это суждение поэта и критика П. А. Вяземского объясняет особое место поэмы Гоголя в истории русской литературы: и огромный успех у читателей, и необычайную остроту полемики вокруг главной гоголевской книги, и многообразие высказанных мнений, каждое из которых так или иначе вовлекает в размышления о природе национального мышления и культурного сознания, о настоящем и будущем России.",
                PublishedYear = 1842,
                Author = authors[3],
                Genres = new List<Genre>()
                {
                    genres[2],
                    genres[3],
                },
            },
            new()
            {
                Title = "Повести Белкин",
                Description =
                    "Цикл повестей Александра Сергеевича Пушкина, состоящий из 5 повестей и выпущенный им без указания имени настоящего автора, то есть самого Пушкина.",
                PublishedYear = 1831,
                Author = authors[2],
                Genres = new List<Genre>()
                {
                    genres[0],
                    genres[1],
                },
            },
            new()
            {
                Title = "Мастер и Маргарита",
                Description =
                    "Мастер и Маргарита - итоговое произведение выдающегося отечественного прозаика и драматурга Михаила Афанасьевича Булгакова",
                PublishedYear = 1940,
                Author = authors[1],
                Genres = new List<Genre>()
                {
                    genres[2],
                    genres[4],
                },
            },
            new()
            {
                Title = "Собачье Сердце",
                Description =
                    "«Собачье сердце» – одно из самых любимых читателями произведений Михаила Булгакова. Вас ждёт полный рассказ о необыкновенном эксперименте гениального доктора.",
                PublishedYear = 1925,
                Author = authors[1],
                Genres = new List<Genre>()
                {
                    genres[0],
                    genres[1],
                },
            },
            new()
            {
                Title = "Преступление и наказание",
                Description =
                    "«Преступление и наказание» (1866) — роман об одном преступлении. Двойное убийство, совершенное бедным студентом из-за денег. Трудно найти фабулу проще, но интеллектуальное и душевное потрясение, которое производит роман, — неизгладимо. ",
                PublishedYear = 1866,
                Author = authors[0],
                Genres = new List<Genre>()
                {
                    genres[2],
                    genres[3],
                },
            },
            new()
            {
                Title = "Село Степанчиково и его обитатели",
                Description =
                    "В повести Достоевский описывает помещичью усадьбу. Эту жизнь автор знает не понаслышке - у его отца было имение в Даровом. Однако герои в основном принадлежат к характерному для Достоевского типу - неудовлетворенные, борющиеся за лучшую жизнь и зачастую попадающие при этом в еще более тяжелые или комичные ситуации.",
                PublishedYear = 1859,
                Author = authors[0],
                Genres = new List<Genre>()
                {
                    genres[3],
                    genres[4],
                },
            },
        };
        await context.AddRangeAsync(books);
        await context.SaveChangesAsync();
    }
}