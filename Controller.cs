
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
            //pending : get the new Id to set  

            return -1;
        }







    }

}