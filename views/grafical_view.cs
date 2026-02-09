using System; 
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
                }
                


            }
                

        }

        private void AddTask(){
            
            var task=Prompt.Input<string>("What is the task name?"); 
            if(string.IsNullOrEmpty(task)){
                Console.WriteLine("Task name cannot be empty");
                
            }else{
                Console.WriteLine($"Task {task} added successfully");
            } 
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(); 

            
         
            
        }





}