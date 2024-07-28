
## Shell

fish shell maximum history legnth, it's unconfigurable, up to 256KB of UNIQUE commands (fish de-dups it. In short, don't worry about configuring it like zsh (which would lose my FUCKING history commands!) |||| terminal, config, zsh, fish, shell, backup, potential-data-loss
remove history entries in zsh via `LC_ALL=C sed -i '' '/porn/d' $HISTFILE` |||| terminal, zsh, macos, privacy
reverse the content in a text file via `tac OLD_FILE.txt > NEW_FILE.txt` |||| terminal, format, text-manipulation

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
