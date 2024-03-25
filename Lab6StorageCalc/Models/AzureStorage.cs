using System.ComponentModel.DataAnnotations;

namespace Lab6StorageCalc.Models
{
    public class AzureStorage
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than zero")]
        public double StorageGB { get; set; }
        public static string[] Redundancy
        {
            get
            {
                return new string[] {"Geographical" , "Local"};
            }
        }

        public double Cost
        {
            get
            {
                double costPerGBFirstTB;
                double costPerGBAfterFirstTB;

                if (Redundancy.Contains("Geographical"))
                {
                    costPerGBFirstTB = 0.125;
                    costPerGBAfterFirstTB = 0.11;
                }
                else
                {
                    costPerGBFirstTB = 0.093;
                    costPerGBAfterFirstTB = 0.083;
                }

                double totalCost;
                if (StorageGB <= 1000)
                {
                    totalCost = StorageGB * costPerGBFirstTB;
                }
                else
                {
                    totalCost = (1000 * costPerGBFirstTB) + ((StorageGB - 1000) * costPerGBAfterFirstTB);
                }

                return totalCost;
            }
        }
            
    }
}
