using PinewoodGrow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using PinewoodGrow.Data.Repositorys;
using PinewoodGrow.Data.SeedData;

namespace PinewoodGrow.Data
{
	public static class GSeedData
    {
        public static Random rnd = new Random();
		public static void Initialize(IServiceProvider serviceProvider)
		{

			using (var context = new GROWContext(
				serviceProvider.GetRequiredService<DbContextOptions<GROWContext>>()))
			{
				if (!context.Genders.Any())
				{
					var genders = new List<Gender>
					{
						new Gender { ID = 1, Name = "Male"},
						new Gender { ID = 2, Name = "Female"},
						new Gender { ID = 3, Name = "Non-Binary"},
						new Gender { ID = 4, Name = "Other"},
						new Gender { ID = 5, Name = "Prefer not to say"}
					};
					context.Genders.AddRange(genders);
					context.SaveChanges();
				}

				if (!context.Situations.Any())
				{
					var situations = new List<Situation>
					{
						new Situation { ID = 1, Name = "ODSP"},
						new Situation { ID = 2, Name = "Ontario Works"},
						new Situation { ID = 3, Name = "CPP-Disability"},
						new Situation { ID = 4, Name = "EI"},
						new Situation { ID = 5, Name = "GAINS (For Seniors)"},
						new Situation { ID = 6, Name = "Post-Sec. Student"},
						new Situation { ID = 7, Name = "Other"},
						new Situation { ID = 8, Name = "Employed"}
					};
					context.Situations.AddRange(situations);
					context.SaveChanges();
				}

				if (!context.Dietaries.Any())
				{
					var dietaries = new List<Dietary>
					{
						new Dietary { ID = 3, Name = "Lactose Intolerance"},
						new Dietary { ID = 4, Name = "Gluten Intolerance/Sensitivity"},
						new Dietary { ID = 9, Name = "Food Allergies"}
					};
					context.Dietaries.AddRange(dietaries);
					context.SaveChanges();
				}

                if (!context.Illnesses.Any())
                {
                    var illnesses = new List<Illness>
                    {
                        new Illness { ID = 1, Name = "Diabetes"},
                        new Illness { ID = 2, Name = "Obesity"},
                        new Illness { ID = 8, Name = "Digestive Disorders"},
                        new Illness { ID = 5, Name = "Cancer"},
                        new Illness { ID = 6, Name = "Heart Disease"},
                        new Illness { ID = 7, Name = "Osteoperosis"}
                    };
                    context.Illnesses.AddRange(illnesses);
                    context.SaveChanges();
                }

                if (!context.Volunteers.Any())
                {
                    var volunteers = new List<Volunteer>
                    {
                        new Volunteer
                         {
                             FirstName = "Gregory",
                             LastName = "March",
                             Email = "admin1@outlook.com",
                             Phone = "2897438725"
                         },
                         new Volunteer
                         {
                             FirstName = "Abigale",
                             LastName = "Summer",
                             Email = "super1@outlook.com",
                             Phone = "2897431525"
                         },
                         new Volunteer
                         {
                             FirstName = "Trevor",
                             LastName = "Smith",
                             Email = "volunteer1@outlook.com",
                             Phone = "2897405348"
                         },
                         new Volunteer
                         {
                             FirstName = "Johnny",
                             LastName = "Barns",
                             Email = "jBarns@outlook.com",
                             Phone = "2891964825"
                         },
                         new Volunteer
                         {
                             FirstName = "Annie",
                             LastName = "Westford",
                             Email = "aWestford@outlook.com",
                             Phone = "2897492725"
                         }
                    };
                    context.Volunteers.AddRange(volunteers);
                    context.SaveChanges();
                }

                if (!context.Payments.Any())
                {
                    var payments = new List<Payment>
                    {
                        new Payment { ID = 1, Type = "Cash"},
                        new Payment { ID = 2, Type = "Cheque"},
                        new Payment { ID = 3, Type = "Credit Card"},
                        new Payment { ID = 4, Type = "Debit Card"},
                        new Payment { ID = 5, Type = "Master Card"},
                        new Payment { ID = 6, Type = "Visa"}
                    };
                    context.Payments.AddRange(payments);
                    context.SaveChanges();
                }

                if (!context.ProductTypes.Any())
                {
                    var productTypes = new List<ProductType>
                    {
                        new ProductType { ID = 1, Type = "Produce"},
                        new ProductType { ID = 2, Type = "Freezer"},
                        new ProductType { ID = 3, Type = "Dairy/Eggs/Bread"},
                        new ProductType { ID = 4, Type = "Pantry"},
                        new ProductType { ID = 5, Type = "Specials"}
                    };
                    context.ProductTypes.AddRange(productTypes);
                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    var products = new List<Product>
                    {
                        new Product { ID = 101, Name = "Apples", UnitPrice = 0.1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 102, Name = "Avocado large*", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 103, Name = "Avocado small*", UnitPrice = 0.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 104, Name = "Bananas", UnitPrice = 0.1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 105, Name = "Blueberries / Blackberries", UnitPrice = 1.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 106, Name = "Broccoli", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 107, Name = "Cantaloupe", UnitPrice = 1.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 108, Name = "Carrots", UnitPrice = 0.05, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 109, Name = "Cauliflower", UnitPrice = 2.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 110, Name = "Celery", UnitPrice = 1.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 111, Name = "Clementine", UnitPrice = 0.1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 112, Name = "Corn", UnitPrice = 0.25, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 113, Name = "Cucumber", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 114, Name = "Cucumber Mini", UnitPrice = 0.05, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 115, Name = "Eggplant", UnitPrice = 0.1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 116, Name = "Garlic*", UnitPrice = 0.25, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 117, Name = "Grapes*", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 118, Name = "Green Onions", UnitPrice = 0.25, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 119, Name = "Kale", UnitPrice = 0.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 120, Name = "Kiwi", UnitPrice = 0.25, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 121, Name = "Lemon*", UnitPrice = 0.25, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 122, Name = "Lettuce Romaine Hearts", UnitPrice = 0.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 123, Name = "Limes", UnitPrice = 0.05, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 124, Name = "Mango", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 125, Name = "Micro Greens", UnitPrice = 0.25, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 126, Name = "Mushrooms*", UnitPrice = 1.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 127, Name = "Cabbage*", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 128, Name = "Onion", UnitPrice = 0.05, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 129, Name = "Oranges", UnitPrice = 0.2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 130, Name = "Peaches/Nectarines", UnitPrice = 0.1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 131, Name = "Pear", UnitPrice = 0.1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 132, Name = "Peppers", UnitPrice = 0.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 133, Name = "Peppers Hot 3", UnitPrice = 0.05, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 134, Name = "Peppers Mini ", UnitPrice = 0.05, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 135, Name = "Plums", UnitPrice = 0.05, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 136, Name = "Potatoes", UnitPrice = 0.05 / 1.50, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 137, Name = "Potatoes Baby Basket", UnitPrice = 0.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 138, Name = "Potatoes Sweet (Yam)", UnitPrice = 0.75, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 139, Name = "Raspberries", UnitPrice = 1.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 140, Name = "Squash", UnitPrice = 0.1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 141, Name = "Strawberries", UnitPrice = 1.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 142, Name = "Swiss Chard", UnitPrice = 0.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 143, Name = "Tomato Cherry / Grape Basket", UnitPrice = 0.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 144, Name = "Tomatoes ", UnitPrice = 0.1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 145, Name = "Watermelon", UnitPrice = 2.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 146, Name = "Zucchini", UnitPrice = 0.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 147, Name = "Brussel Sprouts", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 148, Name = "Shallots", UnitPrice = 0.05, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},
                        new Product { ID = 149, Name = "Anise / Fennel", UnitPrice = 1.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Produce").ID,},

                        new Product { ID = 201, Name = "Chicken Legs (2)", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Freezer").ID,},
                        new Product { ID = 202, Name = "Chicken Drumsticks 4lbs", UnitPrice = 3, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Freezer").ID,},
                        new Product { ID = 203, Name = "Chicken Thighs 4lbs", UnitPrice = 3, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Freezer").ID,},
                        new Product { ID = 204, Name = "Chicken Wings 2lbs", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Freezer").ID,},
                        new Product { ID = 205, Name = "Ground Beef", UnitPrice = 2.75, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Freezer").ID,},
                        new Product { ID = 206, Name = "Veggie Burger 2pc", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Freezer").ID,},
                        new Product { ID = 207, Name = "Fish (Haddock / Basa)", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Freezer").ID,},

                        new Product { ID = 301, Name = "Almond Milk 2L", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 302, Name = "Bread Costco", UnitPrice = 0.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 303, Name = "Butter", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 304, Name = "Cheese Large", UnitPrice = 3, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 305, Name = "Cream Cheese", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 306, Name = "Eggs (12) / Eggs (18)", UnitPrice = 2.00 / 3.00, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 307, Name = "Goat Milk 1l", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 308, Name = "Hummus", UnitPrice = 2.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 309, Name = "Hummus Mini", UnitPrice = 0.25, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 310, Name = "Margerine", UnitPrice = 1.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 311, Name = "Milk - 1L", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 312, Name = "Milk - 4L", UnitPrice = 3, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 313, Name = "Oat Milk 1l", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 314, Name = "Orange Juice", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 315, Name = "Pizza Dough", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 316, Name = "Sour Crème", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 317, Name = "Soy Milk 1l", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 318, Name = "Tofu", UnitPrice = 2.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 319, Name = "Yogurt 4 pack", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 320, Name = "Yogurt Greek", UnitPrice = 3, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 321, Name = "Yogurt Tub", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 322, Name = "Yogurt 6 pack", UnitPrice = 1.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 323, Name = "Sliced Cheese", UnitPrice = 2.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},
                        new Product { ID = 324, Name = "Bread Commisso's", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Dairy/Eggs/Bread").ID,},

                        new Product { ID = 401, Name = "Apple Sauce", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 402, Name = "Baking Powder", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 403, Name = "Bars Cereal, Protein, Cookie", UnitPrice = 0.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 404, Name = "BBQ Sauce", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 405, Name = "Bleach", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 406, Name = "Broth", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 407, Name = "Canned Beans, Veggies, and Fruit", UnitPrice = 0.75, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 408, Name = "Canola Oil", UnitPrice = 3, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 409, Name = "Cereal all other", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 410, Name = "Cereal Rice Krispies", UnitPrice = 3, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 411, Name = "Crackers ", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 412, Name = "Dried Legumes/Beans", UnitPrice = 1.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 413, Name = "Flour", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 414, Name = "Garden Cocktail", UnitPrice = 0.75, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 415, Name = "Granola Bars 6 pack", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 416, Name = "Jam", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 417, Name = "Kraft Dinner", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 418, Name = "Laundry Soap large", UnitPrice = 6, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 419, Name = "Laundry Soap small", UnitPrice = 3, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 420, Name = "Miracle Whip", UnitPrice = 3, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 421, Name = "Nuts", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 422, Name = "Oats", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 423, Name = "Olive Oil", UnitPrice = 6, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 424, Name = "Passata", UnitPrice = 0.75, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 425, Name = "Pasta", UnitPrice = 0.75, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 426, Name = "Pasta Sauce", UnitPrice = 0.75, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 427, Name = "Peanut Butter", UnitPrice = 2.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 428, Name = "Polenta", UnitPrice = 3, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 429, Name = "Rice", UnitPrice = 1.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 430, Name = "Salad Dressing", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 431, Name = "Soap ", UnitPrice = 0.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 432, Name = "Soup Small", UnitPrice = 0.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 433, Name = "Spices", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 434, Name = "Sugar White and Brown", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 435, Name = "Tea", UnitPrice = 2, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 436, Name = "Tea Green Tea", UnitPrice = 4.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 437, Name = "Tea Orange Pekoe", UnitPrice = 3, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 438, Name = "Tea Red Rose", UnitPrice = 5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 439, Name = "Toilet Paper", UnitPrice = 5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 440, Name = "Tomato Paste", UnitPrice = 0.75, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 441, Name = "Tooth Paste / Brush / Floss", UnitPrice = 0.75, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 442, Name = "Tuna", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 443, Name = "Wild Rice Blend", UnitPrice = 0.25, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 444, Name = "Yeast", UnitPrice = 0.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 445, Name = "Coconut Milk", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 446, Name = "Coffee", UnitPrice = 4, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 447, Name = "Protein Drink", UnitPrice = 0.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 448, Name = "Salsa", UnitPrice = 1.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 449, Name = "Gummies", UnitPrice = 0.1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},
                        new Product { ID = 450, Name = "Raisins", UnitPrice = 4, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Pantry").ID,},

                        new Product { ID = 501, Name = "Cat Food (wet)", UnitPrice = 0.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Specials").ID,},
                        new Product { ID = 502, Name = "Sweets (Costco)", UnitPrice = 0.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Specials").ID,},
                        new Product { ID = 503, Name = "Drinks ", UnitPrice = 0.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Specials").ID,},
                        new Product { ID = 504, Name = "GROW Soup", UnitPrice = 2.5, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Specials").ID,},
                        new Product { ID = 505, Name = "Deoderant", UnitPrice = 1, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Specials").ID,},
                        new Product { ID = 506, Name = "Polenta", UnitPrice = 3, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Specials").ID,},
                        new Product { ID = 507, Name = "Orzo", UnitPrice = 0.75, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Specials").ID,},
                        new Product { ID = 508, Name = "Ramen / Rice Krispies", UnitPrice = 0.25, ProductTypeID=context.ProductTypes.FirstOrDefault(d => d.Type == "Specials").ID,},
                    };
                    context.Products.AddRange(products);
                    context.SaveChanges();
                }

                if (!context.ProductUnitPrices.Any())
                {
                    var products = context.Products.Select(a => a).ToList();

                    var unitPrices = products.Select(a => new ProductUnitPrice
                    {
                        ProductPrice = a.UnitPrice,
                        ProductID = a.ID
                    });

                    context.ProductUnitPrices.AddRange(unitPrices);
                    context.SaveChanges();
                }

                if (!context.Addresses.Any())
				{
                    var addresses = new List<Address>
                {
                    new Address
                    {
                        PlaceID = "ChIJ4b6H3DND04kR7As4iJJThxM",
                        FullAddress = "4352 5th Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4R2",
                        Latitude = 43.1105654,
                        Longitude = -79.0797108
                    },
                    new Address
                    {
                        PlaceID = "ChIJdcUvjjFD04kRq6g4mn5ujvU",
                        FullAddress = "4447 3rd Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4L1",
                        Latitude = 43.1110133,
                        Longitude = -79.0807247
                    },
                    new Address
                    {
                        PlaceID = "ChIJS3EXEzFD04kRxOg93TUaJBI",
                        FullAddress = "5125 Bridge St",
                        City = "Niagara Falls",
                        PostalCode = "L2E 2S9",
                        Latitude = 43.1087576,
                        Longitude = -79.0795157
                    },
                    new Address
                    {
                        PlaceID = "ChIJvQAkPjJD04kRpODLlfkuIrI",
                        FullAddress = "4342 3rd Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4K6",
                        Latitude = 43.1108061,
                        Longitude = -79.0772197
                    },
                    new Address
                    {
                        PlaceID = "ChIJe1UrPjFD04kRfz0MV6qhdk8",
                        FullAddress = "5155 Bridge St",
                        City = "Niagara Falls",
                        PostalCode = "L2E 2T2",
                        Latitude = 43.108767,
                        Longitude = -79.080085
                    },
                    new Address
                    {
                        PlaceID = "ChIJqYKnAzJD04kRzzs4Ss0_67k",
                        FullAddress = "4407 2nd Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4H1",
                        Latitude = 43.1099135,
                        Longitude = -79.0763052
                    },
                    new Address
                    {
                        PlaceID = "ChIJ8Vm6jyxD04kRpZbmBkvyUMc",
                        FullAddress = "4677 Buttrey St",
                        City = "Niagara Falls",
                        PostalCode = "L2E 2X5",
                        Latitude = 43.112119,
                        Longitude = -79.070966
                    },
                    new Address
                    {
                        PlaceID = "ChIJbf6m4jFD04kR1yYC_1dzufs",
                        FullAddress = "4472 2nd Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4H2",
                        Latitude = 43.1090012,
                        Longitude = -79.0757509
                    },
                    new Address
                    {
                        PlaceID = "ChIJP3dg_TFD04kRlhRE-JE3XpY",
                        FullAddress = "4462 2nd Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4H2",
                        Latitude = 43.1091381,
                        Longitude = -79.0757251
                    },
                    new Address
                    {
                        PlaceID = "ChIJfZXbPzJD04kRRwFND7QtRAQ",
                        FullAddress = "4340 3rd Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4K6",
                        Latitude = 43.1109053,
                        Longitude = -79.0771677
                    },
                    new Address
                    {
                        PlaceID = "ChIJSeedOzJD04kRQBac6j88i9Q",
                        FullAddress = "4351 3rd Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4K6",
                        Latitude = 43.1105922,
                        Longitude = -79.077649
                    },
                    new Address
                    {
                        PlaceID = "ChIJ8UCNVDFD04kRexzQ9HivYME",
                        FullAddress = "4399 6th Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4S7",
                        Latitude = 43.1099483,
                        Longitude = -79.0812512
                    },
                    new Address
                    {
                        PlaceID = "ChIJjTa59zND04kRAv56_dztOgU",
                        FullAddress = "4329 6th Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4S7",
                        Latitude = 43.1109074,
                        Longitude = -79.0812878
                    },
                    new Address
                    {
                        PlaceID = "ChIJT7f68TND04kRkOGkTXFWG3w",
                        FullAddress = "4322 6th Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4S8",
                        Latitude = 43.1110133,
                        Longitude = -79.0807247
                    },
                    new Address
                    {
                        PlaceID = "ChIJPSjN8TND04kRRtHafO7rbSo",
                        FullAddress = "4330 6th Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4S8",
                        Latitude = 43.1109018,
                        Longitude = -79.0807447
                    },
                    new Address
                    {
                        PlaceID = "ChIJxfEQ8DND04kRdaR3sb_yy9c",
                        FullAddress = "4338 6th Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4S8",
                        Latitude = 43.1108024,
                        Longitude = -79.0807499
                    },
                    new Address
                    {
                        PlaceID = "ChIJrQaWjTND04kRQ8NQEE1vQtI",
                        FullAddress = "4282 6th Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4S8",
                        Latitude = 43.11156,
                        Longitude = -79.0807837
                    },
                    new Address
                    {
                        PlaceID = "ChIJo0whijND04kRwor60Ap3QK0",
                        FullAddress = "4271 6th Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4S7",
                        Latitude = 43.1116959,
                        Longitude = -79.0812982
                    },
                    new Address
                    {
                        PlaceID = "ChIJbeVfijND04kRQJ70swlj-2k",
                        FullAddress = "4281 6th Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4S7",
                        Latitude = 43.1115584,
                        Longitude = -79.0813122
                    },
                    new Address
                    {
                        PlaceID = "ChIJkTTEijND04kRe7GMBI9kOy4",
                        FullAddress = "4289 6th Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4S7",
                        Latitude = 43.1144691,
                        Longitude = -79.081271
                    },
                    new Address
                    {
                        PlaceID = "ChIJTejKxjND04kR97mx7WIDcqo",
                        FullAddress = "4322 5th Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4R2",
                        Latitude = 43.1110134,
                        Longitude = -79.0796185
                    },
                    new Address
                    {
                        PlaceID = "ChIJM0YVtjND04kRB4zuE76r0RQ",
                        FullAddress = "4307 Fourth Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4N1",
                        Latitude = 43.1112813,
                        Longitude = -79.0791171
                    },
                    new Address
                    {
                        PlaceID = "ChIJTQTztjND04kR4K3AtlQpJkk",
                        FullAddress = "4295 Fourth Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4N1",
                        Latitude = 43.1113849,
                        Longitude = -79.0910137
                    },

                    new Address
                    {
                        PlaceID = "ChIJV_mg3DND04kRUrLrvQfuSWA",
                        FullAddress = "4354 5th Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4R2",
                        Latitude = 43.1105826,
                        Longitude = -79.079664
                    },
                    new Address
                    {
                        PlaceID = "ChIJL8342zND04kRwzR2Zmpz1dg",
                        FullAddress = "4370 5th Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4R2",
                        Latitude = 43.1103517,
                        Longitude = -79.0796343
                    },
                    new Address
                    {
                        PlaceID = "ChIJKeCiKjJD04kRQAAnOzznevw",
                        FullAddress = "4398 Fourth Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4N3",
                        Latitude = 43.1099746,
                        Longitude = -79.0784874
                    },
                    new Address
                    {
                        PlaceID = "ChIJ53qpLDJD04kR7KjCIsq7cTc",
                        FullAddress = "4380 Fourth Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4N2",
                        Latitude = 43.1102633,
                        Longitude = -79.0785068
                    },
                    new Address
                    {
                        PlaceID = "ChIJwzJSKzJD04kRyawYBD_3a-k",
                        FullAddress = "4386 Fourth Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4N2",
                        Latitude = 43.110365,
                        Longitude = -79.0785821
                    },
                    new Address
                    {
                        PlaceID = "ChIJE76jUDFD04kRm27wYE9T6tQ",
                        FullAddress = "4416 6th Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4T1",
                        Latitude = 43.1097783,
                        Longitude = -79.0807468
                    },
                    new Address
                    {
                        PlaceID = "ChIJ_a2UUDFD04kRHZXigCRWCJw",
                        FullAddress = "4412 6th Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4T1",
                        Latitude = 43.1097642,
                        Longitude = -79.080814
                    },
                    new Address
                    {
                        PlaceID = "ChIJn2d9UjFD04kRTT9FztB_U3o",
                        FullAddress = "4425 6th Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4S9",
                        Latitude = 43.1096581,
                        Longitude = -79.0812546
                    },
                    new Address()
                    {
                        PlaceID = "ChIJCcNF0TND04kRWpYDE3PBq1A",
                        FullAddress = "4377 Fourth Ave",
                        City = "Niagara Falls",
                        PostalCode = "L2E 4N1",
                        Latitude = 43.1103374,
                        Longitude= -79.07902519999999
                    }
                };
                    context.Addresses.AddRange(addresses);
                    context.SaveChanges();
                }

                if (!context.GroceryStores.Any())
                {
                    var stores = new List<GroceryStore>
                    {
                        new GroceryStore
                        {
                            ID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                            FullAddress = "4167 Victoria Ave, Niagara Falls",
                            Name = "Lococo's (Victoria) - Fresh Fruits, Vegetables and Meats",
                            Latitude = 43.1133892,
                            Longitude = -79.07392759999999
                        },
                        new GroceryStore
                        {
                            ID = "ChIJZSRqZ01D04kRA8V_zFSvB98",
                            FullAddress = "6161 Thorold Stone Rd, Niagara Falls",
                            Name = "Commisso's Fresh Foods",
                            Latitude = 43.1161111,
                            Longitude = -79.0977778
                        },
                        new GroceryStore
                        {
                            ID = "ChIJnW3xZDpD04kRPFDm3Gj7_FE",
                            FullAddress = "5124 Morrison St, Niagara Falls",
                            Name = "Morrison Variety & Grocery",
                            Latitude = 43.104396,
                            Longitude = -79.079185
                        },
                        new GroceryStore
                        {
                            ID = "ChIJQ5LXLi9D04kRXMX3xTAM3FM",
                            FullAddress = "4670 Queen St, Niagara Falls",
                            Name = "Your everything store",
                            Latitude = 43.106465,
                            Longitude = -79.070678
                        },
              
                    };
                    context.GroceryStores.AddRange(stores);
                    context.SaveChanges();
                }

                if (!context.TravelDetails.Any())
                {

                    var addressDictionary = context.Addresses.ToDictionary(a => a.PlaceID, a => a.ID);


                    var y = addressDictionary["ChIJTejKxjND04kR97mx7WIDcqo"];
                    //var u= "";
                    var travels = new List<TravelDetail>
                    {
                        new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 949,
                        GroceryDrive = 128,
                        GroceryBike = 263,
                        GroceryWalk = 684,
                        GrowDistance = 225,
                        GrowDrive = 51,
                        GrowBike = 39,
                        GrowWalk = 166,
                        AddressID = addressDictionary["ChIJdcUvjjFD04kRq6g4mn5ujvU"]
            
                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJnW3xZDpD04kRPFDm3Gj7_FE",
                        GroceryDistance = 562,
                        GroceryDrive = 95,
                        GroceryBike = 123,
                        GroceryWalk = 387,
                        GrowDistance = 264,
                        GrowDrive = 39,
                        GrowBike = 63,
                        GrowWalk = 194,
                        AddressID = addressDictionary["ChIJS3EXEzFD04kRxOg93TUaJBI"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 1117,
                        GroceryDrive = 165,
                        GroceryBike = 293,
                        GroceryWalk = 809,
                        GrowDistance = 207,
                        GrowDrive = 47,
                        GrowBike = 38,
                        GrowWalk = 154,
                        AddressID = addressDictionary["ChIJvQAkPjJD04kRpODLlfkuIrI"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJnW3xZDpD04kRPFDm3Gj7_FE",
                        GroceryDistance = 601,
                        GroceryDrive = 98,
                        GroceryBike = 121,
                        GroceryWalk = 379,
                        GrowDistance = 304,
                        GrowDrive = 42,
                        GrowBike = 68,
                        GrowWalk = 223,
                        AddressID = addressDictionary["ChIJe1UrPjFD04kRfz0MV6qhdk8"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 909,
                        GroceryDrive = 105,
                        GroceryBike = 258,
                        GroceryWalk = 656,
                        GrowDistance = 259,
                        GrowDrive = 61,
                        GrowBike = 47,
                        GrowWalk = 196,
                        AddressID = addressDictionary["ChIJqYKnAzJD04kRzzs4Ss0_67k"]

                    },

                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 364,
                        GroceryDrive = 38,
                        GroceryBike = 88,
                        GroceryWalk = 264,
                        GrowDistance = 1179,
                        GrowDrive = 130,
                        GrowBike = 294,
                        GrowWalk = 882,
                        AddressID = addressDictionary["ChIJ8Vm6jyxD04kRpZbmBkvyUMc"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 823,
                        GroceryDrive = 92,
                        GroceryBike = 243,
                        GroceryWalk = 593,
                        GrowDistance = 346,
                        GrowDrive = 76,
                        GrowBike = 60,
                        GrowWalk = 257,
                        AddressID = addressDictionary["ChIJP3dg_TFD04kRlhRE-JE3XpY"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 1129,
                        GroceryDrive = 167,
                        GroceryBike = 295,
                        GroceryWalk = 818,
                        GrowDistance = 219,
                        GrowDrive = 50,
                        GrowBike = 40,
                        GrowWalk = 163,
                        AddressID = addressDictionary["ChIJfZXbPzJD04kRRwFND7QtRAQ"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 1095,
                        GroceryDrive = 161,
                        GroceryBike = 288,
                        GroceryWalk = 793,
                        GrowDistance = 185,
                        GrowDrive = 44,
                        GrowBike = 34,
                        GrowWalk = 138,
                        AddressID = addressDictionary["ChIJSeedOzJD04kRQBac6j88i9Q"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJnW3xZDpD04kRPFDm3Gj7_FE",
                        GroceryDistance = 749,
                        GroceryDrive = 131,
                        GroceryBike = 185,
                        GroceryWalk = 559,
                        GrowDistance = 219,
                        GrowDrive = 51,
                        GrowBike = 35,
                        GrowWalk = 159,
                        AddressID = addressDictionary["ChIJ8UCNVDFD04kRexzQ9HivYME"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 1420,
                        GroceryDrive = 181,
                        GroceryBike = 338,
                        GroceryWalk = 1028,
                        GrowDistance = 292,
                        GrowDrive = 68,
                        GrowBike = 49,
                        GrowWalk = 214,
                        AddressID = addressDictionary["ChIJjTa59zND04kRAv56_dztOgU"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 1433,
                        GroceryDrive = 184,
                        GroceryBike = 340,
                        GroceryWalk = 1038,
                        GrowDistance = 304,
                        GrowDrive = 71,
                        GrowBike = 51,
                        GrowWalk = 223,
                        AddressID = addressDictionary["ChIJT7f68TND04kRkOGkTXFWG3w"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJQ5LXLi9D04kRXMX3xTAM3FM",
                        GroceryDistance = 701,
                        GroceryDrive = 106,
                        GroceryBike = 179,
                        GroceryWalk = 529,
                        GrowDistance = 469,
                        GrowDrive = 75,
                        GrowBike = 63,
                        GrowWalk = 268,
                        AddressID = addressDictionary["ChIJbf6m4jFD04kR1yYC_1dzufs"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 1422,
                        GroceryDrive = 182,
                        GroceryBike = 338,
                        GroceryWalk = 1029,
                        GrowDistance = 293,
                        GrowDrive = 69,
                        GrowBike = 49,
                        GrowWalk = 214,
                        AddressID = addressDictionary["ChIJPSjN8TND04kRRtHafO7rbSo"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 1410,
                        GroceryDrive = 179,
                        GroceryBike = 336,
                        GroceryWalk = 1020,
                        GrowDistance = 281,
                        GrowDrive = 67,
                        GrowBike = 47,
                        GrowWalk = 205,
                        AddressID = addressDictionary["ChIJxfEQ8DND04kRdaR3sb_yy9c"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 1493,
                        GroceryDrive = 194,
                        GroceryBike = 351,
                        GroceryWalk = 1082,
                        GrowDistance = 364,
                        GrowDrive = 81,
                        GrowBike = 62,
                        GrowWalk = 267,
                        AddressID = addressDictionary["ChIJrQaWjTND04kRQ8NQEE1vQtI"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 1483,
                        GroceryDrive = 193,
                        GroceryBike = 350,
                        GroceryWalk = 1075,
                        GrowDistance = 354,
                        GrowDrive = 80,
                        GrowBike = 60,
                        GrowWalk = 260,
                        AddressID = addressDictionary["ChIJkTTEijND04kRe7GMBI9kOy4"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 1494,
                        GroceryDrive = 195,
                        GroceryBike = 352,
                        GroceryWalk = 1083,
                        GrowDistance = 366,
                        GrowDrive = 82,
                        GrowBike = 62,
                        GrowWalk = 268,
                        AddressID = addressDictionary["ChIJbeVfijND04kRQJ70swlj-2k"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 1284,
                        GroceryDrive = 147,
                        GroceryBike = 315,
                        GroceryWalk = 928,
                        GrowDistance = 155,
                        GrowDrive = 40,
                        GrowBike = 26,
                        GrowWalk = 113,
                        AddressID = addressDictionary["ChIJ4b6H3DND04kR7As4iJJThxM"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 1344,
                        GroceryDrive = 160,
                        GroceryBike = 325,
                        GroceryWalk = 972,
                        GrowDistance = 214,
                        GrowDrive = 52,
                        GrowBike = 36,
                        GrowWalk = 156,
                        AddressID = addressDictionary["ChIJTejKxjND04kR97mx7WIDcqo"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 1279,
                        GroceryDrive = 152,
                        GroceryBike = 314,
                        GroceryWalk = 923,
                        GrowDistance = 104,
                        GrowDrive = 17,
                        GrowBike = 16,
                        GrowWalk = 75,
                        AddressID = addressDictionary["ChIJM0YVtjND04kRB4zuE76r0RQ"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJZSRqZ01D04kRA8V_zFSvB98",
                        GroceryDistance = 2681,
                        GroceryDrive = 301,
                        GroceryBike = 442,
                        GroceryWalk = 1516,
                        GrowDistance = 115,
                        GrowDrive = 19,
                        GrowBike = 18,
                        GrowWalk = 83,
                        AddressID = addressDictionary["ChIJTQTztjND04kR4K3AtlQpJkk"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 1503,
                        GroceryDrive = 196,
                        GroceryBike = 353,
                        GroceryWalk = 1090,
                        GrowDistance = 374,
                        GrowDrive = 83,
                        GrowBike = 64,
                        GrowWalk = 275,
                        AddressID = addressDictionary["ChIJo0whijND04kRwor60Ap3QK0"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 1295,
                        GroceryDrive = 150,
                        GroceryBike = 317,
                        GroceryWalk = 936,
                        GrowDistance = 165,
                        GrowDrive = 42,
                        GrowBike = 27,
                        GrowWalk = 120,
                        AddressID = addressDictionary["ChIJV_mg3DND04kRUrLrvQfuSWA"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 1269,
                        GroceryDrive = 144,
                        GroceryBike = 313,
                        GroceryWalk = 917,
                        GrowDistance = 140,
                        GrowDrive = 36,
                        GrowBike = 23,
                        GrowWalk = 102,
                        AddressID = addressDictionary["ChIJL8342zND04kRwzR2Zmpz1dg"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 1166,
                        GroceryDrive = 134,
                        GroceryBike = 297,
                        GroceryWalk = 842,
                        GrowDistance = 8,
                        GrowDrive = 1,
                        GrowBike = 1,
                        GrowWalk = 6,
                        AddressID = addressDictionary["ChIJ53qpLDJD04kR7KjCIsq7cTc"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 1162,
                        GroceryDrive = 133,
                        GroceryBike = 297,
                        GroceryWalk = 840,
                        GrowDistance = 12,
                        GrowDrive = 2,
                        GrowBike = 2,
                        GrowWalk = 9,
                        AddressID = addressDictionary["ChIJwzJSKzJD04kRyawYBD_3a-k"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJm9VTOy1D04kRklz9MMK3bek",
                        GroceryDistance = 1134,
                        GroceryDrive = 124,
                        GroceryBike = 292,
                        GroceryWalk = 817,
                        GrowDistance = 41,
                        GrowDrive = 10,
                        GrowBike = 7,
                        GrowWalk = 31,
                        AddressID = addressDictionary["ChIJKeCiKjJD04kRQAAnOzznevw"]

                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJnW3xZDpD04kRPFDm3Gj7_FE",
                        GroceryDistance = 729,
                        GroceryDrive = 129,
                        GroceryBike = 181,
                        GroceryWalk = 543,
                        GrowDistance = 239,
                        GrowDrive = 53,
                        GrowBike = 37,
                        GrowWalk = 172,
                        AddressID = addressDictionary["ChIJE76jUDFD04kRm27wYE9T6tQ"]
                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJnW3xZDpD04kRPFDm3Gj7_FE",
                        GroceryDistance = 726,
                        GroceryDrive = 128,
                        GroceryBike = 180,
                        GroceryWalk = 541,
                        GrowDistance = 241,
                        GrowDrive = 53,
                        GrowBike = 38,
                        GrowWalk = 174,
                        AddressID = addressDictionary["ChIJ_a2UUDFD04kRHZXigCRWCJw"]
                    },
                    new TravelDetail
                    {
                        GroceryID = "ChIJnW3xZDpD04kRPFDm3Gj7_FE",
                        GroceryDistance = 711,
                        GroceryDrive = 127,
                        GroceryBike = 177,
                        GroceryWalk = 530,
                        GrowDistance = 257,
                        GrowDrive = 55,
                        GrowBike = 40,
                        GrowWalk = 185,
                        AddressID = addressDictionary["ChIJn2d9UjFD04kRTT9FztB_U3o"]
                    },
                    new TravelDetail()
                    {
                        GroceryID = "ChIJnW3xZDpD04kRPFDm3Gj7_FE",
                        GroceryDistance = 693,
                        GroceryDrive = 124,
                        GroceryBike = 174,
                        GroceryWalk = 524,
                        GrowDistance = 0,
                        GrowBike = 0,
                        GrowDrive = 0,
                        GrowWalk = 0,
                        AddressID =  addressDictionary["ChIJCcNF0TND04kRWpYDE3PBq1A"]

                    }
                };

                    context.TravelDetails.AddRange(travels);
                context.SaveChanges();


                }

                if (!context.Households.Any())
				{
                    SeedHouseHolds.Initialize(serviceProvider);
                }

				if (!context.MemberSituations.Any())
				{
                    var Members = context.Members.Select(a=> a).ToList();
                    var Situations = context.Situations.Select(a => a).ToList();
                    var SituationIDs = Situations.Where(a => a.Name != "Volunteer" && a.Name != "Other" && a.Name != "GAINS (For Seniors)").Select(a=> a.ID).ToArray();
                    var ToAdd = new List<MemberSituation>();

                    var Gains = context.Situations.FirstOrDefault(a => a.Name == "GAINS (For Seniors)");

                    foreach (var member in Members)
                    {
                        if (Int32.Parse(member.Age) > 65)
                        {
							ToAdd.Add(new MemberSituation
                            {
                                MemberID = member.ID, 
                                SituationID = Gains.ID,
                                SituationIncome = rnd.Next(100, 2500)
                            });
                        }

                        if (rnd.Next(1, 3) == 2)
                        {
                            ToAdd.Add(new MemberSituation
                            {
                                MemberID = member.ID,
                                SituationID = SituationIDs[(rnd.Next(0, SituationIDs.Length))],
                                SituationIncome = rnd.Next(100, 2500)
                            });
                        }
                    }
					context.AddRange(ToAdd);
                    context.SaveChanges();

                }

				if (!context.MemberDietaries.Any())
				{
                    var Members = context.Members.Select(a => a).ToList();
                    var Dietaries = context.Dietaries.Select(a => a.ID).ToArray();
                    var ToAdd = new List<MemberDietary>();

                    var Gains = context.Situations.FirstOrDefault(a => a.Name == "GAINS (For Seniors)");

                    foreach (var member in Members)
                    {
                      
                        if (rnd.Next(1, 3) == 2)
                        {
                            ToAdd.Add(new MemberDietary
							{
                                MemberID = member.ID,
                                DietaryID= Dietaries[(rnd.Next(0, Dietaries.Length))]
                            });
                        }
                    }
                    context.AddRange(ToAdd);
                    context.SaveChanges();

				}

                if (!context.MemberIllnesses.Any())
                {
                    var Members = context.Members.Select(a => a).ToList();
                    var Illnesses = context.Illnesses.Select(a => a.ID).ToArray();
                    var ToAdd = new List<MemberIllness>();

                    foreach (var member in Members)
                    {

                        if (rnd.Next(1, 3) == 2)
                        {
                            ToAdd.Add(new MemberIllness
                            {
                                MemberID = member.ID,
                                IllnessID = Illnesses[(rnd.Next(0, Illnesses.Length))]
                            });
                        }
                    }
                    context.AddRange(ToAdd);
                    context.SaveChanges();

                }                
            }
		}
	}
}