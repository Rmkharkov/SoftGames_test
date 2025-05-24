# Game Mode Documentation

This documentation describes each gameplay mode implemented in the project, including the main menu and three demo modes created as part of the test tasks.

---

## MainMenu Mode

### Overview
The hub scene from which all demo/game modes are launched. All UI buttons leading to other modes are displayed here.

### Scene
- Persistent: `MainScene` (or your root scene containing the UI Canvas and `MainMenu` script).
- No separate scene is loaded for MainMenu; all switching logic is in place.

### UI & Controls
- All buttons are visible when in `MainMenu` mode.
- When switching to any other mode, only the "Main Menu" return button remains active.

### Logic Summary
- Buttons mapped to `EGameMode` values.
- Uses `GameModeSwitcher.SetMode(mode)`.
- `SetButtonsActiveForGameMode()` ensures only relevant buttons are shown.

---

## FireDemo Mode

### Overview
Displays a particle effect simulating fire. A UI button toggles color cycling via an Animator Controller.

### Scene
- Additive demo scene or prefab instantiated in the persistent scene.

### UI & Controls
- Button toggles color animation on/off.
- Color transitions: Orange → Green → Blue → Orange (loop).

### Logic Summary
- ParticleSystem uses custom ShaderGraph material with `_Color` parameter.
- Animator smoothly transitions the `_Color` value over time.
- Button toggles `animator.enabled`.

### Notes
- Material must support color blending.
- Texture required to avoid pixelated "blocky" fire.

---

## DialogDemo Mode

### Overview
Renders character dialogue using text and Unicode emojis, dynamically loaded from a remote endpoint.

### Scene
- DialogCanvas is either instantiated or shown additively.

### UI & Controls
- Only "Back to Main Menu" is visible in this mode.

### Logic Summary
- Downloads JSON with `dialogue` and `avatars`.
- Loads avatar textures from URL, falling back to default.
- Displays one dialogue bubble at a time, updating text, name, and avatar.

### Notes
- WebGL-safe requests.
- Avatars preloaded and passed as sprites.

---

## FireworksDemo Mode *(Optional Name)*

### Overview
Displays a firework or magic word demo (if implemented as third task).

### Scene
- Treated same as other demos.

### UI & Controls
- One "Back to Main Menu" button.

### Logic Summary
- Based on data from: `https://private-624120-softgamesassignment.apiary-mock.com/v3/magicwords`
- Displays stylized text, emojis, possibly avatar or timed display.
