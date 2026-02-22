
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
                var task = new TaskModel();   
                var allTasks= new List<TaskModel>(); 
                task.Description= Description;  
                task.Status="todo"; 
                allTasks=this.getAllTasks();  
                 
                                
                if (allTasks.Count==0)
                {
                    task.Id=1;
                }
                else
                {
                    task.Id=allTasks.Max(i=>i.Id)+1;
                    id=task.Id;  
                    
                
                }


                allTasks.Add(task); 
                string data=JsonSerializer.Serialize(allTasks,new JsonSerializerOptions
                                                                                        {
                                                                               WriteIndented=true             
                                                                                            
                                                                                        });

                var file=this.getTasksFile();  
                File.WriteAllText(file,data);
                

                
                
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
            try
            {
                var allTasks= new List<TaskModel>();  
                string file=this.getTasksFile();
                if (File.Exists(file))
                {
                    var data=File.ReadAllText(file);  
                    allTasks=JsonSerializer.Deserialize<List<TaskModel>>(data);
                    
                

                }
               

                return allTasks; 

            }
            catch
            {
                return new List<TaskModel>();     

            }
            
            
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
