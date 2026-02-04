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

            Console.WriteLine(option);  
                

        }





}