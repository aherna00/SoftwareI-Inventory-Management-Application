using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C968_Software_I.Classes
{
    public class Product
    {

        public BindingList<Part> AssociatedParts = new BindingList<Part>();
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }


        
        public void addAssociatedPart(Part part) {
            AssociatedParts.Add(part);
        }

        
        public bool removeAssociatedPart(int partToRemoveID) {

            bool removedSuccessfully = false;

            foreach (Part part in AssociatedParts.ToList())
            {
                if (part.PartID == partToRemoveID)
                {
                    AssociatedParts.Remove(part);
                    removedSuccessfully = true;
                    return removedSuccessfully;
                }
            }

            throw new Exception($"Failed to remove associated part with ID: {partToRemoveID}");

        } 

   
        public Part lookupAssociatedPart(int partToLookupID)
        {
            foreach (Part part in AssociatedParts.ToList())
                if (part.PartID == partToLookupID)
                {
                    return part;
                }

            throw new Exception($"Failed to find associated part with ID: {partToLookupID} ");
        }

    }
}
