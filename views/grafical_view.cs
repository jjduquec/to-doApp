using System;
using System.Reflection;
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
                    
                    case "Delete Task":
                        this.DeleteTask(); 
                        break;

                    case "List All Tasks":
                        this.ListAllTasks();  
                        break;  
                    case "List All TODO Tasks":
                        this.ListTasksByStatus("ToDo");
                        break;
                    case "List All In-Progress Tasks":
                        this.ListTasksByStatus("In-Progress");
                        break;
                    case "List All Done Tasks":
                        this.ListTasksByStatus("Done");
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
            bool result=false;  
            taskList=controller.getAllTasks();  
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

                    taskId=int.Parse((option.Split("\t"))[0]);                    
                    option=Prompt.Select("What you want update in this task?", new []
                                                                                    {
                                                                                     "Change the status", 
                                                                                     "Change the desription",
                                                                                     "exit"                                                                    
                                                                                    } );

                    switch (option)
                    {
                        case"Change the status":
                            string newStatus=Prompt.Select("Select the new status",new []
                                                                                        {
                                                                                         "ToDo",
                                                                                         "In-Progress",  
                                                                                         "Done"  
                                                                                        });

                            result=controller.UpdateTask(taskId,newStatus,"Status");
                            

                            break;    
                        case "Change the desription": 
                            string newDescription=Prompt.Input<string>("What is the new description? ");
                            result=controller.UpdateTask(taskId,newDescription,"Description");
                            break;  
                        

                    }
                    if (result)
                            {
                                Console.WriteLine("Change has been made successfully ");
                            }
                            else
                            {
                                Console.WriteLine("Task hasn't been modified");
                            }

                    
                }
                
                Console.WriteLine("Press any key to continue"); 
                Console.ReadKey(); 

            }
        
        
        
        }//end UpdateTask

        private void DeleteTask()
        {
            var controller= new TaskController();  
            var taskList= new List<(int Id , string Description , string Status)>();  
            var options= new List<string>();
            var option=""; 
            int taskId=0; 
            bool result=false;  
            taskList=controller.getAllTasks();   
            foreach(var task in taskList)
            {
                      option=$"{task.Id}\t{task.Description}\t{task.Status}";      
                      options.Add(option); 
                      
            }
            options.Add("Exit"); 
            option=Prompt.Select("Select the task to be deleted",options);
        if (option != "Exit") 
        {
            //gettitng task Id 
            taskId=int.Parse((option.Split("\t")[0]));   
            result=controller.DeleteTask(taskId);
            if (result)
            {
                Console.WriteLine("Task has been deleted successfully");
            }
            else
            {
                Console.WriteLine("Something went wrong , please check the log file");  
            }

        }
        else
        {
            Console.WriteLine("Delete operation has been canceled");  
        }
        Console.WriteLine("Press any key to continue");  
        Console.ReadKey();  


    
            
        }// end DeleteTask
         private void ListAllTasks()
        {   
            var controller = new TaskController();  
            var taskList = new List<(int Id,string Description,string Status)>();  
            taskList= controller.getAllTasks(); 
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
            
        }//end ListAllTasks  

        private void ListTasksByStatus(string Status)
        {
            var controller = new TaskController();  
            var taskList= new List<(int Id , string Description)>();
            taskList=controller.getTasksByStatus(Status);
            if (taskList.Count != 0)
            {
                Console.WriteLine("Id \t Description");
                foreach(var task in taskList)
                {
                    Console.WriteLine(task.Id+"\t "+task.Description);
                    


                }
            }
            else
            {
                Console.WriteLine($"There are no task with the status {Status} \n");   
            }

            Console.WriteLine("Press any key to continue \n");  
            Console.ReadKey();
                
        }





}