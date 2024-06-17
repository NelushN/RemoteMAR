# Week 1
- Installed unity and cloned the repo
- Succesfully got project working in unity
- Started reviewing the codebase

# Week 2
- Tried and failed to build to Windows; Vuforia does not support it
- Tried and failed to build to Android; something is breaking the build

# Week 3
- Investigated arrow annotation floating above models

# Week 4
- Added a basketball model
- Fixed floating arrow annotation; changed mesh colliders to concave instead of convex
- All annotations are not correctly being synced with the server

# Week 5

# Week 6

# Week 7
- Met with Parsa about app structure and blockers
- Started implementing features from most recent build into Parsa's build

# Week 8
- Implemented dropdown, circle annotation
- Performed some minor restyling
- Investigated the lasso being depdentant on camera location; it does not display correctly when the camera position is different; circle annotation is not syncing
- Investigated the circle annotation not syncing position correctly. Anchor object is shared, visible circle is not 
- Implemented rudimentary annotation disposal, currently selects all lassos

# Week 9
- Continued working on getting annotations to work online (lasso works but is not anchored, circle doesn't show at all)
- Converted selecting annotations to trash to a delete all model to simplify removing objects
- Nailed down the multiplayer issue to the objects sharing locations but are not parented to the model on the guest account
- Syncing works, problem is the hitmethod for finding where to place the circle runs on both machines, meaning the mouse location on the client matters when it should be dependant on owner
- Circle on both host and client models show but for some reason the positions are incorrect 
	- Send email with information from meeting
	- Fix positioning of anchored objects
	- import previous annotations 

# Week 10
- Changed approach for circle annotations and got it to work in multiplayer! When a circle is added by one user, it is instantiated by Photon then added as a parent to the model. By passing the Photon viewId for the circle into an RPC targeted at other users that does the same thing, it works correctly. 
- Adding the arrow and 2D text annotations back to the latest build
- Bringing build from personal repo to Dr. Hasan's repo 
- Found bug where clicking the add circle button when it's already enabled will spawn a bunch of circles slightly above the viewport 
- Attempted to build to Android but failed; gets stuck on start screen. Need to inspect with a logger with Android Studio, but Parsa's build works fine

# Week 11
- Make the circle parallel with model - kind of fixed by adjusting the box collider, need a smarter solution
- Fix extra circle bug on button click - fixed by changing annotation behavior 
- Bring over other model/scripts (arrow + text)
- Fix button and make it more clear - changed sprites to a color tint system
- Get a build to load - kind of fixed by optimizing build settings

# Week 12
- Make circle tangent to the model
- Improve delete system to highlight object
- Sync model info with the new player
- Bring over 2D notes

# Week 13
- Automatically set the model when a new player joins an existing room
- Add lasso based on 2D text annotation
- Add UI elements to distinguish which user is making an annotation

# Week 14
- 'Delete' working off of select
- Implement previous 2d text
- (less important) auto select model for player 2

 # Week 15 forward
 - make lasso based on 2D text annotation
 - Add branch to Khalad's repo
 - Refer to [[Final Stretch TODO]] for more
