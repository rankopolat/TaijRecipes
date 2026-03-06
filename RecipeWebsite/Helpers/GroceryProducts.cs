namespace RecipeWebsite.Helpers;

public class GroceryProduct
{
    public string Name { get; set; } = "";
    public string Category { get; set; } = "";
    public decimal Price { get; set; }
    public string Unit { get; set; } = "";
    public string Size { get; set; } = "";

    public string DisplayPrice => $"${Price:F2}";
    public string DisplayInfo => string.IsNullOrEmpty(Size) ? DisplayPrice : $"{Size} - {DisplayPrice}";
}

public static class GroceryProducts
{
    public static readonly GroceryProduct[] All = new[]
    {
        // === MEAT & POULTRY ===
        new GroceryProduct { Name = "Chicken Breast", Category = "Meat", Price = 11.00m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Chicken Thigh", Category = "Meat", Price = 8.50m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Chicken Drumsticks", Category = "Meat", Price = 5.50m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Chicken Mince", Category = "Meat", Price = 10.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Whole Chicken", Category = "Meat", Price = 7.50m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Beef Mince", Category = "Meat", Price = 12.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Beef Steak Scotch Fillet", Category = "Meat", Price = 40.00m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Beef Rump Steak", Category = "Meat", Price = 22.00m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Beef Chuck Steak", Category = "Meat", Price = 16.00m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Beef Sausages", Category = "Meat", Price = 8.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Lamb Chops", Category = "Meat", Price = 22.00m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Lamb Mince", Category = "Meat", Price = 14.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Lamb Leg Roast", Category = "Meat", Price = 16.00m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Pork Chops", Category = "Meat", Price = 12.00m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Pork Belly", Category = "Meat", Price = 15.00m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Pork Mince", Category = "Meat", Price = 10.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Bacon Rashers", Category = "Meat", Price = 6.50m, Unit = "200g", Size = "200g" },
        new GroceryProduct { Name = "Bacon Short Cut", Category = "Meat", Price = 7.00m, Unit = "250g", Size = "250g" },
        new GroceryProduct { Name = "Prosciutto", Category = "Meat", Price = 7.00m, Unit = "100g", Size = "100g" },

        // === SEAFOOD ===
        new GroceryProduct { Name = "Salmon Fillet", Category = "Seafood", Price = 14.00m, Unit = "200g", Size = "200g" },
        new GroceryProduct { Name = "Barramundi Fillet", Category = "Seafood", Price = 15.00m, Unit = "200g", Size = "200g" },
        new GroceryProduct { Name = "Prawns Raw", Category = "Seafood", Price = 18.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Prawns Cooked", Category = "Seafood", Price = 20.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Tuna Steak", Category = "Seafood", Price = 16.00m, Unit = "200g", Size = "200g" },
        new GroceryProduct { Name = "Fish Fillets Crumbed", Category = "Seafood", Price = 8.50m, Unit = "400g", Size = "400g" },
        new GroceryProduct { Name = "Calamari Rings", Category = "Seafood", Price = 12.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Mussels", Category = "Seafood", Price = 7.00m, Unit = "1kg", Size = "1kg" },
        new GroceryProduct { Name = "Canned Tuna", Category = "Seafood", Price = 1.85m, Unit = "95g", Size = "95g" },
        new GroceryProduct { Name = "Canned Salmon", Category = "Seafood", Price = 3.50m, Unit = "210g", Size = "210g" },

        // === DAIRY & EGGS ===
        new GroceryProduct { Name = "Full Cream Milk", Category = "Dairy", Price = 1.60m, Unit = "1L", Size = "1L" },
        new GroceryProduct { Name = "Full Cream Milk 2L", Category = "Dairy", Price = 2.90m, Unit = "2L", Size = "2L" },
        new GroceryProduct { Name = "Skim Milk", Category = "Dairy", Price = 1.60m, Unit = "1L", Size = "1L" },
        new GroceryProduct { Name = "Butter", Category = "Dairy", Price = 5.50m, Unit = "250g", Size = "250g" },
        new GroceryProduct { Name = "Unsalted Butter", Category = "Dairy", Price = 5.50m, Unit = "250g", Size = "250g" },
        new GroceryProduct { Name = "Thickened Cream", Category = "Dairy", Price = 3.50m, Unit = "300ml", Size = "300ml" },
        new GroceryProduct { Name = "Sour Cream", Category = "Dairy", Price = 2.80m, Unit = "300ml", Size = "300ml" },
        new GroceryProduct { Name = "Greek Yoghurt", Category = "Dairy", Price = 5.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Natural Yoghurt", Category = "Dairy", Price = 3.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Cheddar Cheese Block", Category = "Dairy", Price = 8.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Cheddar Cheese Shredded", Category = "Dairy", Price = 7.50m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Parmesan Cheese", Category = "Dairy", Price = 7.00m, Unit = "250g", Size = "250g" },
        new GroceryProduct { Name = "Mozzarella Cheese", Category = "Dairy", Price = 5.50m, Unit = "250g", Size = "250g" },
        new GroceryProduct { Name = "Cream Cheese", Category = "Dairy", Price = 3.80m, Unit = "250g", Size = "250g" },
        new GroceryProduct { Name = "Feta Cheese", Category = "Dairy", Price = 5.00m, Unit = "200g", Size = "200g" },
        new GroceryProduct { Name = "Halloumi", Category = "Dairy", Price = 6.00m, Unit = "200g", Size = "200g" },
        new GroceryProduct { Name = "Ricotta", Category = "Dairy", Price = 4.00m, Unit = "250g", Size = "250g" },
        new GroceryProduct { Name = "Eggs Free Range 12pk", Category = "Dairy", Price = 6.50m, Unit = "12 pack", Size = "12 pack" },
        new GroceryProduct { Name = "Eggs Cage Free 12pk", Category = "Dairy", Price = 5.00m, Unit = "12 pack", Size = "12 pack" },

        // === FRUIT ===
        new GroceryProduct { Name = "Bananas", Category = "Fruit", Price = 3.90m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Apples Royal Gala", Category = "Fruit", Price = 4.50m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Apples Granny Smith", Category = "Fruit", Price = 4.50m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Oranges", Category = "Fruit", Price = 4.00m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Lemons", Category = "Fruit", Price = 1.20m, Unit = "each", Size = "each" },
        new GroceryProduct { Name = "Limes", Category = "Fruit", Price = 1.00m, Unit = "each", Size = "each" },
        new GroceryProduct { Name = "Avocado", Category = "Fruit", Price = 2.50m, Unit = "each", Size = "each" },
        new GroceryProduct { Name = "Strawberries", Category = "Fruit", Price = 4.50m, Unit = "250g", Size = "250g punnet" },
        new GroceryProduct { Name = "Blueberries", Category = "Fruit", Price = 5.00m, Unit = "125g", Size = "125g punnet" },
        new GroceryProduct { Name = "Raspberries", Category = "Fruit", Price = 5.50m, Unit = "125g", Size = "125g punnet" },
        new GroceryProduct { Name = "Mango", Category = "Fruit", Price = 3.00m, Unit = "each", Size = "each" },
        new GroceryProduct { Name = "Pineapple", Category = "Fruit", Price = 4.00m, Unit = "each", Size = "each" },
        new GroceryProduct { Name = "Watermelon", Category = "Fruit", Price = 8.00m, Unit = "whole", Size = "whole" },
        new GroceryProduct { Name = "Grapes", Category = "Fruit", Price = 5.50m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Pear", Category = "Fruit", Price = 4.50m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Kiwi Fruit", Category = "Fruit", Price = 0.80m, Unit = "each", Size = "each" },

        // === VEGETABLES ===
        new GroceryProduct { Name = "Onion Brown", Category = "Vegetables", Price = 2.50m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Onion Red", Category = "Vegetables", Price = 4.00m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Spring Onion", Category = "Vegetables", Price = 2.00m, Unit = "bunch", Size = "bunch" },
        new GroceryProduct { Name = "Garlic", Category = "Vegetables", Price = 1.50m, Unit = "each", Size = "each bulb" },
        new GroceryProduct { Name = "Ginger", Category = "Vegetables", Price = 25.00m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Potato", Category = "Vegetables", Price = 3.50m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Sweet Potato", Category = "Vegetables", Price = 4.50m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Carrot", Category = "Vegetables", Price = 2.00m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Celery", Category = "Vegetables", Price = 3.50m, Unit = "bunch", Size = "bunch" },
        new GroceryProduct { Name = "Broccoli", Category = "Vegetables", Price = 3.90m, Unit = "each", Size = "each head" },
        new GroceryProduct { Name = "Cauliflower", Category = "Vegetables", Price = 4.50m, Unit = "each", Size = "each head" },
        new GroceryProduct { Name = "Capsicum Red", Category = "Vegetables", Price = 3.00m, Unit = "each", Size = "each" },
        new GroceryProduct { Name = "Capsicum Green", Category = "Vegetables", Price = 2.00m, Unit = "each", Size = "each" },
        new GroceryProduct { Name = "Tomato", Category = "Vegetables", Price = 5.50m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Cherry Tomatoes", Category = "Vegetables", Price = 4.50m, Unit = "250g", Size = "250g punnet" },
        new GroceryProduct { Name = "Zucchini", Category = "Vegetables", Price = 5.00m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Eggplant", Category = "Vegetables", Price = 5.00m, Unit = "each", Size = "each" },
        new GroceryProduct { Name = "Mushrooms Cup", Category = "Vegetables", Price = 5.50m, Unit = "200g", Size = "200g punnet" },
        new GroceryProduct { Name = "Mushrooms Flat", Category = "Vegetables", Price = 9.00m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Spinach Baby", Category = "Vegetables", Price = 3.50m, Unit = "120g", Size = "120g bag" },
        new GroceryProduct { Name = "Lettuce Iceberg", Category = "Vegetables", Price = 3.00m, Unit = "each", Size = "each" },
        new GroceryProduct { Name = "Mixed Salad Leaves", Category = "Vegetables", Price = 3.50m, Unit = "120g", Size = "120g bag" },
        new GroceryProduct { Name = "Cucumber", Category = "Vegetables", Price = 2.00m, Unit = "each", Size = "each" },
        new GroceryProduct { Name = "Corn Cob", Category = "Vegetables", Price = 1.50m, Unit = "each", Size = "each" },
        new GroceryProduct { Name = "Peas Frozen", Category = "Vegetables", Price = 2.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Green Beans", Category = "Vegetables", Price = 5.00m, Unit = "250g", Size = "250g" },
        new GroceryProduct { Name = "Pumpkin", Category = "Vegetables", Price = 2.50m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Chilli Red", Category = "Vegetables", Price = 30.00m, Unit = "kg", Size = "per kg" },
        new GroceryProduct { Name = "Coriander Fresh", Category = "Vegetables", Price = 2.00m, Unit = "bunch", Size = "bunch" },
        new GroceryProduct { Name = "Basil Fresh", Category = "Vegetables", Price = 3.50m, Unit = "bunch", Size = "bunch" },
        new GroceryProduct { Name = "Parsley Fresh", Category = "Vegetables", Price = 2.50m, Unit = "bunch", Size = "bunch" },
        new GroceryProduct { Name = "Mint Fresh", Category = "Vegetables", Price = 2.50m, Unit = "bunch", Size = "bunch" },
        new GroceryProduct { Name = "Rosemary Fresh", Category = "Vegetables", Price = 3.00m, Unit = "bunch", Size = "bunch" },
        new GroceryProduct { Name = "Thyme Fresh", Category = "Vegetables", Price = 3.00m, Unit = "bunch", Size = "bunch" },

        // === BAKERY & BREAD ===
        new GroceryProduct { Name = "White Bread Sliced", Category = "Bakery", Price = 2.40m, Unit = "loaf", Size = "650g" },
        new GroceryProduct { Name = "Wholemeal Bread", Category = "Bakery", Price = 3.00m, Unit = "loaf", Size = "650g" },
        new GroceryProduct { Name = "Sourdough Bread", Category = "Bakery", Price = 5.50m, Unit = "loaf", Size = "loaf" },
        new GroceryProduct { Name = "Turkish Bread", Category = "Bakery", Price = 4.00m, Unit = "loaf", Size = "loaf" },
        new GroceryProduct { Name = "Wraps Tortilla", Category = "Bakery", Price = 3.50m, Unit = "8 pack", Size = "8 pack" },
        new GroceryProduct { Name = "Pita Bread", Category = "Bakery", Price = 3.00m, Unit = "5 pack", Size = "5 pack" },
        new GroceryProduct { Name = "Burger Buns", Category = "Bakery", Price = 3.50m, Unit = "6 pack", Size = "6 pack" },
        new GroceryProduct { Name = "Breadcrumbs", Category = "Bakery", Price = 2.50m, Unit = "200g", Size = "200g" },
        new GroceryProduct { Name = "Panko Breadcrumbs", Category = "Bakery", Price = 3.50m, Unit = "200g", Size = "200g" },

        // === PANTRY STAPLES ===
        new GroceryProduct { Name = "Olive Oil Extra Virgin", Category = "Pantry", Price = 8.00m, Unit = "500ml", Size = "500ml" },
        new GroceryProduct { Name = "Olive Oil", Category = "Pantry", Price = 7.00m, Unit = "500ml", Size = "500ml" },
        new GroceryProduct { Name = "Vegetable Oil", Category = "Pantry", Price = 4.00m, Unit = "1L", Size = "1L" },
        new GroceryProduct { Name = "Canola Oil", Category = "Pantry", Price = 4.50m, Unit = "1L", Size = "1L" },
        new GroceryProduct { Name = "Sesame Oil", Category = "Pantry", Price = 4.50m, Unit = "200ml", Size = "200ml" },
        new GroceryProduct { Name = "Coconut Oil", Category = "Pantry", Price = 6.00m, Unit = "300ml", Size = "300ml" },
        new GroceryProduct { Name = "Soy Sauce", Category = "Pantry", Price = 3.00m, Unit = "250ml", Size = "250ml" },
        new GroceryProduct { Name = "Fish Sauce", Category = "Pantry", Price = 3.50m, Unit = "200ml", Size = "200ml" },
        new GroceryProduct { Name = "Oyster Sauce", Category = "Pantry", Price = 3.50m, Unit = "255ml", Size = "255ml" },
        new GroceryProduct { Name = "Worcestershire Sauce", Category = "Pantry", Price = 3.50m, Unit = "250ml", Size = "250ml" },
        new GroceryProduct { Name = "Tomato Sauce", Category = "Pantry", Price = 3.00m, Unit = "500ml", Size = "500ml" },
        new GroceryProduct { Name = "BBQ Sauce", Category = "Pantry", Price = 3.50m, Unit = "500ml", Size = "500ml" },
        new GroceryProduct { Name = "Sweet Chilli Sauce", Category = "Pantry", Price = 3.50m, Unit = "500ml", Size = "500ml" },
        new GroceryProduct { Name = "Hot Sauce", Category = "Pantry", Price = 4.00m, Unit = "150ml", Size = "150ml" },
        new GroceryProduct { Name = "Tomato Paste", Category = "Pantry", Price = 1.80m, Unit = "140g", Size = "140g" },
        new GroceryProduct { Name = "Canned Tomatoes Diced", Category = "Pantry", Price = 1.50m, Unit = "400g", Size = "400g" },
        new GroceryProduct { Name = "Canned Tomatoes Crushed", Category = "Pantry", Price = 1.50m, Unit = "400g", Size = "400g" },
        new GroceryProduct { Name = "Passata", Category = "Pantry", Price = 2.50m, Unit = "700ml", Size = "700ml" },
        new GroceryProduct { Name = "Coconut Milk", Category = "Pantry", Price = 2.00m, Unit = "400ml", Size = "400ml" },
        new GroceryProduct { Name = "Coconut Cream", Category = "Pantry", Price = 2.00m, Unit = "400ml", Size = "400ml" },
        new GroceryProduct { Name = "White Vinegar", Category = "Pantry", Price = 1.50m, Unit = "750ml", Size = "750ml" },
        new GroceryProduct { Name = "Balsamic Vinegar", Category = "Pantry", Price = 5.00m, Unit = "250ml", Size = "250ml" },
        new GroceryProduct { Name = "Apple Cider Vinegar", Category = "Pantry", Price = 3.50m, Unit = "500ml", Size = "500ml" },
        new GroceryProduct { Name = "Chicken Stock", Category = "Pantry", Price = 2.50m, Unit = "500ml", Size = "500ml" },
        new GroceryProduct { Name = "Beef Stock", Category = "Pantry", Price = 2.50m, Unit = "500ml", Size = "500ml" },
        new GroceryProduct { Name = "Vegetable Stock", Category = "Pantry", Price = 2.50m, Unit = "500ml", Size = "500ml" },
        new GroceryProduct { Name = "Stock Cubes Chicken", Category = "Pantry", Price = 2.00m, Unit = "12 pack", Size = "12 pack" },
        new GroceryProduct { Name = "Peanut Butter", Category = "Pantry", Price = 4.50m, Unit = "375g", Size = "375g" },
        new GroceryProduct { Name = "Vegemite", Category = "Pantry", Price = 5.50m, Unit = "220g", Size = "220g" },
        new GroceryProduct { Name = "Canned Chickpeas", Category = "Pantry", Price = 1.20m, Unit = "400g", Size = "400g" },
        new GroceryProduct { Name = "Canned Kidney Beans", Category = "Pantry", Price = 1.20m, Unit = "400g", Size = "400g" },
        new GroceryProduct { Name = "Canned Lentils", Category = "Pantry", Price = 1.30m, Unit = "400g", Size = "400g" },
        new GroceryProduct { Name = "Canned Baked Beans", Category = "Pantry", Price = 1.80m, Unit = "420g", Size = "420g" },
        new GroceryProduct { Name = "Canned Corn Kernels", Category = "Pantry", Price = 1.50m, Unit = "420g", Size = "420g" },

        // === RICE, PASTA & GRAINS ===
        new GroceryProduct { Name = "Basmati Rice", Category = "Grains", Price = 5.00m, Unit = "1kg", Size = "1kg" },
        new GroceryProduct { Name = "Jasmine Rice", Category = "Grains", Price = 4.50m, Unit = "1kg", Size = "1kg" },
        new GroceryProduct { Name = "Arborio Rice", Category = "Grains", Price = 4.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Brown Rice", Category = "Grains", Price = 4.00m, Unit = "1kg", Size = "1kg" },
        new GroceryProduct { Name = "Spaghetti", Category = "Grains", Price = 1.80m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Penne Pasta", Category = "Grains", Price = 1.80m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Fettuccine", Category = "Grains", Price = 2.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Lasagne Sheets", Category = "Grains", Price = 3.00m, Unit = "375g", Size = "375g" },
        new GroceryProduct { Name = "Egg Noodles", Category = "Grains", Price = 2.50m, Unit = "375g", Size = "375g" },
        new GroceryProduct { Name = "Rice Noodles", Category = "Grains", Price = 3.00m, Unit = "375g", Size = "375g" },
        new GroceryProduct { Name = "Hokkien Noodles", Category = "Grains", Price = 3.00m, Unit = "450g", Size = "450g" },
        new GroceryProduct { Name = "Couscous", Category = "Grains", Price = 3.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Quinoa", Category = "Grains", Price = 6.00m, Unit = "400g", Size = "400g" },
        new GroceryProduct { Name = "Rolled Oats", Category = "Grains", Price = 3.50m, Unit = "1kg", Size = "1kg" },

        // === BAKING ===
        new GroceryProduct { Name = "Plain Flour", Category = "Baking", Price = 1.80m, Unit = "1kg", Size = "1kg" },
        new GroceryProduct { Name = "Self-Raising Flour", Category = "Baking", Price = 1.80m, Unit = "1kg", Size = "1kg" },
        new GroceryProduct { Name = "Cornflour", Category = "Baking", Price = 2.00m, Unit = "300g", Size = "300g" },
        new GroceryProduct { Name = "White Sugar", Category = "Baking", Price = 2.50m, Unit = "1kg", Size = "1kg" },
        new GroceryProduct { Name = "Brown Sugar", Category = "Baking", Price = 3.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Caster Sugar", Category = "Baking", Price = 3.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Icing Sugar", Category = "Baking", Price = 2.50m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Honey", Category = "Baking", Price = 6.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Maple Syrup", Category = "Baking", Price = 7.50m, Unit = "250ml", Size = "250ml" },
        new GroceryProduct { Name = "Golden Syrup", Category = "Baking", Price = 4.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Vanilla Extract", Category = "Baking", Price = 5.50m, Unit = "100ml", Size = "100ml" },
        new GroceryProduct { Name = "Vanilla Essence", Category = "Baking", Price = 3.00m, Unit = "100ml", Size = "100ml" },
        new GroceryProduct { Name = "Cocoa Powder", Category = "Baking", Price = 4.00m, Unit = "200g", Size = "200g" },
        new GroceryProduct { Name = "Baking Powder", Category = "Baking", Price = 2.50m, Unit = "125g", Size = "125g" },
        new GroceryProduct { Name = "Bicarbonate of Soda", Category = "Baking", Price = 2.00m, Unit = "200g", Size = "200g" },
        new GroceryProduct { Name = "Yeast Dry", Category = "Baking", Price = 3.50m, Unit = "12g x7", Size = "7 sachets" },
        new GroceryProduct { Name = "Chocolate Chips Dark", Category = "Baking", Price = 4.50m, Unit = "200g", Size = "200g" },
        new GroceryProduct { Name = "Chocolate Chips Milk", Category = "Baking", Price = 4.50m, Unit = "200g", Size = "200g" },
        new GroceryProduct { Name = "Desiccated Coconut", Category = "Baking", Price = 3.00m, Unit = "250g", Size = "250g" },
        new GroceryProduct { Name = "Almond Meal", Category = "Baking", Price = 7.00m, Unit = "250g", Size = "250g" },

        // === HERBS & SPICES ===
        new GroceryProduct { Name = "Salt Table", Category = "Spices", Price = 1.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Sea Salt Flakes", Category = "Spices", Price = 4.50m, Unit = "250g", Size = "250g" },
        new GroceryProduct { Name = "Black Pepper Ground", Category = "Spices", Price = 3.50m, Unit = "50g", Size = "50g" },
        new GroceryProduct { Name = "Black Peppercorns", Category = "Spices", Price = 4.00m, Unit = "50g", Size = "50g" },
        new GroceryProduct { Name = "Paprika", Category = "Spices", Price = 2.50m, Unit = "30g", Size = "30g" },
        new GroceryProduct { Name = "Smoked Paprika", Category = "Spices", Price = 3.50m, Unit = "30g", Size = "30g" },
        new GroceryProduct { Name = "Cumin Ground", Category = "Spices", Price = 2.50m, Unit = "30g", Size = "30g" },
        new GroceryProduct { Name = "Cumin Seeds", Category = "Spices", Price = 3.00m, Unit = "30g", Size = "30g" },
        new GroceryProduct { Name = "Coriander Ground", Category = "Spices", Price = 2.50m, Unit = "25g", Size = "25g" },
        new GroceryProduct { Name = "Turmeric", Category = "Spices", Price = 2.50m, Unit = "30g", Size = "30g" },
        new GroceryProduct { Name = "Cinnamon Ground", Category = "Spices", Price = 2.50m, Unit = "30g", Size = "30g" },
        new GroceryProduct { Name = "Cinnamon Sticks", Category = "Spices", Price = 4.00m, Unit = "30g", Size = "30g" },
        new GroceryProduct { Name = "Oregano Dried", Category = "Spices", Price = 2.50m, Unit = "10g", Size = "10g" },
        new GroceryProduct { Name = "Basil Dried", Category = "Spices", Price = 2.50m, Unit = "10g", Size = "10g" },
        new GroceryProduct { Name = "Thyme Dried", Category = "Spices", Price = 2.50m, Unit = "10g", Size = "10g" },
        new GroceryProduct { Name = "Rosemary Dried", Category = "Spices", Price = 2.50m, Unit = "15g", Size = "15g" },
        new GroceryProduct { Name = "Mixed Herbs", Category = "Spices", Price = 2.50m, Unit = "15g", Size = "15g" },
        new GroceryProduct { Name = "Bay Leaves", Category = "Spices", Price = 3.00m, Unit = "10g", Size = "10g" },
        new GroceryProduct { Name = "Chilli Flakes", Category = "Spices", Price = 3.00m, Unit = "25g", Size = "25g" },
        new GroceryProduct { Name = "Chilli Powder", Category = "Spices", Price = 2.50m, Unit = "30g", Size = "30g" },
        new GroceryProduct { Name = "Garlic Powder", Category = "Spices", Price = 2.50m, Unit = "50g", Size = "50g" },
        new GroceryProduct { Name = "Onion Powder", Category = "Spices", Price = 2.50m, Unit = "50g", Size = "50g" },
        new GroceryProduct { Name = "Curry Powder", Category = "Spices", Price = 3.00m, Unit = "35g", Size = "35g" },
        new GroceryProduct { Name = "Garam Masala", Category = "Spices", Price = 3.50m, Unit = "30g", Size = "30g" },
        new GroceryProduct { Name = "Chinese Five Spice", Category = "Spices", Price = 3.00m, Unit = "25g", Size = "25g" },
        new GroceryProduct { Name = "Nutmeg Ground", Category = "Spices", Price = 3.50m, Unit = "30g", Size = "30g" },
        new GroceryProduct { Name = "Mustard Powder", Category = "Spices", Price = 3.50m, Unit = "60g", Size = "60g" },

        // === FROZEN ===
        new GroceryProduct { Name = "Frozen Mixed Vegetables", Category = "Frozen", Price = 2.50m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Frozen Stir Fry Vegetables", Category = "Frozen", Price = 3.50m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Frozen Spinach", Category = "Frozen", Price = 2.50m, Unit = "250g", Size = "250g" },
        new GroceryProduct { Name = "Frozen Chips", Category = "Frozen", Price = 4.00m, Unit = "1kg", Size = "1kg" },
        new GroceryProduct { Name = "Frozen Pastry Puff", Category = "Frozen", Price = 4.50m, Unit = "6 sheets", Size = "6 sheets" },
        new GroceryProduct { Name = "Frozen Pastry Shortcrust", Category = "Frozen", Price = 4.50m, Unit = "5 sheets", Size = "5 sheets" },
        new GroceryProduct { Name = "Frozen Berries Mixed", Category = "Frozen", Price = 5.00m, Unit = "500g", Size = "500g" },
        new GroceryProduct { Name = "Ice Cream Vanilla", Category = "Frozen", Price = 6.00m, Unit = "1L", Size = "1L" },
    };

    public static IEnumerable<GroceryProduct> Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return Enumerable.Empty<GroceryProduct>();

        return All
            .Where(p => p.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
            .OrderBy(p => p.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase))
            .ThenBy(p => p.Name.Length);
    }

    public static string[] Categories => All.Select(p => p.Category).Distinct().ToArray();
}
