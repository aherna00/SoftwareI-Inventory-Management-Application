using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C968_Software_I.Classes
{
    public static class Inventory
    {
        public static BindingList<Product> Products = new BindingList<Product>();

        public static BindingList<Part> AllParts = new BindingList<Part>();

        public static void SampleDataLoad() 
        {
            Part TestPart1 = new Inhouse 
            {
                PartID = 1,
                Name = "MyPart1",
                Price = 10.00m,
                InStock = 1,
                Min = 1,
                Max = 5,
                MachineID = 1
            };

            AllParts.Add(TestPart1);

            Part TestPart2 = new Outsourced
            {
                PartID = 2,
                Name = "MyPart2",
                Price = 11.00m,
                InStock = 1,
                Min = 1, 
                Max = 5,
                CompanyName = "ABC Company"
            };

            AllParts.Add(TestPart2);


            Product TestProduct1 = new Product
            {
                ProductID = 1,
                Name = "Product1",
                Price = 9.99m,
                InStock = 1,
                Min = 1,
                Max = 5,
               
                
            };
            TestProduct1.addAssociatedPart(TestPart2);

            Products.Add(TestProduct1);

            Product TestProduct2 = new Product
            {
                ProductID = 2,
                Name = "Product2",
                Price = 9.99m,
                InStock = 6,
                Min = 1,
                Max = 10
            };

            Products.Add(TestProduct2);
        }

      
        public static void AddProduct(Product product)  
        {
            Products.Add(product);
        }


        public static void AddPart(Part part)
        {
            AllParts.Add(part);
        }

        public static void updatePart(int partID, Part partToUpdate)
        {
            for (int i = 0; i < AllParts.Count; i++)
            {
                if (AllParts[i].PartID == partID)
                {
                    AllParts[i] = partToUpdate;
                    return;
                }
            }

            throw new Exception($"Could not update Part with PartID: {partID}");
        }


        public static Part LookupPart(int partID)
        {
            foreach (Part part in AllParts)
            {
                if (part.PartID == partID)
                {
                    return part;
                }
            }

            throw new Exception($"Could not find part with ID: {partID}");
        }

        public static bool DeletePart(Part partToDelete)
        {
            bool deleteSuccessful = false;

            try {
                AllParts.Remove(partToDelete);
                deleteSuccessful = true;
                return deleteSuccessful;
            }
            catch(Exception err) {
                Console.WriteLine($"Error could not delete: {err.Message} ");

                return deleteSuccessful;
            
            }
       
        }

        public static bool RemoveProduct(int productToRemoveID)
        {
            bool removeSuccessful;

            foreach (Product product in Products.ToList())
            {
                if (product.ProductID == productToRemoveID)
                {
                    Products.Remove(product);
                    removeSuccessful = true;
                    return removeSuccessful;
                }
            }

            throw new Exception($"Could not delete Product with Product ID: {productToRemoveID}");
        }

        public static Product LookupProduct(int productToFindID)
        {
            foreach(Product product in Products)
            {
                if (product.ProductID == productToFindID)
                {
                    return product;
                }
            }

            throw new Exception($"Could not find Product with Product ID: {productToFindID}");
        }

        public static void UpdateProduct(int productToUpdateID, Product productToUpdate)
        {
 

            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].ProductID == productToUpdateID)
                {
                    Products[i] = productToUpdate;
                    return;
                }
            }

            throw new Exception($"Could not update Part with PartID: {productToUpdateID}");
        }

        // Helpers

        public static bool ValidateMinMax(Part part)
        {
            if(part.Min > part.Max)
            {
                MessageBox.Show("ERROR - Min must be less than Max value");
                return false;
            };

            return true;
        }

        public static bool ValidateMinMax(Product product)
        {
            if (product.Min > product.Max)
            {
                MessageBox.Show("ERROR - Min must be less than Max value");
                return false;
            };

            return true;
        }

        public static bool ValidateInventory(Part part)
        {
            bool validationSuccessful = true;

            if(part.InStock > part.Max || part.InStock < part.Min)
            {
                MessageBox.Show($"ERROR - Inventory must be between Minimum: {part.Min} and Maximum: {part.Max}");
                validationSuccessful = false;
                return validationSuccessful;
            };

            return validationSuccessful;
        }

        public static bool ValidateInventory(Product product)
        {
            bool validationSuccessful = true;

            if (product.InStock > product.Max || product.InStock < product.Min)
            {
                MessageBox.Show($"Error - Inventory must be between Minimum: {product.Min} and Maximum: {product.Max}");
                validationSuccessful = false;
                return validationSuccessful;
            }

            return validationSuccessful;
        }

        public static int GenerateID()
        {
            Random rnd = new Random();
            int generatedID = rnd.Next(3, 2000); 
            return generatedID;

        }


    }
}
