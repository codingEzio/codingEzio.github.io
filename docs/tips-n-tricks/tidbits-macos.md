
## Content

### M-series Macs

- Q: Can you run x86 apps on Windows 11 via VMWare Fusion
- A: Yes (oh, okay)

### iTerm2

- Q: Hide/remove the border-thingy after clicking a random spot in dark theme by
- A
    - Go to General / Selection
    - Uncheck "Clicking on a command selects it to restrict Find and Filter"

### macOS Tweaks via `defaults`

```sh
# Enable single app mode in macOS
# Disable single app mode in macOS
defaults write com.apple.dock single-app -bool true; killall Dock
defaults write com.apple.dock single-app -bool false; killall Dock

# Reduce save window animation speed
# Revert save window animation speed
defaults write NSGlobalDomain NSWindowResizeTime .001
defaults delete NSGlobalDomain NSWindowResizeTime

# Reduce check file info animation speed
# Revert check file info animation speed
defaults write com.apple.finder DisableAllAnimations -bool true
defaults delete com.apple.finder DisableAllAnimations

# Fix Safari cloud tabs showing old/closed tabs
rm ~/Library/Containers/com.apple.Safari/Data/Library/Safari/CloudTabs.* && open -a Safari

# Show only opened apps in the Dock
defaults write com.apple.dock static-only -bool true; killall Dock

# Add a spacer to the Dock
defaults write com.apple.dock persistent-apps -array-add '{"tile-type"="spacer-tile";}'; killall Dock
```
