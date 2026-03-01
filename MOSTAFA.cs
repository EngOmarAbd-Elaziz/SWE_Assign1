

internal class MOSTAFA
{
    static void Main()
    {
        string[] names = new string[10];
        double[] prices = new double[10];
        int[] quantities = new int[10];

        int count = 0;
        double totalSales = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Super Market System ====");
            Console.WriteLine("1- Add Product");
            Console.WriteLine("2- View Products");
            Console.WriteLine("3- Sell Product");
            Console.WriteLine("4- Exit");
            Console.Write("Choose: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Enter Product Name: ");
                names[count] = Console.ReadLine();

                Console.Write("Enter Price: ");
                prices[count] = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Quantity: ");
                quantities[count] = Convert.ToInt32(Console.ReadLine());

                count++;
                Console.WriteLine("Product Added Successfully!");
            }
            else if (choice == 2)
            {
                Console.WriteLine("\n--- Products List ---");
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"{i + 1}- {names[i]} | Price: {prices[i]} | Quantity: {quantities[i]}");
                }
            }
            else if (choice == 3)
            {
                Console.Write("Enter Product Number: ");
                int index = Convert.ToInt32(Console.ReadLine()) - 1;

                if (index >= 0 && index < count)
                {
                    Console.Write("Enter Quantity to Sell: ");
                    int sellQty = Convert.ToInt32(Console.ReadLine());

                    if (sellQty <= quantities[index])
                    {
                        quantities[index] -= sellQty;
                        double sale = sellQty * prices[index];
                        totalSales += sale;

                        Console.WriteLine("Sale Completed!");
                        Console.WriteLine("Total Price: " + sale);
                        Console.WriteLine("Total Sales Today: " + totalSales);
                    }
                    else
                    {
                        Console.WriteLine("Not enough stock!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Product Number!");
                }
            }
            else if (choice == 4)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid Choice!");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}