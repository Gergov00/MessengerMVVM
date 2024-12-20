using MsBox.Avalonia;


namespace MessengerMVVM
{
    static class ShowMessage
    {
        public static async void Message(string title, string message)
        {
            var messageBox = MessageBoxManager
                .GetMessageBoxStandard(title, message);
            var result = await messageBox.ShowAsync();
        }
    }
}
