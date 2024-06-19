using CodePulse.API.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);

        Task<IEnumerable<Category>> GetAllAsync();
        //write a method for GetCategoryById
        Task<Category> GetByIdAsync(string id);
        //write a method for UpdateCategory
        Task<Category>? UpdateAsync(Category category);
        //write a method for DeleteCategory
        Task DeleteAsync(Category category);


    }
}
