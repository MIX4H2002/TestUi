using System;
using System.Windows.Automation;
class AuthenticationRobot
{
    static void Main()
    {
        int a = 2000;
        AutomationElement myServerDialog = null;
        try
        {
            myServerDialog = AutomationElement.RootElement.FindFirst(
                TreeScope.Descendants, new PropertyCondition(
                    AutomationElement.NameProperty, "Подключение к myserver")); // поиск диалогового окна 
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка в поиске диалогового окна: " + ex.Message);
        }

        if (myServerDialog != null)
        {
            try
            {
                AutomationElement usernameField = myServerDialog.FindFirst(
                    TreeScope.Descendants, new PropertyCondition(
                        AutomationElement.AutomationIdProperty, "1003")); // поиск поля "Пользователь:"
                if (usernameField != null)
                {
                    ValuePattern usernameValuePattern = (ValuePattern)usernameField.GetCurrentPattern(ValuePattern.Pattern);
                    usernameValuePattern.SetValue("qwerty"); // ввод логина в поле "Пользователь:"
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка заполнения поля 'Имя пользователя': " + ex.Message);
            }

            System.Threading.Thread.Sleep(a); // пауза перед введением пароля

            try
            {
                AutomationElement passwordField = myServerDialog.FindFirst(
                    TreeScope.Descendants, new PropertyCondition(
                        AutomationElement.AutomationIdProperty, "1005")); // поиск поля "Пароль:"
                if (passwordField != null)
                {
                    ValuePattern passwordValuePattern = (ValuePattern)passwordField.GetCurrentPattern(ValuePattern.Pattern);
                    passwordValuePattern.SetValue("12345"); // ввод пароля в поле "Пароль:"
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка заполнения поля 'Пароль': " + ex.Message);
            }

            System.Threading.Thread.Sleep(a); // пауза перед нажатием на кнопку ОК

            try
            {
                AutomationElement okButton = myServerDialog.FindFirst(
                    TreeScope.Descendants, new PropertyCondition(
                        AutomationElement.NameProperty, "ОК")); // поиск кнопки ОК
                if (okButton != null)
                {
                    InvokePattern okInvokePattern = (InvokePattern)okButton.GetCurrentPattern(InvokePattern.Pattern);
                    okInvokePattern.Invoke(); // нажатие на кнопку ОК
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при нажатии кнопки 'ОК': " + ex.Message);
            }
        }
    }
}
