using EntityFinalShopUser.Services;
using System.Text.Json;

bool condition = true;

while (condition)
{
    if (UserManager.User is null)
    {
    MainPage:

        UserPanel.MainPage();

        Console.Write("Enter your choice : ");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":

                UserPanel.RegisterPage();
                break;

            case "2":

                UserPanel.LogInPage();
                UserPanel.UserMenu();

                goto MainPage;

            case "0":

                condition = false;

                break;

            default:
                Console.WriteLine("Wrong choice");
                Thread.Sleep(2000);
                Console.Clear();
                goto MainPage;
        }
    }
}

