
## Tip

### JetBrains IDE

#### Drag to Snap

> Tweak via `Registry`

- old: `ide.tabbedPane.dragOutMultiplier -> 0.1`
- new `ide.tabbedPane.dragOutMultiplier -> 2`

### VS Code

#### Turn Off Line Wrapping

> for Markdown files

- Press `Command + Shift + P` (macOS)
- Enter *Preferences: Open Settings (JSON)*

    > The 2nd one is essential as it was set to `on` by default by VS Code! 😬

    ```json
    "editor.wordWrap": "off",
    "[markdown]": {
        "editor.wordWrap": "off",
    }
    ```

#### Clean Up History

> Press `Cmd + P` on macOS

- Entry `Clean Editor History`
- Entry `Clean Command History`
- Entry `Clean Search History`

#### Export Extensions

```sh
code --list-extensions > EXT_VSCODE_LIST.txt
```

#### Install Extensions

```sh
cat ~/EXT_VSCODE_LIST.txt \
    | xargs -L 1 echo code --install-extension \
    | % { "code --install-extension $_” }
```

#### Issues with Plugin *PlantUML*

> Install these fonts first to avoid the error

- Times
- Lucida Bright
