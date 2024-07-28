
## Shell

### One-liner

fish shell maximum history legnth, it's unconfigurable, up to 256KB of UNIQUE commands (fish de-dups it. In short, don't worry about configuring it like zsh (which would lose my FUCKING history commands!) |||| terminal, config, zsh, fish, shell, backup, potential-data-loss
remove history entries in zsh via `LC_ALL=C sed -i '' '/porn/d' $HISTFILE` |||| terminal, zsh, macos, privacy
reverse the content in a text file via `tac OLD_FILE.txt > NEW_FILE.txt` |||| terminal, format, text-manipulation

### Multi-liner

- Setup up *fish* shell

```sh
# ~/.zshrc == ~/.config/fish/config.fish
brew install fish && fish --version
curl -L https://get.oh-my.fish | fish


# One timer set for proxy
# set proxy IN THIS WAY https://stackoverflow.com/a/30187924
# 1. run these in terminal
set -Ux https_proxy "http://127.0.0.1:7890"
set -Ux http_proxy "http://127.0.0.1:7890"
set -Ux all_proxy "socks5://127.0.0.1:7890"
set -Ux HTTPS_PROXY "http://127.0.0.1:7890"
set -Ux HTTP_PROXY "http://127.0.0.1:7890"
set -Ux ALL_PROXY "socks5://127.0.0.1:7890"
# 2. check via
cat ~/.config/fish/fish_variables

# One timer set for token
# Other one-timer global variable declaration
set -Ux HOMEBREW_GITHUB_API_TOKEN ".."  # check ~/.config/fish/fish_variables

# One timer set for PATHs (append to USER PATHs)
# I prefer 'fish_add_path /opt/mycoolthing/bin' in config.fish
# So that I could actually see and copy it over for export/backup

# change to zsh-alike default theme
omf install eclm
omf theme eclm
omf reload

# basic config
curl -sL https://git.io/fisher | source && fisher install jorgebucaran/fisher
fisher list
fisher install PatrickF1/fzf.fish
fisher install jethrokuan/z
fisher install jorgebucaran/nvm.fish && nvm install lts


# install and configure in set
# :: asdf
# 1
brew install asdf
# 2
# Add 'source ~/.asdf/asdf.fish' to ~/.config/fish/config.fish
# Run 'mkdir -p ~/.config/fish/completions; and ln -s ~/.asdf/completions/asdf.fish ~/.config/fish/completions'



# change default shell to fish
echo /usr/local/bin/fish | sudo tee -a /etc/shells
cat /etc/shells
bash
chsh -s /usr/local/bin/fish
```

## Terminal

use curl to save/download file via `curl .. --output FILE.EXTENSION` |||| terminal, curl, download
making the image smaller using (image)magick via `magick source.jpg -strip -interlace Plane -quality 85% result.jpg` |||| terminal, image, image-manipulation
minify aka compress multi-line json into one-line json through jq via `jq --compact-output < FILE.json` |||| terminal, json, format
compile applescript into a macOS application via `osacompile -o output.app input.applescript` |||| terminal, compile, application, macos, script, applescript
list npm globally installed packages via `npm list -g --depth=0` |||| terminal, javascript, package-manager, npm
list yarn globally installed packages via `yarn global list` |||| terminal, javascript, package-manager, yarn
download, archive videos: lux for Bilibili, you-get for AcFun(or 'https://leesoar.com/acfun#parse'), yt-dlp for YouTube/Xv/Ph |||| data, backup, archive, video
try new python version with anaconda via `conda create -n py312 python=3.12 && conda activate py312` |||| terminal, python
profiling like eat X RAM/CPU/Disk .. via 'https://github.com/shawn-bluce/eat' |||| terminal, profiling, fun, script, golang, go, stress-test
add dedicated Github token for homebrew via applying a classic token on 'https://github.com/settings/tokens' with no scope selected, then add that via `export HOMEBREW_GITHUB_API_TOKEN=YOUR_TOKEN` |||| terminal, homebrew, github, token, config, macos
