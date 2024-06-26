﻿using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Repositories.Implementation;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext dbContext;

    public CategoryRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Category> CreateAsync(Category category)
    {
        await dbContext.Categories.AddAsync(category);
        await dbContext.SaveChangesAsync();

        return category;
    }


    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await dbContext.Categories.ToListAsync();
    }

    //write code to get category by id from db
    public async Task<Category> GetByIdAsync(string id)
    {
        Guid categoryId;
        if (!Guid.TryParse(id, out categoryId))
        {
            // Handle invalid id here, for example, return null or throw an exception
            return null;
        }

        return await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
    }
    //write code to update category
    public async Task<Category> UpdateAsync(Category category)
    {
        dbContext.Categories.Update(category);
        await dbContext.SaveChangesAsync();

        return category;
    }
    //write code to delete category
    public async Task DeleteAsync(Category category)
    {
        dbContext.Categories.Remove(category);
        await dbContext.SaveChangesAsync();
    }
}
