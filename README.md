# GDIM33 Vertical Slice
## Milestone 1 Devlog
### Part I
In spite having little practice in actually applying visual scripting in my program, I managed to find some use in it when attaching it to the state machine. I created a conditional within the NPC which would dictate when certain behaviors, known under the _infectionstate variable, would be called. For example, if the total favor the player accumulates during the experience is Greater than or equal to ten, it will be read as being "Stable," if it were greater than five, it would be read as "infected," and anything beyond would be considered "Critical". While this mechanic does not play a real role within the demo is there, the present infrastructure can be expanded upon within future milestones.

### Part II
<img width="876" height="656" alt="Screenshot 2026-05-02 015400" src="https://github.com/user-attachments/assets/064d9d14-503a-4994-b94f-a09d00d881ef" />

From the start, the state machine was always going to be used to determine the _infectionstate of the given NPC, hence not much changed beyond some of the specifics. For example, state changes used to be made on Awake() after each day ahd passed and the scene reset. Now however, this will change at the end of every dialogue node. This is in hopes to make the experience much more dynamic between interactions, as the condition will always be updated. The means for this change is tied with the current "favor" system implemented in game, where players continually gain a social stat called favor which is stored as an integer within the player class. Using this integer, the player class can be referenced to allow for certain events to happen as a response to changes in favor. In the demo, this is what allows for certain dialogue options to appear only after choosing a certain path, and dissapearing in others.

In the future, the state machine will be used to trigger entire dialogue nodes according to the present infection state, which will provide further impact and variance between player experiences. In this case, these changes would be stored within the Awake() function so that whenever a new NPC appears within the scene, it will immediately determine which dialogue node to select in accordance with their current stored _infectionstate. The terms for these changes will vary using an inherited class,so that certain NPC will be able to be stabilized faster and easier than others.
## Milestone 2 Devlog
### Part I
1. Creating the Inventory system:
- Have items be stored within the Player inventory.
    - Create a ScriptableObject class for Items
    - Attach created Item ScriptableObjects to DialogueNode when necessary.
    - Create a list within the player class that can take the ScriptableObject from the node and sotry it within the class itself.
- Allow players to use these items through a projected menu between NPC visits. 
    - Create a public bool that indicates when dialogue has ended with an NPC, allowing the inventory menu to appear.
    - Create a function that takes the sprite from the Item ScriptableObject within the player class and crates an icon out of it within the inventory.
    - Create an OnClick() function that allows players to inspect the item, both with an enlarged image and clear description. This should be concurent with the activation of a button that will let the player use the item.
    - Create another OnClick, this time on the Use button, to allow players to experience any of the item's effects.
    - Have a button to close out the menu and continue the game.

### Part II
2. The use of the breakdowns can typically vary between mechanics. Typically they provide a good foundation toward what needs to be done, but they are, and should, often be suject to change. For example, under the second step there is a sub-step that states that the icon must be taken from the player class and implemented to the button gameObject. This had to be changed in practice due to how sprites work on Unity, and instead, raw images were added above the icon spaces within the inventory in order to allow Item ScriptableObject to simply provide the texture instead of the sprite. While my breakdown was flawed in this interpretation, it ultimately did its job of providing me a framework to base my work off of upon implementation.
3. Within the NPC class, there is an enum that referred to as "NPCSpeech". This enum describes behaviors done by the NPC within dialogue, such as activating the dialogue box and allowing the player to progress through dialogue by clicking on their mouse / trackpad. Using a state machine, I was able to notify when the NPC made a switch to the "Talking" behavior by triggering a small animation, where the sprite would move up and down upon changing the state. Not only would this demonstrate that the NPC has switched behaviors as intended, it also allows NPCs appear more lively to the player upon interaction.
4. ScriptableOBjects have been the most modular and prevelant Unity System I have used while working on this project. Within DialogueNodes alone they carry data for the dialogue, changes in stats such as favor and energy, parameters around certain dialogue nodes, and any special conditions that may be in play, such as when the dialogue ends and the inventory needs to be set to active. Beyond this, however, they were also used to define the use of items, as well as the descriptions they will have within the inventory, and the raw image data used for the icons.

## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
- Energy Drink PNG:
https://www.pngarts.com/explore/136211
- Old Woman PNG
https://www.magnific.com/free-photos-vectors/older-women-transparent
- Stock image of College Student
https://www.istockphoto.com/photo/college-student-with-books-gm177232576-19910458
- Apartment Stock Image
https://www.istockphoto.com/search/2/image-film?phrase=scary+apartment
- Image of William Hurt playing Tom Grunick in "Broadcast News"
https://www.tcm.com/articles/1074453/broadcast-news
