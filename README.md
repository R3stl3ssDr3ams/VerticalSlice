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
<img width="1917" height="828" alt="Screenshot 2026-05-14 230242" src="https://github.com/user-attachments/assets/b21fdd4b-72be-4820-b267-6baf9e7e14c2" />

4. ScriptableOBjects have been the most modular and prevelant Unity System I have used while working on this project. Within DialogueNodes alone they carry data for the dialogue, changes in stats such as favor and energy, parameters around certain dialogue nodes, and any special conditions that may be in play, such as when the dialogue ends and the inventory needs to be set to active. Beyond this, however, they were also used to define the use of items, as well as the descriptions they will have within the inventory, and the raw image data used for the icons.

## Milestone 3 Devlog
<img width="611" height="418" alt="Screenshot 2026-06-03 224322" src="https://github.com/user-attachments/assets/57739609-481d-46d9-9872-8be51ef1a335" />

1. The shader graph plays very briefly at the start of the game, taking elements from both the shine effect and fullscreen rendering effect from the W8 in-class activity. It blends between the background and a standard black wave to create the effect of lights flickering. A sin timer and lerp node are used to oscilate between showing the image and fading to black creating an uneasy environment from the start of the experience.
2. While there were not many notes within the feedback I had received, there were multiple areas with that needed improvement in order to ensure the development of this game could progress as smoothly as possible. In essence, while much of the game's fundamental code was set up within the last milestone, there was a lot of room to streamline and decouple these systems to make them more modular. The two systems that were changed the most were NPC switching and inventory management. NPC switching within the last milestone was extremely bare bones, as the OldLady was called directly within the code to activate, ensuring the effect could run smoothly as quickly as possible before the dealine. Naturally, if I wanted to add new NPCs, this would have to change, and I made a new version of this system where, using a string attached to a ScriptableObject, I could find the desired NPC under a parent object and set it active remotely. This allows me to call different NPCs at different times depending on different events within the Unity Inspector itself, instead of hard coding it. Inventory management had a similar treatment. When I had built it initially it was only really meant to hold one item, and display within the scene. That said, some work needed to be done in order to ensure that the list would actually remove items, once used, within runtime in order to allow new items to be slotted in.
3. In terms of content, the last milestone was focused on establishing player choice through the introduction of the inventory, item usage, and investigations. Within this milestone, the effects of those choices are explored to make one coherent experience that takes players throughout one day in-game. Killing the Old Lady proves to be a vital choice as it sets the player along two paths, with different dialogues depending on which path the player is in. For example, in both paths, the player is met with the "Hunter" after being visited by the Old Lady. If the player killed her, and agrees with the Hunter that the Old Lady was indeed suspicious, he will give the cigarette item. Currently this item is locked behind these conditions, and provides the ability to gain new items which the player would, in theory, use later in the game if they choose not to interact with their next visitor. These kinds of interactions create a feeling of lasting impact withint the player as they continue to progress.
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
