# C-Sharp-Variable-Mem-Sim

The following c# code creates a Gui based variable memory simulator. The free space displays how much memory is available to be used up to 1000 Mb. 

![capture](https://user-images.githubusercontent.com/35905246/44883775-4c453800-ac86-11e8-9357-42b354f3d290.PNG)

The blocks of memory can be allocated in whatever sized chunks the user desires up to 1000 Mb by typing in the amount in the box at the bottom and clicking the "add" button. Once a block of memory is added the free space is subtracted from the amount the user added in. A process number is given and displayed under P# in the order of each block of memory that was added to the simulator.

![capture1](https://user-images.githubusercontent.com/35905246/44883829-94fcf100-ac86-11e8-98e9-e6f0229924f5.PNG)

Once all the free space is taken a pop up box displays the message that "The memory is full" and the "add" button is then disabled because no more memory is free to be allocated.

![capture2](https://user-images.githubusercontent.com/35905246/44883832-962e1e00-ac86-11e8-8650-029407484ee9.PNG)

![capture3](https://user-images.githubusercontent.com/35905246/44883833-97f7e180-ac86-11e8-8fab-3739f436f5e2.PNG)

Left clicking on the Process removes that block of used memory and adds it back into the free space and this displays a message that the "add" button is "Enabled because the memory is less then full!".

![capture4](https://user-images.githubusercontent.com/35905246/44884039-aabee600-ac87-11e8-8cf7-de337862bcea.PNG)
![capture5](https://user-images.githubusercontent.com/35905246/44884040-ac88a980-ac87-11e8-9653-6db591383149.PNG)

The compaction button at the bottom adds all free spaces together into one large chunk.






