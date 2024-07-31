
## Shell

### One-liner

fish shell maximum history legnth, it's unconfigurable, up to 256KB of UNIQUE commands (fish de-dups it). In short, don't worry about configuring it like zsh (which would lose my FUCKING history commands!) |||| terminal, config, zsh, fish, shell, backup, potential-data-loss
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

### `curl`

To download a file using `curl`, use:

```bash
curl [URL] --output FILE.EXTENSION
```

### Image Manipulation

To make an image smaller using ImageMagick:

```bash
magick source.jpg -strip -interlace Plane -quality 85% result.jpg
```

### `jq`

To minify (compress) multi-line JSON into one-line JSON:

```bash
jq --compact-output < FILE.json
```

### AppleScript

To compile AppleScript into a macOS application:

```bash
osacompile -o /Applcations/output.app /input.applescript
```

### `npm`

To list globally installed npm packages:

```bash
npm list -g --depth=0
```

### `yarn`

To list globally installed Yarn packages:

```bash
yarn global list
```

### Video

To download and archive videos from platforms:

- For Bilibili: **lux**
- For AcFun: **you-get** (or visit `https://leesoar.com/acfun#parse`)
- For YouTube: **yt-dlp**

### Python

To try a new Python version with Anaconda:

```bash
conda create -n py312 python=3.12 && conda activate py312
```

### Profiling

To profile resource usage like RAM, CPU, or Disk: [eat](https://github.com/shawn-bluce/eat).

### Homebrew

To add a dedicated GitHub token for Homebrew:

1. Apply a classic token at [GitHub tokens](https://github.com/settings/tokens) with no scope selected.

2. Add it using:

```bash
export HOMEBREW_GITHUB_API_TOKEN=YOUR_TOKEN
```
