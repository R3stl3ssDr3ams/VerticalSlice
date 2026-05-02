# GDIM33 Vertical Slice
## Milestone 1 Devlog
### Part I
In spite having little practice in actually applying visual scripting in my program, I managed to find some use in it when attaching it to the state machine. I created a conditional within the NPC which would dictate when certain behaviors, known under the _infectionstate variable, would be called. For example, if the total favor the player accumulates during the experience is Greater than or equal to ten, it will be read as being "Stable," if it were greater than five, it would be read as "infected," and anything beyond would be considered "Critical". While this mechanic does not play a real role within the demo is there, the present infrastructure can be expanded upon within future milestones.

### Part II
<img width="876" height="656" alt="Screenshot 2026-05-02 015400" src="https://github.com/user-attachments/assets/064d9d14-503a-4994-b94f-a09d00d881ef" />

From the start, the state machine was always going to be used to determine the _infectionstate of the given NPC, hence not much changed beyond some of the specifics. For example, state changes used to be made on Awake() after each day ahd passed and the scene reset. Now however, this will change at the end of every dialogue node. This is in hopes to make the experience much more dynamic between interactions, as the condition will always be updated. The means for this change is tied with the current "favor" system implemented in game, where players continually gain a social stat called favor which is stored as an integer within the player class. Using this integer, the player class can be referenced to allow for certain events to happen as a response to changes in favor. In the demo, this is what allows for certain dialogue options to appear only after choosing a certain path, and dissapearing in others.

In the future, the state machine will be used to trigger entire dialogue nodes according to the present infection state, which will provide further impact and variance between player experiences. In this case, these changes would be stored within the Awake() function so that whenever a new NPC appears within the scene, it will immediately determine which dialogue node to select in accordance with their current stored _infectionstate. The terms for these changes will vary using an inherited class,so that certain NPC will be able to be stabilized faster and easier than others.
## Milestone 2 Devlog
Milestone 2 Devlog goes here.
## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
- Cite any external assets used here!
