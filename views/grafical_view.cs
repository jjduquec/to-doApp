using System; 
using Controller;
using Sharprompt;  

namespace views; 
class GraficalView
{

        public GraficalView(){}

        public void MainMenu()
        {
            string option="";
            while(option!="Exit"){
                Console.Clear();
                option=Prompt.Select("Main Menu", new []{"Add Task",
                                                        "Update Task",
                                                        "Delete Task",
                                                        "List All Tasks",
                                                        "List All TODO Tasks",
                                                        "List All In-Progress Tasks",
                                                        "List All Done Tasks",
                                                        "Exit"

                                                        });
                Console.Clear();
                switch (option)
                {
                    case "Add Task": 
                        this.AddTask(); 
                        break;  

                    case "Update Task": 
                        this.UpdateTask(); 
                        break;


                    case "List All Tasks":
                        this.ListAllTasks();  
                        break;  

                }
                


            }
                

        }

        private void AddTask(){
            
            var task=Prompt.Input<string>("What is the task name?"); 
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
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(); 

            
         
            
        }

        
        private void UpdateTask()
        {
            var controller= new TaskController();  
            var taskList= new List<(int Id , string Description , string Status)>();  
            var options= new List<string>();
            var option=""; 
            int taskId=0; 
            taskList=controller.listAllTasks();  
            if (taskList.Count==0)
            {
                Console.WriteLine("Tasks not found, please add a task ");
                Console.WriteLine("Press any key to continue"); 
                Console.ReadKey();

            }
            else
            {
                foreach(var task in taskList)
                {
                      option=$"{task.Id}\t{task.Description}\t{task.Status}";      
                      options.Add(option); 
                      
                }    
                options.Add("exit");

                option=Prompt.Select("Select the task to be updated",options);
                if (option != "exit")
                {
                    var temp=option.Split("\t"); 
                    taskId=int.Parse(temp[0]); 
                    
                }
                
                Console.WriteLine("Press any key to continue"); 
                Console.ReadKey(); 

            }
        
        
        
        }//end UpdateTask
         private void ListAllTasks()
        {   
            var controller = new TaskController();  
            var taskList = new List<(int Id,string Description,string Status)>();  
            taskList= controller.listAllTasks(); 
            if(taskList.Count != 0)
            {    

               
                foreach(var task in taskList)
                {
                    Console.WriteLine(task.Id+"\t"+task.Description+"\t"+task.Status+"\n");




                }

        }
        else
        {
            Console.WriteLine("There are no new tasks \n");
        }
        Console.WriteLine("Press any key to continue \n");
        Console.ReadKey(); 
            
        }





}