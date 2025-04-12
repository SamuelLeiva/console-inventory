namespace ConsoleInventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Inventario (producto, cantidad)
            Dictionary<string, int> inventory = new Dictionary<string, int>();

            bool open = true;

            try
            {
                do
                {

                    int option;
                    Console.WriteLine("==========SISTEMA DE INVENTARIO==========");
                    Console.WriteLine("Elija una operación");
                    Console.WriteLine("1.Mostrar inventario");
                    Console.WriteLine("2.Agregar nuevo producto");
                    Console.WriteLine("3.Actualizar cantidad de producto");
                    Console.WriteLine("4.Salir\n");
                    option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            showInventory(inventory);
                            break;
                        case 2:
                            addProduct(inventory);
                            break;
                        case 3:
                            updateProduct(inventory);
                            break;
                        case 4:
                            open = false;
                            break;
                        default:
                            Console.WriteLine("Opción incorrecta. Elija una opción entre 1 y 4.\n");
                            break;
                    }

                } while (open == true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void showInventory(Dictionary<string, int> inventory)
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("No hay items en el inventario.\n");
            }
            else
            {
                foreach (var item in inventory)
                {
                    Console.WriteLine($"Item: {item.Key} - Cantidad: {item.Value}");
                }
                Console.Write("\n");
            }

        }

        static void addProduct(Dictionary<string, int> inventory)
        {
            Console.WriteLine("Ingrese el nombre del producto");
            string product = Console.ReadLine();
            Console.WriteLine("Ingrese la cantidad del producto");
            int qty = Convert.ToInt32(Console.ReadLine());

            if (product == null || product.Trim().Length == 0)
            {
                Console.WriteLine("Error! El nombre del producto no puede ser vacío.\n");
            }
            else if (qty < 0)
            {
                Console.WriteLine("Error! La cantidad de producto no puede ser negativa.\n");
            }
            else
            {
                if (inventory.ContainsKey(product))
                {
                    Console.WriteLine("Item ya existente.");
                }
                else
                {
                    inventory.Add(product, qty);
                    Console.WriteLine("Producto agregado.\n");
                }
            }
        }

        static void updateProduct(Dictionary<string, int> inventory)
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("Inventario vacío. Primero agregue productos.\n");
            }
            else
            {
                Console.WriteLine("Ingrese el nombre del producto");
                string product = Console.ReadLine();

                if (product == null || product.Trim().Length == 0)
                {
                    Console.WriteLine("Error! No ingreso el nombre del producto.\n");
                }
                else if (!inventory.ContainsKey(product))
                {
                    Console.WriteLine("Error! El inventario no tiene un item con el nombre ingresado.\n");
                }
                else
                {
                    Console.WriteLine("Ingrese la nueva cantidad.");
                    int newQty = Convert.ToInt32(Console.ReadLine());

                    if (newQty < 0 || newQty == 0)
                    {
                        Console.WriteLine("Cantidad nula o inválida.\n");
                    }
                    else
                    {
                        inventory[product] = newQty;
                        Console.WriteLine("Producto actualizado.\n");
                    }
                }
            }

        }
    }
}
