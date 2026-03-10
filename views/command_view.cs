using Controller; 
class CommandView
{
    public CommandView(){}

    public void processArguments(string[] parameters)
    {
        string command= parameters[0];
    
        switch (command)
        {
            case "add":
                this.addTask(parameters[1]);
                break;  

            case "update":
                if (parameters.Length == 3)
                {
                    this.updateDescription(int.Parse(parameters[1]),parameters[2]);
                }
                else
                {
                    Console.WriteLine("For update a task is required : an id and a description");
                    Console.WriteLine("Please check your command");
                }
                
                break;
        }
    } 

    private void addTask(string task)
    {
        if(string.IsNullOrEmpty(task)){
                Console.WriteLine("Task name cannot be empty");
                
            }else{
                TaskController controller= new TaskController();  
                var result= controller.AddTask(task);  
                if(result != -1)
                {
                  Console.WriteLine("Task has been added succesfully\n"); 
                  Console.WriteLine($"Task Id: {result}");  
                }
                else
                {
                 Console.WriteLine("Something went wrong, please check the log file \n");   
                 Console.WriteLine($"Id received: {result}");
                }
            }
    
    }

    //update description 
    private void updateDescription(int id , string description)
    {
        var controller= new TaskController();  
        bool result;
        if (string.IsNullOrEmpty(description))
        {
            Console.WriteLine("Task must have a new description, please check your command");
        }
        else
        {   
            result = controller.UpdateTask(id,description,"description"); 
            if (result)
            {
                Console.WriteLine("The description has been updated");
            }
            else
            {
                Console.WriteLine("The task has not been updated"); 
                Console.WriteLine("Please check the command introduced"); 
            }    
        }
        
    }






}