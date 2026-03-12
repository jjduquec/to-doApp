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
                if (parameters.Length==2)
                {
                    this.addTask(parameters[1]);
                }
                else
                {
                    Console.WriteLine("To add a task is required a description, eg : add \"wash the dishes\" ");
                    Console.WriteLine("Please check your command");
                }
                
                break;   
            
            case "list": 
                this.listTasks(); 
                break;

            case "update":
                if (parameters.Length == 3)
                {
                    this.updateDescription(int.Parse(parameters[1]),parameters[2]);
                }
                else
                {
                    Console.WriteLine("To update a task is required : an id and a description");
                    Console.WriteLine("Please check your command");
                }
                break;

            case "mark-in-progress": 
                if (parameters.Length == 2)
                {
                    this.updateStatus(int.Parse(parameters[1]),"In-Progress");
                }
                else
                {
                    Console.WriteLine("For mark a task in progress, its required the task Id eg: mark-in-progress 1");
                    Console.WriteLine("Please check your command");
                }
              
                break;

            case "mark-done": 

                if (parameters.Length == 2)
                    {
                        this.updateStatus(int.Parse(parameters[1]),"Done");
                    }
                    else
                    {
                        Console.WriteLine("To mark a task as done , its required the task Id eg: mark-done 1");
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

    private void listTasks()
    {
        var controller= new TaskController(); 
        var taskList= new List<(int id , string description , string status)>();

        taskList=controller.getAllTasks();
        if (taskList.Count > 0)
        {
            foreach(var task in taskList)
            {
                Console.WriteLine(task.id+"\t"+task.description+"\t"+task.status);
            }
        }
        else
        {
            Console.WriteLine("There are not task to show");
        }
    }
    private void updateStatus(int id , string status)
    {
        var controller= new TaskController();  
        bool change =controller.UpdateTask(id,status,"Status");
        if (change)
        {
            Console.WriteLine("Task status has been updated");
        }
        else
        {
            Console.WriteLine("Something went wrong, please check the log");
        }

    }






}