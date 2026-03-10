using views;
class ToDoApp
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            var graficalView= new GraficalView();  
            graficalView.MainMenu();
        }
        else
        {
            var commandView= new CommandView();  
            commandView.processArguments(args);
        }
    }


    
}

