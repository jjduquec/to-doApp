This is a ToDo App made to be used through command line interface  
the app provide two ways of interaction : 
  - commands
  - simple interface

to access to the simple interface, its just required run the project  
in case you preffer use it by commands :  

# Adding a new task
task-cli add "Buy groceries"
# Output: Task added successfully (ID: 1)
# Updating and deleting tasks
task-cli update 1 "Buy groceries and cook dinner"
task-cli delete 1
# Marking a task as in progress or done
task-cli mark-in-progress 1
task-cli mark-done 1
# Listing all tasks
task-cli list
# Listing tasks by status
task-cli list done
task-cli list todo
task-cli list in-progress

This project was based by roadmap.sh task tracker project :  
https://roadmap.sh/projects/task-tracker
