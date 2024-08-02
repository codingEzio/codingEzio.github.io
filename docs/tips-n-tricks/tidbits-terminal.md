
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
