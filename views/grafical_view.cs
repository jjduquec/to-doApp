using System; 
using Sharprompt;  

namespace views; 
class GraficalView
{

        public GraficalView(){}

        public void MainMenu()
        {
            var option=Prompt.Select("Main Menu", new []{"Add Task",
                                                        "Update Task",
                                                        "Delete Task",
                                                        "List All Tasks",
                                                        "List All TODO Tasks",
                                                        "List All In-Progress Tasks",
                                                        "List All Done Tasks"
                                                        });

            switch (option)
            {
                case "Add Task": 
                    this.AddTask(); 
                    break;    
            }
                

        }

        private void AddTask(){

            var task=Prompt.Input<String>("What is the task name?"); 
            Console.WriteLine($"The task is : {task}");
        }





}