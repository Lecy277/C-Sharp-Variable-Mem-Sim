# C-Sharp-Variable-Mem-Sim

The following c# code creates a gui based variable memory simulator. The free space displays how much memory is available to be used up to 1000 mb. 
![capture](https://user-images.githubusercontent.com/35905246/44883775-4c453800-ac86-11e8-9357-42b354f3d290.PNG)
The blocks of memory can be allocated in whatever sized chunks the user desires up to 1000 mb by typing in the amount in the box at the bottom and clicking the "add" button. Once a block of memory is added the free space is subtracted from the ammount the user added in. A process number is given and displayed under P# in the order of each block of memory that was added to the simultor.


Once all the free space is taken a pop up box displays the message that "The memory is full" and the add button is then disabled because no more memory is free to be allocated. Left clicking on the Process removes that block of used memory and adds it back into the free space and this displays a message that the add button is "Enabled because the memory is less then full!". The compaction button at the bottom adds all free spaces together into one large chunk.


