
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
            int id=1;
            try{
                TaskModel task = new TaskModel();   
                task.Description= Description;  
                task.Status="todo"; 
                var allTasks=this.getAllTasks();  
                if( allTasks!=null )
                {
                    task.Id=allTasks.Max(i=>i.Id)+1;
                    id=task.Id;  
                    allTasks.Add(task); 
                }
                else
                {
                    task.Id=id;  
                }

                string json= JsonSerializer.Serialize(allTasks);
                var file=this.getTasksFile();  
                File.WriteAllText(file,json);


                
                
            }catch(Exception e)
            {
                var logFile=Path.Join(Directory.GetCurrentDirectory(),"log.txt") ;
                File.WriteAllText(logFile,e.ToString());
                id=-1;
            }

            

            return id;
        }

        public List<TaskModel> getAllTasks()
        {
            List<TaskModel> allTasks = new List<TaskModel>();
            var file=this.getTasksFile();
            if (File.Exists(file))
            {
                string data=File.ReadAllText(file);  
                allTasks=JsonSerializer.Deserialize<List<TaskModel>>(data); 

            }
            return allTasks; 
        }

        private string getTasksFile()
        {
            var file=Path.Join(Directory.GetCurrentDirectory(),"tasks.json");
            return file;  
        }
        private int getNewId()
        {
            int Id=1; 
            var tasks=this.getAllTasks();  
            //check if file exists and look for the highest id task 
            if((!(tasks==null) || !(tasks.Count==0)))
                {
                    Id=tasks.Max(task =>task.Id)+1;  
                }
               
            
            

            return Id; 
        }




    }

}
