using CastleActiveRecord.Entity;
using CastleActiveRecord.Persistence;
using System;
using System.Collections.Generic;
using static System.Console;

namespace CastleActiveRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            // If you are developing a web application, call this method in Global.asax / Application_Start
            InitializeActiveRecord();
            // =====================

            ActiveRecordSamples();                                    
            ReadLine();
        }

        /// <summary>
        /// This method demonstrates how to use the most used ActiveRecord features.
        /// Debug and change this method to learn how ActiveRecord works.
        /// </summary>
        private static void ActiveRecordSamples()
        {
            // Creating a new customer...
            Customer customer = new Customer();
            customer.FirstName = "Danilo";
            customer.LastName = "A. Meireles";
            Customer.Save(customer);





            // Creating some categories...
            List<Category> categories = new List<Category>()
            {
                new Category() { Name = "Cellphones" },
                new Category() { Name = "Computers" },
                new Category() { Name = "Tablets" },
                new Category() { Name = "Video Games" },
                new Category() { Name = "Accessories" }
            };

            foreach (var category in categories)
                Category.Save(category);




            // Creating some products...
            List<Product> products = new List<Product>()
            {
                new Product() { Name = "Samsung Galaxy S8", Price = new decimal(789.99), Category = categories[0] },
                new Product() { Name = "Dell XPS 13", Price = new decimal(1144.99), Category = categories[1] },
                new Product() { Name = "Samsung Galaxy Tab", Price = new decimal(989.59), Category = categories[2] },
                new Product() { Name = "Playstation 4", Price = new decimal(299.99), Category = categories[3] },
                new Product() { Name = "Microsoft Surface Mouse", Price = new decimal(64.99), Category = categories[4] }
            };

            foreach (var prod in products)
                Product.Save(prod);




            // Creating a Shopping Cart...
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                CreationDate = DateTime.Now,
                Customer = customer
            };

            ShoppingCart.Save(shoppingCart);




            // Adding items (products) to the Shopping Cart:
            List<ShoppingCartItem> items = new List<ShoppingCartItem>()
            {
                new ShoppingCartItem() { ShoppingCart = shoppingCart, Product = products[3], Quantity = 1 },
                new ShoppingCartItem() { ShoppingCart = shoppingCart, Product = products[4], Quantity = 2 }
            };

            foreach (var item in items)
                ShoppingCartItem.Save(item);



            // Getting a product by Id:
            var product = Product.Find(1);




            // Updating a product:
            product.Name = "New name.";
            product.Price = new decimal(850.45);
            Product.Save(product);



                        
            // Deleting a product:
            Product.Delete(product);




            // Getting a product by property:
            var productsInACategory = Product.FindAllByProperty("Category.Id", 2); // returns products in category 2




            // Getting a customer shopping cart:
            var custumerShoppingCart = ShoppingCart.GetShoppingCartByCustomer(1); // returns the shopping cart of customer 1





            // Getting itens in shopping cart:
            var itemsInCart = ShoppingCartItem.GetItemsByShoppingCart(custumerShoppingCart.Id); // returns itens in a shopping cart




            // Canceling a shopping cart:
            custumerShoppingCart.Cancel();
            ShoppingCart.Save(custumerShoppingCart);
        }
        
        /// <summary>
        /// This method demonstrates how to initialize the ActiveRecord with PostgreSQL.        
        /// </summary>
        private static void InitializeActiveRecord()
        {
            ActiveRecordPostgresConfig arPostgresConfig = 
                new ActiveRecordPostgresConfig(activeRecordClassesAssemblyName: "CastleActiveRecord", showSql: false);

            arPostgresConfig.Initialize();
            //arPostgresConfig.DropSchema(); // Call this method to drop the database schema.
            //arPostgresConfig.CreateSchema(); // Call this method to create the database schema.

            // Call GenerateCreationScripts() method if you want to see the Creation Script:
            string directory = @"C:\Users\danilomeireles\Downloads\";
            string fileName = directory + "script_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".sql";
            arPostgresConfig.GenerateCreationScripts(fileName);
        }
    }
}
