using Starcounter;

[AddIngredientPage_json]
partial class AddIngredientPage : Page
{
    void Handle(Input.NewIngredient input)
    {
        var ingredient = new PolyjuiceBoilerplate.Ingredient();
        ingredient.Name = input.Value;
        Transaction.Commit();
    }
}

