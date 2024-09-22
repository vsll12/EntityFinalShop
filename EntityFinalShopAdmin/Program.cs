using EntityFinalShopAdmin.Services;

bool condition = true;
while (condition)
{
MenuCommand:
    Console.Clear();
    Console.WriteLine("1. Login");
    Console.WriteLine("2. Exit");
    Console.Write("Enter your choice : ");
    string choice = Console.ReadLine()!;
    switch (choice)
    {
        case "1":

            AdminPanel.LogIn();
            AdminPanel.MainMenu();

            break;

        case "2":

            condition = false;

            break;

        default:

            Console.WriteLine("Wrong choice");
            Thread.Sleep(2000);

            goto MenuCommand;
    }
}
