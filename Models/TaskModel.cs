namespace Model{

    public class TaskModel
    {
        public int Id  {get;set;}
        public string Description {get;set;} 
        public string Status {get;set;}  
        public DateOnly CreationDate {get;set;} 

        public DateOnly UpdateDate {get;set;}

        public TaskModel()
        {
            Id=0;  
            Description=""; 
            Status="ToDo"; 
            CreationDate=DateOnly.FromDateTime(DateTime.Today);
            UpdateDate=DateOnly.FromDateTime(DateTime.Today);
        }    


        
        
    }
}