namespace DataAccess
{
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredients> RecipeIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RecipeIngredients>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            builder.Entity<RecipeIngredients>()
                .HasOne<Recipe>(r => r.Recipe)
                .WithMany(ri => ri.RecipeIngredients)
                .HasForeignKey(r => r.RecipeId);

            builder.Entity<RecipeIngredients>()
                .HasOne<Ingredient>(i => i.Ingredient)
                .WithMany(ri => ri.RecipesIngredients)
                .HasForeignKey(i => i.IngredientId);
                
        }
    }
}
