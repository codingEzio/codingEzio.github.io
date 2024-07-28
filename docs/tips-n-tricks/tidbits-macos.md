macos single app mode via `defaults write com.apple.dock single-app -bool true/no ;killall Dock` |||| macos, focus, toggle, config
macos reduce save windows animation speed via `defaults write NSGlobalDomain NSWindowResizeTime .001` |||| macos, animation, config
macos revert reduce save windows animation speed via `defaults delete NSGlobalDomain NSWindowResizeTime` |||| macos, animation, config
macos reduce check file info animation speed via `defaults write com.apple.finder DisableAllAnimations -bool true` |||| macos, animation, config
macos revert reduce check file info animation speed via `defaults delete com.apple.finder DisableAllAnimations` |||| macos, animation, config
safari cloud tabs showing old/closed tabs, fix by deleting files started with 'CloudTabs.' under '~/Library/Containers/com.apple.Safari/Data/Library/Safari', then relaunch safari |||| macos, safari, cloud, data, potential-data-loss
macos dock only shown opened apps via `defaults write com.apple.dock static-only -bool True` |||| macos, animation, config
macos dock add spacer via `efaults write com.apple.dock persistent-apps -array-add '{"tile-type"="spacer-tile";}' ;` |||| macos, dock

iTerm turn off selection in block mode (find and replace only in that context) |||| terminal, config, iterm
Hide/remove the border-thingy after clicking a random spot in dark theme by 'Uncheck "Clicking on a command selects it to restrict Find and Filter" within General / Selection' |||| terminal, gui, config, style

can run x86 apps on windows 11 via VMWare Fusion on M-seires Mac |||| windows, mac, vmware, m-chip, virtualization
