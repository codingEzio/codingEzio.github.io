
## Shell

### One-liner

#### Nice to Have

- Reverse content in a text file via `tac OLD_FILE.txt > NEW_FILE.txt`
- Remove history entries in `zsh`

```sh
LC_ALL=C sed -i '' '/matching-this-pattern/d' $HISTFILE
```

#### Good to Know

- `fish` shell maximum history legnth
    - it's unconfigurable
    - up to 256KB of UNIQUE commands (fish de-dups it)
    - In short, don't worry about configuring it like `zsh`

### Multi-liner

> Lots of installation below will be based on `brew`, `asdf` or something else.

#### Environment for *KotLin*

```sh
# I'm not entirely sure about what this does
# All I got in mind right now is this allows
# asdf to know how to handle specific languages
# or frameworks (as it's community-managed?)
asdf plugin add kotlin

# List, choose, set
asdf list-all kotlin
asdf install kotlin 1.9.25
asdf global kotlin 1.9.25


kotlin  # REPL
```

#### `fish` Shell

> 即有配置其本身，亦有基于 fish 配置其他工具

##### Installation

> `~/zshrc` == `~/.config/fish/config.fish`

```sh
brew install fish && fish --version
curl -L https://get.oh-my.fish | fish
```

##### Change Default Shell

```sh
# Append to /etc/shells
echo /usr/local/bin/fish | sudo tee -a /etc/shells

# Check whether it's in there
cat /etc/shells

# Switch to a non-fish shell and make the change effective
bash
chsh -s /usr/local/bin/fish


# Now restart the terminal
```

##### `PATH`s for binaries

```sh
# One timer set for PATHs (append to USER PATHs)
# I prefer 'fish_add_path /opt/mycoolthing/bin' in config.fish
# So that I could actually see and copy it over for export/backup

# Run this in fish shell
fish_add_path /opt/some_cool_stuff/bin
```

##### Proxy

```sh
# https://stackoverflow.com/a/30187924
# Run this in fish shell
set -Ux https_proxy "http://127.0.0.1:7890"
set -Ux http_proxy "http://127.0.0.1:7890"
set -Ux all_proxy "socks5://127.0.0.1:7890"
set -Ux HTTPS_PROXY "http://127.0.0.1:7890"
set -Ux HTTP_PROXY "http://127.0.0.1:7890"
set -Ux ALL_PROXY "socks5://127.0.0.1:7890"


cat ~/.config/fish/fish_variables
```

##### Common Utilities

> via `fisher`

```sh
curl -sL https://git.io/fisher | source && fisher install jorgebucaran/fisher

# Fuzzy pipe search
# e.g. ls | fzf
fisher install PatrickF1/fzf.fish

# Jump to recent directory
# e.g. z doc, z blog
fisher install jethrokuan/z

# Node Version Manager
# e.g. nvm install lts, nvm use lts
fisher install jorgebucaran/nvm.fish && nvm install lts


# Check what do we got
fisher list
```

##### Homebrew Token

```sh
# Generate token from https://github.com/settings/tokens with no scope selected
# Run this in fish shell
set -Ux HOMEBREW_GITHUB_API_TOKEN ".."

cat ~/.config/fish/fish_variables
```

##### Theme

> Just like *oh-my-zsh*

```sh
omf install eclm
omf theme eclm
omf reload
```

##### `asdf`

> Like *NVM* but for more languages

```sh
brew install asdf


# Inject into config.fish
echo "source ~/.asdf/asdf.fish" >> ~/.config/fish/config.fish

# Install completions
mkdir -p ~/.config/fish/completions
ln -s ~/.asdf/completions/asdf.fish ~/.config/fish/completions


# Checking, checking
asdf info
asdf current
```

## Terminal

### `curl`

- Download file via `curl [URL] --output NAME.EXT`

### `imagemagick`

- Smaller image

```bash
magick SRC.jpg -strip -interlace Plane -quality 85% SRC_smaller.jpg
```

### `jq`

Minify/compress multi-line into one-liner

```bash
jq --compact-output < FILE.json
```

### AppleScript

Compile into a macOS application:

```bash
osacompile -o /Applcations/output.app ~/scripts/input.applescript
```

### JavaScript Package Manager

List globally installed packages:

```bash
npm list -g --depth=0


yarn global list
```

### Video

- For Bilibili: [`lux`](https://github.com/iawia002/lux)
- For AcFun: [`you-get`](https://github.com/soimort/you-get) <sup>or [AcFun 视频解析及下载](https://leesoar.com/acfun#parse)</sup>
- For YouTube: [`yt-dlp`](https://github.com/yt-dlp/yt-dlp)

### Python

Try new versions with Anaconda:

```bash
conda create -n py312 python=3.12 && conda activate py312
```
