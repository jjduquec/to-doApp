
using System;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Model; 
namespace Controller
{

    public class TaskController
    {
        
        //constructor
        public TaskController()
        {
            
        }

        
        public int AddTask(string Description)
        {
            TaskModel task = new TaskModel();   
            task.Description= Description;  
            task.Status="todo"; 
            task.CreationDate=DateOnly.FromDateTime(DateTime.Today); 
            task.UpdateDate=task.CreationDate;  

            //pending : get the new Id to set  

            return -1;
        }

        private string getTasksFile()
        {
            var file=Path.Join(Directory.GetCurrentDirectory(),"tasks.json");
            return file;  
        }
        private int getNewId()
        {
            int Id=0; 
            string file= this.getTasksFile(); 
            string jsonString=File.ReadAllText(file);
            if ((!File.Exists(file)) || (string.IsNullOrWhiteSpace(jsonString)) ){
                Id=1;


            }
            else
            {
                var tasks=JsonSerializer.Deserialize<List<Task>>(jsonString);
                if(tasks==null || tasks.Count == 0)
                {
                    Id=1;
                }
                else
                {
                    Id=tasks.Max(task =>task.Id)+1;  
                }
            }
            

            return Id; 
        }




    }

}